using CeyhunKutahyaliWebProject.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CeyhunKutahyaliWebProject.Models
{
    public class Contact : ModelBase
    {
        SqlDataProcess data;
        public Contact()
        {
            data = new SqlDataProcess();
        }

        public string PhoneNumber { get; set; }

        public string EMail_ { get; set; }

        public string Address { get; set; }

        public string ContactPicture { get; set; }

        public int Deleted { get; set; }



        public List<Contact> GetList_Contact()
        {


            List<Contact> _contact = new List<Contact>();
            DataTable dtcontact = data.GetExecuteDataTable("GetList_Contact", CommandType.StoredProcedure);


            foreach (DataRow dataRow in dtcontact.Rows)
            {
                _contact.Add(new Contact
                {
                    id = Convert.ToInt32(dataRow["id"]),
                    PhoneNumber = dataRow["PhoneNumber"].ToString(),
                    EMail_ = dataRow["EMail_"].ToString(),
                    Address = dataRow["Address"].ToString(),
                    ContactPicture = dataRow["ContactPicture"].ToString(),
                    Deleted = Convert.ToInt32(dataRow["Deleted"])

                });
            }
            return _contact;
        }


        public bool ContactAdd()
        {
            try
            {
                return data.SetExecuteNonQuery("Contact_Add",
                    CommandType.StoredProcedure,
                    new SqlParameter("@phoneNumber", PhoneNumber),
                    new SqlParameter("@email_", EMail_),
                    new SqlParameter("@Address_", Address),
                    new SqlParameter("@pictureContact", ContactPicture)
                    );
            }
            catch (Exception)
            {
                return false;
            }
        }



        public bool DeleteContact()
        {
            return data.SetExecuteNonQuery("Contact_Delete", CommandType.StoredProcedure, new SqlParameter("@id", id));
        }


        public bool UpdateContact()
        {
            try
            {
                return data.SetExecuteNonQuery("Contact_Update",
                    CommandType.StoredProcedure,
                    new SqlParameter("@id", id),
                    new SqlParameter("@phoneNumber",PhoneNumber),
                    new SqlParameter("@email_",EMail_),
                    new SqlParameter("@Address_",Address),
                    new SqlParameter("@pictureContact",ContactPicture)
                    );
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}