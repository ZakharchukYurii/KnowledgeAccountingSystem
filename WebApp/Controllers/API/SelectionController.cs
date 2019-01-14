using System.Collections.Generic;
using System.Web.Http;
using BLL.Interfaces;
using AutoMapper;
using WebApp.Models;
using BLL.DTO;

namespace WebApp.Controllers.API
{
    public class SelectionController : ApiController
    {
        IMakeSelectionService db;

        public SelectionController(IMakeSelectionService service)
        {
            db = service;
        }

        // GET api/Selection/{knowledge}/{rate}
        [HttpGet]
        public IHttpActionResult Selection(string knowledge, int rate)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRateDTO, RateVM>()).CreateMapper();
            var result = mapper.Map<IEnumerable<KnowledgeRateDTO>, IEnumerable<RateVM>>
                (db.MakeSelection(new SelectionRequestDTO { Knowledge = knowledge, Rate = rate }));

            return Ok(result);
        }
    }
}