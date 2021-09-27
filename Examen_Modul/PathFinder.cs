using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Modul
{
    class PathFinder
    {
        List<Activity> activities = new List<Activity>(); //Список всех работ (в графике это дуги)
        List<Path> pathes = new List<Path>(); //Список всех путей
        int FindStartingPos() //Метод для поиска начальной точки
        {
            foreach (Activity activity in activities) //Если нет таких дуг, которые бы входили в данную точку, то она начальная.
                if (activities.Where(x => x.eventEnd == activity.eventStart).Count() == 0) return activity.eventStart;
            return -1;
        }

        int FindEndingPos() //Метод для поиска конечной точки
        {
            foreach (Activity activity in activities) //Если нет таких дуг, которые бы исходили из данной точки, то она конечная.
                if (activities.Where(x => x.eventStart == activity.eventEnd).Count() == 0) return activity.eventEnd;
            return -1;
        }

    }
}
