using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranscribeMe.API.Data.Queries
{
    public abstract class FilterQuery 
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
