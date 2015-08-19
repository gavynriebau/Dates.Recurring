using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates.Recurring.Builders
{
    public class StartingBuilder
    {
        private DateTime _starting;

        public StartingBuilder(DateTime starting)
        {
            _starting = starting;
        }

        public EveryBuilder Every(int x)
        {
            return new EveryBuilder(_starting, x);
        }
    }
}
