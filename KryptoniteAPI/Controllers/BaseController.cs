using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KryptoniteAPI.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace KryptoniteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly KryptoniteAPIConfiguration configuration;
        public BaseController(IOptions<KryptoniteAPIConfiguration> configuration)
            => this.configuration = configuration.Value;
    }
}
