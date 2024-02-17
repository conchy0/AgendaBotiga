using System;

class Program
{
    static void Main(string[] args)
    {
        decimal diners = 0;
        string[] productesBotiga = {
            "Entrecot a la brasa",
            "Fideuà",
            "Sushi",
            "Rissoto de gamba",
            "Pollastre amb salses",
            "Macarrons amb Tomaquina",
            "Llanties amb Xorís",
            "Pastís de formatge"
        };
        decimal[] preus = {
            15.99m,
            12.50m,
            10.75m,
            9.25m,
            8.99m,
            7.75m,
            6.50m,
            5.99m
        };
        Menu(ref diners, productesBotiga, preus);
    }

    static void Menu(ref decimal diners, string[] productesBotiga, decimal[] preus)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.WriteLine("Bones, quin és el teu nom?");
        string nom = Console.ReadLine();
        Console.WriteLine($"De quants diners disposes {nom}?");
        diners = Convert.ToDecimal(Console.ReadLine());

        string[] Menu = {
            " ╔═════════════════════════════════════════════════════════╗ ",
            " ║                    Botiga  Ca la Maria                  ║ ",
            " ║=========================================================║ ",
            " ║                    1) Mostrar Botiga                    ║ ",
            " ║                    2) Mostrar Cistella                  ║ ",
            " ║                    3) Realitzar el Pagament             ║ ",
            " ║                    4) Afegir Producte                   ║ ",
            " ║                    5) Ampliar Tenda                     ║ ",
            " ║                    6) Modificar Preu                    ║ ",
            " ║                    7) Modificar Producte                ║ ",
            " ║                    8) Ordenar Productes                 ║ ",
            " ║                    9) Ordenar Preus                     ║ ",
            " ║                    10) Comprar Producte                 ║ ",
            " ║                    11) Sortir                           ║ ",
            " ║=========================================================║ ",
            " ║   - Escull una opcio -                                  ║ ",
            " ║=========================================================║ ",
            " ║                                             Nil i Alex  ║ ",
            " ║_________________________________________________________║ "
        };

        foreach (string line in Menu)
        {
            Console.WriteLine(line);
        }

        int opcio = Convert.ToInt32(Console.ReadLine());

        switch (opcio)
        {
            case 1:
                MostrarBotiga(productesBotiga, preus);
                break;
            case 2:
                MostrarCistella(productesBotiga, preus);
                break;
            case 3:
                RealitzarPagament(ref diners);
                break;
            case 4:
                AfegirProducte(productesBotiga, preus);
                break;
            case 5:
                AmpliarTenda(ref productesBotiga, ref preus);
                break;
            case 6:
                ModificarPreu(productesBotiga, preus);
                break;
            case 7:
                ModificarProducte(productesBotiga);
                break;
            case 8:
                OrdenarProductes(productesBotiga, preus);
                break;
            case 9:
                OrdenarPreus(productesBotiga, preus);
                break;
            case 10:
                ComprarProducte(productesBotiga, preus, ref diners);
                break;
            case 11:
                Console.WriteLine("Gràcies per la teva visita!");
                return;
            default:
                Console.WriteLine("Opció no vàlida. Torna a seleccionar.");
                break;
        }
        Console.WriteLine("Prem qualsevol tecla per continuar...");
        Console.ReadKey();
        
    }

    private static void ComprarProducte(string[] productesBotiga, decimal[] preus, ref decimal diners)
    {
        throw new NotImplementedException();
    }

    private static void OrdenarPreus(string[] productesBotiga, decimal[] preus)
    {
        throw new NotImplementedException();
    }

    private static void OrdenarProductes(string[] productesBotiga, decimal[] preus)
    {
        throw new NotImplementedException();
    }

    private static void ModificarProducte(string[] productesBotiga)
    {
        throw new NotImplementedException();
    }

    private static void ModificarPreu(string[] productesBotiga, decimal[] preus)
    {
        throw new NotImplementedException();
    }

    private static void AmpliarTenda(ref string[] productesBotiga, ref decimal[] preus)
    {
        throw new NotImplementedException();
    }

    private static void AfegirProducte(string[] productesBotiga, decimal[] preus)
    {
        throw new NotImplementedException();
    }

    static void MostrarBotiga(string[] productes, decimal[] preus)
    {
        Console.WriteLine("\nLlista de Productes Disponibles:\n");
        for (int i = 0; i < productes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {productes[i]} - {preus[i]:0.00}€");
        }
    }

    static void MostrarCistella(string[] productes, decimal[] preus)
    {
        Console.WriteLine("\nProductes a la Cistella:\n");

        // Verificar si la cistella está vacía
        if (productes.Length == 0)
        {
            Console.WriteLine("La cistella està buida.");
        }
        else
        {
            // Mostrar cada producto en la cistella junto con su precio
            for (int i = 0; i < productes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {productes[i]} - {preus[i]:0.00}€");
            }
        }
    }


    static void RealitzarPagament(ref decimal diners)
    {
        Console.WriteLine("Introdueix el preu total de la compra:");
        decimal preuTotal = Convert.ToDecimal(Console.ReadLine());

        // Verificar si hay suficiente dinero para realizar el pago
        if (diners >= preuTotal)
        {
            decimal canvi = diners - preuTotal;
            Console.WriteLine($"Pagament realitzat amb èxit. El teu canvi és {canvi:0.00}€. Gràcies per la teva compra!");
            diners = 0; // Reiniciar la cantidad de dinero
        }
        else
        {
            Console.WriteLine("No tens suficients diners per a realitzar el pagament.");
        }
    }

    static void AfegirProducte(ref string[] productes, ref double[] preus, ref int nElem, string producteAfegir, double preuAfegir)
    {
            if (nElem >= productes.Length)
            {
                Console.WriteLine("La botiga esta plena, vols afagir algun producte nou?");
                string resposta = Console.ReadLine();
                if (resposta.ToLower() == "s")
                {
                    Console.Write("Quants productes vols afegir? ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    AmpliarTenda(num, ref productes, ref preus);
                }
            }
            productes[nElem] = producteAfegir;
            preus[nElem] = preuAfegir;
            nElem++;

    static void AmpliarTenda(int num, ref string[] productes, ref double[] preus)
    {
            string[] producte = new string[productes.Length + num];
            double[] preu = new double[preus.Length + num];
            for (int i = 0; i < productes.Length; i++)
            {
                producte[i] = productes[i];
                preu[i] = preus[i];
            }
            productes = producte;
            preus = preu;
    }

    static void ModificarPreu(string[] productes, double[] preus, string Canviar)
    {
            for (int i = 0; i < productes.Length; i++)
            {
                if (productes[i].Contains(Canviar))
                {
                    Console.WriteLine($"Quin preu vols modificar a: {Canviar}");
                    double preuNou = Convert.ToDouble(Console.ReadLine());
                    preus[i] = preuNou;
                }
                if (!productes.Contains(Canviar))
                {
                    Console.WriteLine("No es troba el producte");
                }
            }
    }

    static void ModificarProducte(string[] productes, string ProducVell, string ProducNou)
    {
            for (int i = 0; i < productes.Length; i++)
            {
                if (productes[i].Contains(ProducVell))
                {
                    productes[i] = ProducNou;
                }
                if (!productes.Contains(ProducVell) && !productes.Contains(ProducNou))
                    Console.WriteLine("No es troba el producte");
            }
    }

    static void OrdenarProducte(string[] productes, double[] preus, int nElem)
    {
            for (int Volta = 0; Volta < nElem - 1; Volta++)
            {
                for (int i = 0; i < nElem - 1; i++)
                {

                    if (string.Compare(productes[i], productes[i + 1]) > 0)
                    {
                        string temp = productes[i];
                        productes[i] = productes[i + 1];
                        productes[i + 1] = temp;
                        double preu = preus[i];
                        preus[i] = preus[i + 1];
                        preus[i + 1] = preu;
                    }
                }
            }
            for (int i = 0; i < nElem - 1; i++)
                Console.WriteLine($"Producte: {productes[i]} Preu: {preus[i]}");
    }


    static void OrdenarPreus(string[] productes, double[] preus, int li, int ls, int nElem)
    {

            int mig = (int)preus[(li + ls) / 2];
            int i = li;
            int j = ls;

            do
            {
                while (preus[i] < mig && i < ls) i++;
                while (preus[j] > mig && j > li) j--;
                if (i <= j)
                {
                    Permuta(ref preus[i], ref preus[j], ref productes[i], ref productes[j]);
                    i++;
                    j--;
                }
            } while (i <= j);
            if (j > li) OrdenarPreus(productes, preus, li, j, nElem);
            if (i > ls) OrdenarPreus(productes, preus, i, ls, nElem);
            for (int k = 0; k < nElem; k++)
                Console.WriteLine($"Producte: {productes[k]} Preu: {preus[k]}");
    }

        static void ComprarProducte(string[] productesBotiga, decimal[] preus, ref decimal diners)
    {
        // Implementación de ComprarProducte
    }
}

    static void Permuta(ref double preu1, ref double preu2, ref string producte1, ref string producte2)
    {
        double temp = preu1;
        preu1 = preu2;
        preu2 = temp;
        string producte = producte1;
        producte1 = producte2;
        producte2 = producte;
    }
}
