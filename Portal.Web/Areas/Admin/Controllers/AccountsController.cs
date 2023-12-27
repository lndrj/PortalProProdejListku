using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Identity.Enums;

namespace Portal.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class AccountsController : Controller
    {
        private readonly IAccountsAdminService _accountsAdminService;

        public AccountsController(IAccountsAdminService accountsAdminService)
        {
            _accountsAdminService = accountsAdminService;
        }

        public IActionResult Accounts()
        {
            IList<Account> accounts = _accountsAdminService.Select();
            return View(accounts);
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _accountsAdminService.Delete(Id);

            if (deleted)
            {
                return RedirectToAction(nameof(Accounts));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Account? account = _accountsAdminService.Select().FirstOrDefault(acc => acc.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        [HttpPost]
        public IActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                // Logika pro úpravu účtu
                _accountsAdminService.Update(account);
                return RedirectToAction(nameof(Accounts));
            }

            return View(account);
        }
    }
}