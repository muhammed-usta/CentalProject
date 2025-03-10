using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.ContactDtos
{
    public class CreateContactDto
    {

        public string Adress { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string WebsiteUrl { get; set; }
        public string OpenDay { get; set; }
        public string OffDay { get; set; }

        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }

        public string MapUrl { get; set; }
        public int SocialMediaId { get; set; }

      

    }
}
