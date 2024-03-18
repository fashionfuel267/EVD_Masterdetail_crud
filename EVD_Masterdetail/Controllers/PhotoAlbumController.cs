using EVD_Masterdetail.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EVD_Masterdetail.Controllers
{
    public class PhotoAlbumController : Controller
    {
        dbmodel dbmodel = new dbmodel();
        // GET: PhotoAlbum
        public ActionResult Index()
        {

            return View(dbmodel.PhotoAlbums.Include(p=>p.PhotoGallery));
        }
        public ActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(dbmodel.PhotoAlbums, "Id", "Title");
            PhotoAlbum photoAlbum = new PhotoAlbum();
            photoAlbum.PhotoGallery.Add(new PhotoGallery
            {
                ImageUrl = "",
                Title = "",
                Id = 0, 
                Image=null
            });
            return View(photoAlbum);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PhotoAlbum photoAlbum,int AlbumId)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                try
                {
                    string pathTosave = "";
                    if (photoAlbum.PhotoGallery != null)
                    {
                        string wwwRootPath = Server.MapPath("~/");
                        foreach (var imag in photoAlbum.PhotoGallery)
                        {
                            if (imag.Image != null)
                            {
                            string fileName = Path.GetFileNameWithoutExtension(imag.Image.FileName);
                            string extension = Path.GetExtension(imag.Image.FileName);
                            string savetoFile = imag.Title + extension;
                            string path = Path.Combine(wwwRootPath + "/PhotoGallery", savetoFile);
                            imag.Image.SaveAs(path);
                            pathTosave = "~/PhotoGallery/" + imag.Title + extension;
                            imag.ImageUrl = pathTosave;
                                imag.AlbumId= AlbumId;
                            if (photoAlbum.Id > 0)
                            {
                                dbmodel.Entry(photoAlbum).State = EntityState.Modified;
                            }
                            else
                            {
                                dbmodel.PhotoAlbums.Add(photoAlbum);
                            }
                             result = await dbmodel.SaveChangesAsync();
                            }
                        }
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
            ViewData["AlbumId"] = new SelectList(dbmodel.PhotoAlbums, "Id", "Title");
            return View(photoAlbum);
        }
    }
}