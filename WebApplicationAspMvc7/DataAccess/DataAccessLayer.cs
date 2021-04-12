using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplicationAspMvc7.DataAccess
{
    public class DataAccessLayer
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        
        // this url for load drop down 
        // https://www.aspdotnet-suresh.com/2016/10/aspnet-mvc-bind-populate-dropdownlist-from-database-with-example.html
    }
}