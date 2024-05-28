using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions
{
    public class NotFoundException :Exception
    {
        public NotFoundException(string errorMssg) :base(errorMssg)
        {
        }

        public NotFoundException(string name, Object key) : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
