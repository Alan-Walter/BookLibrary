using BookLibrary.Db.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Data.Models
{
    public class FileModel : BaseModel<BinaryFile>
    {
        public string TemporaryFilePath { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }
    }
}
