using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CharacterTestMvc.Models;

namespace CharacterTestMvc.ViewModels
{
    public class CreateViewModel
    {
        public IEnumerable<Race> AllRaces { get; set; }
        public IEnumerable<Class> AllClasses { get; set; }
        public IEnumerable<Alignment> AllAlignments { get; set; }
        public IEnumerable<Language> AllLanguages { get; set; }
        public IEnumerable<Trait> AllTraits { get; set; }

        public Character TheOneCharacter { get; set; }

        public List<SelectListItem> getAlignmentNames()
        {
            List<SelectListItem> l = new List<SelectListItem>();

            l.Add(new SelectListItem { Text = "", Value = "AL0" });

            foreach (var a in AllAlignments)
                l.Add(new SelectListItem {Text = a.AlignmentName, Value = String.Concat("AL", a.AlignmentId)} );

            return l;
        }

        public String getAlignmentDescription(Alignment charAlignment)
        {
            return charAlignment.AlignmentDescription;
        }
    }

    
}