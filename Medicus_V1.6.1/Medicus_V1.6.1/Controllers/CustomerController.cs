﻿using Medicus_V1._6._1.Models;
using Medicus_V1._6._1.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medicus_V1._6._1.Controllers
{
    public class CustomerController : Controller
    {
        PharmacyContext db = new PharmacyContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderMedicine()
        {
            var data = new CustomerOrderMedicineViewData();
            data.medicineList = db.MedicineTable.ToList();
            data.pharmacyList = db.PharmacyTable.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult OrderMedicine(CustomerOrderMedicineViewData viewModel)
        {

            if (ModelState.IsValid)
            {
                CustomerOrder c = new CustomerOrder
                {
                    CustomerId = Int32.Parse(Session["ID"].ToString()),
                    MedicineId = viewModel.medicineId,
                    PharmacyId = viewModel.pharmacyId,
                    Quantity = viewModel.quantity,
                    OrderDate = DateTime.Today
                };
                db.CustomerOrderTable.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }
        public ActionResult MedicineList()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult NearbyPharmacy()
        {
            return View();
        }
        public ActionResult AllOrders()
        {
            return View();
        }

    }
}