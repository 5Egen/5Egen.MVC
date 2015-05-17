using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CharacterTestMvc.Models;
using CharacterTestMvc.ViewModels;

namespace CharacterTestMvc.Controllers
{
    public class HomeController : Controller
    {
        CharacterDb cdb = new CharacterDb();

        public ActionResult Index()
        {
            var model = cdb.Alignments.ToList();

            List<SelectListItem> alignments = new List<SelectListItem>();
            alignments.Add(new SelectListItem { Text = " " });
            for (int i = 1; i < model.Count; i++)
            {
                alignments.Add(new SelectListItem { Text = model[i].AlignmentName});
            }

            ViewBag.ListOfAlignments = alignments;

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            CreateViewModel allInfo = new CreateViewModel();
            allInfo.AllAlignments = cdb.Alignments.ToList();
            allInfo.AllClasses = cdb.Classes.ToList();
            allInfo.AllRaces = cdb.Races.ToList();
            allInfo.AllTraits = cdb.Traits.ToList();
            allInfo.AllLanguages = cdb.Languages.ToList();

            //-------------------------------------------------------

            List<Alignment> al = cdb.Alignments.ToList<Alignment>();

            SelectList sl = new SelectList(al);
            
            ViewBag.AlList = sl;

            return View(allInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if(cdb != null)
            {
                cdb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}