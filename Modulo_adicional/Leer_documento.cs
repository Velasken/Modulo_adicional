using System;
using System.IO;
using System.Diagnostics;

namespace Modulo_adicional {
    public class LoadByCSV{

        public int contador = 0; //Numero de fichas validas
        public int descartes = 0; //Numero de fichas descartadas
        Stopwatch stopwatch = new Stopwatch();

        public void PerformOperation()
        {
            Console.Write("Enter the file path (File should be in files folder): ");
            string fileName = Console.ReadLine();

            string filePath = "../../../" + fileName;

            // Search for errors with the path
            try
            {
                stopwatch.Start();

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = "";
                    string separator = ";";

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(separator);

                        if (values[0] == null || values[0] == "")
                        {
                            descartes++;
                            continue;
                        }
                        string Obra = values[0];

                        if (values[1] == null || values[1] == "")
                        {
                            descartes++;
                            continue;
                        }
                        string Apellautor = values[1];
                        string Nomautor = values[2];
                        string Tonalidad = values[3];
                        string Opus = values[4];
                        string Duracion = values[5];

                        contador++;
                    }
                    stopwatch.Stop();

                    TimeSpan elapsed = stopwatch.Elapsed;
                    double microsegundos = (stopwatch.ElapsedTicks * 1_000_000.0) / Stopwatch.Frequency;

                    Console.WriteLine($"Numero de fichas cargadas: {contador}");
                    Console.WriteLine($"Numero de fichas descartadas: {descartes}");
                    Console.WriteLine($"Tiempo de ejecución (en microsegundos): {microsegundos}");
                }
            }

            // Error if the path doesn't exist
            catch (FileNotFoundException f)
            {
                Console.WriteLine($"{f}; File does not exist");
            }

            // Error if the directory is not found
            catch (DirectoryNotFoundException d)
            {
                Console.WriteLine($"{d}; Directory does not exist");
            }
        }
    }
}