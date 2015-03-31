using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoSqlWeb.Models
{
    public class AvFile
    {
        public string FileName { get; set; }

        public string FilePath { get; set; }
        public string Id { get; set; }

        public string FileType { get; set; }

        public byte[] StreamByteArray { get; set; }
        
    }
}