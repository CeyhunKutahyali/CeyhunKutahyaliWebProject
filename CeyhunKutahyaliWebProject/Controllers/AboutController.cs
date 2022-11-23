using CeyhunKutahyaliWebProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CeyhunKutahyaliWebProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            About about = new About();
            return View (about.GetList_About());
        }

        public ActionResult AboutEdit()
        {
            About about = new About();
            AboutDTO aboutDTO = new AboutDTO();
            aboutDTO.AboutList = about.GetList_About();
            return View(aboutDTO);
        }

        public ActionResult EditInformationAbout()
        {
            About about = new About();
            AboutDTO aboutDTO= new AboutDTO();
            aboutDTO.AboutList=about.GetList_About();
            return View(aboutDTO);
        }


        [HttpPost]
        public ActionResult AboutAdd(string aboutText, string aboutPicture)
        {
            About about = new About
            {
                AboutText = aboutText,
                AboutPictures = aboutPicture
            };

            if (about.AboutAdd())
            {
                return RedirectToAction("AboutEdit", "About");
            }
            else
            {
                return RedirectToAction("AboutEdit", "About");
            }
        }

        [HttpPost]
        public void DeleteAbout(int id)
        {
            About about = new About();
            about.id = id;
            about.AboutDelete();
        }


        [HttpPost]
        public ActionResult AboutUpdate(int id,string aboutText, string aboutPictures)
        {
            About about = new About();

            about.id = id;
            about.AboutText = aboutText;
            about.AboutPictures = aboutPictures;
            about.UpdateAbout();
            //ViewBag.Message = "Güncelleme Başarılı";
            return RedirectToAction("AboutEdit", "About");
        }

    }

 
}