using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc.Ajax;

namespace medamtest.Models
{
    public class repo
    {
        static string ds = ConfigurationManager.ConnectionStrings["constr"].ToString();
        public int AddUser(form f1)
        {
            SqlConnection conn = new SqlConnection(ds);
            string query = "insert into form(uid,uname,password,conpassword,gender,state,city,hobbies,address)values(@uid,@uname,@password,@conpassword,@gender,@state,@city,@hobbies,@address)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", f1.uid);
            cmd.Parameters.AddWithValue("@uname", f1.uname);
            cmd.Parameters.AddWithValue("@password", f1.password);
            cmd.Parameters.AddWithValue("@conpassword", f1.conpassword);
            cmd.Parameters.AddWithValue("@gender", f1.gender);
            cmd.Parameters.AddWithValue("@state", f1.state);
            cmd.Parameters.AddWithValue("@city", f1.city);
            cmd.Parameters.AddWithValue("@hobbies", string.Join(",", f1.hobbies));

            cmd.Parameters.AddWithValue("@address", f1.address);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
        public int UpdateUser(form f1)
        {
            SqlConnection conn = new SqlConnection(ds);
            string query = "update form set uname=@uname, password=@password, conpassword=@conpassword,gender=@gender, state=@state, city=@city, hobbies=@hobbies, address=@address where uid=@uid";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", f1.uid);
            cmd.Parameters.AddWithValue("@uname", f1.uname);
            cmd.Parameters.AddWithValue("@password", f1.password);
            cmd.Parameters.AddWithValue("@conpassword", f1.conpassword);
            cmd.Parameters.AddWithValue("@gender", f1.gender);
            cmd.Parameters.AddWithValue("@state", f1.state);
            cmd.Parameters.AddWithValue("@city", f1.city);
            cmd.Parameters.AddWithValue("@hobbies", string.Join(",", f1.hobbies));

            cmd.Parameters.AddWithValue("@address", f1.address);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
        public int DeleteUser(int uid)
        {
            SqlConnection conn = new SqlConnection(ds);
            string query = "delete from form where uid=@uid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", uid);
            conn.Open();
            return cmd.ExecuteNonQuery();

        }
        public List<form> GetAll()
        {
            List<form> list = new List<form>();
            SqlConnection conn = new SqlConnection(ds);
            {
                SqlCommand cmd = new SqlCommand("select * from form", conn);
                conn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new form()
                    {
                        uid = Convert.ToInt32(r["uid"]),
                        uname = Convert.ToString(r["uname"]),
                        password = Convert.ToString(r["password"]),
                        conpassword = Convert.ToString(r["conpassword"]),
                        gender = Convert.ToString(r["gender"]),
                        state = Convert.ToString(r["state"]),
                        city = Convert.ToString(r["city"]),
                        hobbies = Convert.ToString(r["hobbies"]).Split(',').ToList(),
                        address = Convert.ToString(r["address"])
                    });
                }
            }
            return list;
        }
    }
}



