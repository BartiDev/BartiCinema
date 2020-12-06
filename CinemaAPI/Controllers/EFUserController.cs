using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFUserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public EFUserController(
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task RegisterUser(string name, string lastName, string password, string emailAddress)
        {

        }
    }
}
