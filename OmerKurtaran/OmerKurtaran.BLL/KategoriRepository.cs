using OmerKurtaran.BLL.Core;
using OmerKurtaran.DAL.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerKurtaran.BLL
{
    public class KategoriRepository : IRepository<Kategori>
    {
        OmerKurtaranEntities db = new OmerKurtaranEntities();

        public void Add(Kategori entity)
        {
            db.Kategoris.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Kategori entity)
        {
            db.Kategoris.Remove(entity);
            db.SaveChanges();
        }

        public List<Kategori> GetAll()
        {
            return db.Kategoris.ToList();
        }

        public Kategori GetById(int Id)
        {
            return db.Kategoris.FirstOrDefault(z => z.KategoriId == Id);
        }

        public void Update(Kategori entity)
        {
            Kategori k = db.Kategoris.FirstOrDefault(z => z.KategoriId == entity.KategoriId);
            k.Adi = entity.Adi;
            k.Aciklama = entity.Aciklama;
            k.Makales = entity.Makales;
            db.SaveChanges();
        }
    }
}
