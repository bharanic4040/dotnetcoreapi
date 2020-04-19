using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetHello.Core.DTOs;
using AutoMapper;
using DotNetHello.Core.Entities;
using DotNetHello.Core.Interfaces;

namespace DotNetHello.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ISearchRepository _searchRepository;

        private readonly ILogger<SearchController> _logger;

       

        public SearchController(ISearchRepository searchRepository,ILogger<SearchController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _searchRepository = searchRepository;
        }


        [HttpGet]
        public ActionResult<SearchDto> GetSearch()
        {
            try
            {
                SearchDto one = (SearchDto)_mapper.Map<SearchDto>(_searchRepository.GetAll().ElementAt(0));
                if (one==null)
                {
                    return NotFound();
                }
                return Ok(one);
            }
            catch(Exception e)
            {
                _logger.LogError("Serious Error - "+e);
            }
            return BadRequest("Bad Request 500");
           
        }


        [HttpPost]
        public ActionResult<SearchDto> Post([FromBody] SearchDto payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validation failure from the app");
            }

            Search search = _mapper.Map<Search>(payload);
            _searchRepository.Add(search);
            _searchRepository.Save();

            return Ok(payload);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpGet("{isbn}")]
        public ActionResult<SearchDto> Get(string isbn)
        {
            Search item = _searchRepository.GetById(isbn);

            if(item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SearchDto>(item));
        }



        [HttpDelete("{isbn}")]
        public void Delete(string isbn)
        {
            _searchRepository.DeleteById(isbn);
        }

       
      
    }
}
