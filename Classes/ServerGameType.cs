// automatic generation D2Sym.Sync 2015

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Sym.Classes
{
    public class ServerGameType : ID2OClass
    {
        [Cache]
        public static List<ServerGameType> ServerGameTypes = new List<ServerGameType>();
        public Int32 id;
        public Int32 nameId;
        public ServerGameType(Int32 id, Int32 nameId)
        {
            this.id = id;
            this.nameId = nameId;
        }
    }
}
