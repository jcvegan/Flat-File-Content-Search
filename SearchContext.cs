using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvegan.Com.ContentSearch
{
    public class SearchContext {
        private readonly SearchStrategy strategy = null;
        public SearchContext(SearchStrategy strategy) {
            this.strategy = strategy;
        }
        public void LookUp() {
            this.strategy.SearchContent();
        }
    }
}