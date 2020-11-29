using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public class SearchViewModel
    {
        public string SearchString { get; set; }
        public List<Car> SearchResult{ get; set; }
        public int SearchResultCounter { get; set; }
    }
}
