using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class LinkDTO
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ClickCount { get; set; }
    }
}
