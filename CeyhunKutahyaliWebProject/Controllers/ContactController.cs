using CeyhunKutahyaliWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CeyhunKutahyaliWebProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            Contact contact = new Contact();
            return View(contact.GetList_Contact());
        }


        public ActionResult ContactEdit()
        {
            Contact contact = new Contact();
            ContactDTO contactDTO = new ContactDTO();
            contactDTO.Contacts=contact.GetList_Contact();
            return View(contactDTO);
        }

        public ActionResult EditInformationContact()
        {
            Contact contact = new Contact();
            ContactDTO contactDTO = new ContactDTO();
            contactDTO.Contacts=contact.GetList_Contact();
            return View(contactDTO);
        }


        [HttpPost]
        public ActionResult ContactAdd(string phoneNumberContact, string emailContact, string addressContact, string contactPicture)
        {
            Contact contact = new Contact
            {
                PhoneNumber= phoneNumberContact,
                EMail_= emailContact,
                Address= addressContact,
                ContactPicture= contactPicture
            };

            if (contact.ContactAdd())
            {
                return RedirectToAction("ContactEdit", "Contact");
            }
            else
            {
                return RedirectToAction("ContactEdit", "Contact");
            }
        }



        [HttpPost]
        public void ContactDelete(int id)
        {
           Contact contact = new Contact();
           contact.id = id;
           contact.DeleteContact();
        }

        [HttpPost]
        public ActionResult ContactUpdate(int id,string phoneNumber,string EMail_,string Address,string contactPicture)
        {
            Contact contact = new Contact();
            contact.id = id;
            contact.PhoneNumber= phoneNumber;
            contact.EMail_= EMail_;
            contact.Address= Address;
            contact.ContactPicture= contactPicture;
            contact.UpdateContact();
            return RedirectToAction("ContactEdit", "Contact");
        }

    }
}