using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using BLL.Interfaces;
using AutoMapper;
using WebApp.Models;
using BLL.DTO;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Controllers.API
{
    public class RatesController : ApiController
    {
        IRateService db;

        public RatesController(IRateService service)
        {
            db = service;
        }

        // GET api/Rates
        public IHttpActionResult Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRateDTO, RateVM>()).CreateMapper();
            var result = mapper.Map<IEnumerable<KnowledgeRateDTO>, IEnumerable<RateVM>>(db.Get());

            return Ok(result);
        }

        // GET api/Rates/2
        public IHttpActionResult Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRateDTO, RateVM>()).CreateMapper();
            var result = mapper.Map<KnowledgeRateDTO, RateVM>(db.Get(id));

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/Rates
        public IHttpActionResult Post([FromBody]RateVM value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RateVM, KnowledgeRateDTO>()).CreateMapper();

            try
            {
                db.Create(mapper.Map<RateVM, KnowledgeRateDTO>(value));
                return StatusCode(HttpStatusCode.Created);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/Rates/5
        public IHttpActionResult Put(int id, [FromBody]RateVM value)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RateVM, KnowledgeRateDTO>()).CreateMapper();

            try
            {
                db.Update(id, mapper.Map<RateVM, KnowledgeRateDTO>(value));
                return Ok();
            }
            catch(ValidationException)
            {
                return NotFound();
            }
        }

        // DELETE api/Rates/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                db.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(ValidationException)
            {
                return NotFound();
            }
        }
    }
}
