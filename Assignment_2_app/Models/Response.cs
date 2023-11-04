using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    internal class Response
    {
        public int statusCode { get; set; }

        public string message { get; set; }

        public Products product { get; set; }

        public List<Products> products { get; set; }
    }
}
