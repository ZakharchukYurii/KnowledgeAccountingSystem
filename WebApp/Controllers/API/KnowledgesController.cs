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
    public class KnowledgesController : ApiController
    {
        IKnowledgeService db;

        public KnowledgesController(IKnowledgeService service)
        {
            db = service;
        }

        // GET api/Knowledges
        public IHttpActionResult Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, KnowledgeVM>()).CreateMapper();
            var result = mapper.Map<IEnumerable<KnowledgeDTO>, IEnumerable<KnowledgeVM>>(db.Get());

            return Ok(result);
        }

        // GET api/Knowledges/2
        public IHttpActionResult Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, KnowledgeVM>()).CreateMapper();
            var result = mapper.Map<KnowledgeDTO, KnowledgeVM>(db.Get(id));

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/Knowledges
        public IHttpActionResult Post([FromBody]KnowledgeVM value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeVM, KnowledgeDTO>()).CreateMapper();

            try
            {
                db.Create(mapper.Map<KnowledgeVM, KnowledgeDTO>(value));
                return StatusCode(HttpStatusCode.Created);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/Knowledges/5
        public IHttpActionResult Put(int id, [FromBody]KnowledgeVM value)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeVM, KnowledgeDTO>()).CreateMapper();

            try
            {
                db.Update(id, mapper.Map<KnowledgeVM, KnowledgeDTO>(value));
                return Ok();
            }
            catch(ValidationException)
            {
                return NotFound();
            }
        }

        // DELETE api/Knowledges/2
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
