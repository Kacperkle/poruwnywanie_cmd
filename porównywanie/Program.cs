class Program
{
    static void PorownajPliki(string sciezka1, string sciezka2)
    {
        if (File.Exists(sciezka1) && File.Exists(sciezka2))
        {
            List<int> gdzie = new List<int>();
            List<int> gdzie1 = new List<int>();
            List<int> gdzie2 = new List<int>();
            string[] linesFile1 = File.ReadAllLines(sciezka1);
            string[] linesFile2 = File.ReadAllLines(sciezka2);
            int dlugosc = Math.Min(linesFile1.Length, linesFile2.Length);
            int dlugoscMax = Math.Max(linesFile1.Length, linesFile2.Length);
            int f = dlugosc / 2;
            int a = 0;
            int e = 0;
            if (f < 2)
            {
                f = 2;
            }

            for (int i = 0; i < dlugosc; i++)
            {
                if (linesFile1[i] != linesFile2[i])
                {
                    gdzie.Add(i);
                }
            }
            for (int c = 1; c < f; c++)
            {
                for (int i = 0; i < dlugosc; i++)
                {
                    if (i + c < linesFile2.Length)
                    {
                        if (linesFile1[i] != linesFile2[i + c])
                        {
                            gdzie1.Add(i);
                        }
                    }
                }
                for (int i = 0; i < dlugosc; i++)
                {
                    if (i + c < linesFile1.Length)
                    {
                        if (linesFile1[i + c] != linesFile2[i])
                        {
                            gdzie2.Add(i);
                        }
                    }
                }
                if (gdzie1.Count < gdzie.Count && gdzie1.Count < gdzie2.Count)
                {
                    gdzie.Clear();
                    gdzie.AddRange(gdzie1);
                    gdzie2.Clear();
                    gdzie1.Clear();
                    a = 2;
                    e = c;
                }
                else if (gdzie2.Count < gdzie1.Count && gdzie2.Count < gdzie.Count)
                {
                    gdzie.Clear();
                    gdzie.AddRange(gdzie2);
                    gdzie1.Clear();
                    gdzie2.Clear();
                    a = 1;
                    e = c;
                }
                else
                {
                    gdzie1.Clear();
                    gdzie2.Clear();
                }
            }
            Console.WriteLine();
            if (gdzie.Count == 0)
            {
                Console.WriteLine("Pliki są takie same.");
                return;
            }

            //wyświetlanie
            int m = 0;
            if (a == 1)
            {
                m = e;
            }
            Console.WriteLine("Porównywana zawartość pliku 1:");
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine("(" + linesFile1[i] + ") linia przesunięcia");
            }
            for (int i = 0; i < gdzie.Count; i++)
            {
                int index = gdzie[i];
                if (index > 2 && (i == 0 || index - 3 > gdzie[i - 1]))
                {
                    Console.WriteLine(linesFile1[index - 3 + m]);
                    Console.WriteLine(linesFile1[index - 2 + m]);
                    Console.WriteLine(linesFile1[index - 1 + m]);
                }
                else if (index > 1 && (i == 0 || index - 2 > gdzie[i - 1]))
                {
                    Console.WriteLine(linesFile1[index - 2 + m]);
                    Console.WriteLine(linesFile1[index - 1 + m]);
                }
                else if (index > 0 && (i == 0 || index - 1 > gdzie[i - 1]))
                {
                    Console.WriteLine(linesFile1[index - 1 + m]);
                }

                Console.WriteLine("(" + linesFile1[index + m] + ") linia się różni");

                if (index < dlugosc - 4 && i + 1 < gdzie.Count - 1 && index + 4 < gdzie[i + 1])
                {
                    Console.WriteLine(linesFile1[index + 1 + m]);
                    Console.WriteLine(linesFile1[index + 2 + m]);
                    Console.WriteLine(linesFile1[index + 3 + m]);
                }
                else if (index < dlugosc - 3 && i + 1 < gdzie.Count - 1 && index + 3 < gdzie[i + 1])
                {
                    Console.WriteLine(linesFile1[index + 1 + m]);
                    Console.WriteLine(linesFile1[index + 2 + m]);
                }
                else if (index < dlugosc - 2 && i + 1 < gdzie.Count - 1 && index + 2 < gdzie[i + 1])
                {
                    Console.WriteLine(linesFile1[index + 1 + m]);
                }
            }
            if (linesFile1.Length == linesFile2.Length)
            {
                if (a == 0)
                {
                }
                else if (a == 1)
                {
                    if (linesFile1.Length > linesFile2.Length + e)
                    {
                        for (int i = dlugosc - e; i < linesFile1.Length; i++)
                        {
                            Console.WriteLine("(" + linesFile1[i] + ") linia nie istnieje w drugim pliku ");
                        }
                    }
                    else if (linesFile1.Length < linesFile2.Length + e)
                    {
                        for (int i = dlugosc - e; i < linesFile2.Length; i++)
                        {
                            Console.WriteLine("Linia nie istnieje w tym pliku");
                        }
                    }
                }
                else if (a == 2)
                {
                    if (linesFile1.Length + e > linesFile2.Length)
                    {
                        for (int i = dlugosc - e; i < linesFile1.Length; i++)
                        {
                            Console.WriteLine("(" + linesFile1[i] + ") linia nie istnieje w drugim pliku ");
                        }
                    }
                    else if (linesFile1.Length + e < linesFile2.Length)
                    {
                        for (int i = dlugosc - e; i < linesFile2.Length; i++)
                        {
                            Console.WriteLine("Linia nie istnieje w tym pliku");
                        }
                    }
                }
            }
            else if (linesFile1.Length > linesFile2.Length)
            {
                for (int i = dlugosc + e; i < linesFile1.Length; i++)
                {
                    Console.WriteLine("(" + linesFile1[i] + ") linia nie istnieje w drugim pliku ");
                }
            }
            else if (linesFile1.Length < linesFile2.Length)
            {
                for (int i = dlugosc + e; i < linesFile2.Length; i++)
                {
                    Console.WriteLine("Linia nie istnieje w tym pliku");
                }
            }
            m = 0;
            if (a == 2)
            {
                m = e;
            }
            Console.WriteLine();
            Console.WriteLine("Porównywana zawartość pliku 2:");
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine("(" + linesFile2[i] + ") linia przesunięcia");
            }
            for (int i = 0; i < gdzie.Count; i++)
            {
                int index = gdzie[i];
                if (index > 2 && (i == 0 || index - 3 > gdzie[i - 1]))
                {
                    Console.WriteLine(linesFile2[index - 3 + m]);
                    Console.WriteLine(linesFile2[index - 2 + m]);
                    Console.WriteLine(linesFile2[index - 1 + m]);
                }
                else if (index > 1 && (i == 0 || index - 2 > gdzie[i - 1]))
                {
                    Console.WriteLine(linesFile2[index - 2 + m]);
                    Console.WriteLine(linesFile2[index - 1 + m]);
                }
                else if (index > 0 && (i == 0 || index - 1 > gdzie[i - 1]))
                {
                    Console.WriteLine(linesFile2[index - 1 + m]);
                }

                Console.WriteLine("(" + linesFile2[index + m] + ") linia się różni");

                if (index < dlugosc - 4 && i + 1 < gdzie.Count - 1 && index + 4 < gdzie[i + 1])
                {
                    Console.WriteLine(linesFile2[index + 1 + m]);
                    Console.WriteLine(linesFile2[index + 2 + m]);
                    Console.WriteLine(linesFile2[index + 3 + m]);
                }
                else if (index < dlugosc - 3 && i + 1 < gdzie.Count - 1 && index + 3 < gdzie[i + 1])
                {
                    Console.WriteLine(linesFile2[index + 1 + m]);
                    Console.WriteLine(linesFile2[index + 2 + m]);
                }
                else if (index < dlugosc - 2 && i + 1 < gdzie.Count - 1 && index + 2 < gdzie[i + 1])
                {
                    Console.WriteLine(linesFile2[index + 1 + m]);
                }
            }
            if (linesFile1.Length == linesFile2.Length)
            {
                if (a == 0)
                {
                }
                else if (a == 1)
                {
                    if (linesFile1.Length < linesFile2.Length + e)
                    {
                        for (int i = dlugosc - e; i < linesFile2.Length; i++)
                        {
                            Console.WriteLine("(" + linesFile2[i] + ") linia nie istnieje w drugim pliku ");
                        }
                    }
                    else if (linesFile1.Length > linesFile2.Length + e)
                    {
                        for (int i = dlugosc - e; i < linesFile2.Length; i++)
                        {
                            Console.WriteLine("Linia nie istnieje w tym pliku");
                        }
                    }
                }
                else if (a == 2)
                {
                    if (linesFile1.Length + e < linesFile2.Length)
                    {
                        for (int i = dlugosc - e; i < linesFile1.Length; i++)
                        {
                            Console.WriteLine("(" + linesFile2[i] + ") linia nie istnieje w drugim pliku ");
                        }
                    }
                    else if (linesFile1.Length + e > linesFile2.Length)
                    {
                        for (int i = dlugosc - e; i < linesFile2.Length; i++)
                        {
                            Console.WriteLine("Linia nie istnieje w tym pliku");
                        }
                    }
                }
            }
            else if (linesFile1.Length < linesFile2.Length)
            {
                for (int i = dlugosc + e; i < linesFile2.Length; i++)
                {
                    Console.WriteLine("(" + linesFile2[i] + ") linia nie istnieje w drugim pliku ");
                }
            }
            else if (linesFile1.Length > linesFile1.Length)
            {
                for (int i = dlugosc + e; i < linesFile1.Length; i++)
                {
                    Console.WriteLine("Linia nie istnieje w tym pliku");
                }
            }
        }
        else
        {
            Console.WriteLine("Ścieżki do plików są błędne.");
        }
    }
    static void Main(string[] args)
    {
        int on = 0;
        while (on == 0)
        {
            Console.WriteLine();
            Console.WriteLine("1 - porównywanie plików 2 - porównywanie katalogów 3 - wyłącz program");
            string numer = Console.ReadLine();
            int tybPorownania;
            if (!int.TryParse(numer, out tybPorownania))
            {
                Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
                continue;
            }

            switch (tybPorownania)
            {
                case 1:
                    Console.WriteLine("Podaj ścieżkę do 1 pliku");
                    string sciezka1 = Console.ReadLine();
                    Console.WriteLine("Podaj ścieżkę do 2 pliku");
                    string sciezka2 = Console.ReadLine();
                    Console.WriteLine();
                    PorownajPliki(sciezka1, sciezka2);
                    break;
                case 2:
                    Console.WriteLine("Podaj ścieżkę do 1 folderu.");
                    sciezka1 = Console.ReadLine();
                    Console.WriteLine("Podaj ścieżkę do 2 folderu.");
                    sciezka2 = Console.ReadLine();
                    Console.WriteLine();
                    if (Directory.Exists(sciezka1) && Directory.Exists(sciezka2))
                    {
                        List<int> takieSame = new List<int>();
                        string[] filesF1 = Directory.GetFiles(sciezka1);
                        string[] filesF2 = Directory.GetFiles(sciezka2);
                        Console.WriteLine("Pliki o takiej samej nazwie:");
                        for (int i = 0; i < filesF1.Length; i++)
                        {
                            for (int j = 0; j < filesF2.Length; j++)
                            {
                                if (Path.GetFileName(filesF1[i]) == Path.GetFileName(filesF2[j]))
                                {
                                    takieSame.Add(i);
                                    string sDP1 = Path.Combine(sciezka1, filesF1[i]);
                                    string sDP2 = Path.Combine(sciezka2, filesF2[j]);
                                    Console.WriteLine("- " + Path.GetFileName(filesF1[i]));
                                    Console.WriteLine("Oto porównanie zawartości plików o tej nazwie.");
                                    PorownajPliki(sDP1, sDP2);
                                    break;
                                }
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Pliki z folderu 1, których niema w drugim folderze:");
                        for (int i = 0; i < filesF1.Length; i++)
                        {
                            if (!takieSame.Contains(i))
                            {
                                Console.WriteLine("- " + Path.GetFileName(filesF1[i]));
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("Pliki z folderu 2, których niema w pierwszym folderze:");
                        for (int j = 0; j < filesF2.Length; j++)
                        {
                            bool found = false;
                            for (int i = 0; i < filesF1.Length; i++)
                            {
                                if (Path.GetFileName(filesF1[i]) == Path.GetFileName(filesF2[j]))
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine("- " + Path.GetFileName(filesF2[j]));
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ścieżki do folderów są błędne.");
                    }
                    break;
                case 3:
                    on = 1;
                    break;
                default:
                    Console.WriteLine("Taka opcja nie istnieje.");
                    break;
            }
        }
    }
}
