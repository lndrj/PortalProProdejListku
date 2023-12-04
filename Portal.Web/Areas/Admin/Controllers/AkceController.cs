using Microsoft.AspNetCore.Mvc;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AkceController : Controller
    {
        IAkceAdminService _akceAdminService;
        public AkceController(IAkceAdminService akceAdminService)
        {
            _akceAdminService = akceAdminService;
        }

        public IActionResult Akce()
        {
            IList<Akce> akces = _akceAdminService.Select();
            return View(akces);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Akce akce)
        {
            _akceAdminService.Create(akce);

            return RedirectToAction(nameof(AkceController.Akce));
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _akceAdminService.Delete(Id);

            if (deleted)
            {
                return RedirectToAction(nameof(AkceController.Akce));
            }
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Console.WriteLine($"Přijato ID pro aktualizaci: {id}");

            Akce? akce = _akceAdminService.Select().FirstOrDefault(ak => ak.Id == id);

            if (akce == null)
            {
                return NotFound();
            }

            return View(akce);
        }

        [HttpPost]
        public IActionResult Edit(Akce akce)
        {
            if (ModelState.IsValid)
            {
                _akceAdminService.Update(akce);
                return RedirectToAction(nameof(Akce));
            }

            return View(akce);
        }
    }
}
