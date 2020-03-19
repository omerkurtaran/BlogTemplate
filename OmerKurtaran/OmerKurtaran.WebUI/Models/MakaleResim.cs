using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerKurtaran.WebUI.Models
{
    [Table("MakaleResim")]
    public partial class MakaleResim
    {
        [Key]
        public int MakaleResimId { get; set; }

        public Resim Resim { get; set; }

        public Makale Makale { get; set; }
    }
}