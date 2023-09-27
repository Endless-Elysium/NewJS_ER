using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewERScaling
{
    // Weapon reinforce stuff
    struct ReinforceParamWeapon
    {
        public double Upgrade_PhysicalAttack;
        public double Upgrade_MagicAttack;
        public double Upgrade_FireAttack;
        public double Upgrade_LightningAttack;
        public double Upgrade_HolyAttack;

        public double Upgrade_StrScaling;
        public double Upgrade_DexScaling;
        public double Upgrade_IntScaling;
        public double Upgrade_FaiScaling;
        public double Upgrade_ArcScaling;

        public ReinforceParamWeapon(Infusions inf)
        {
            // Get the infusion stats
            if (inf == Infusions.None)
            {
                Upgrade_PhysicalAttack = 2.45;
                Upgrade_MagicAttack = 2.45;
                Upgrade_FireAttack = 2.45;
                Upgrade_LightningAttack = 2.45;
                Upgrade_HolyAttack = 2.45;

                Upgrade_StrScaling = 1.5;
                Upgrade_DexScaling = 1.5;
                Upgrade_IntScaling = 1.8;
                Upgrade_FaiScaling = 1.8;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.Heavy)
            {
                Upgrade_PhysicalAttack = 2.35;
                Upgrade_MagicAttack = 2.35;
                Upgrade_FireAttack = 2.35;
                Upgrade_LightningAttack = 2.35;
                Upgrade_HolyAttack = 2.35;

                Upgrade_StrScaling = 2.8;
                Upgrade_DexScaling = 0.0;
                Upgrade_IntScaling = 1.8;
                Upgrade_FaiScaling = 1.8;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.Keen)
            {
                Upgrade_PhysicalAttack = 2.35;
                Upgrade_MagicAttack = 2.35;
                Upgrade_FireAttack = 2.35;
                Upgrade_LightningAttack = 2.35;
                Upgrade_HolyAttack = 2.35;

                Upgrade_StrScaling = 1.3;
                Upgrade_DexScaling = 2.8;
                Upgrade_IntScaling = 1.8;
                Upgrade_FaiScaling = 1.8;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.Quality)
            {
                Upgrade_PhysicalAttack = 2.05;
                Upgrade_MagicAttack = 2.05;
                Upgrade_FireAttack = 2.05;
                Upgrade_LightningAttack = 2.05;
                Upgrade_HolyAttack = 2.05;

                Upgrade_StrScaling = 1.9;
                Upgrade_DexScaling = 1.9;
                Upgrade_IntScaling = 1.8;
                Upgrade_FaiScaling = 1.8;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.Fire)
            {
                Upgrade_PhysicalAttack = 1.7;
                Upgrade_MagicAttack = 1.7;
                Upgrade_FireAttack = 1.7;
                Upgrade_LightningAttack = 1.7;
                Upgrade_HolyAttack = 1.7;

                Upgrade_StrScaling = 2.1;
                Upgrade_DexScaling = 1.2;
                Upgrade_IntScaling = 1.8;
                Upgrade_FaiScaling = 1.8;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.FlameArt)
            {
                Upgrade_PhysicalAttack = 2.0;
                Upgrade_MagicAttack = 2.0;
                Upgrade_FireAttack = 2.0;
                Upgrade_LightningAttack = 2.0;
                Upgrade_HolyAttack = 2.0;

                Upgrade_StrScaling = 1.8;
                Upgrade_DexScaling = 1.8;
                Upgrade_IntScaling = 1.8;
                Upgrade_FaiScaling = 2.3;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.Lightning)
            {
                Upgrade_PhysicalAttack = 1.74;
                Upgrade_MagicAttack = 1.74;
                Upgrade_FireAttack = 1.74;
                Upgrade_LightningAttack = 1.74;
                Upgrade_HolyAttack = 1.74;

                Upgrade_StrScaling = 1.2;
                Upgrade_DexScaling = 2.1;
                Upgrade_IntScaling = 1.8;
                Upgrade_FaiScaling = 1.8;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.Sacred)
            {
                Upgrade_PhysicalAttack = 2.0;
                Upgrade_MagicAttack = 2.0;
                Upgrade_FireAttack = 2.0;
                Upgrade_LightningAttack = 2.0;
                Upgrade_HolyAttack = 2.0;

                Upgrade_StrScaling = 1.8;
                Upgrade_DexScaling = 1.8;
                Upgrade_IntScaling = 1.8;
                Upgrade_FaiScaling = 2.3;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.Magic)
            {
                Upgrade_PhysicalAttack = 2.0;
                Upgrade_MagicAttack = 2.0;
                Upgrade_FireAttack = 2.0;
                Upgrade_LightningAttack = 2.0;
                Upgrade_HolyAttack = 2.0;

                Upgrade_StrScaling = 1.3;
                Upgrade_DexScaling = 1.3;
                Upgrade_IntScaling = 2.35;
                Upgrade_FaiScaling = 1.8;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.Cold)
            {
                Upgrade_PhysicalAttack = 1.8;
                Upgrade_MagicAttack = 1.8;
                Upgrade_FireAttack = 1.8;
                Upgrade_LightningAttack = 1.8;
                Upgrade_HolyAttack = 1.8;

                Upgrade_StrScaling = 1.9;
                Upgrade_DexScaling = 1.9;
                Upgrade_IntScaling = 2.0;
                Upgrade_FaiScaling = 1.9;
                Upgrade_ArcScaling = 1.9;
                return;
            }
            if (inf == Infusions.Poison || inf == Infusions.Bleed)
            {
                Upgrade_PhysicalAttack = 2.15;
                Upgrade_MagicAttack = 2.15;
                Upgrade_FireAttack = 2.15;
                Upgrade_LightningAttack = 2.15;
                Upgrade_HolyAttack = 2.15;

                Upgrade_StrScaling = 1.9;
                Upgrade_DexScaling = 1.9;
                Upgrade_IntScaling = 2.0;
                Upgrade_FaiScaling = 1.9;
                Upgrade_ArcScaling = 1.45;
                return;
            }
            if (inf == Infusions.Occult)
            {
                Upgrade_PhysicalAttack = 2.25;
                Upgrade_MagicAttack = 2.25;
                Upgrade_FireAttack = 2.25;
                Upgrade_LightningAttack = 2.25;
                Upgrade_HolyAttack = 2.25;

                Upgrade_StrScaling = 1.5;
                Upgrade_DexScaling = 1.5;
                Upgrade_IntScaling = 1.5;
                Upgrade_FaiScaling = 1.5;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.SpHeavy)
            {
                Upgrade_PhysicalAttack = 2.2;
                Upgrade_MagicAttack = 2.2;
                Upgrade_FireAttack = 2.2;
                Upgrade_LightningAttack = 2.2;
                Upgrade_HolyAttack = 2.2;

                Upgrade_StrScaling = 2.6;
                Upgrade_DexScaling = 1.2;
                Upgrade_IntScaling = 1.8;
                Upgrade_FaiScaling = 1.8;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.SpKeen)
            {
                Upgrade_PhysicalAttack = 2.2;
                Upgrade_MagicAttack = 2.2;
                Upgrade_FireAttack = 2.2;
                Upgrade_LightningAttack = 2.2;
                Upgrade_HolyAttack = 2.2;

                Upgrade_StrScaling = 1.3;
                Upgrade_DexScaling = 2.5;
                Upgrade_IntScaling = 1.8;
                Upgrade_FaiScaling = 1.8;
                Upgrade_ArcScaling = 1.8;
                return;
            }
            if (inf == Infusions.Sp)
            {
                Upgrade_PhysicalAttack = 2.45;
                Upgrade_MagicAttack = 2.45;
                Upgrade_FireAttack = 2.45;
                Upgrade_LightningAttack = 2.45;
                Upgrade_HolyAttack = 2.45;

                Upgrade_StrScaling = 1.8;
                Upgrade_DexScaling = 1.8;
                Upgrade_IntScaling = 1.8;
                Upgrade_FaiScaling = 1.8;
                Upgrade_ArcScaling = 1.8;
                return;
            }

        }
    }
    enum Infusions
    {
        None,
        Sp,
        Heavy,
        SpHeavy,
        Keen,
        SpKeen,
        Quality,
        Fire,
        FlameArt,
        Lightning,
        Sacred,
        Magic,
        Cold,
        Poison,
        Bleed,
        Occult
    }
}
