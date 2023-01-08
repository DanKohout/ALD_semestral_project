using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace try03_ald_sem
{
    public class Crate
    {
        private int i;
        private int j;

        public Crate(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public int getI() { return i; }
        public int getJ() { return j; }
    }
}
