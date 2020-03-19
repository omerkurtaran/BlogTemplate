using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerKurtaran.WebUI.Models
{
    [Table("Rol")]
    public partial class Rol
    {
        public Rol()
        {
            KullaniciRols = new HashSet<KullaniciRol>();

        }
        [Key]
        public int RolId { get; set; }

        [StringLength(100)]
        public string RolAdi { get; set; }

        public virtual ICollection<KullaniciRol> KullaniciRols { get; set; }


    }
}