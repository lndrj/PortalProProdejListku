using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Interfaces;
using Portal.Infrastructure.Identity;
using Portal.Infrastructure.Identity.Enums;

namespace Portal.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class AccountsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountsController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Accounts()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> DeleteAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Accounts));
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var existing = await _userManager.FindByIdAsync(user.Id.ToString());
                if(existing == null)
                {
                    return NotFound();
                }
                existing.UserName = user.UserName;
                existing.FirstName = user.FirstName;
                existing.LastName = user.LastName;
                existing.Email = user.Email;
                existing.PhoneNumber = user.PhoneNumber;

                var result = await _userManager.UpdateAsync(existing); 

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Accounts));
                }
                else
                {
                    return View("Error");
                }
            }

            return View(user);
        }
    }
}