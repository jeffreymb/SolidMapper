using System.Collections.Generic;

namespace SolidMapper.ConsoleApp.Models
{
    public sealed class ViewList
    {
        public IList<ViewListItem> Items { get; set; }
        public string Name { get; set; }
    }
}
