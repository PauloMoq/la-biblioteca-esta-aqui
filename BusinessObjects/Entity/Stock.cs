using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Entity
{
    internal class Stock
    {
        public Library? Library { get; set; }
        public Book? Book { get; set; }
    }
}
