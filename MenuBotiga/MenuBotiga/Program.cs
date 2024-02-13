using System;

namespace MenuBotiga
{
    internal class Program
    {
        static string[] productesBotiga = { "Entrecot a la brasa", "Fideuà", "Sushi", "Rissoto de gamba", "Pollastre amb salses", "Macarrons amb Tomaquina", "Llanties amb Xorís", "Pastís de formatge" };
        static double[] preus = { 15.99, 12.50, 10.75, 9.25, 8.99, 7.75, 6.50, 5.99 };
        static int nElemBotiga = productesBotiga.Length;
        static string[] productesCistella = new string[10];
        static int[] quantitat = new int[10];
        static int nElemCistella = 0;
        static decimal diners;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Bones, quin és el teu nom?");
            string nom = Console.ReadLine();
            Console.WriteLine($"De quants diners disposes {nom}?");
            diners = Convert.ToDecimal(Console.ReadLine());
            Menu();
        }

        static void Menu()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" ╔═════════════════════════════════════════════════════════╗ ");
            Console.WriteLine(" ║                    Botiga  Ca la Maria                  ║ ");
            Console.WriteLine(" ║=========================================================║ ");
            Console.WriteLine(" ║                    1) Mostrar Botiga                    ║ ");
            Console.WriteLine(" ║                    2) Mostrar Cistella                  ║ ");
            Console.WriteLine(" ║                    3) Realitzar el Pagament             ║ ");
            Console.WriteLine(" ║                    4) Afegir Entrecot a la brasa        ║ ");
            Console.WriteLine(" ║                    5) Afegir Fideuà                     ║ ");
            Console.WriteLine(" ║                    6) Afegir Sushi                      ║ ");
            Console.WriteLine(" ║                    7) Afegir Rissoto de gamba           ║ ");
            Console.WriteLine(" ║                    8) Afegir Pollastre amb salses       ║ ");
            Console.WriteLine(" ║                    9) Afegir Macarrons amb Tomaquina    ║ ");
            Console.WriteLine(" ║                    10) Afegir Llanties amb Xorís        ║ ");
            Console.WriteLine(" ║                    11) Afegir Pastís de formatge        ║ ");
            Console.WriteLine(" ║                    12) Sortir                           ║ ");
            Console.WriteLine(" ║=========================================================║ ");
            Console.WriteLine(" ║   - Escull una opcio -                                  ║ ");
            Console.WriteLine(" ║=========================================================║ ");
            Console.WriteLine(" ║                                             Nil i Alex  ║ ");
            Console.WriteLine(" ║_________________________________________________________║ ");

            int opcio = Convert.ToInt32(Console.ReadLine());

            switch (opcio)
            {
                case 1:
                    MostrarBotiga();
                    break;
                case 2:
                    MostrarCistella();
                    break;
                case 3:
                    RealitzarPagament();
                    break;
                case 4:
                    AfegirProducte("Entrecot a la brasa", 15.99);
                    break;
                case 5:
                    AfegirProducte("Fideuà", 12.50);
                    break;
                case 6:
                    AfegirProducte("Sushi", 10.75);
                    break;
                case 7:
                    AfegirProducte("Rissoto de gamba", 9.25);
                    break;
                case 8:
                    AfegirProducte("Pollastre amb salses", 8.99);
                    break;
                case 9:
                    AfegirProducte("Macarrons amb Tomaquina", 7.75);
                    break;
                case 10:
                    AfegirProducte("Llanties amb Xorís", 6.50);
                    break;
                case 11:
                    AfegirProducte("Pastís de formatge", 5.99);
                    break;
                case 12:
                    Console.WriteLine("Gràcies per la teva visita!");
                    return;
                default:
                    Console.WriteLine("Opció no vàlida. Torna a seleccionar.");
                    break;
            }
            Console.WriteLine("Prem qualsevol tecla per continuar...");
            Console.ReadKey();
            Menu();
        }

        static void AfegirProducte(string producte, double preu)
        {
            if (nElemCistella < productesCistella.Length)
            {
                if (diners >= Convert.ToDecimal(preu))
                {
                    productesCistella[nElemCistella] = producte;
                    quantitat[nElemCistella] = 1;
                    nElemCistella++;
                    diners -= Convert.ToDecimal(preu);
                    Console.WriteLine($"S'ha afegit {producte} a la cistella.");
                }
                else
                {
                    Console.WriteLine("No tens suficients diners per comprar aquest producte.");
                }
            }
            else
            {
                Console.WriteLine("La cistella està plena. No es pot afegir més productes.");
            }
        }

        static void MostrarBotiga()
        {
            Console.WriteLine("\nLlista de Productes Disponibles:\n");
            for (int i = 0; i < nElemBotiga; i++)
            {
                Console.WriteLine($"{i + 1}. {productesBotiga[i]} - {preus[i]}€");
            }
        }

        static void MostrarCistella()
        {
            if (nElemCistella == 0)
            {
                Console.WriteLine("La cistella està buida.");
            }
            else
            {
                Console.WriteLine("\nEls teus productes a la cistella:\n");
                for (int i = 0; i < nElemCistella; i++)
                {
                    Console.WriteLine($"{i + 1}. {productesCistella[i]} - Quantitat: {quantitat[i]}");
                }
            }
        }

        static void RealitzarPagament()
        {
            decimal total = 0;
            for (int i = 0; i < nElemCistella; i++)
            {
                int index = Array.IndexOf(productesBotiga, productesCistella[i]);
                total += (decimal)preus[index] * quantitat[i];
            }

            if (diners >= total)
            {
                diners -= total;
                Console.WriteLine($"Pagament realitzat amb èxit. El teu canvi és {diners}€. Gràcies per la teva compra!");
                nElemCistella = 0;
                Array.Clear(productesCistella, 0, productesCistella.Length);
                Array.Clear(quantitat, 0, quantitat.Length);
            }
            else
            {
                Console.WriteLine($"No tens suficients diners. El total de la compra és {total}€ i només disposes de {diners}€.");
            }
        }
    }
}
