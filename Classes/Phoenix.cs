// automatic generation D2Sym.Sync 2015

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Sym.Classes
{
    public class Phoenix : ID2OClass
    {
        [Cache]
        public static List<Phoenix> Phoenixs = new List<Phoenix>();
        public Int32 mapId;
        public Phoenix(Int32 mapId)
        {
            this.mapId = mapId;
        }
    }
}
