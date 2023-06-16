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

        [HttpPost("pegardetalheainessabosta")]
        public async Task<ActionResult> PostImage( IFormFile image)
        {
              byte[] imageData;
                using (var stream = new MemoryStream())
                  {
                        await image.CopyToAsync(stream);
                          imageData = stream.ToArray();
                        }

            var base64Image = Convert.ToBase64String(imageData);
            var dataUri = $"data:{image.ContentType};base64,{base64Image}";

              var uploadParams = new ImageUploadParams()
                {
                      File = new FileDescription(dataUri),
                        PublicId = image.FileName
                      };

                        var uploadResult = await _cloudinary.UploadAsync(uploadParams);

               return Ok(new { Url = uploadResult.SecureUrl.ToString() });
        }
    }
}