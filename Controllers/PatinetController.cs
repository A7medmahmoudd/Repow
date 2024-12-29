using Clinic.Models.Entites;
using Clinic.Models.Irepo;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    public class PatinetController : Controller
    {
        public readonly iPatinet ido;
        public PatinetController(iPatinet iPatinet)
        {
            ido = iPatinet;
        }

        public async Task< IActionResult> Index()
        {
            var w = await ido.Getall();
            return View(w);
        }
        public async Task<IActionResult> Adddoct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adddoct(Patinet patinet)
        {
            ido.adddpa(patinet);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Deletep(int id)
        {

            var a = await ido.getbypa(id);
            if (a == null)
            {
                return NotFound();
            }

            return View(a);

        }
        [HttpPost, ActionName("Deletep")]

        public async Task<IActionResult> Deletep(Patinet patinet)
        {
            if (patinet == null)
            {
                return View("Index");
            }
        
            ido.deletepa(patinet);

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int id)
        {
            var a = await ido.getbypa(id);
            if (a == null)
            {
                return NotFound();
            }

            return View(a);

        }
        [HttpPost]

        public async Task<IActionResult> Edit(Patinet patinet)
        {

            ido.updatepa(patinet);

            return RedirectToAction("Index");
        }


    }
}
