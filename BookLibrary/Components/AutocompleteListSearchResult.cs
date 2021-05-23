using MatBlazor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Components
{
    internal class AutocompleteListSearchResult<TItem>
    {
        public List<MatAutocompleteListItem<TItem>> ListResult { get; set; }

        public IEnumerable<TItem> Items { get; set; }

        public string SearchText { get; set; }
    }
}
