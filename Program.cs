using System;

namespace MenuBotiga
{
    internal class Program
    {
        // Definició de les variables globals
        static string[] productesBotiga = { "Entrecot a la brasa", "Fiduà", "Sushi", "Rissoto de gamba", "Pollastre amb salses", "Macarrons amb Tomaquina", "Llanties amb Xorís", "Pastís de formatge" };
        static double[] preus = { 15.99, 12.50, 10.75, 9.25, 8.99, 7.75, 6.50, 5.99 };
        static int nElemBotiga = productesBotiga.Length;

        static string[] productesCistella;
        static int[] quantitat;
        static int nElemCistella;
        static decimal diners;

        static void Main(string[] args)
        {
            Console.WriteLine("Bones, quin és el teu nom?");
            string nom = Console.ReadLine();

            Console.WriteLine($"De quants diners disposes {nom}?");
            diners = Convert.ToDecimal(Console.ReadLine());

            // Cistella de Compra
            productesCistella = new string[10]; //10 PRODUCTES PER DEFECTE
            nElemCistella = 0;

            // Executar el menú
            Menu();
        }

        static void Menu()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;

            // Quadre
            string[] MenuInterfaz = {
                    " ╔═════════════════════════════════════════════════════════╗ ",
                    " ║                    Botiga  Ca la Maria                  ║ ",
                    " ║=========================================================║ ",
                    " ║                    1) Entrecot a la brasa               ║ ",
                    " ║                    2) Fiduà                             ║ ",
                    " ║                    3) Sushi                             ║ ",
                    " ║                    4) Rissoto de gamba                  ║ ",
                    " ║                    5) Pollastre amb salses              ║ ",
                    " ║                    6) Macarrons amb Tomaquina           ║ ",
                    " ║                    7) Llanties amb Xorís                ║ ",
                    " ║                    8) Pastís de formatge                ║ ",
                    " ║                    9) Sortir                            ║ ",
                    " ║=========================================================║ ",
                    " ║   - Escull una opcio -                                  ║ ",
                    " ║=========================================================║ ",
                    " ║                                             Nil i Alex  ║ ",
                    " ║_________________________________________________________║ "
            };

            // POSICIO EN VERTICAL
            int centreY = (Console.WindowHeight - MenuInterfaz.Length) / 2;

            // Bucle per posar cada línia del menú centrada
            foreach (string linea in MenuInterfaz)
            {
                // Calcular la posició
                int centreX = (Console.WindowWidth - linea.Length) / 2;

                Console.SetCursorPosition(centreX, centreY);
                Console.WriteLine(linea);

                // Increment per la següent línia
                centreY++;
            }

            int opcio = Convert.ToInt32(Console.ReadLine());

            // Seleccionar opció y preguntar números
            switch (opcio)
            {
                case 1:
                    AfegirProducte("Entrecot a la brasa", 15.99);
                    break;
                case 2:
                    AfegirProducte("Fiduà", 12.50);
                    break;
                case 3:
                    AfegirProducte("Sushi", 10.75);
                    break;
                case 4:
                    AfegirProducte("Rissoto de gamba", 9.25);
                    break;
                case 5:
                    AfegirProducte("Pollastre amb salses", 8.99);
                    break;
                case 6:
                    AfegirProducte("Macarrons amb Tomaquina", 7.75);
                    break;
                case 7:
                    AfegirProducte("Llanties amb Xorís", 6.50);
                    break;
                case 8:
                    AfegirProducte("Pastís de formatge", 5.99);
                    break;
                case 9:
                    break;
                default:
                    Console.WriteLine("Opció no vàlida. Torna a seleccionar.");
                    break;
            }

            // Tornar a mostrar el menú
            Menu();
        }

        static void AfegirProducte(string producte, double preu)
        {
            
            if (nElemCistella < productesCistella.Length)
            {
                // Comprovar si tenim suficients diners
                if (diners >= Convert.ToDecimal(preu))
                {
                    productesCistella[nElemCistella] = producte;
                    quantitat[nElemCistella] = 1; // Afegim una unitat
                    nElemCistella++;
                    diners -= Convert.ToDecimal(preu); // Actualitzar la quantitat de diners
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

        static void MostrarProductesBotiga()
        {
            Console.WriteLine("Productes disponibles a la botiga:");
            for (int i = 0; i < nElemBotiga; i++)
            {
                Console.WriteLine($"{i + 1}. {productesBotiga[i]} - {preus[i]}€");
            }
        }
    }
}
