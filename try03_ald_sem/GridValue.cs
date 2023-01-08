using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace try03_ald_sem
{
    public enum GridValue
    {
        ER404=-1,//if it is unable to fill with anything else
        Empty=0,//
        EndTop=1,//dead ends
        EndBottom=2,//
        EndLeft=3,//
        EndRight=4,//
        Curve0=5,//90 angle
        Curve90=6,//
        Curve180=7,//
        Curve270=8,//
        Straight0=9,//straights
        Straight90=10,//
        Cross3_0=11,//threes
        Cross3_90=12,//
        Cross3_180=13,//
        Cross3_270=14,//
        Cross4=15,//has all four sides
        NotReady=16
        
    }
}
