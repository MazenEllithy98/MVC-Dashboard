using Microsoft.AspNetCore.Mvc;
using MStartPreHiringTask.BLL.Interfaces;
using MStartPreHiringTask.DAL.Models.User;
using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MStartPreHiringTask.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            { 
            var users = _userRepository.GetAll();
            return View(users);
            }
            else
            {
                var users = _userRepository.GetByName(SearchValue);
                return View(users);
            }
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(User user , string? Command)
        {
            if (ModelState.IsValid) //Server side validation
            {
                _userRepository.Add(user);
                if (Command == "Save")
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (Command == "Save and Continue")
                {
                    return RedirectToAction(nameof(AddUser));
                }
            }
            return View(user);

        }

        public IActionResult Details (int? id , string ViewName = "Details" )
        {
            if (id is null)
                return BadRequest();
            var users = _userRepository.GetByID(id.Value);
            if (users is null)
                return NotFound();
            return View(ViewName , users);
        }



        public IActionResult Edit(int? id)
        {
            return Details(id , "Edit");
            ///if (id is null)
            ///    return BadRequest();
            ///var user = _userRepository.GetByID(id.Value);
            ///if (user == null)
            ///    return NotFound();
            ///return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id , User user , string? Command)
        {
            if (id != user.Id) 
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _userRepository.Update(user);
                    if (Command == "Save")
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else if (Command == "Save and Continue")
                    {
                        return RedirectToAction(nameof(Edit));
                    }
                }
                catch (Exception ex)
                {
                    //Log Error
                    //Return Friendly Message
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id , "Delete");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete ([FromRoute] int id , User user)
        {
            if (id != user.Id)
                return BadRequest();
            try
            {
                _userRepository.Delete(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View (user);
            }
        }



    }
}
