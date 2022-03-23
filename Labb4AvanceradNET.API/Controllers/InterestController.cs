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
    public class InterestController : ControllerBase
    {
        private IProgramRepository<Interest> _interestRepo;
        public InterestController(IProgramRepository<Interest> interRepo)
        {
            _interestRepo = interRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _interestRepo.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Interest>> GetInterest(int id)
        {
            try
            {
                var result = await _interestRepo.GetSingel(id);
                if (result == null)
                {
                    return NotFound($"Interest with Id: '{id}' could not be found in the database");
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve singel user from database.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Interest>> CreateNewInterest(Interest newInterest)
        {
            try
            {

                var createdInterest = await _interestRepo.Add(newInterest);


                if (newInterest != null)
                {
                    return Created("", createdInterest);
                }

                return NotFound("Error");


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to connect to database.");
            }



        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interest>> DeleteInterest(int id)
        {
            try
            {
                var deleteInterest = await _interestRepo.GetSingel(id);
                if (deleteInterest == null)
                {
                    return NotFound($"Interest with Id: '{id}' could not be found in the database");
                }

                return await _interestRepo.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete interest from database.");
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Interest>> UpdateInterest(int id, Interest interest)
        {
            try
            {
                if (id != interest.Id)
                {
                    return BadRequest("Interest ID dosnt exists.");
                }

                var interestToUpdate = await _interestRepo.GetSingel(id);
                if (interestToUpdate == null)
                {
                    return NotFound($"Interest with Id: '{id}' could not be found in the database");
                }
                return await _interestRepo.Update(interest);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update interest in database.");
            }
        }
        [HttpGet("{userinterests}")]

        public async Task<ActionResult<Interest>> GetUserWithInterests(int id)
        {

            try
            {
                var result = await _interestRepo.GetUserWithInterests(id);
                if (result.Any())
                {
                    return Ok(result);

                }
                return NotFound($"User with Id: '{id}' could not be found in the database");
                
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to find users interests");
            }


        }



    }
}
