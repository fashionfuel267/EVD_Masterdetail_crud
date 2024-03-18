using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EVD_Masterdetail.Models
{
    public class PhotoGallery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped ]
        public HttpPostedFileBase Image { get; set; }
        [ForeignKey("PhotoAlbum")]
        public int AlbumId { get; set; }
         
        public PhotoAlbum PhotoAlbum { get; set; }
        [NotMapped]
         
        public string AlbumName { get; set; }
    }
    public class dbmodel:DbContext
    {
        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<PhotoGallery> PhotoGalleries { get; set; }
    }
    public class PhotoAlbum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date),DisplayFormat(DataFormatString ="{0:yyyy/mm/dd}",ApplyFormatInEditMode =true)]
       public DateTime Created { get; set; }
        public int TotalPic{ get; set; } 
        public List<PhotoGallery> PhotoGallery { get; set; } = new List<PhotoGallery>();

    }
}