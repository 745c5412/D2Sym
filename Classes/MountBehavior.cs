// automatic generation D2Sym.Sync 2015

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Sym.Classes
{
    public class MountBehavior : ID2OClass
    {
        [Cache]
        public static List<MountBehavior> MountBehaviors = new List<MountBehavior>();
        public Int32 id;
        public Int32 nameId;
        public Int32 descriptionId;
        public MountBehavior(Int32 id, Int32 nameId, Int32 descriptionId)
        {
            this.id = id;
            this.nameId = nameId;
            this.descriptionId = descriptionId;
        }
    }
}
