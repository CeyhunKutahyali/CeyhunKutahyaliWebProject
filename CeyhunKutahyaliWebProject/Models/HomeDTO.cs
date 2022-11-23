using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeyhunKutahyaliWebProject.Models
{
    public class HomeDTO
    {
        public List<Product> products { get; set; }
        public List<About> abouts { get; set; }

        public List<HomePictures> homepictures { get; set; }

        public List<Contact> contacts { get; set; }
        
    }
}