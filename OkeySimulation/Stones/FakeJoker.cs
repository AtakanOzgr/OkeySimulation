using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeySimulation.Stones
{
    public class FakeJoker : Stone
    {
        public FakeJoker(int value) : base(value)
        {
            base.setColor("None");
            base.setBound(0x34);
        }

    }
}
