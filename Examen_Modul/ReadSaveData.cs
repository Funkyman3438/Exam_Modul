using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Modul
{
    public struct Item : IComparable<Item>
    {
        public int number, aTime, bTime;

        public override string ToString()
        {
            return aTime + " " + bTime;
        }

        public int CompareTo(Item item)
        {
            if (aTime <= bTime)
            {
                if (aTime > item.aTime)
                    return 1;
                if (aTime < item.aTime)
                    return -1;
            }
            else
            {
                if (bTime > item.bTime)
                    return 1;
                if (bTime < item.bTime)
                    return -1;
            }
            return 0;
        }
    }

    struct Activity
    {
        public int eventStart, eventEnd, time;
    }
    struct Path
    {
        public string path;
        public int lastPoint, length;
    }

    static class ReadSaveData
    {
        //Считывание данных для поиска критического и минимального пути
        //В первую строку записывается начало работы
        //Во вторую строку конец работы
        //В третью — ее длительность
        //В файле: начало | конец | длительность
        public static void ReadData(string path, ref List<Activity> activities)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                string[] str = line.Split(';');
                activities.Add(new Activity { eventStart = Convert.ToInt32(str[0]), eventEnd = Convert.ToInt32(str[1]), time = Convert.ToInt32(str[2]) });
            }
        }

        public static void WriteToFile(string path, Path savingPath)
        {
            if (!File.Exists(path)) File.Create(path).Close();
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.WriteLine("Найденный путь имеет вид:");
                    sw.WriteLine(savingPath.path);
                    sw.WriteLine("Его длина составляет: " + savingPath.length);
                }
            }
            catch
            {
                Console.WriteLine("Не удалось записать данные в файл!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
