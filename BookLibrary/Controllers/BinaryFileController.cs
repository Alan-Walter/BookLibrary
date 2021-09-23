using BookLibrary.Data.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinaryFileController : ControllerBase
    {
        // POST api/<BinaryFileController>
        [HttpPost]
        public async Task<ActionResult<IList<BinaryFileModel>>> Post([FromForm] IEnumerable<IFormFile> files)
        {
            var result = new List<BinaryFileModel>();
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    var filePath = Path.GetTempFileName();
                    using var stream = System.IO.File.Create(filePath);
                    await file.CopyToAsync(stream);
                    result.Add(new BinaryFileModel
                    {
                        FilePath = filePath,
                        FileName = file.Name,
                        FileType = file.ContentType
                    });
                }
            }
            return new JsonResult(result);
        }
    }
}
