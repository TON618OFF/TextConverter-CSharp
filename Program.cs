using System.Runtime.Serialization;
using System.Xml.Serialization;
using TextConverterClass;
using System.IO;
using System.Reflection.Metadata;
using Newtonsoft.Json;

namespace TextConverter
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите путь до файла (вместе с названием) который хотите открыть.");
            string path = Console.ReadLine();
            string txt = File.ReadAllText(path);
            string ttxxtt1 = "Terraria\nПесочница\n81";
            string ttxxtt2 = "Minecraft\nПесочница\n89";

            var start_menu = new Action(() =>
            {
                Console.Clear();
                Console.WriteLine("Сохранить файл в одном формате(txt, json, xml) - F1. Закрыть программу - Escape");
                Console.WriteLine(txt);
            });
            Select();
        }

        static void Select()
        {
            Game1 parameters1 = new Game1();
            parameters1.Title = "Terraria";
            parameters1.Genre = "Песочница";
            parameters1.Rating = "81";

            Game2 parameters2 = new Game2();
            parameters2.Title = "Minecraft";
            parameters2.Genre = "Песочница";
            parameters2.Rating = "89";

            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.F1)
            {
                Console.Clear();
                Console.WriteLine("Введите путь до файла (вместе с названием) куда хотите сохранить.");
                string path = Console.ReadLine();

                if (path.EndsWith(".xml"))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Game1));
                    using (FileStream a = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        xml.Serialize(a, parameters1);
                    }
                }
                else if (path.EndsWith(".json"))
                {
                    string json = JsonConvert.SerializeObject(parameters1);
                    File.WriteAllText(path, json);
                }
                else if (path.EndsWith(".txt"))
                {
                    File.WriteAllText(path, parameters1.Title);
                    File.WriteAllText(path, parameters1.Genre);
                    File.WriteAllText(path, parameters1.Rating);

                    File.WriteAllText(path, parameters2.Title);
                    File.WriteAllText(path, parameters2.Genre);
                    File.WriteAllText(path, parameters2.Rating);

                }

            }
            else if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
            

    }
}