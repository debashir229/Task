using System;

class Task
{
    static void RandGeneration(ref List<int> t, int s = 20)
    {
        for (int i = 0; i < s; i++)
        {
            Random r = new Random();
            t.Add(r.Next(-20, 15));
        }
    }
    static void func_1(ref List<int> num)
    {
        for (int i = 0; i < num.Count; i++)
        {
            for (int j = 0; j < num.Count; j++)
            {
                if (num[i] >= 0 && num[j] < 0)
                    (num[i], num[j]) = (num[j], num[i]);
            }
        }
    }
    static int func_2(int ptr, List<int> num)
    {
        int res = 0;
        for (int i = 0; i < num.Count; ++i)
            if (num[i] == ptr) { res++; }
        return res;
    }

    enum Transport { Bike = 90, SportCar = 215, Car = 410, Wagon = 750, Track = 1130 };
    static void Main()
    {
        #region Task1
        List<int> exp = new List<int>();
        RandGeneration(ref exp);
        Console.WriteLine(string.Join(" ", exp));
        func_1(ref exp);
        Console.WriteLine("Отсортированный массив: {0}", string.Join(" ", exp));
        #endregion
        #region Task2
        Console.Write("Введите число: ");
        string? temp = Console.ReadLine();
        int num = Convert.ToInt32(temp);
        Console.WriteLine("Число {0} повторяется в массиве столько раз: {1}", num, func_2(num, exp));
        #endregion
        #region Task3
        Console.Write("Введите вес груза: ");
        temp = Console.ReadLine();
        num = Convert.ToInt32(temp);
        foreach (int i in Enum.GetValues(typeof(Transport)))
        {
            if (num <= i)
            {
                Console.WriteLine("{0}", Enum.GetName(typeof(Transport), i));
            }
        }
        #endregion
    }
}
