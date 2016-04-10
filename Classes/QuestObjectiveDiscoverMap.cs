// automatic generation D2Sym.Sync 2015

using D2Sym.InternalClasses;
using D2Sym.D2O;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Sym.Classes
{
    public class QuestObjectiveDiscoverMap : ID2OClass
    {
        [Cache]
        public static List<QuestObjectiveDiscoverMap> QuestObjectiveDiscoverMaps = new List<QuestObjectiveDiscoverMap>();
        public Int32 id;
        public Int32 mapId;
        public Point coords;
        public UInt32[] parameters;
        public Int32 stepId;
        public Int32 dialogId;
        public Int32 typeId;
        public QuestObjectiveDiscoverMap(Int32 id, Int32 mapId, Point coords, UInt32[] parameters, Int32 stepId, Int32 dialogId, Int32 typeId)
        {
            this.id = id;
            this.mapId = mapId;
            this.coords = coords;
            this.parameters = parameters;
            this.stepId = stepId;
            this.dialogId = dialogId;
            this.typeId = typeId;
        }
    }
}
