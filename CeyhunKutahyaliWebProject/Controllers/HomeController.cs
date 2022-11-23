using CeyhunKutahyaliWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CeyhunKutahyaliWebProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomePictures _homePictures = new HomePictures();
            HomeDTO homeDTO = new HomeDTO();
            About about = new About();
            Contact contact = new Contact();


            homeDTO.homepictures = _homePictures.GetList_HomePicture();
            homeDTO.abouts=about.GetList_About();
            homeDTO.contacts=contact.GetList_Contact();
            return View(homeDTO);
        }
    }
}