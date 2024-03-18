using App_exp_CRUD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_exp_CRUD.Controllers
{
    public class ApplicaantsController : Controller
    {
        DbMasterDetailEntities db = new DbMasterDetailEntities();
        // GET: Applicaants
        public ActionResult Index()
        {
            return View(db.Applicants.ToList());
        }
        public ActionResult Create()
        {
            var model = new Applicant();
            model.ApplicantExperiences.Add(new ApplicantExperience
            {
                CompanyName = "",
                Designation = "",
                 YearofExperience=0
            }) ;

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(
            Applicant applicant,string btn="")
        {
            int result = 0;
            if (btn == "add")
            {
                applicant.ApplicantExperiences.Add(new ApplicantExperience());
                foreach (var v in ModelState.Values)
                {
                    v.Errors.Clear();
                }
            }
            if (btn == "insert")
            {
                try
                {
                    string pathTosave = "";
                    if (applicant.Picture != null)
                    {
                        string wwwRootPath = Server.MapPath("~/");
                                string fileName = Path.GetFileNameWithoutExtension(applicant.Picture.FileName);
                                string extension = Path.GetExtension(applicant.Picture.FileName);
                                string savetoFile = applicant.Name + extension;
                                string path = Path.Combine(wwwRootPath + "/PhotoGallery", savetoFile);
                        applicant.Picture.SaveAs(path);
                                pathTosave = "~/PhotoGallery/" + applicant.Name+ extension;
                                applicant.PicPath = pathTosave;
                        applicant.TotalExperience=(int)( applicant.ApplicantExperiences.Sum(s => s.YearofExperience));
                                if (applicant.ID > 0)
                                {
                                    db.Entry(applicant).State = System.Data.Entity.EntityState.Modified;
                                }
                                else
                                {
                                    db.Applicants.Add(applicant);
                                }
                                result =  db.SaveChanges();
                            }
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
       
            return View(applicant);
        }
        public ActionResult Edit(int id)
        {
            var model = db.Applicants.Find(id);
            model.ApplicantExperiences.Add(new ApplicantExperience
            {
                CompanyName = "",
                Designation = "",
                YearofExperience = 0
            });

            return View(model);
        }
    }
}