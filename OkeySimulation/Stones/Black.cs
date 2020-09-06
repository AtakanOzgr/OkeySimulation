using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeySimulation.Stones
{
    public class Black : Stone
    {
        public Black(int value) : base(value)
        {
            base.setColor("Black");
            base.setBound(0x26);
        }

    }
}
