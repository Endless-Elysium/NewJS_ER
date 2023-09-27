using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewERScaling
{
    class CalcStats
    {
        public int ThresholdP0 = 1;
        public int ThresholdP1;
        public int ThresholdP2;
        public int ThresholdP3;
        public int ThresholdP4;

        public int Coefficient0 = 0;
        public int Coefficient1;
        public int Coefficient2;
        public int Coefficient3;
        public int Coefficient4;

        public double AdjustmentF0;
        public double AdjustmentF1;
        public double AdjustmentF2;
        public double AdjustmentF3;
        public double AdjustmentF4;

        public CalcStats(int Id)
        {
            SetMajorValues(Id);
        }

        public override string ToString()
        {
            return $"{ThresholdP0}, {ThresholdP1}, {ThresholdP2}, {ThresholdP3}, {ThresholdP4}";
        }
        public void SetMajorValues(int IdPart)
        {
            switch (IdPart)
            {
                case 0: // "None"
                    ThresholdP1 = 18;
                    ThresholdP2 = 60;
                    ThresholdP3 = 80;
                    ThresholdP4 = 150;

                    Coefficient1 = 25;
                    Coefficient2 = 75;
                    Coefficient3 = 90;
                    Coefficient4 = 110;

                    AdjustmentF0 = 1.2;
                    AdjustmentF1 = -1.2;
                    AdjustmentF2 = AdjustmentF3 = AdjustmentF4 = 1.0;
                    break;
                case 1:
                case 2: // heavy, Keen
                    ThresholdP1 = 20;
                    ThresholdP2 = 60;
                    ThresholdP3 = 80;
                    ThresholdP4 = 150;

                    Coefficient1 = 35;
                    Coefficient2 = 75;
                    Coefficient3 = 90;
                    Coefficient4 = 110;

                    AdjustmentF0 = 1.2;
                    AdjustmentF1 = -1.2;
                    AdjustmentF2 = AdjustmentF3 = AdjustmentF4 = 1.0;
                    break;
                case 4: // Magic, Fire, Lightning, Holy
                    ThresholdP1 = 20;
                    ThresholdP2 = 50;
                    ThresholdP3 = 80;
                    ThresholdP4 = 99;

                    Coefficient1 = 40;
                    Coefficient2 = 80;
                    Coefficient3 = 95;
                    Coefficient4 = 110;

                    AdjustmentF0 = AdjustmentF1 = AdjustmentF2 = AdjustmentF3 = AdjustmentF4 = 1.0;


                    break;
            }
        }
    }
    struct CalcCorrectId
    {
        [JsonProperty(propertyName: "Physical_ccg")] public int Physical { get; init; } = 0;
        [JsonProperty(propertyName: "Magic_ccg")] public int Magic { get; init; } = 0;
        [JsonProperty(propertyName: "Fire_ccg")] public int Fire { get; init; } = 0;
        [JsonProperty(propertyName: "Lightning_ccg")] public int Lightning { get; init; } = 0;
        [JsonProperty(propertyName: "Holy_ccg")] public int Holy { get; init; } = 0;

        public CalcCorrectId(int a, int b, int c, int d, int e)
        {
            Physical = a; 
            Magic = b; 
            Fire = c; 
            Lightning = d; 
            Holy = e;
        }

    }
    internal class CalcCorrect
    {

        public CalcStats CalcPhysical;
        public CalcStats CalcMagic;
        public CalcStats CalcFire;
        public CalcStats CalcLightning;
        public CalcStats CalcHoly;

        CalcCorrectId Id { get; init; }
        public CalcCorrect(CalcCorrectId CCId)
        {
            Id = CCId;
            CalcPhysical = new CalcStats(CCId.Physical);
            CalcMagic = new CalcStats(CCId.Magic);
            CalcFire = new CalcStats(CCId.Fire);
            CalcLightning = new CalcStats(CCId.Lightning);
            CalcHoly = new CalcStats(CCId.Holy);
        }

        public double CalculateCorrect(int Input, CalcStats cc)
        {
            WriteLine($"Input is {Input}", ConsoleColor.Red);
            WriteLine($"CCG is {cc}", ConsoleColor.Red);
                if (Input == 0) return 0;

                double EXP = 0;
                int LowerThreshold = 0;
                int UpperThreshold = 0;
                int LowerCoefficient = 0;
                int UpperCoefficient = 0;

                if (Input >= cc.ThresholdP0 && Input <= cc.ThresholdP1)
                {
                    LowerThreshold = cc.ThresholdP0;
                    UpperThreshold = cc.ThresholdP1;

                    LowerCoefficient = cc.Coefficient0;
                    UpperCoefficient = cc.Coefficient1;
                    EXP = cc.AdjustmentF0;
                } else if (Input >= cc.ThresholdP1 && Input <= cc.ThresholdP2)
                {
                    LowerThreshold = cc.ThresholdP1;
                    UpperThreshold = cc.ThresholdP2;

                    LowerCoefficient = cc.Coefficient1;
                    UpperCoefficient = cc.Coefficient2;
                    EXP = cc.AdjustmentF1;
                } else if (Input >= cc.ThresholdP2 && Input <= cc.ThresholdP3)
                {
                    LowerThreshold = cc.ThresholdP2;
                    UpperThreshold = cc.ThresholdP3;

                    LowerCoefficient = cc.Coefficient2;
                    UpperCoefficient = cc.Coefficient3;
                    EXP = cc.AdjustmentF2;
                } else if (Input >= cc.ThresholdP3 && Input <= cc.ThresholdP4)
                {
                    LowerThreshold = cc.ThresholdP3;
                    UpperThreshold = cc.ThresholdP4;

                    LowerCoefficient = cc.Coefficient3;
                    UpperCoefficient = cc.Coefficient4;
                    EXP = cc.AdjustmentF3;

                }

                WriteLine($"Lower: {LowerThreshold}, {LowerCoefficient}", ConsoleColor.DarkRed);
                WriteLine($"Upper: {UpperThreshold}, {UpperCoefficient}", ConsoleColor.DarkRed);
                double Ratio = ((double)Input - (double)LowerThreshold) / ((double)UpperThreshold - (double)LowerThreshold);
                WriteLine($"Ratio: {Ratio}", ConsoleColor.DarkCyan);
                double n = 0;

                if (EXP > 0) n = Math.Pow(Ratio, EXP);
                if (EXP < 0) n = 1 - Math.Pow((1 - Ratio), Math.Abs(EXP));
                WriteLine($"N: {n}", ConsoleColor.Magenta);

                double Out = LowerCoefficient + ((UpperCoefficient - LowerCoefficient) * n);
                WriteLine($"Out: {Out} \n", ConsoleColor.Magenta);

                return Out / 100;
        }
    }
}
