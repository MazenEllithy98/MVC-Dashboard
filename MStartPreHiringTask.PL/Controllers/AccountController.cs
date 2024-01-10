using Microsoft.AspNetCore.Mvc;
using MStartPreHiringTask.BLL.Interfaces;
using MStartPreHiringTask.DAL.Models.Account;
using MStartPreHiringTask.DAL.Models.User;
using System;

namespace MStartPreHiringTask.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public AccountController(IAccountRepository accountRepository , IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index(int? SearchValue)
        {
            if (SearchValue is null)
            {
            var accounts = _accountRepository.GetAll();
            return View(accounts);
            }
            else
            {
                var accounts = _accountRepository.GetByAccountNumber(SearchValue.Value);
                return View(accounts);
            }
        }
        [HttpGet]
        public IActionResult AddAccount()
        {
            ViewBag.Users = _userRepository.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAccount(Account account, string? Command)
        {
            if (ModelState.IsValid) //Server side validation
            {
                _accountRepository.Add(account);
                if (Command == "Save")
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (Command == "Save and Continue")
                {
                    return RedirectToAction(nameof(AddAccount));
                }
            }
            return View(account);

        }

        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var account = _accountRepository.GetByAccountID(id.Value);
            if (account is null)
                return NotFound();
            return View(ViewName, account);
        }



        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Account account, string? Command)
        {
            if (id != account.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _accountRepository.Update(account);
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
            return View(account);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Account account)
        {
            if (id != account.Id)
                return BadRequest();
            try
            {
                _accountRepository.Delete(account);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(account);
            }
        }


    }
}
