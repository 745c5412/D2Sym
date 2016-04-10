// automatic generation D2Sym.Sync 2015
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace D2Sym.Classes
{
         public class EmblemBackground
   {
[Cache]
public static List<EmblemBackground> EmblemBackgrounds = new List<EmblemBackground>();
public Int32 id;
public Int32 order;
public EmblemBackground(Int32 id,Int32 order)
{
this.id= id;
this.order= order;
}
}
}
