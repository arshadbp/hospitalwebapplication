using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWebApi.Models
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();

        Patient GetById(int id);
         
        void Add(Patient patient);

        void Update(int ID, Patient patient);

        void Delete(int id);
    }
}
