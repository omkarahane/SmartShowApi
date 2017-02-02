using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShow.DTO.Models
{
    public class File
    {
        [Key,Column(Order =0)]
        public int Id { get; set; }
        [Key, Column(Order =1)]
        public string Name { get; set; }
        [Required]
        public string Url { get; set;}
        public int Type { get; set; }
        [ForeignKey("Type ")]
        public AllowedFileType AllowedFileType { get; set; }
        public DateTime? UploadedAt { get; set; }  
      
    }
}
