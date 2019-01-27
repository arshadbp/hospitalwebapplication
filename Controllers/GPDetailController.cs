using DoctorWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoctorWebApi.Controllers
{
    public class GPDetailController : ApiController
    {
        private readonly IGPDetailRepository _repository;

        public GPDetailController(IGPDetailRepository repository) 
        {
            this._repository = repository;
        }

        public IEnumerable<GPDetail> Get()
        {
            return _repository.GetAll();
        }


        public IHttpActionResult Get(int id)
        {
            var gpDetail = _repository.GetById(id);
            if (gpDetail == null)
            {
                return NotFound();
            }
            return Ok(gpDetail);
        }


        [HttpPost]
        public void AddGPDetail(GPDetail gpDetail)
        {
            _repository.Add(gpDetail);
        }

    }
}
