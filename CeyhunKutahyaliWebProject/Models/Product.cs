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
    public class Product : ModelBase
    {
        SqlDataProcess data;
        public Product()
        {
            data = new SqlDataProcess();
        }

        public string ProductName { get; set; }
        public string ProductFeature { get; set; }
        public string ProductPicture { get; set; }


        public List<Product> GetList_Product()
        {


            List<Product> _product = new List<Product>();
            DataTable dtproduct = data.GetExecuteDataTable("Select * from Product where Deleted=0", CommandType.Text);


            foreach (DataRow dataRow in dtproduct.Rows)
            {
                _product.Add(new Product
                {
                    id = Convert.ToInt32(dataRow["id"]),
                    ProductName = dataRow["ProductName"].ToString(),
                    ProductFeature = dataRow["ProductFeature"].ToString(),
                    ProductPicture = dataRow["ProductPicture"].ToString()
                });
            }
            return _product;
        }


        public bool ProductAdd()
        {
            try
            {
                return data.SetExecuteNonQuery("Product_Add",
                    CommandType.StoredProcedure,
                    new SqlParameter("@ProductName", ProductName),
                    new SqlParameter("@ProductFeature", ProductFeature),
                    new SqlParameter("@ProductPicture", ProductPicture)
                    );
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Delete()
        {
            return data.SetExecuteNonQuery("Product_Delete", CommandType.StoredProcedure, new SqlParameter("@id", id));
        }


        public bool UpdateProduct()
        {
            try
            {
                return data.SetExecuteNonQuery("Product_Update",
                    CommandType.StoredProcedure,
                    new SqlParameter("@id", id),
                    new SqlParameter("@ProductName", ProductName),
                    new SqlParameter("@ProductFeature", ProductFeature),
                    new SqlParameter("@ProductPicture", ProductPicture)
                    );
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}