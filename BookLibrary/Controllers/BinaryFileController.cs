using AutoMapper;

using BookLibrary.Core.Services;
using BookLibrary.Data.Models;
using BookLibrary.Db.Interfaces;
using BookLibrary.Db.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinaryFileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IBinaryFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public BinaryFileController(IFileService fileService, 
            IBinaryFileRepository fileRepository, 
            IMapper mapper)
        {
            _fileService = fileService;
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        // POST api/<BinaryFileController>
        [HttpPost]
        public async Task<ActionResult<IList<BinaryFileModel>>> Post([FromForm] IEnumerable<IFormFile> files)
        {
            var result = new List<BinaryFileModel>();
            foreach (var file in files)
            {
                if (file != null && file.Length > 0 && _fileService.CanSave(file.ContentType, file.Length))
                {
                    var id = Guid.NewGuid();
                    var filePath = await _fileService.SaveFileAsync(file.CopyToAsync, id);
                    var binaryFile = await _fileRepository.AddAsync(new BinaryFile
                    {
                        Id = id,
                        FileName = file.FileName,
                        FilePath = filePath,
                        FileType = file.ContentType
                    });
                    result.Add(_mapper.Map<BinaryFileModel>(binaryFile));
                }
            }
            return result.Count > 0 ? new CreatedResult(string.Empty, result) : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            var stream = _fileService.OpenFile(file.FilePath);
            return File(stream, file.FileType);
        }
    }
}
