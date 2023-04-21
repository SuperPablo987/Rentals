using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalsMVC.Controllers
{
    [Authorize]
    public class OwnersController : Controller
    {
        // GET: OwnersController
        
        public ActionResult Index()
        {
            List<Owner> owners = OwnersManager.GetAll();
            return View(owners);
        }



        // GET: OwnersController/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            try
            {
                OwnersManager.Add(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
    }
}
