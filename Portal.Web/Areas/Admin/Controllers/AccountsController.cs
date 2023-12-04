using System;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;

namespace Portal.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        IAccountsAdminService _accountsAdminService;
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
                return RedirectToAction(nameof(AccountsController.Accounts));
            }
            else
                return NotFound();
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
                _accountsAdminService.Update(account);
                return RedirectToAction(nameof(Accounts));
            }

            return View(account);
        }

        [HttpGet]
        public IActionResult ToggleAdmin(int id, bool isAdmin)
        {
            Account? account = _accountsAdminService.Select().FirstOrDefault(acc => acc.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            account.IsAdmin = isAdmin;

            return View(account);
        }

        [HttpPost]
        public IActionResult ToggleAdmin(Account account)
        {
            // Uložení změny IsAdmin
            _accountsAdminService.Update(account);
            return RedirectToAction(nameof(Accounts));
        }
    }
}
