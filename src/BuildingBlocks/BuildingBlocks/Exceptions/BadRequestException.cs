using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions
{
    internal class BadRequestException :Exception
    {
        public string? Details { get; set; }
        public BadRequestException(string message):base(message) { 
        }

        public BadRequestException(string message,string Details) : base(message)
        {
            this.Details = Details;
        }
    }
}
