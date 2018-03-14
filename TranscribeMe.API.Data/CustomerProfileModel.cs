using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranscribeMe.API.Data
{
    public class CustomerProfileModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string TimeZone { get; set; }
        public string Email { get; set; }
    }
}
