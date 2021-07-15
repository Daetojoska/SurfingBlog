using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurfClub.Models.DbModels
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Псевдоним обязателен")]
        [MaxLength(20, ErrorMessage = "Максимальная длина двадцать символов"), MinLength(3, ErrorMessage = "Минимальная длина три символа")]
        public String Nickname { get; set; }

        [Required(ErrorMessage = "Почта обязательна")]
        [MaxLength(31, ErrorMessage = "Максимальная длина тридцать один символ"), MinLength(7, ErrorMessage = "Минимальная длина семь символов")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [MaxLength(20, ErrorMessage = "Максимальная длина двадцать символов"), MinLength(6, ErrorMessage = "Минимальная длина шесть символов")]
        public String Password { get; set; }

        [NotMapped]
        public String ConfirmPassword { get; set; }

        [MaxLength(31, ErrorMessage = "Максимальная длина тридцать один символ")]
        public String Surname { get; set; }

        [MaxLength(31, ErrorMessage = "Максимальная длина тридцать один символ")]
        public String Name { get; set; }

        public Guid? Photo { get; set; }

        [MaxLength(255, ErrorMessage = "Максимальная длина двадцать символов")]
        public String Contact { get; set; }

        [MaxLength(255, ErrorMessage = "Максимальная длина двадцать символов")]
        public String AboutMe { get; set; }

        [MaxLength(255, ErrorMessage = "Максимальная длина двадцать символов")]
        public String Progress { get; set; }
    }
}