using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeySimulation.Stones
{
    public class Yellow : Stone
    {
        public Yellow(int value) : base(value)
        {
            base.setColor("Yellow");
            base.setBound(12);
        }

    }
}
