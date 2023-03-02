using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Tovar_hw_6_2
{
    class My_store : IEnumerable
    {
        public List<Tovar> tovars = new List<Tovar>();

        public IEnumerator GetEnumerator() => tovars.GetEnumerator();

    }
}
