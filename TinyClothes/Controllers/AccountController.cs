﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyClothes.Data;
using TinyClothes.Models;

namespace TinyClothes.Controllers
{
    public class AccountController : Controller
    {
        private readonly StoreContext _context;
        private readonly IHttpContextAccessor _http;

        public AccountController(StoreContext context, IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel reg)
        {
            if (ModelState.IsValid)
            {
                // Check username is not taken
                if (!await AccountDb.IsUsernameTaken(reg.Username, _context))
                {
                    Account acc = new Account()
                    {
                        Email = reg.Email, 
                        FullName = reg.FullName,
                        Password = reg.Password,
                        Username = reg.Username
                    };

                    await AccountDb.Register(_context, acc);

                    SessionHelper.CreateUserSession(acc.AccountId, acc.Username, _http);

                    return RedirectToAction("Index", "Home");
                }
                else // If username is taken, add error
                {
                    ModelState.AddModelError(nameof(Account.Username), "Username is already taken");
                }
            }

            return View(reg);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                Account acc = await AccountDb.DoesUserMatch(login, _context);

                SessionHelper.CreateUserSession(acc.AccountId, acc.Username, _http);

                return RedirectToAction("Index", "Home");
            }

            return View(login);
        }

        public IActionResult Logout()
        {
            SessionHelper.DestroyUserSession(_http);
            return RedirectToAction("Index", "Home");
        }
    }
}