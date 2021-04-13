﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApplicationAspMvc7.Models;

namespace WebApplicationAspMvc7.DataAccess
{
    public class DataAccessLayer
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());


        public Department getDeptComboList()
        {
            Department deptAl = new Department();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Sp_GetAll_Department", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            List<Department> deptList = new List<Department>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Department dept = new Department();
                dept.Dept_Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Dept_Id"].ToString());
                dept.Dept_name = ds.Tables[0].Rows[i]["Dept_name"].ToString();
                deptList.Add(dept);
            }
            deptAl.deptInfo = deptList;
            conn.Close();
            return deptAl;
        }
        
         
        public DataSet Show_AllEmp()
        {
            SqlCommand cmd = new SqlCommand("Sp_Emp_getAllData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;         
        }



        public DataSet Show_Employee(int empid)
        {
            SqlCommand cmd = new SqlCommand("Sp_Emp_getDataByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Emp_id",empid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public Boolean SaveEmployee(Employee e)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Emp_Save", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", e.Name);
                cmd.Parameters.AddWithValue("@Department_id", e.Department_id);
                cmd.Parameters.AddWithValue("@Gender", e.Gender);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                conn.Open();
                if(cmd.ExecuteNonQuery()>0)
                    b = true;
            }
            catch
            {
                
            }
            finally
            {
                conn.Close();
            }
            return b;
        }

    }
}