using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SurfClub.Models.ViewModels
{
    public class RegistrViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Псевдоним обязательный")]
        [MaxLength(20), MinLength(3, ErrorMessage = "Минимальная длина псевдонима 3")]
        public String Nickname { get; set; }

        [Required(ErrorMessage = "Почта обязательна")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Пароль обязательный")]
        [MaxLength(20), MinLength(6, ErrorMessage = "Минимальная длина пароля 6")]
        public String Password { get; set; }
        public String Surname { get; set; }
        public String Name { get; set; }
        public String Contact { get; set; }
        public String AboutMe { get; set; }
        public String Progress { get; set; }
        public Guid Photo { get; set; }

    }
}
