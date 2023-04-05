using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FileItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public FileExtensionEnum FileExtension { get; set; }

        [NotMapped]
        public string Base64Content
        {
            get
            {
                return Convert.ToBase64String(Content);
            }
        }
    }
}
