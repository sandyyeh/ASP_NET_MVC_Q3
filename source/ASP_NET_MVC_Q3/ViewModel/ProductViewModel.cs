using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Locale { get; set; }

        public DateTime UpdateDate { get; set; }

        public List<SelectListItem> LocaleListItem { get; set; }
    }

    
}