using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewERScaling
{
    internal class AttackElementCorrect
    {
        public bool PhysStr, PhysDex, PhysInt, PhysFaith, PhysArc;
        public bool MagStr, MagDex, MagInt, MagFaith, MagArc;
        public bool FireStr, FireDex, FireInt, FireFaith, FireArc;
        public bool LightStr, LightDex, LightInt, LightFaith, LightArc;
        public bool HolyStr, HolyDex, HolyInt, HolyFaith, HolyArc;
        public AttackElementCorrect(AttackElementCorrectID Id)
        {
            PhysStr = PhysDex = PhysInt = PhysFaith = PhysArc = false;
            MagStr = MagDex = MagInt = MagFaith = MagArc = false;
            FireStr = FireDex = FireInt = FireFaith = FireArc = false;
            LightStr = LightDex = LightInt = LightInt = LightArc = false;
            HolyStr = HolyDex = HolyInt = HolyFaith = HolyArc = false;


            switch(Id.Id)
            {
                case 10000:
                    PhysStr = PhysDex = true;
                    MagInt = true;
                    FireFaith = true;
                    LightDex = true;
                    HolyFaith = true;
                    break;
                case 10005:
                    PhysStr = PhysDex = true;
                    MagInt = true;
                    FireStr = true;
                    LightDex = true;
                    HolyFaith = true;
                    break;
            };
        }
    }

    record struct AttackElementCorrectID
    {
        public int Id { get; set; }
        public AttackElementCorrectID(int i)
        {
            Id = i;
        }
    }
}
