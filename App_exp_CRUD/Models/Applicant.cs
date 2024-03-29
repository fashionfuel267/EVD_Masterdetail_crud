//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App_exp_CRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Applicant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Applicant()
        {
            this.ApplicantExperiences = new List<ApplicantExperience>();
        }
    
        public int ID { get; set; }
        [Required,StringLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime DOB { get; set; }
        public int TotalExperience { get; set; }
        public string PicPath { get; set; }
        public bool IsAvailAble { get; set; }
        [NotMapped]
       public HttpPostedFileBase Picture { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<ApplicantExperience> ApplicantExperiences { get; set; }
    }
}
