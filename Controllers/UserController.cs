
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookReview.Services;               
using BookReview.DTOs.UserDTOs;          
using System.Threading.Tasks;           

namespace BookReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;   

       
        public UserController(UserService userService)   
        {
            _userService = userService;                  
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
        {
            if (dto == null) return BadRequest("Ingen data skickades.");

            var user = await _userService.RegisterUserAsync(dto);
            if (user == null)
                return BadRequest("E-post finns redan.");

            return Ok(new { user.Id, user.Name, user.Email });
        }


        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)   
        {
            if (dto == null) return BadRequest("Ingen data skickades.");
            var user = await _userService.LoginUserAsync(dto);
            if (user == null) return Unauthorized("Fel e-post eller lösenord.");

            
            return Ok(new { user.Id, user.Name, user.Email });
        }
    }
}
