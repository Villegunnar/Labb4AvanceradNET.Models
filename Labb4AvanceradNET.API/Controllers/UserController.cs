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
    public class UserController : ControllerBase
    {
        private IProgramRepository<User> _userRepo;
        public UserController(IProgramRepository<User> uRepo)
        {
            _userRepo = uRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userRepo.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await _userRepo.GetSingel(id);
                if (result == null)
                {
                    return NotFound($"User with Id: '{id}' could not be found in the database");
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve singel user from database.");
            }
        }



        [HttpPost]
        public async Task<ActionResult<User>> CreateNewUser(User newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return BadRequest();
                }

                var createdUser = await _userRepo.Add(newUser);

                return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var deletePro = await _userRepo.GetSingel(id);
                if (deletePro == null)
                {
                    return NotFound($"User with Id: '{id}' could not be found in the database");
                }

                return await _userRepo.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete user from database.");
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User pro)
        {
            try
            {
                if (id != pro.Id)
                {
                    return BadRequest("User ID dosnt exists.");
                }

                var proToUpdate = await _userRepo.GetSingel(id);
                if (proToUpdate == null)
                {
                    return NotFound($"User with Id: '{id}' could not be found in the database");
                }
                return await _userRepo.Update(pro);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update user in database.");
            }
        }

        [HttpGet("{searchforuser}")]
        public async Task<ActionResult<User>> SearchUsers(string name)
        {

            var searchResult =  await _userRepo.SearchUsers(name);

            if (searchResult.Any())
            {
                return Ok(searchResult);
            }
            return NotFound($"Could not find any user containing {name} in the database");

        }
    }
}
