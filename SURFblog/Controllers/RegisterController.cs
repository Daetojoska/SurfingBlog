using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurfClub.Helpers;
using SurfClub.Models;
using SurfClub.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SurfClub.Controllers
{
    public class RegisterController : Controller
    {
        public readonly SurfClubDBContext dbContext;
        public RegisterController(SurfClubDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User model, IFormFile imageData)
        {
            /// проверять, что пользователь есть в БД
            if (ModelState.IsValid)
            {
                var user = dbContext.User.FirstOrDefault(c =>
                c.Nickname == model.Nickname);
                var email = dbContext.User.FirstOrDefault(c =>
                c.Email == model.Email);

                if (user != null)
                {
                    ModelState.AddModelError(string.Empty, "Такой псевдоним уже занят");
                    return View("Index", model);
                }
                if (email != null)
                {
                    ModelState.AddModelError(string.Empty, "Такая почта уже зарегистрирована");
                    return View("Index", model);
                }
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Пароли не совпадают");
                    return View("Index", model);
                }
                if(imageData!= null) model.Photo = ImageHelper.UploadImage(imageData);

                dbContext.User.Add(model);
                dbContext.SaveChanges();


                user = dbContext.User.FirstOrDefault(c =>
                c.Nickname == model.Nickname);

                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString())
                };


                // создаем объект ClaimsIdentity
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                // установка аутентификационных куки
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(id));

                HttpContext.Session.SetString("NickName", user.Nickname);
                HttpContext.Session.SetString("Photo", user.Photo.ToString());
                HttpContext.Session.SetInt32("UserId", user.Id);

                return RedirectToAction("Index", "Feed");

            }
            return View("Index", model);
        }
    }
}