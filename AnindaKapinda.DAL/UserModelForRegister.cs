using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    public class UserModelForRegister
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı gerekli")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kullanıcı Soyadı gerekli")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Eposta adresi gerekli")]
        [EmailAddress]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre gerekli")]
        [MinLength(8, ErrorMessage = "{0} en az {1} karakter olmalıdır")]
        
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        public bool IsAccountActive { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public string Role { get; set; }
    }
}