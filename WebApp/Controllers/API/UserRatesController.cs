using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers.API
{
    public class UserRatesController : ApiController
    {
        IRateService db;

        public UserRatesController(IRateService service)
        {
            db = service;
        }

        // GET api/UserRates/2
        public IHttpActionResult Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRateDTO, RateVM>()).CreateMapper();
            var result = mapper.Map<IEnumerable<KnowledgeRateDTO>, IEnumerable<RateVM>>(db.GetByUser(id));

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}