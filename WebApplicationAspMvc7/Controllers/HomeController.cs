using System;
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
        Employee e = new Employee();
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
           
            DataTable dt = new DataTable();
            var ds = da.Show_Employee(Convert.ToInt32(id));
            e = da.Show_OneEmployee(Convert.ToInt32(id));
            Department d = da.getDeptComboList();
            // dt = ds.Tables[0];
            // ViewBag.employee = ds.Tables[0];
            return View(e);
        }


        [HttpPost]
        public ActionResult Update_Eployee(FormCollection fc)
        {
            Employee e = new Employee();
            e.Emp_id = Convert.ToInt32(fc["Emp_id"].ToString());
            e.Name = fc["Name"];
            e.Department_id = Convert.ToInt32(fc["Dept_Id"].ToString());
            e.Email = fc["Email"];
            e.Gender = fc["Gender"];
            if (da.UpdateEmployee(e))
            {
                return RedirectToAction("Display_Employee");
            }
            else
            {
                return RedirectToAction("Update_Eployee");
            }
            
        }


        public ActionResult Delete_Eployee(string id)
        {
            da.DeleteEmployee(Convert.ToInt32(id));
            return RedirectToAction("Display_Employee");                       
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
