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
    public class UsersController : ApiController
    {
        IUserService db;

        public UsersController(IUserService service)
        {
            db = service;
        }

        // GET api/Users
        public IHttpActionResult Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserVM>()).CreateMapper();
            var result = mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserVM>>(db.Get());

            return Ok(result);
        }

        // GET api/Users/2
        public IHttpActionResult Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserVM>()).CreateMapper();
            var result = mapper.Map<UserDTO, UserVM>(db.Get(id));

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/Users
        public IHttpActionResult Post([FromBody]UserVM value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserVM, UserDTO>()).CreateMapper();

            try
            {
                db.Create(mapper.Map<UserVM, UserDTO>(value));
                return StatusCode(HttpStatusCode.Created);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/Users/5
        public IHttpActionResult Put(int id, [FromBody]UserVM value)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserVM, UserDTO>()).CreateMapper();

            try
            {
                db.Update(id, mapper.Map<UserVM, UserDTO>(value));
                return Ok();
            }
            catch(ValidationException)
            {
                return NotFound();
            }
        }

        // DELETE api/Users/1
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