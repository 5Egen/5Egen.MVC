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
        static CreateViewModel cvm = new CreateViewModel();

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

        [HttpGet]
        public String getAlignmentDescription(String alID)
        {
            foreach (Alignment a in cvm.AllAlignments)
            {
                if (a.AlignmentId == Convert.ToInt32(alID.Substring(2)))
                    return a.AlignmentDescription;
            }

            return "Please select an alignment.";
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
            cvm.AllAlignments = cdb.Alignments.ToList();
            cvm.AllClasses = cdb.Classes.ToList();
            cvm.AllRaces = cdb.Races.ToList();
            cvm.AllTraits = cdb.Traits.ToList();
            cvm.AllLanguages = cdb.Languages.ToList();

            return View(cvm);
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