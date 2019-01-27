using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorWebApi.Models
{
    public interface IGPDetailRepository
    {
        IEnumerable<GPDetail> GetAll();

        GPDetail GetById(int id);

        void Add(GPDetail patient);
    }
}