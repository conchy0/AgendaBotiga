using System;

class Program
{
    static void Main(string[] args)
    {
        //diners inicials
        decimal diners = 0;
        //productes disponibles el principi
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

        //preus dels prodcutes
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
        int numProductes = productesBotiga.Length; //Longitut inicial

        bool sortir = false;
        string nom = ""; 

        // nom i diners disponibles
        Console.WriteLine("Bones, quin és el teu nom?");
        nom = Console.ReadLine();
        Console.WriteLine($"De quants diners disposes {nom}?");
        diners = Convert.ToDecimal(Console.ReadLine());

        while (!sortir)
        {
            Menu(ref diners, productesBotiga, preus, ref numProductes, ref sortir, nom);
        }
    }

    //menu i interfaz
    static void Menu(ref decimal diners, string[] productesBotiga, decimal[] preus, ref int numProductes, ref bool sortir, string nom)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGray;

        string[] Menu = {
          " ╔═════════════════════════════════════════════════════════╗ ",
          " ║                    Botiga Ca la Maria                   ║ ",
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
          " ║  - Escull una opcio -                                   ║ ",
          " ║=========================================================║ ",
          $" ║                                              {nom}        ║ ",
          " ║_________________________________________________________║ "
        };

        for (int i = 0; i < Menu.Length; i++)
        {
            Console.WriteLine(Menu[i]);
        }

        int opcio = Convert.ToInt32(Console.ReadLine());

        //oPCIONS I METODES
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
                AfegirProducte(ref productesBotiga, ref preus, ref numProductes);
                break;
            case 5:
                AmpliarTenda(ref numProductes);
                break;
            case 6:
                ModificarPreu(ref productesBotiga, ref preus);
                break;
            case 7:
                ModificarProducte(ref productesBotiga);
                break;
            case 8:
                OrdenarProductes(ref productesBotiga, ref preus);
                break;
            case 9:
                OrdenarPreus(ref productesBotiga, ref preus);
                break;
            case 10:
                ComprarProducte(productesBotiga, preus, ref diners);
                break;
            case 11:
                Console.WriteLine("Gràcies per la teva visita!");
                sortir = true; 
                return;
            default:
                Console.WriteLine("Opció no vàlida. Torna a seleccionar.");
                break;
        }
        Console.WriteLine("Prem una tecla per continuar...");
        Console.ReadKey();
    }

    //Mostrar Botiga
    static void MostrarBotiga(string[] productes, decimal[] preus)
        //Llista
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

        // La cistella esta buida?
        if (productes.Length == 0)
        {
            Console.WriteLine("La cistella està buida.");
        }
        else
        {
            // mostrar cistella amb preus
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

        // Per si te diners suficients per pagar
        if (diners >= preuTotal)
        {
            decimal canvi = diners - preuTotal;
            Console.WriteLine($"Pagament realitzat amb èxit. El teu canvi és {canvi:0.00}€. Gràcies per la teva compra!");
            diners = 0; // Reiniciar els diners
        }
        else
        {
            Console.WriteLine("No tens suficients diners per a realitzar el pagament.");
        }
    }

    static void AfegirProducte(ref string[] productes, ref decimal[] preus, ref int numProductes)
    {
        Console.WriteLine("Quin producte vols afegir?");
        string producteAfegir = Console.ReadLine();
        Console.WriteLine("Quin és el preu d'aquest producte?");
        decimal preuAfegir = Convert.ToDecimal(Console.ReadLine());

        //afegir producte
        if (numProductes < productes.Length)
        {
            productes[numProductes] = producteAfegir;
            preus[numProductes] = preuAfegir;
            numProductes++;
        }
        else
        {
            Console.WriteLine("No hi ha prou espai per afegir més productes.");
        }
    }

    static void AmpliarTenda(ref int capacitatMaxima)
    {
        Console.WriteLine("Quants productes vols afegir?");
        int num = Convert.ToInt32(Console.ReadLine());

        capacitatMaxima += num;

        Console.WriteLine($"S'ha ampliat la capacitat de la tenda a {capacitatMaxima} productes.");
    }

    //modificar preu
    static void ModificarPreu(ref string[] productes, ref decimal[] preus)
    {
        Console.WriteLine("Quin és el nom del producte que vols modificar?");
        string Canviar = Console.ReadLine();

        //bucle que agafa la longitud
        for (int i = 0; i < productes.Length; i++)
        {
            if (productes[i] == Canviar)
            {
                Console.WriteLine($"Quin preu vols per al producte {Canviar}?");
                decimal preuNou = Convert.ToDecimal(Console.ReadLine());
                preus[i] = preuNou;
                return;
            }
        }

        Console.WriteLine("No s'ha trobat el producte.");
    }

    //MODIFICAR PRODUCTE
    static void ModificarProducte(ref string[] productes)
    {
        //preguntar
        Console.WriteLine("Quin és el nom del producte que vols modificar?");
        string ProducVell = Console.ReadLine();

        Console.WriteLine("Quin és el nou nom per a aquest producte?");
        string ProducNou = Console.ReadLine();

        for (int i = 0; i < productes.Length; i++)
        {
            if (productes[i] == ProducVell)
            {
                productes[i] = ProducNou;
                return;
            }
        }

        Console.WriteLine("No s'ha trobat el producte.");
    }

    static void OrdenarProductes(ref string[] productes, ref decimal[] preus)
    {
        for (int i = 0; i < productes.Length - 1; i++)
        {
            for (int j = i + 1; j < productes.Length; j++)
            {
                if (string.Compare(productes[i], productes[j], StringComparison.Ordinal) > 0)
                {
                    // Intercambiar noms 
                    string tempProducte = productes[i];
                    productes[i] = productes[j];
                    productes[j] = tempProducte;

                    // Intercambiar preus
                    decimal tempPreu = preus[i];
                    preus[i] = preus[j];
                    preus[j] = tempPreu;
                }
            }
        }
    }

    static void OrdenarPreus(ref string[] productes, ref decimal[] preus)
    {
        for (int i = 0; i < preus.Length - 1; i++)
        {
            for (int j = i + 1; j < preus.Length; j++)
            {
                if (preus[i] > preus[j])
                {
                    // Intercambiar preus
                    decimal tempPreu = preus[i];
                    preus[i] = preus[j];
                    preus[j] = tempPreu;

                    // Intercambiar noms de productes
                    string tempProducte = productes[i];
                    productes[i] = productes[j];
                    productes[j] = tempProducte;
                }
            }
        }
    }

    static void ComprarProducte(string[] productesBotiga, decimal[] preus, ref decimal diners)
    {
        // Mostrar els productes disponibles
        MostrarBotiga(productesBotiga, preus);

        Console.WriteLine("Quin producte vols comprar? Introdueix el número corresponent:");
        int opcioProducte = Convert.ToInt32(Console.ReadLine());

        // Verificar si l'opció és vàlida
        if (opcioProducte >= 1 && opcioProducte <= productesBotiga.Length)
        {
            int indexProducteSeleccionat = opcioProducte - 1;
            decimal preuProducteSeleccionat = preus[indexProducteSeleccionat];

            // SI HI HA DINERS
            if (diners >= preuProducteSeleccionat)
            {
                // Actualitzar els diners 
                diners -= preuProducteSeleccionat;
                Console.WriteLine($"Has comprat {productesBotiga[indexProducteSeleccionat]} per {preuProducteSeleccionat:0.00}€. Diners restants: {diners:0.00}€");
            }
            else
            {
                Console.WriteLine("No tens suficients diners per comprar aquest producte.");
            }
        }
        else
        {
            Console.WriteLine("Opció invàlida.");
        }
    }

}
