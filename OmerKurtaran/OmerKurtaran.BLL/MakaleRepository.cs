using OmerKurtaran.BLL.Core;
using OmerKurtaran.DAL.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerKurtaran.BLL
{
    public class MakaleRepository : IRepository<Makale>
    {
        OmerKurtaranEntities db = new OmerKurtaranEntities();

        public void Add(Makale entity)
        {
            db.Makales.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Makale entity)
        {
            db.Makales.Remove(entity);
            db.SaveChanges();
        }

        public List<Makale> GetAll()
        {
            return db.Makales.ToList();
        }

        public Makale GetById(int Id)
        {
            return db.Makales.FirstOrDefault(z => z.MakaleId == Id);
        }

        public void Update(Makale entity)
        {
            Makale m = db.Makales.FirstOrDefault(z => z.MakaleId == entity.MakaleId);
            m.Icerik = entity.Icerik;
            m.Kategori = entity.Kategori;
            m.Resims = entity.Resims;
            m.Yazar = entity.Yazar;
            m.Yorums = entity.Yorums;
            db.SaveChanges();
        }
    }
}
