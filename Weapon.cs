using NewJS_ER;
using Newtonsoft.Json;

namespace NewERScaling
{
    // EquipParamWeapon -> Base Stats of a weapon
    // ReinforceParamWeapon -> Reinforce mods of a weapon
    // CalcCorrectGraph -> how damage scaling of a weapon works
    // CalcCorrectGraph IDs -> tells you which element uses what CCG
    // AttackElementCorrectParam -> tells which stat boosts which element



    // Base Stats of a weapon
    record struct EquipParamWeapon
    {
        [JsonProperty(propertyName: "Physical Attack")] public int PhysicalAttack { get; init; } = 0;
        [JsonProperty(propertyName: "Magic Attack")] public int MagicAttack { get; init; } = 0;
        [JsonProperty(propertyName: "Fire Attack")] public int FireAttack { get; init; } = 0;
        [JsonProperty(propertyName: "Lightning Attack")] public int LightningAttack { get; init; } = 0;
        [JsonProperty(propertyName: "Holy Attack")] public int HolyAttack { get; init; } = 0;

        [JsonProperty(propertyName: "Str Scaling")] public int StrScaling { get; init; } = 0;
        [JsonProperty(propertyName: "Dex Scaling")] public int DexScaling { get; init; } = 0;
        [JsonProperty(propertyName: "Int Scaling")] public int IntScaling { get; init; } = 0;
        [JsonProperty(propertyName: "Faith Scaling")] public int FaiScaling { get; init; } = 0;
        [JsonProperty(propertyName: "Arc Scaling")] public int ArcScaling { get; init; } = 0;
        public EquipParamWeapon(int p, int m, int f, int l, int h, int s, int d, int i, int fa, int a)
        {
            PhysicalAttack = p;
            MagicAttack = m;
            FireAttack = f;
            LightningAttack = l;
            HolyAttack = h;

            StrScaling = s; 
            DexScaling = d; 
            IntScaling = i; 
            FaiScaling = fa; 
            ArcScaling = a;
        }
    }

    // Large weapon struct
    internal record struct Weapon
    {
        public int AR = 0;

        public string Name { get; private set; }




        EquipParamWeapon ParamWeapon;
        ReinforceParamWeapon ReinforceParam;
        readonly CalcCorrect CCG;
        readonly AttackElementCorrect AEC;

        readonly double Physical_Attack;
        readonly double Magic_Attack;
        readonly double Fire_Attack;
        readonly double Lightning_Attack;
        readonly double Holy_Attack;

        public readonly override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"AR: {AR}\n" +
                   $"PHY: {Physical_Attack}\n" +
                   $"MAGIC: {Magic_Attack}\n" +
                   $"Fire: {Fire_Attack}\n" +
                   $"Lightning: {Lightning_Attack}\n" +
                   $"Holy: {Holy_Attack}";
        }

        public Weapon(string a, EquipParamWeapon epw, ReinforceParamWeapon rpw, AttackElementCorrectID aecid)
        {
            Name = a;
            ParamWeapon = epw;
            ReinforceParam = rpw;
            CCG = new CalcCorrect(new CalcCorrectId(0,0,4,0,0));
            AEC = new AttackElementCorrect(aecid);

            Physical_Attack = ParamWeapon.PhysicalAttack * ReinforceParam.Upgrade_PhysicalAttack;
            Magic_Attack = ParamWeapon.MagicAttack * ReinforceParam.Upgrade_MagicAttack;
            Fire_Attack = ParamWeapon.FireAttack * ReinforceParam.Upgrade_FireAttack;
            Lightning_Attack = ParamWeapon.LightningAttack * ReinforceParam.Upgrade_LightningAttack;
            Holy_Attack = ParamWeapon.HolyAttack * ReinforceParam.Upgrade_HolyAttack;

            AR = (int)( Physical_Attack + Magic_Attack + Fire_Attack + Lightning_Attack);
        }
        public Weapon (B_weapon BaseWeapon)
        {
            Name = BaseWeapon.Name;
            ParamWeapon = BaseWeapon.EPW;
            ReinforceParam = new ReinforceParamWeapon(BaseWeapon.MyInfusion);
            CCG = new CalcCorrect(BaseWeapon.CCGID);
            AEC = new AttackElementCorrect(BaseWeapon.AECID);

            Physical_Attack = ParamWeapon.PhysicalAttack * ReinforceParam.Upgrade_PhysicalAttack;
            Magic_Attack = ParamWeapon.MagicAttack * ReinforceParam.Upgrade_MagicAttack;
            Fire_Attack = ParamWeapon.FireAttack * ReinforceParam.Upgrade_FireAttack;
            Lightning_Attack = ParamWeapon.LightningAttack * ReinforceParam.Upgrade_LightningAttack;
            Holy_Attack = ParamWeapon.HolyAttack * ReinforceParam.Upgrade_HolyAttack;

            AR = (int)(Physical_Attack + Magic_Attack + Fire_Attack + Lightning_Attack);
        }

        public int GetAR(Player p)
        {
            int Phy = (int) Math.Floor(GetPhys(p));
            int Mag = (int) Math.Floor(GetMag(p));
            int Fire = (int) Math.Floor(GetFire(p));
            int Light = (int)Math.Floor(GetThunder(p));
            int Holy = (int)Math.Floor(GetHoly(p));

            AR += Phy + Mag + Fire + Light + Holy;
            Console.WriteLine($"PHYS: {Phy}");
            Console.WriteLine($"MAG: {Mag}");
            Console.WriteLine($"FIRE: {Fire}");
            Console.WriteLine($"LIGHT: {Light}");
            Console.WriteLine($"HOLY: {Holy}");


            return AR;
        }


        public readonly double GetPhys(Player p)
        {


            double FinalPhys = 0;
            if (AEC.PhysStr)
            {
                double Weapon_PhyStrScaling = (ParamWeapon.StrScaling * ReinforceParam.Upgrade_StrScaling) / 100;
                Weapon_PhyStrScaling = Weapon_PhyStrScaling * CCG.CalculateCorrect(p.Str, CCG.CalcPhysical) * Physical_Attack;
                FinalPhys += Weapon_PhyStrScaling;
            }
            if (AEC.PhysDex)
            {
                double Weapon_PhyDexScaling = (ParamWeapon.DexScaling * ReinforceParam.Upgrade_DexScaling) / 100;
                Weapon_PhyDexScaling = Weapon_PhyDexScaling * CCG.CalculateCorrect(p.Dex, CCG.CalcPhysical) * Physical_Attack;
                FinalPhys += Weapon_PhyDexScaling;
            }
            if (AEC.PhysInt)
            {
                double Weapon_PhyIntScaling = (ParamWeapon.IntScaling * ReinforceParam.Upgrade_IntScaling) / 100;
                Weapon_PhyIntScaling = Weapon_PhyIntScaling * CCG.CalculateCorrect(p.Int, CCG.CalcPhysical) * Physical_Attack;
                FinalPhys += Weapon_PhyIntScaling;
            }
            if (AEC.PhysFaith)
            {
                double Weapon_PhyFaiScaling = (ParamWeapon.FaiScaling * ReinforceParam.Upgrade_FaiScaling) / 100;
                Weapon_PhyFaiScaling = Weapon_PhyFaiScaling * CCG.CalculateCorrect(p.Faith, CCG.CalcPhysical) * Physical_Attack;
                FinalPhys += Weapon_PhyFaiScaling;
            }
            if (AEC.PhysArc)
            {
                double Weapon_PhyArcScaling = (ParamWeapon.ArcScaling * ReinforceParam.Upgrade_ArcScaling) / 100;
                Weapon_PhyArcScaling = Weapon_PhyArcScaling * CCG.CalculateCorrect(p.Arcane, CCG.CalcPhysical) * Physical_Attack;
                FinalPhys += Weapon_PhyArcScaling;
            }
            return FinalPhys;

        }
        public readonly double GetMag(Player p)
        {


            double FinalMag = 0;
            if (AEC.MagStr)
            {
                double Weapon_MagStrScaling = (ParamWeapon.StrScaling * ReinforceParam.Upgrade_StrScaling) / 100;
                Weapon_MagStrScaling = Weapon_MagStrScaling * CCG.CalculateCorrect(p.Str, CCG.CalcMagic) * Magic_Attack;
                FinalMag += Weapon_MagStrScaling;
            }
            if (AEC.MagDex)
            {
                double Weapon_MagDexScaling = (ParamWeapon.DexScaling * ReinforceParam.Upgrade_DexScaling) / 100;
                Weapon_MagDexScaling = Weapon_MagDexScaling * CCG.CalculateCorrect(p.Dex, CCG.CalcMagic) * Magic_Attack;
                FinalMag += Weapon_MagDexScaling;
            }
            if (AEC.MagInt)
            {
                double Weapon_MagIntScaling = (ParamWeapon.IntScaling * ReinforceParam.Upgrade_IntScaling) / 100;
                Weapon_MagIntScaling = Weapon_MagIntScaling * CCG.CalculateCorrect(p.Int, CCG.CalcMagic) * Magic_Attack;
                FinalMag += Weapon_MagIntScaling;
            }
            if (AEC.MagFaith)
            {
                double Weapon_MagFaiScaling = (ParamWeapon.FaiScaling * ReinforceParam.Upgrade_FaiScaling) / 100;
                Weapon_MagFaiScaling = Weapon_MagFaiScaling * CCG.CalculateCorrect(p.Faith, CCG.CalcMagic) * Magic_Attack;
                FinalMag += Weapon_MagFaiScaling;
            }
            if (AEC.MagArc)
            {
                double Weapon_MagArcScaling = (ParamWeapon.ArcScaling * ReinforceParam.Upgrade_ArcScaling) / 100;
                Weapon_MagArcScaling = Weapon_MagArcScaling * CCG.CalculateCorrect(p.Arcane, CCG.CalcMagic) * Magic_Attack;
                FinalMag += Weapon_MagArcScaling;
            }
            return FinalMag;

        }
        public readonly double GetFire(Player p)
        {


            double FinalFire = 0;
            if (AEC.FireStr)
            {
                double Weapon_FireStrScaling = (ParamWeapon.StrScaling * ReinforceParam.Upgrade_StrScaling) / 100;
                Weapon_FireStrScaling = Weapon_FireStrScaling * CCG.CalculateCorrect(p.Str, CCG.CalcFire) * Fire_Attack;
                FinalFire += Weapon_FireStrScaling;
            }
            if (AEC.FireDex)
            {
                double Weapon_FireDexScaling = (ParamWeapon.DexScaling * ReinforceParam.Upgrade_DexScaling) / 100;
                Weapon_FireDexScaling = Weapon_FireDexScaling * CCG.CalculateCorrect(p.Dex, CCG.CalcFire) * Fire_Attack;
                FinalFire += Weapon_FireDexScaling;
            }
            if (AEC.FireInt)
            {
                double Weapon_FireIntScaling = (ParamWeapon.IntScaling * ReinforceParam.Upgrade_IntScaling) / 100;
                Weapon_FireIntScaling = Weapon_FireIntScaling * CCG.CalculateCorrect(p.Int, CCG.CalcFire) * Fire_Attack;
                FinalFire += Weapon_FireIntScaling;
            }
            if (AEC.FireFaith)
            {
                double Weapon_FireFaiScaling = (ParamWeapon.FaiScaling * ReinforceParam.Upgrade_FaiScaling) / 100;
                Weapon_FireFaiScaling = Weapon_FireFaiScaling * CCG.CalculateCorrect(p.Faith, CCG.CalcFire) * Fire_Attack;
                FinalFire += Weapon_FireFaiScaling;
            }
            if (AEC.FireArc)
            {
                double Weapon_FireArcScaling = (ParamWeapon.ArcScaling * ReinforceParam.Upgrade_ArcScaling) / 100;
                Weapon_FireArcScaling = Weapon_FireArcScaling * CCG.CalculateCorrect(p.Arcane, CCG.CalcFire) * Fire_Attack;
                FinalFire += Weapon_FireArcScaling;
            }
            return FinalFire;

        }
        public readonly double GetThunder(Player p)
        {


            double FinalLight = 0;
            if (AEC.LightStr)
            {
                double Weapon_LightStrScaling = (ParamWeapon.StrScaling * ReinforceParam.Upgrade_StrScaling) / 100;
                Weapon_LightStrScaling = Weapon_LightStrScaling * CCG.CalculateCorrect(p.Str, CCG.CalcLightning) * Lightning_Attack;
                FinalLight += Weapon_LightStrScaling;
            }
            if (AEC.LightDex)
            {
                double Weapon_LightDexScaling = (ParamWeapon.DexScaling * ReinforceParam.Upgrade_DexScaling) / 100;
                Weapon_LightDexScaling = Weapon_LightDexScaling * CCG.CalculateCorrect(p.Dex, CCG.CalcLightning) * Lightning_Attack;
                FinalLight += Weapon_LightDexScaling;
            }
            if (AEC.LightInt)
            {
                double Weapon_LightIntScaling = (ParamWeapon.IntScaling * ReinforceParam.Upgrade_IntScaling) / 100;
                Weapon_LightIntScaling = Weapon_LightIntScaling * CCG.CalculateCorrect(p.Int, CCG.CalcLightning) * Lightning_Attack;
                FinalLight += Weapon_LightIntScaling;
            }
            if (AEC.LightFaith)
            {
                double Weapon_LightFaiScaling = (ParamWeapon.FaiScaling * ReinforceParam.Upgrade_FaiScaling) / 100;
                Weapon_LightFaiScaling = Weapon_LightFaiScaling * CCG.CalculateCorrect(p.Faith, CCG.CalcLightning) * Lightning_Attack;
                FinalLight += Weapon_LightFaiScaling;
            }
            if (AEC.LightArc)
            {
                double Weapon_LightArcScaling = (ParamWeapon.ArcScaling * ReinforceParam.Upgrade_ArcScaling) / 100;
                Weapon_LightArcScaling = Weapon_LightArcScaling * CCG.CalculateCorrect(p.Arcane, CCG.CalcLightning) * Lightning_Attack;
                FinalLight += Weapon_LightArcScaling;
            }
            return FinalLight;

        }
        public readonly double GetHoly(Player p)
        {


            double FinalHoly = 0;
            if (AEC.HolyStr)
            {
                double Weapon_HolyStrScaling = (ParamWeapon.StrScaling * ReinforceParam.Upgrade_StrScaling) / 100;
                Weapon_HolyStrScaling = Weapon_HolyStrScaling * CCG.CalculateCorrect(p.Str, CCG.CalcHoly) * Holy_Attack;
                FinalHoly += Weapon_HolyStrScaling;
            }
            if (AEC.HolyDex)
            {
                double Weapon_HolyDexScaling = (ParamWeapon.DexScaling * ReinforceParam.Upgrade_DexScaling) / 100;
                Weapon_HolyDexScaling = Weapon_HolyDexScaling * CCG.CalculateCorrect(p.Dex, CCG.CalcHoly) * Holy_Attack;
                FinalHoly += Weapon_HolyDexScaling;
            }
            if (AEC.HolyInt)
            {
                double Weapon_HolyIntScaling = (ParamWeapon.IntScaling * ReinforceParam.Upgrade_IntScaling) / 100;
                Weapon_HolyIntScaling = Weapon_HolyIntScaling * CCG.CalculateCorrect(p.Int, CCG.CalcHoly) * Holy_Attack;
                FinalHoly += Weapon_HolyIntScaling;
            }
            if (AEC.HolyFaith)
            {
                double Weapon_HolyFaiScaling = (ParamWeapon.FaiScaling * ReinforceParam.Upgrade_FaiScaling) / 100;
                Weapon_HolyFaiScaling = Weapon_HolyFaiScaling * CCG.CalculateCorrect(p.Faith, CCG.CalcHoly) * Holy_Attack;
                FinalHoly += Weapon_HolyFaiScaling;
            }
            if (AEC.HolyArc)
            {
                double Weapon_HolyArcScaling = (ParamWeapon.ArcScaling * ReinforceParam.Upgrade_ArcScaling) / 100;
                Weapon_HolyArcScaling = Weapon_HolyArcScaling * CCG.CalculateCorrect(p.Arcane, CCG.CalcHoly) * Holy_Attack;
                FinalHoly += Weapon_HolyArcScaling;
            }
            return FinalHoly;

        }
    }



}
