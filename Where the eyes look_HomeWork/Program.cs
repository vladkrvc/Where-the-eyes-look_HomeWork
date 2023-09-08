using System;
using System.Collections.Generic;

namespace WhereTheLook
{
    internal class Program
    {
        public static void Main(string [] args)
        {
            // Считываем количество городов из консоли
            int n = Convert.ToInt32(Console.ReadLine());
            // Создаём матрицу смежности
            int[,] graf = new int[n, n];
            // Считываем количество дорог из консоли
            int m = Convert.ToInt32(Console.ReadLine());

            int end;
            int start;
            // Заполняем матрицу
            for (int i = 0; i < m; i++)
            {   // Из какого города идет дорога
                start = Convert.ToInt32(Console.ReadLine());
                // Куда идет дорога
                end = Convert.ToInt32(Console.ReadLine());
                // Сколько составляет длина дороги
                int size = Convert.ToInt32(Console.ReadLine());
                // Записываем эти данные в матрицу
                graf[start, end] = size;
                
            }
            // Считываем, из какой точки стартуем
            int x = Convert.ToInt32(Console.ReadLine());
            start = x;
            // Создаем переменную, в которой хранится минимальный путь в город из точки старта
            int[] path = new int [n];
            for (int i = 0; i < n; i++)
            {
                path[i] = Int32.MaxValue;
            }

            Queue<int> list = new Queue<int>();
            path[start] = 0;
            list.Enqueue(start);
            while (list.Count > 0)
            {
                int u = list.Dequeue();
                for (int i = 0; i < n; i++)
                {
                    if (graf[u, i] > 0)
                    {
                        if (path[u] + graf[u, i] < path[i])
                        {
                            path[i] = path[u] + graf[u, i];
                            list.Enqueue(i);
                        }
                    }
                }
            }
            // Создаем переменную, в которой хранится ближайший город к городу из точки старта
            int nearestCity = -1;
            int shortestDistance = Int32.MaxValue;

            for (int i = 0; i < n; i++)
            {
                if (i != start && path[i] < shortestDistance)
                {
                    shortestDistance = path[i];
                    nearestCity = i;
                }
            }

            // Выведем номер ближайшего города
            Console.WriteLine(nearestCity);

        }
    }
}