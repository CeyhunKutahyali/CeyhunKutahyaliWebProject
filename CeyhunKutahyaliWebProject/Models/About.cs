using CeyhunKutahyaliWebProject.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;

namespace CeyhunKutahyaliWebProject.Models
{
    public class About : ModelBase
    {
        SqlDataProcess data;
        public About()
        {
            data = new SqlDataProcess();
        }

        public string AboutText { get; set; }

        public string AboutPictures { get; set; }
        public int Deleted { get; set; }



        public List<About> GetList_About()
        {

            List<About> _about = new List<About>();
            DataTable dtabout = data.GetExecuteDataTable("GetList_About", CommandType.StoredProcedure);


            foreach (DataRow dataRow in dtabout.Rows)
            {
                _about.Add(new About
                {
                    id = Convert.ToInt32(dataRow["id"]),
                    AboutText = dataRow["AboutText"].ToString(),
                    AboutPictures = dataRow["AboutPictures"].ToString(),
                    Deleted = Convert.ToInt32(dataRow["Deleted"]),

                });
            }
            return _about;
        }

        public About Get_About_Id()
        {
            DataTable dt = data.GetExecuteDataTable("Get_About_Id", CommandType.StoredProcedure, new SqlParameter("@id", id));
            About about = new About();
            if (dt.Rows.Count > 0)
            {
                about.id = dt.Rows[0].Field<int>("id");
                about.AboutText = dt.Rows[0].Field<string>("AboutText");
                about.AboutPictures = dt.Rows[0].Field<string>("AboutPictures");
            }

            return about;

        }

        public bool AboutAdd()
        {
            try
            {
                return data.SetExecuteNonQuery("About_Add",
                    CommandType.StoredProcedure,
                    new SqlParameter("@AboutText", AboutText),
                    new SqlParameter("@AboutPicture", AboutPictures)
                    );
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool UpdateAbout()
        {
            try
            {
                return data.SetExecuteNonQuery("About_Update",
                    CommandType.StoredProcedure,
                    new SqlParameter("@id", id),
                    new SqlParameter("@AboutText", AboutText),
                    new SqlParameter("@AboutPicture", AboutPictures)
                    );
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool AboutDelete()
        {
            return data.SetExecuteNonQuery("About_Delete", CommandType.StoredProcedure, new SqlParameter("@id", id));
        }
    }
}