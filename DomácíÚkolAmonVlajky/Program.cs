using System;

namespace DomaciUkolAmonVlajky
{
    enum Vlajky { CZ = 1, DE, US, FR, JP, IT, ES }

    interface IVlajka
    {
        string Nazev { get; }
        void Vykresli();
    }

    static class VlajkaFactory
    {
        public static IVlajka VytvorVlajku(Vlajky typ)
        {
            switch (typ)
            {
                case Vlajky.CZ: return new CeskaVlajka();
                case Vlajky.DE: return new NemeckaVlajka();
                case Vlajky.US: return new AmerickaVlajka();
                case Vlajky.FR: return new FrancouzskaVlajka();
                case Vlajky.JP: return new JaponskaVlajka();
                case Vlajky.IT: return new ItalskaVlajka();
                case Vlajky.ES: return new SpanelskaVlajka();
                default: return null;
            }
        }
    }

    abstract class Vlajka : IVlajka
    {
        protected const int vyska = 20;
        protected const int sirka = 60;
        public abstract string Nazev { get; }
        public abstract void Vykresli();
    }

    class CeskaVlajka : Vlajka
    {
        public override string Nazev => "Česká republika";
        public override void Vykresli()
        {
            for (int i = 0; i < vyska; i++)
            {
                int delkaModre = (i <= vyska / 2) ? (2 * i * sirka) / vyska : (2 * (vyska - i) * sirka) / vyska;
                int delkaBile = sirka - delkaModre;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(new string('█', delkaModre));
                Console.ForegroundColor = (i <= vyska / 2) ? ConsoleColor.White : ConsoleColor.Red;
                Console.WriteLine(new string('█', delkaBile));
            }
            Console.ResetColor();
        }
    }

    class NemeckaVlajka : Vlajka
    {
        public override string Nazev => "Německo";
        public override void Vykresli()
        {
            int pruh = vyska / 3;
            for (int i = 0; i < vyska; i++)
            {
                Console.ForegroundColor = (i < pruh) ? ConsoleColor.Black : (i < 2 * pruh) ? ConsoleColor.Red : ConsoleColor.Yellow;
                Console.WriteLine(new string('█', sirka));
            }
            Console.ResetColor();
        }
    }

    class AmerickaVlajka : Vlajka
    {
        public override string Nazev => "USA";
        public override void Vykresli()
        {
            int pruhy = 13;
            int vyskaPruhu = vyska / pruhy;
            int sirkaPole = sirka * 2 / 5;
            int vyskaPole = vyskaPruhu * 7;

            for (int i = 0; i < pruhy; i++)
            {
                for (int j = 0; j < vyskaPruhu; j++)
                {
                    int aktualniY = i * vyskaPruhu + j;
                    if (aktualniY < vyskaPole)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(new string('█', sirkaPole));
                        Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Red : ConsoleColor.White;
                        Console.WriteLine(new string('█', sirka - sirkaPole));
                    }
                    else
                    {
                        Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Red : ConsoleColor.White;
                        Console.WriteLine(new string('█', sirka));
                    }
                }
            }
            Console.ResetColor();
        }
    }

    class FrancouzskaVlajka : Vlajka
    {
        public override string Nazev => "Francie";
        public override void Vykresli()
        {
            int sirkaPruhu = sirka / 3;
            for (int i = 0; i < vyska; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(new string('█', sirkaPruhu));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(new string('█', sirkaPruhu));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new string('█', sirka - 2 * sirkaPruhu));
            }
            Console.ResetColor();
        }
    }

    class JaponskaVlajka : Vlajka
    {
        public override string Nazev => "Japonsko";
        public override void Vykresli()
        {
            int stredX = sirka / 2;
            int stredY = vyska / 2;
            int polomer = Math.Min(vyska, sirka) / 4;

            for (int y = 0; y < vyska; y++)
            {
                for (int x = 0; x < sirka; x++)
                {
                    int dx = x - stredX;
                    int dy = y - stredY;
                    bool jeVKruhu = dx * dx + dy * dy <= polomer * polomer;

                    Console.ForegroundColor = jeVKruhu ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write('█');
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }

    class ItalskaVlajka : Vlajka
    {
        public override string Nazev => "Itálie";
        public override void Vykresli()
        {
            int sirkaPruhu = sirka / 3;
            for (int i = 0; i < vyska; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(new string('█', sirkaPruhu));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(new string('█', sirkaPruhu));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new string('█', sirka - 2 * sirkaPruhu));
            }
            Console.ResetColor();
        }
    }

    class SpanelskaVlajka : Vlajka
    {
        public override string Nazev => "Španělsko";
        public override void Vykresli()
        {
            int pruh = vyska / 3;
            for (int i = 0; i < vyska; i++)
            {
                Console.ForegroundColor = (i < pruh || i >= 2 * pruh) ? ConsoleColor.Red : ConsoleColor.Yellow;
                Console.WriteLine(new string('█', sirka));
            }
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════╗");
                Console.WriteLine("║      >>> VLAJKY <<<      ║");
                Console.WriteLine("╠══════════════════════╣");
                foreach (Vlajky vlajka in Enum.GetValues(typeof(Vlajky)))
                {
                    Console.WriteLine($"║ {(int)vlajka} - {vlajka}            ║");
                }
                Console.WriteLine("║ 0 - Konec               ║");
                Console.WriteLine("╚══════════════════════╝");

                Console.Write("Vyberte číslo vlajky: ");
                if (!int.TryParse(Console.ReadLine(), out int volba) || !Enum.IsDefined(typeof(Vlajky), volba) && volba != 0)
                {
                    Console.WriteLine("Neplatná volba. Zkuste to znovu.");
                    Console.ReadKey();
                    continue;
                }

                if (volba == 0) break;

                IVlajka vlajkaInstance = VlajkaFactory.VytvorVlajku((Vlajky)volba);
                if (vlajkaInstance == null)
                {
                    Console.WriteLine("Nepodařilo se vytvořit vlajku.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"--- {vlajkaInstance.Nazev} ---\n");
                    vlajkaInstance.Vykresli();
                }

                Console.WriteLine("\nStiskněte libovolnou klávesu pro návrat do menu...");
                Console.ReadKey();
            }

            Console.WriteLine("Program ukončen.");
        }
    }
}
