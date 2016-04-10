// automatic generation D2Sym.Sync 2015

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Sym.Classes
{
    public class PointOfInterestCategory : ID2OClass
    {
        [Cache]
        public static List<PointOfInterestCategory> PointOfInterestCategorys = new List<PointOfInterestCategory>();
        public Int32 id;
        public Int32 actionLabelId;
        public PointOfInterestCategory(Int32 id, Int32 actionLabelId)
        {
            this.id = id;
            this.actionLabelId = actionLabelId;
        }
    }
}
