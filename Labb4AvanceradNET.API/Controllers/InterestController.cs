
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvanceradNET.Models
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Interest>> GetInterest(int id)
        {
            try
            {
                var result = await _interestRepo.GetSingel(id);
                if (result == null)
                {
                    return NotFound();
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
                if (newInterest == null)
                {
                    return BadRequest();
                }

                var createdInterest = await _interestRepo.Add(newInterest);

                return CreatedAtAction(nameof(GetInterest), new { id = createdInterest.Id }, createdInterest);

            }
            catch (Exception)
            {

                throw;
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
                    return NotFound($"Interest with ID : {id} was not found.");
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
                    return NotFound($"Interest with ID : {id} was not found.");
                }
                return await _interestRepo.Update(interest);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update interest in database.");
            }
        }
    }
}
