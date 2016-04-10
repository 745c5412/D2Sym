// automatic generation D2Sym.Sync 2015

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Sym.Classes
{
    public class MonsterMiniBoss : ID2OClass
    {
        [Cache]
        public static List<MonsterMiniBoss> MonsterMiniBosss = new List<MonsterMiniBoss>();
        public Int32 id;
        public Int32 monsterReplacingId;
        public MonsterMiniBoss(Int32 id, Int32 monsterReplacingId)
        {
            this.id = id;
            this.monsterReplacingId = monsterReplacingId;
        }
    }
}
