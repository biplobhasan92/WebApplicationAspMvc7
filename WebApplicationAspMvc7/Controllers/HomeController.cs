﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationAspMvc7.Models;
using WebApplicationAspMvc7.DataAccess;
using System.Data;

namespace WebApplicationAspMvc7.Controllers
{
    public class HomeController : Controller
    {

        Department ds = new Department();
        DataAccessLayer da = new DataAccessLayer();

        // GET: Home
        public ActionResult Index()
        {
            ds = da.getDeptComboList();
            return View(ds);
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            Employee e = new Employee();
            e.Name = fc["Name"];
            e.Department_id = Convert.ToInt32(fc["Dept_Id"]);
            e.Email  = fc["Email"];
            e.Gender = fc["Gender"];
            da.SaveEmployee(e);
            return RedirectToAction("Display_Employee");
        }


        public ActionResult Display_Employee()
        {
            DataSet ds = da.Show_AllEmp();
            ViewBag.epmlist = ds.Tables[0];
            return View();
        }


        public ActionResult Update_Eployee(string id)
        {
            DataSet ds = da.Show_Employee(Convert.ToInt32(id));
            Department d = da.getDeptComboList();
            ViewBag.employee = ds.Tables[0];
            return View(d);
        }


        /*
         public EditUser(int userId) {
            var user = LoadUserFromDB(userId);
            var model = new UserModel();
            model.CountryId = user.CountryId;
            model.Countries = GetAllCountries();
            //... other code to set the rest of the properties
            return View(model);
        }
         
         */


    }
}
