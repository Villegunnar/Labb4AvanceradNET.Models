
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
    public class WebbsiteController : ControllerBase
    {
        private IProgramRepository<Webbsite> _webbsiteRepo;
        public WebbsiteController(IProgramRepository<Webbsite> webbRepo)
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Webbsite>> GetWebbsite(int id)
        {
            try
            {
                var result = await _webbsiteRepo.GetSingel(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve singel webbsite from database.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Webbsite>> CreateNewWebbsite(Webbsite newWebbsite)
        {
            try
            {
                if (newWebbsite == null)
                {
                    return BadRequest();
                }

                var createdWebbsite = await _webbsiteRepo.Add(newWebbsite);

                return CreatedAtAction(nameof(GetWebbsite), new { id = createdWebbsite.Id }, createdWebbsite);

            }
            catch (Exception)
            {

                throw;
            }



        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Webbsite>> DeleteWebbsite(int id)
        {
            try
            {
                var deleteWebbsite = await _webbsiteRepo.GetSingel(id);
                if (deleteWebbsite == null)
                {
                    return NotFound($"Webbsite with ID : {id} was not found.");
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
        public async Task<ActionResult<Webbsite>> UpdateWebbsite(int id, Webbsite webbsite)
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
                    return NotFound($"Webbsite with ID : {id} was not found.");
                }
                return await _webbsiteRepo.Update(webbsite);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update webbsite in database.");
            }
        }
    }
}

