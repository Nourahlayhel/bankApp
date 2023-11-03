using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TransAccount.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult<UserDto>> Authenticate(LoginDto loginDto)
        {
            var user = await this.userService.Authenticate(loginDto);
            return this.Ok(user);
        }
    }
}
