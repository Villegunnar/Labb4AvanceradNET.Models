using Labb4AvanceradNET.API.Services;
using Labb4AvanceradNET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvanceradNET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteController : ControllerBase
    {
        private IProgramRepository<Website> _webbsiteRepo;
        public WebsiteController(IProgramRepository<Website> webbRepo)
        {
            _webbsiteRepo = webbRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWebbsites()
        {
            try
            {
                return Ok(await _webbsiteRepo.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Website>> GetWebbsite(int id)
        {
            try
            {
                var result = await _webbsiteRepo.GetSingel(id);
                if (result == null)
                {
                    return NotFound($"No website with Id: '{id}' could not be found in the database");
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve singel webbsite from database.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Website>> CreateNewWebbsite(Website newWebbsite)
        {
            try
            {

                var createdWebsite = await _webbsiteRepo.Add(newWebbsite);


                if (createdWebsite != null)
                {
                    return Created("", createdWebsite);
                }

                return NotFound("Error");
    

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to connect to database.");
            }



        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Website>> DeleteWebbsite(int id)
        {
            try
            {
                var deleteWebbsite = await _webbsiteRepo.GetSingel(id);
                if (deleteWebbsite == null)
                {
                    return NotFound($"Webbsite with Id: '{id}' could not be found in the database");
                }

                return await _webbsiteRepo.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete webbsite from database.");
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Website>> UpdateWebbsite(int id, Website webbsite)
        {
            try
            {
                if (id != webbsite.Id)
                {
                    return BadRequest("Interest ID dosnt exists.");
                }

                var webbsiteToUpdate = await _webbsiteRepo.GetSingel(id);
                if (webbsiteToUpdate == null)
                {
                    return NotFound($"Webbsite with Id: '{id}' could not be found in the database");
                }
                return await _webbsiteRepo.Update(webbsite);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update webbsite in database.");
            }
        }

        [HttpGet("{userwebbsites}")]
        public async Task<ActionResult<Website>> GetUserWithWebbsites(int id)
        {

            try
            {
                var result = await _webbsiteRepo.GetUserWithWebbsites(id);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound($"User with Id: '{id}' could not be found in the database");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to find users webbsites");
            }


        }
        [HttpGet("{search}/{userinterestswebsites}")]
        public async Task<ActionResult<Website>> GetUserWithInterestWebbsites(int id)
        {
            try
            {
                var result = await _webbsiteRepo.GetUserWithInterestWebbsites(id);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound($"User with Id: '{id}' could not be found in the database");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to find users webbsites");
            }
        }


    }
}

