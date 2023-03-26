using Microsoft.AspNetCore.Mvc;
using TeamViewer2.EntityContext.Entites;
using TeamViewer2.EntityContext.Services;
using TeamViewer2.Server2.Business.Utils.ResultModel;

namespace TeamViewer2.Server2.Business.Users.Api.Controllers
{
        [ApiController]
        [Route("users/[controller]")]

        public class UsersController : ControllerBase
        {
                private readonly ILogger<UsersController> _logger;
                private readonly UserService _userService;

                public UsersController(ILogger<UsersController> logger,
                                       UserService userService)
                {
                        _logger = logger;
                        this._userService = userService;
                }

                [HttpPost]
                public async Task<ActionResult<User>> AddUser(User user)
                {
                        try
                        {
                                if (user == null)
                                        return BadRequest();

                                int ret = await this._userService.AddUserAsync(user);

                                var data = new Result<bool>()
                                {
                                        code = 0,
                                        data = ret == 1
                                };
                                return CreatedAtAction(nameof(AddUser), data);
                        }
                        catch (Exception)
                        {
                                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error creating new User record");
                        }
                }

                [HttpGet]
                public async Task<ActionResult> Login(User user)
                {
                        return BadRequest();
                }
        }
}
