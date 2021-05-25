using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Db.Models
{
    public class BinaryFile : Entity
    {
        public string FileName { get; set; }

        public string FileType { get; set; }

        public string FilePath { get; set; }
    }
}
