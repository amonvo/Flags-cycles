/*
 * Created by SharpDevelop.
 * User: Amon
 * Date: 08.10.2021
 * Time: 10:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DomácíÚkolAmonVlajky
{
	public
		class Program
	{	
		public static void Main()
		{
			
			const int vyska = 20;
			const int sirka = 60;
			Console.WriteLine(">>> VLAJKY <<<");
			Console.WriteLine("1 - CZ");
			Console.WriteLine("2 - DE");
			Console.WriteLine("3 - US");
			string Vstup = Console.ReadLine();
			if (Vstup == "1")
			{						
				for (int i = 0; i < vyska; i++) 
				{
	
					if(i <= vyska / 2)
					{
						Console.Write(new string('▓', 2 * i));
						Console.Write(new string('█', sirka - 2 * i));
					}
					else
					{
						Console.Write(new string('▓', 2 * (vyska - i)));
						Console.Write(new string('▒', sirka - 2 * (vyska - i)));
					}
	
					Console.WriteLine("");
				}	
			}
			else if (Vstup == "2")
			{
				for (int i = 0; i < vyska; i++) 
				{
					if (i <= vyska / 3)
					{
						Console.Write(new string('█', sirka));
					}
					else if (i <= 2 * vyska / 3)
					{
						Console.Write(new string('▒', sirka));
					}
					else
					{
						Console.Write(new string('▓', sirka));
					}
					Console.WriteLine("");
				}	
			}
			else if (Vstup == "3")
			{
					for (int i = 0; i < vyska; i++) {
	
					if (i <= vyska / 2)
					{
						Console.Write(new string('*', sirka / 2));
						Console.Write(new string( i % 2 == 0 ? '▒' : '▓', sirka / 2));
					}
					else
					{
						Console.Write(new string(i % 2 == 0 ? '▒' : '▓', sirka));
					}
					Console.WriteLine("");
				}
			}
			else 
			{
			 	Console.WriteLine("Zadal jste neznámý požadavek");			
			}
			Console.WriteLine();
			
			Console.WriteLine("Zmačkněte libovolnou klávesu pro ukončení");
			Console.ReadKey();
		}		
	}	
}