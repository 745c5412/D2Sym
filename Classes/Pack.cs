// automatic generation D2Sym.Sync 2015

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Sym.Classes
{
    public class Pack : ID2OClass
    {
        [Cache]
        public static List<Pack> Packs = new List<Pack>();
        public Int32 id;
        public String name;
        public Boolean hasSubAreas;
        public Pack(Int32 id, String name, Boolean hasSubAreas)
        {
            this.id = id;
            this.name = name;
            this.hasSubAreas = hasSubAreas;
        }
    }
}
