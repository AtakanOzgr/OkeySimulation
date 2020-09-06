using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeySimulation.Stones
{
    public class Blue :Stone
    {
        public Blue(int value) : base(value)
        {
            base.setColor("Blue");
            base.setBound(0x19);
        }

    }
}
