using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorWebApi.Models
{
    public class GPDetailRepository : IGPDetailRepository
    {
        private DoctorDBContext db = new DoctorDBContext();
        public void Add(GPDetail gpDetail) 
        {
            db.GPDetails.Add(gpDetail);
            db.SaveChanges();
        }

        public IEnumerable<GPDetail> GetAll()
        {
            return db.GPDetails;
        }

        public GPDetail GetById(int id)
        {
            return db.GPDetails.FirstOrDefault(g => g.ID == id);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}