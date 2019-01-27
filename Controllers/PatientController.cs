using DoctorWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoctorWebApi.Controllers
{
    public class PatientController : ApiController
    {

        private readonly IPatientRepository _repository;

        public PatientController(IPatientRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Patient> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var patient = _repository.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public void AddPatient(Patient patient) {
            _repository.Add(patient);
        }

        [HttpPut] 
        public void UpdatePatient(int ID,Patient patient)
        {
            _repository.Update(ID,patient);
            //_repository.Add(patient);
        }

        [HttpDelete]
        public void Delete(int id) {
            _repository.Delete(id);
        }

    }
}
