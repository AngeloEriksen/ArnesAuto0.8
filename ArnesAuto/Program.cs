﻿using ArnesAuto.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ArnesAuto
{
    class program
    {
        List<Kunder> kundeListe = new List<Kunder>();
        static void Main(string[] args)
        {
            Console.Title = "ArnesAuto";


            /// <summary>
            // Endless while Loop med bool til af afslutte programmet
            // Fandt ud af efter jeg bare kunne sætte'break;' ind, men nu fik den en bool til det.
            /// </summary>
            bool kørProgram = true;
            while (kørProgram)
            {
                // Start menu med valgmuligheder
                Console.WriteLine("Velkommen Til ArnesAuto ");
                Console.WriteLine("Du har nu følgene valgmuligheder");
                Console.WriteLine("Tryk 1. For at registrer ny kunde");
                Console.WriteLine("Tryk 2. For at Vise kunde kontaktinformation");
                Console.WriteLine("Tryk 3. For at afslutte programmet");
                ConsoleKeyInfo valg = Console.ReadKey();
                Console.Clear();

                //Simple Menu
                if (valg.Key == ConsoleKey.D1)
                {
                    NyKunde();
                    Console.Clear();
                }
                else if (valg.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("Kontaktinformation");
                }
                else if (valg.Key == ConsoleKey.D3)
                {
                    kørProgram = false;
                }
                else if (valg.Key == ConsoleKey.D4)
                {
                    //Arnes-Hemlighed! :)
                    Console.WriteLine("           .      ..\r\n   __..---/______//-----.        ((  )\r\n .\".--.```|    - /.--.  =:    ( VROOM! ))  \r\n(.: {} :__L______: {} :__; __--( __- -_= ) \r\n   *--*           *--*              Program af- Angelo Z. Eriksen       ");
                    //Credit for art - Jnh from https://ascii.co.uk/art
                }
                else
                {
                    Console.WriteLine("FEJL: Dette er ikke en valgmulighed\nTryk på en vilkårlig tast for at prøve igen.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void NyKunde()
        {
            Console.Clear();

            Kunder nyKunde = new Kunder();

            Console.Write("Indtast dit Fornavn: ");
            nyKunde.Fornavn = Console.ReadLine();

            Console.Write("Indtast dit Efternavn: ");
            nyKunde.Efternavn = Console.ReadLine();

            Console.Write("Indtast dit Telefonnummer: ");
            nyKunde.Telefonnummer = Console.ReadLine();

            Console.Write("Indtast bilens Nummerplade: ");
            nyKunde.Nummerplade = Console.ReadLine();

            Console.Write("Indtast bilens Mærke: ");
            nyKunde.Mærke = Console.ReadLine();

            Console.Write("Indtast bilens model: ");
            nyKunde.Model = Console.ReadLine();

            Console.Write("Indtast bilens motorstørrelse: ");
            nyKunde.Motorstørrelse = Convert.ToDouble(Console.ReadLine());

            Console.Write("Indtast bilens Årgang: ");
            nyKunde.Årgang = Console.ReadLine();

            bool Forkertsvar = true;

            while (Forkertsvar)
            {
                Console.Write("Indtast bilens første registreringsdato dd-MM-yyyy: ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime førsteRegistrering))
                {
                    nyKunde.FørsteRegistrering = førsteRegistrering;
                    Forkertsvar = false;
                }
                else
                {
                    Console.WriteLine("Du har indtastet en ugyldig dato. Prøv igen.");
                }
            }

            if ((DateTime.Now - nyKunde.FørsteRegistrering).TotalDays < 1825) // Check om bilen er under 5 år gammel (1825 dage)
            {
                Console.WriteLine("Bilen er under 5 år gammel og skal ikke til syn.");
                Console.WriteLine("Registreringen er nu færdiggjort.");
                Console.WriteLine("Tryk på en vilkårlig-Tast for at kommer tilbage til start menuen");
            }
            else
            {
                bool Forkertsvar2 = true;
                while (Forkertsvar2)
                {
                    Console.Write("Indtast datoen for sidste syn dd-MM-yyyy: ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime sidsteSynsdato))
                    {
                        nyKunde.SidsteSynsdato = sidsteSynsdato;
                        if ((DateTime.Now - nyKunde.SidsteSynsdato).TotalDays > 730) // Check om der er gået mere end 2 år siden sidste syn (730 dage)
                        {
                            Console.WriteLine("Bilen skal til syn.");
                            Console.WriteLine("Registreringen er nu færdiggjort.");
                            Console.WriteLine("Tryk på en vilkårlig-Tast for at kommer tilbage til start menuen");
                            Forkertsvar2 = false;
                        }
                        else
                        {
                            Console.WriteLine("Bilen skal ikke til syn.");
                            Console.WriteLine("Registreringen er nu færdiggjort.");
                            Console.WriteLine("Tryk på en vilkårlig-Tast for at kommer tilbage til start menuen");
                            Forkertsvar2 = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du har indtastet en ugyldig dato for sidste syn.");
                    }
                }
            }

            Console.ReadKey();

        }
    }
}
