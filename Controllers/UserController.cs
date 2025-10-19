using Microsoft.AspNetCore.Mvc;
using BudgetApprovedApi.Models;
using BudgetApprovedApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BudgetApprovedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        /// <summary>
        /// Preluarea tuturor utilizatorilor.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            
            if (users == null || !users.Any())
            {
                return NotFound("Nu au fost găsiți utilizatori.");
            }
            
            return Ok(users);
        }

        // POST: api/Users
        /// <summary>
        /// Crearea unui nou utilizator.
        /// </summary>
        /// <param name="user">Obiectul utilizator de creat.</param>
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser(UserModel user)
        {

            var createdUser = await _userService.AddUserAsync(user);

            return CreatedAtAction(nameof(GetUsers), new { id = createdUser.Id }, createdUser);
        }
    }
}
