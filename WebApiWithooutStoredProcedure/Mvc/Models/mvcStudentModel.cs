using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcStudentModel
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage =" * Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = " * Course Code Required")]
        public string Course { get; set; }
        [Required(ErrorMessage = " * Section Required")]
        public Nullable<int> Section { get; set; }
        [Required(ErrorMessage = " * Mark Required")]
        public Nullable<int> Mark { get; set; }
    }
}