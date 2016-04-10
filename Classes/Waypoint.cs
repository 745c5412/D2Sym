// automatic generation D2Sym.Sync 2015

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Sym.Classes
{
    public class Waypoint : ID2OClass
    {
        [Cache]
        public static List<Waypoint> Waypoints = new List<Waypoint>();
        public Int32 id;
        public Int32 mapId;
        public Int32 subAreaId;
        public Waypoint(Int32 id, Int32 mapId, Int32 subAreaId)
        {
            this.id = id;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
        }
    }
}
