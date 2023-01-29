using System;
using System.Threading.Tasks;
using KryptoniteAPI.Configuration;
using KryptoniteAPI.Exceptions;
using KryptoniteAPI.Interfaces;
using KryptoniteAPI.Models.APIModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KryptoniteAPI.Controllers
{
    [Route("api/Kryptonite")]
    [ApiController]
    public class KryptoniteController : BaseController
    {
        private readonly IKryptoniteService kryptoniteService;
        public KryptoniteController(IKryptoniteService kryptoniteService, IOptions<KryptoniteAPIConfiguration> configuration) : base(configuration)
        {
            this.kryptoniteService = kryptoniteService;
            this.kryptoniteService.SetCipherInstace(configuration.Value.EncryptionImplimentationName);
        }

        [HttpPost("Encrypt")]
        public IActionResult Encrypt([FromBody] string[] encryptRequest)
        {
            try
            {
                EncryptResult encryptResult = new EncryptResult()
                {
                    encryptedText = kryptoniteService.Encrypt(encryptRequest)
                };
                return Ok(JsonConvert.SerializeObject(encryptResult));
            }
            catch(InvalidConfigurationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPost("Decrypt")]
        public IActionResult Decrypt([FromBody] string textToDecrypt)
        {
            try
            {
                DecryptResult decryptResult = new DecryptResult()
                {
                    decryptedText = kryptoniteService.Decrypt(textToDecrypt)
                };
                return Ok(JsonConvert.SerializeObject(decryptResult));
            }
            catch (InvalidConfigurationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
