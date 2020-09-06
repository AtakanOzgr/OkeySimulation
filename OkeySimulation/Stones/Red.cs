using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeySimulation.Stones
{
    public class Red : Stone
    {
        public Red(int value) : base(value)
        {
            base.setColor("Red");
            base.setBound(0x33);
        }

    }
}
