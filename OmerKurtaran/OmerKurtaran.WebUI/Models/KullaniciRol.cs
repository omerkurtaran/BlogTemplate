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
        public int KullaniciRolId { get; set; }

        
        public virtual Kullanici Kullanici { get; set; }

        
        public virtual Rol Rol { get; set; }


    }
}