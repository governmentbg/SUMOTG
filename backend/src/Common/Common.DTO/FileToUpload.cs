using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class FileToUpload
    {
        public int Id { get; set; }
        public int IdDog { get; set; }
        public int DocType { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public string FileAsBase64 { get; set; }
        public byte[] FileAsByteArray { get; set; }
    }
}
