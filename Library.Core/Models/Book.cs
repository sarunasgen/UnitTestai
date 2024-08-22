using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models
{
    public class Book : LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public override bool Equals(object? obj)
        {
            if (LibraryItemId == ((Book)obj).LibraryItemId)
                return true;
            else
                return false;
        }
    }
}
