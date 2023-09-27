using NewERScaling;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewJS_ER
{
    internal class B_weapon
    {
        [JsonProperty(propertyName: "Name")] public string Name { get; set; }
        [JsonProperty(propertyName: "Infusion")] public Infusions MyInfusion { get; set; }
        [JsonProperty(propertyName: "EPW")] public EquipParamWeapon EPW { get; set; }
        [JsonProperty(propertyName: "CCG")] public CalcCorrectId CCGID { get; set; }
        [JsonProperty(propertyName: "AEC")] public AttackElementCorrectID AECID { get; set; }

    }
}
