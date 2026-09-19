namespace EsFontanaUML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPiazze;

            do
            {
                Console.WriteLine("Inserisci il numero di piazze che vuole inserire");

            }while(!int.TryParse(Console.ReadLine(), out numPiazze) || numPiazze <= 0);

            CPiazza[] piazze = new CPiazza[numPiazze];

            for(int i = 0; i < piazze.Length; i++)
            {
                float diametro;
                do
                {
                    Console.WriteLine("Inserisci il diametro della piazza");
                } while (!float.TryParse(Console.ReadLine(), out diametro) || diametro <= 0);

                Console.WriteLine("Insersci il nome della città dove è situata la piazza");
                string  cittàPiazza = Console.ReadLine();

                Console.WriteLine("Inserisci il nome della piazza");
                string nomePiazza = Console.ReadLine();

                Console.WriteLine("Inserisci il nome della fontana");
                string nomeFontana = Console.ReadLine();

                float consumoAcqua;

                do
                {
                    Console.WriteLine("Inserisci il consumo d'acqua della fontana");
                }while(!float.TryParse(Console.ReadLine(),out consumoAcqua));

                string statoString;

                do
                {
                    Console.WriteLine("La fontana rimane accesa anche di notte?");
                    statoString = Console.ReadLine();
                } while (string.IsNullOrEmpty(statoString) || (statoString.ToLower() != "sì" && statoString.ToLower() != "si" && statoString.ToLower() != "no"));

                bool stato = true;

                if(statoString.ToLower() == "sì")
                {
                     stato = true;
                }
                else if(statoString.ToLower() == "no")
                {
                     stato = false;
                }

                Console.WriteLine("Inserisci il nome dell'autore della fontana");
                string autore = Console.ReadLine();

                

                string scelta;
                

                try
                {
                    CPiazza piazza = new CPiazza(nomeFontana,consumoAcqua,stato,autore,diametro,cittàPiazza,nomePiazza);
                    do
                    {
                        do
                        {
                            Console.WriteLine("Vuoi inserire una nuova manutenzione per questa fontana?");
                            scelta = Console.ReadLine();
                        } while (string.IsNullOrEmpty(scelta) || (scelta.ToLower() != "sì" && scelta.ToLower() != "si" && scelta.ToLower() != "no"));

                        if (scelta.ToLower() == "sì" || scelta.ToLower() == "si")
                        {
                            string manutenzione;
                            do
                            {
                                Console.WriteLine("Inserisci la manutenzione da fare:");
                                manutenzione = Console.ReadLine();
                            } while (string.IsNullOrEmpty(manutenzione));


                            piazza.AggManute(manutenzione);
                        }

                    } while (scelta.ToLower() != "no");
                    piazze[i] = piazza;
                    Console.WriteLine("Piazza aggiunta con successo");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    i--;
                }
            }


            Console.WriteLine("\n");
            Console.WriteLine("ELENCO DELLE PIAZZE: ");
            foreach (CPiazza piazza in piazze)
            {
                Console.WriteLine(piazza.print());

                float areaPiazza = piazza.CalcolaArea();
                Console.WriteLine("Area della piazza " + areaPiazza);
                Console.WriteLine();

                if (piazza.Manutezioni.Count > 0)
                {
                    Console.WriteLine("MANUTENZIONI PROGRAMMATE:");
                    foreach(string m in piazza.Manutezioni)
                    {
                        Console.WriteLine($"\t -{m}");
                    }

                    string risposta;
                    
                        do
                        {
                            Console.WriteLine("Vuoi eliminare tutte le manutenzioni di questa fontana?");
                            risposta = Console.ReadLine();
                        } while (string.IsNullOrEmpty(risposta) || (risposta.ToLower() != "sì" && risposta.ToLower() != "si" && risposta.ToLower() != "no"));


                        if(risposta.ToLower() == "si" || risposta.ToLower() == "sì")
                        {
                            piazza.EliminaManute();
                            Console.WriteLine("Tutte le manutenzioni sono state eliminate con successo");
                            Console.WriteLine("MANUTENZIONI PROGRAMMATE:");
                            foreach (string m in piazza.Manutezioni)
                            {
                                Console.WriteLine($"\t -{m}");
                            }
                        }
                        
                    
                }
                else
                {
                    Console.WriteLine("Nessuna manutenzione programmata ");
                }
            }


          }
    }
}
