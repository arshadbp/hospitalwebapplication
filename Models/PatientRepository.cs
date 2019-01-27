using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace DoctorWebApi.Models
{
    public class PatientRepository : IPatientRepository
    {
        private DoctorDBContext db = new DoctorDBContext();

        public IEnumerable<Patient> GetAll() {

            return db.Patients;
        }

        public void Add(Patient product)
        {
            db.Patients.Add(product);
            db.SaveChanges();
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

        public Patient GetById(int id)
        {
            Patient patient = new Patient();

            var result = from p in db.Patients
                         join g in db.GPDetails
                         on p.GeneralPartitioner equals g.ID
                         where p.ID.Equals(id)
                         select new
                         {
                             ID = p.ID, PassNumber = p.PassNumber,ForeNames = p.ForeNames,SurName = p.SurName,DateOfBirth = p.DateOfBirth,
                             Gender = p.Gender,HomeTelephoneNumber = p.HomeTelephoneNumber,GeneralPartitioner = p.GeneralPartitioner,
                             NOKName = p.NOKName,NOKAddress1 = p.NOKAddress1,NOKAddress2 = p.NOKAddress2,NOKAddress3 = p.NOKAddress3,
                             NOKAddress4 = p.NOKAddress4,GPSurName = g.GPSurname,relationShip = p.relationShip
                         };
         
            foreach (var obj in result)
            {
               
                patient.ID = obj.ID;patient.PassNumber = obj.PassNumber;patient.ForeNames = obj.ForeNames;patient.SurName = obj.SurName;
                patient.DateOfBirth = obj.DateOfBirth;patient.Gender = obj.Gender;patient.HomeTelephoneNumber = obj.HomeTelephoneNumber;
                patient.GeneralPartitioner = obj.GeneralPartitioner;patient.NOKName = obj.NOKName;patient.NOKAddress1 = obj.NOKAddress1;
                patient.NOKAddress2 = obj.NOKAddress2;patient.NOKAddress3 = obj.NOKAddress3;patient.NOKAddress4 = obj.NOKAddress4;
                patient.GPSurName = obj.GPSurName;patient.relationShip = obj.relationShip;
            }

            return patient;
        }

        public void Update(int ID, Patient patient)
        {


            db.Entry(patient).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
                //if (!PatientExists(ID))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

        }
         
        private bool PatientExists(int id)
        {
            return db.Patients.Count(e => e.ID == id) > 0;
        }

        public void Delete(int id)
        {
            var patient = new Patient { ID = id };
            db.Entry(patient).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
    }
}