using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using BLL.Interfaces;
using AutoMapper;
using WebApp.Models;
using BLL.DTO;
using BLL.Infrastructure;

namespace WebApp.Controllers.API
{
    public class AreasController : ApiController
    {
        IAreaService db;

        public AreasController(IAreaService service)
        {
            db = service;
        }

        // GET api/Areas
        public IHttpActionResult Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, AreaVM>()).CreateMapper();
            var result = mapper.Map<IEnumerable<AreaDTO>, IEnumerable<AreaVM>>(db.Get());

            return Ok(result);
        }

        // GET api/Areas/2
        public IHttpActionResult Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, AreaVM>()).CreateMapper();
            var result = mapper.Map<AreaDTO, AreaVM>(db.Get(id));

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/Areas
        public IHttpActionResult Post([FromBody]AreaVM value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaVM, AreaDTO>()).CreateMapper();

            try
            {
                db.Create(mapper.Map<AreaVM, AreaDTO>(value));
                return StatusCode(HttpStatusCode.Created);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/Areas/2
        public IHttpActionResult Put(int id, [FromBody]AreaVM value)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaVM, AreaDTO>()).CreateMapper();

            try
            {
                db.Update(id, mapper.Map<AreaVM, AreaDTO>(value));
                return Ok();
            }
            catch(ValidationException)
            {
                return NotFound();
            }
        }

        // DELETE api/Areas/2
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