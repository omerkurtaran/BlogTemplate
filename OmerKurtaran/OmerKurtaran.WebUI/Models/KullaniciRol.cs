using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerKurtaran.WebUI.Models
{
    [Table("KullaniciRol")]
    public partial class KullaniciRol
    {
        [Key]
        [Column(Order = 1)]
        public virtual Kullanici Kullanici { get; set; }

        [Key]
        [Column(Order = 2)]
        public virtual Rol Rol { get; set; }


    }
}