using System.Xml;

namespace SchoolClassesApp;

internal class Aplikace
{
    public void Run()
    {
        
        var data = GetData();
        var o = ("./output.txt");
        bool proceed = true;
        while (proceed)
        {
            Console.WriteLine("Jaký typ?");
            var typ = Console.ReadLine();
            int counter = 0;
            int zkouska = 0;
            int zaci = 0;
            
            for (int i = 0; i < data.Length; i++)
            {
                if (typ == data[i].Type)
                {
                    Console.WriteLine("Třídy: " + data[i].Name +" počet žáků: " +data[i].Students);
                    counter++;
                    zkouska++;
                    zaci = zaci + data[i].Students;
                   
                }
            }
            if (zkouska == 0)
            {
                Console.WriteLine("Tento Typ nebyl nalezen");
            }
            else
            {
                Console.WriteLine("Počet: " + counter);
                Console.WriteLine("Počet žáků: "+ zaci);
                Console.WriteLine("_________________");
                WriteIntoFile(o, "" + $"{typ};{counter};{zaci}");
                

            }
            

        }




    }
    public Class[] GetData()
    {
        var lines = File.ReadAllLines("./classes.txt");
        var classes = new Class[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            var split = lines[i].Split("*");
            classes[i] = new Class
            {
                Id = ToInt(split[0]),
                Name = (split[1]),
                Type = (split[2]),
                Students = ToInt(split[3]),


            };
        }
    return classes;
    }
    public int ToInt(string s)
    {
        if (int.TryParse(s, out var result))
            return result;
        return int.MinValue;
    }
    public void WriteIntoFile(string path, string content)
    {
        using var sw = new StreamWriter(path);
        sw.WriteLine(content);
    }
}


    




