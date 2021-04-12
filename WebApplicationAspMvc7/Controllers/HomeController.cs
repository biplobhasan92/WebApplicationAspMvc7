using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationAspMvc7.Models;

namespace WebApplicationAspMvc7.Controllers
{
    public class HomeController : Controller
    {

        Department ds = new Department();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            /*
                UserDetails objuser = new UserDetails();
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection("Data Source=Suresh;Integrated Security=true;Initial Catalog=MySamplesDB"))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from userdetails", con))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        List<UserDetails> userlist = new List<UserDetails>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            UserDetails uobj = new UserDetails();
                            uobj.UserId = Convert.ToInt32(ds.Tables[0].Rows[i]["userid"].ToString());
                            uobj.UserName = ds.Tables[0].Rows[i]["username"].ToString();
                            uobj.Education = ds.Tables[0].Rows[i]["education"].ToString();
                            uobj.Location = ds.Tables[0].Rows[i]["location"].ToString();
                            userlist.Add(uobj);
                        }
                        objuser.usersinfo = userlist;
                    }
                    con.Close();
                }
                return View(objuser);
            */
            return View();
        }
    }
}
