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
    public class Pet : ID2OClass
    {
        [Cache]
        public static List<Pet> Pets = new List<Pet>();
        public Int32 id;
        public Int32[] foodItems;
        public ArrayList foodTypes;
        public Int32 minDurationBeforeMeal;
        public Int32 maxDurationBeforeMeal;
        public EffectInstanceDice[] possibleEffects;
        public Pet(Int32 id, Int32[] foodItems, ArrayList foodTypes, Int32 minDurationBeforeMeal, Int32 maxDurationBeforeMeal, object[] possibleEffects)
        {
            this.id = id;
            this.foodItems = foodItems;
            this.foodTypes = foodTypes;
            this.minDurationBeforeMeal = minDurationBeforeMeal;
            this.maxDurationBeforeMeal = maxDurationBeforeMeal;
            this.possibleEffects = possibleEffects.Cast<EffectInstanceDice>().ToArray();
        }
    }
}
