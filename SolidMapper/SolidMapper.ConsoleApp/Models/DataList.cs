using System;
using System.Collections.Generic;

namespace SolidMapper.ConsoleApp.Models
{
    public sealed class DataList
    {
        public Guid Id { get; set; }
        public IList<DataListItem> Items { get; set; }
        public string Name { get; set; }
    }
}
