using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepsoitory _repo;

        public AuthController(IAuthRepsoitory repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Registar(UserForRegisterDto userForRegisterDto)
        {
            //validate request

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower(CultureInfo.CurrentCulture);

            if (await _repo.UserExist(userForRegisterDto.Username))
            {
                return BadRequest("Username already exists");
            }

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Registar(userToCreate, userForRegisterDto.Password);

            return StatusCode(210);  //CreatedAtRoute();
        }
    }
}
