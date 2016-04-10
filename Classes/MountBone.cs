// automatic generation D2Sym.Sync 2015

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Sym.Classes
{
    public class MountBone : ID2OClass
    {
        [Cache]
        public static List<MountBone> MountBones = new List<MountBone>();
        public Int32 id;
        public MountBone(Int32 id)
        {
            this.id = id;
        }
    }
}
