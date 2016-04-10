// automatic generation D2Sym.Sync 2015

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Sym.Classes
{
    public class Appearance : ID2OClass
    {
        [Cache]
        public static List<Appearance> Appearances = new List<Appearance>();
        public Int32 id;
        public Int32 type;
        public String data;
        public Appearance(Int32 id, Int32 type, String data)
        {
            this.id = id;
            this.type = type;
            this.data = data;
        }
    }
}
