using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfClub.Helpers;
using SurfClub.Models;
using SurfClub.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurfClub.Controllers
{
    public class FeedController : Controller
    {
        private readonly SurfClubDBContext dBContext;

        public FeedController(SurfClubDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IActionResult Index()
        {
            var posts = dBContext.Post.Include(c=>c.Author).
                OrderBy(c => c.PublishDate).ToArray();
            ViewBag.Post = posts;
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Post model, IFormFile imageData)
        {
            if (string.IsNullOrEmpty(model.Text) && imageData == null)
            {
                var posts1 = dBContext.Post.Include(c => c.Author).
              OrderBy(c => c.PublishDate).ToArray();
                ViewBag.Post = posts1;
                return View("Index",model);
            }
            if (imageData != null)
            {
                model.Photo = ImageHelper.UploadImage(imageData);
            }
            model.PublishDate = DateTime.Now;

            var userId = HttpContext.Session.GetInt32("UserId").Value;//mb pustoy!

            var user = dBContext.User.FirstOrDefault(c => c.Id == userId);


            model.Author = user;

            dBContext.Post.Add(model);
            dBContext.SaveChanges();

            var posts = dBContext.Post.Include(c => c.Author).
                OrderBy(c => c.PublishDate).ToArray();
            ViewBag.Post = posts;


            return View("Index");
        }
    }
}
