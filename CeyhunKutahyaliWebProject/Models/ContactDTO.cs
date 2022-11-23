using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeyhunKutahyaliWebProject.Models
{
    public class ContactDTO:ModelBase
    {
        public List<Contact> Contacts { get; set; }
    }
}