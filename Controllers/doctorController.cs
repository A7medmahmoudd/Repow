using Clinic.Models.Entites;
using Clinic.Models.Irepo;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    public class doctorController : Controller
    {
        public readonly idoctor ido;
        public doctorController(idoctor idoctor)
        {
            ido = idoctor;
        }

        public async  Task<IActionResult> getall ()
        {
            var w=await ido.Getall();
            return View(w);
        }
        [HttpGet]
        public async Task<IActionResult> Adddoct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adddoct(Doctor doctor)
        {
            ido.addd(doctor);
            return RedirectToAction("getall");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id,Doctor doctor)
        {
            
          var a= await ido.getbyid(id);
            if (a == null)
            {
                return NotFound();
            }
            
                return View(a);
            
        }
        [HttpPost,ActionName("Delete")]

        public async Task<IActionResult> Delete(Doctor doctor)
        {
            if(doctor == null)
            {
                return View("getall");
            }

            
            ido.deleted(doctor);

            return RedirectToAction("getall");

        }
        public async Task<IActionResult> Edit(int id)
        {
            var a = await ido.getbyid(id);
            if (a == null)
            {
                return NotFound();
            }

            return View(a);
            
        }
        [HttpPost]

        public async Task<IActionResult> Edit(Doctor doctor)
        {
            
           ido.updated(doctor);

            return RedirectToAction("getall");
        }

    }
}
