using CeyhunKutahyaliWebProject.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CeyhunKutahyaliWebProject.Models
{
    public class HomePictures : ModelBase
    {
        SqlDataProcess data;
        public HomePictures()
        {
            data = new SqlDataProcess();
        }

        public string Picture { get; set; }
        public int Deleted { get; set; }


        public List<HomePictures> GetList_HomePicture()
        {


            List<HomePictures> _picture = new List<HomePictures>();
            DataTable dthomePicture = data.GetExecuteDataTable("Get_Picture", CommandType.StoredProcedure);


            foreach (DataRow dataRow in dthomePicture.Rows)
            {
                _picture.Add(new HomePictures
                {
                    id = Convert.ToInt32(dataRow["id"]),
                    Picture = dataRow["Picture"].ToString(),
                    Deleted = Convert.ToInt32(dataRow["Deleted"])
                });
            }
            return _picture;
        }
    }
}