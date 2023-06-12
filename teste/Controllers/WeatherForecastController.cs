using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;

namespace teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Teste : ControllerBase
    {
        private readonly Cloudinary _cloudinary;

        public Teste(Cloudinary clourdinary)
        {
            _cloudinary = clourdinary;
        }

        [HttpGet("slacaraikkk")]
        public ActionResult GetImage()
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"data:image/png;base64,iVBORw0KGgoAAA
ANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4
//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU
5ErkJggg=="),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            return Ok(uploadResult);
        }

        [HttpGet("pegardetalheainessabosta")]
        public ActionResult PostImage()
        {
            var getResourceResult = _cloudinary.Api.UrlImgUp.BuildUrl("993090172-breno-no-sao-paulo");
            return Ok(getResourceResult);
        }
    }
}