using Clinic.Models;
using Clinic.Models.Entites;
using Clinic.Models.Irepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Immutable;
using System.Net.WebSockets;
using System.Security.Cryptography.Xml;

namespace Clinic.Controllers
{
    public class AppoinmentsController : Controller
    {
        public readonly idoctor ido;
        public readonly iPatinet ip;
        public readonly iAppoinment ipo ;
        public AppoinmentsController(iAppoinment iAppoinment,iPatinet iPatinet,idoctor idoctor)
        {
            ipo = iAppoinment;
            ip = iPatinet;
            ido=idoctor;
        }

        public async Task< IActionResult> Index()
        {

            var w = await ipo.getallapp();
            return View(w);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var doctorss = await ido.Getall();
            var Patientss = await ip.Getall();
            var view = new ViewmodelAppointment()
            {
                doctors = doctorss.ToList(),
                patinets=Patientss.ToList(),
            };
            return View(view);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ViewmodelAppointment viewmodel)
        {

            if (ModelState.IsValid)
            {
                await ipo.adddapp(viewmodel);
                return RedirectToAction("Index");

            }

            return View();

        }

        public async Task<IActionResult> detales(int id)
        {
            var appo=await ipo.getbyidapp(id);

            if(appo == null)
            {
                return RedirectToAction("Index");
            }

            return View(appo);
        }

        [HttpPost]

        public async Task<IActionResult> detales(Appoinment appoinment)
        {
        
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Dele(int id)
        {
            var appo = await ipo.getbyidapp(id);

            if (appo == null)
            {
                return RedirectToAction("Index");
            }

            return View(appo);
          
        }
        [HttpPost]

        public async Task<IActionResult> Dele(Appoinment appoinment)
        {
            await ipo.deletedapp(appoinment);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> edit(int id)
        {
            var appo = await ipo.getbyidapp(id);

            if (appo == null)
            {
                return NotFound();
            }

           

                var doctorss = await ido.Getall();
                var Patientss = await ip.Getall();
            var view = new ViewmodelAppointment()
            {
                Note = appo.Notes,
                Date = appo.DateTime,
                doctors = doctorss,
                patinets = Patientss,
                idDoctor = appo.doctorid,
                idPatinet = appo.Patinett,


            };

            return View(view);
        }
        [HttpPost]

        public async Task<IActionResult> edit(ViewmodelAppointment viewmodelAppointment,int id)
        {
            
           
               await ipo.updatedapp(viewmodelAppointment,id);

                return RedirectToAction("detales");

        }
    }
}
