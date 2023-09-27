global using static NewERScaling.UI;
using NewERScaling;
using Newtonsoft.Json;

namespace NewJS_ER
{
    internal class Program
    {
        static void Main()
        {
            Weapon W = new Weapon("Fire Greatsword",new EquipParamWeapon(159, 0, 159, 0, 0, 32, 15, 0, 0, 0), new ReinforceParamWeapon(Infusions.Fire), new AttackElementCorrectID(10005));
            Console.WriteLine(W);
            Player p = new Player(60, 20, 80, 99, 10);
            WriteLine($"AR: {W.AR}", ConsoleColor.Green);
            WriteLine($"{W}", ConsoleColor.Green);

            WriteLine($"True AR: {W.GetAR(p)}", ConsoleColor.DarkYellow);
            List<B_weapon> weapons;
            using (StreamReader sr = new StreamReader(@"Weapons.json"))
            {
                string Json = sr.ReadToEnd();
                weapons = JsonConvert.DeserializeObject<List<B_weapon>>(Json);
            }
            List<Weapon> TWeapons = new List<Weapon>();
            int i = TWeapons.Count - 1;
            foreach(B_weapon bw in weapons)
            {
                TWeapons.Add(new Weapon(bw));
            }
            foreach(Weapon weapon in TWeapons)
            {
                Console.WriteLine(weapon);
                WriteLine($"True AR: {weapon.GetAR(p)}, {weapon.GetPhys(p)}",ConsoleColor.Green);
                Console.WriteLine();
            }

        }
    }
}