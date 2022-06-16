using Labb3.API.Services;
using Labb3Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository<Person> _personRepository;

        public PersonController(IPersonRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                return Ok(await _personRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to GetAllPersons data from Database...");
            }
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            try
            {
                var single = await _personRepository.GetSingle(id);

                if (single == null)
                {
                    return NotFound($"Could not find Person with ID {id} in database");
                }
                return Ok(single);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to GetPerson data from Database...");
            }
        }

       
        [HttpGet("hobbies/{id}")]
        public async Task<IActionResult> GetHobbies(int id)
        {
            try
            {
                var hobbies = await _personRepository.GetInterests(id);

                if (hobbies == null)
                {
                    return NotFound($"Person with ID {id} does not have a hobby");
                }
                return Ok(hobbies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to GetInterests data from Database...");
            }
        }

       
        [HttpGet("links/{id}")]
        public async Task<IActionResult> GetLinks(int id)
        {
            try
            {
                var links = await _personRepository.GetLinks(id);

                if (links == null)
                {
                    return NotFound($"Person with ID {id} has not added any links");
                }
                return Ok(links);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to GetLinks data from Database...");
            }
        }
    }
}