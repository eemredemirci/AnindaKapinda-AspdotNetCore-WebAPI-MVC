﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    [Table("Users")]
    class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı gerekli")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kullanıcı Soyadı gerekli")]
        public string Surname { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Eposta gerekli")]

        public string Mail { get; set; }

        [Required(ErrorMessage ="Şifre gerekli")]
        public string Password { get; set; }
        public bool IsAccountActive { get; set; }

    }
}
