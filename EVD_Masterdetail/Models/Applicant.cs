using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVD_Masterdetail.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalExperience {  get; set; }
        public DateTime DOB { get; set; }
        public HttpPostedFileBase Pic { get; set; }
        public string PicPath { get; set; }
        public bool IsAvailAble { get; set; }
    }
}