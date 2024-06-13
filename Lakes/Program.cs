using System;
using System.IO;

namespace Lakes
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Zadejte Okres:");
            string district = Console.ReadLine();

            string[] lakes = File.ReadAllLines("./lakes.txt");

            int smallestArea = 0;
            float lakeVolumeTotal = 0;

            Console.WriteLine("");
            Console.WriteLine("Rybníky:");
            Console.WriteLine("--------------");

            foreach (string lake in lakes)
            {
                string[] lakeData = lake.Split('/');
                if (lakeData[4] == district)
                {
                    Console.WriteLine(lakeData[1].Substring(1, lakeData[1].Length - 2));

                    lakeVolumeTotal = lakeVolumeTotal + SafelyConvertToFloat(lakeData[3].Replace(",", "."));

                    if (SafelyConvertToInt(lakeData[2]) <= smallestArea || smallestArea == 0) 
                    {
                        smallestArea = SafelyConvertToInt(lakeData[2]);
                    }
                }
            }

            Console.WriteLine("--------------");
            Console.WriteLine("Objem rybníků: " + lakeVolumeTotal + " m * m3");
            Console.WriteLine("Nejmenší rozloha: " + smallestArea + " ha");
        }

        static int SafelyConvertToInt(string x)
        {
            if (int.TryParse(x, out int result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        static float SafelyConvertToFloat(string x)
        {
            if (float.TryParse(x, out float result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}
