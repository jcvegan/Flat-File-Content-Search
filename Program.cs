using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvegan.Com.ContentSearch {
    class Program {
        static void Main(string[] args) {
            SearchContext searchContext = new SearchContext(new FlatFileSearchStrategy(args[0], args[1], args[2]));
        }
    }
}