using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using CeyhunKutahyaliWebProject.DAL;

namespace CeyhunKutahyaliWebProject.Models
{
    public class Login : ModelBase
    {
        SqlDataProcess data;
        public Login()
        {
            data = new SqlDataProcess();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }


        public bool UserLogin()
        {

            DataTable dt = data.GetExecuteDataTable("Get_List_User",
                CommandType.StoredProcedure,
                new SqlParameter("@UserName", UserName),
                new SqlParameter("@Password", Password));


            if (dt.Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;

            }
        }
    }

}