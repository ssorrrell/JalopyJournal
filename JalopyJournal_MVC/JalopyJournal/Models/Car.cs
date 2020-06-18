using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JalopyJournal.Models
{
    public class Car
    {
        public int ID { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}