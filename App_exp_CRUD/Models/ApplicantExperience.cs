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
    
    public partial class ApplicantExperience
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public Nullable<int> YearofExperience { get; set; }
        public Nullable<int> AppId { get; set; }
    
        public virtual Applicant Applicant { get; set; }
    }
}
