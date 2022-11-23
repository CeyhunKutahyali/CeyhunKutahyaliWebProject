using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeyhunKutahyaliWebProject.Models
{
    public abstract class ModelBase
    {
        public ModelBase()
        {
            CreateDate=DateTime.Now;
        }
        public int id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}