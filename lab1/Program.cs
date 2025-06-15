using System;
using System.Linq;

// Абстрактный базовый класс Array
public abstract class Array
{
    protected int[] data;

    // Конструктор
    public Array(int[] values)
    {
        data = values;
    }

    // Виртуальный метод сложения
    public abstract Array Add(Array other);

    // Виртуальный метод поэлементной обработки
    public abstract void ForEach();

    // Метод для вывода массива
    public void Print()
    {
        Console.WriteLine(string.Join(", ", data));
    }
}

// Производный класс SortArray
public class SortArray : Array
{
    public SortArray(int[] values) : base(values) { }

    // Реализация сложения как объединения множеств
    public override Array Add(Array other)
    {
        var combined = data.Union(other.data).ToArray();
        return new SortArray(combined);
    }

    // Реализация поэлементной обработки как сортировки
    public override void ForEach()
    {
        Array.Sort(data);
    }
}

// Производный класс XorArray
public class XorArray : Array
{
    public XorArray(int[] values) : base(values) { }

    // Реализация сложения как исключающего ИЛИ
    public override Array Add(Array other)
    {
        int maxLength = Math.Max(data.Length, other.data.Length);
        int[] result = new int[maxLength];

        for (int i = 0; i < maxLength; i++)
        {
            int a = i < data.Length ? data[i] : 0;
            int b = i < other.data.Length ? other.data[i] : 0;
            result[i] = a ^ b;
        }

        return new XorArray(result);
    }

    // Реализация поэлементной обработки как вычисления корня
    public override void ForEach()
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = (int)Math.Sqrt(data[i]);
        }
    }
}
        // Демонстрация работы SortArray
        Console.WriteLine("SortArray демонстрация:");
        var sortArr1 = new SortArray(new int[] { 5, 3, 1 });
        var sortArr2 = new SortArray(new int[] { 4, 3, 2 });

        Console.Write("Массив 1: ");
        sortArr1.Print();
        Console.Write("Массив 2: ");
        sortArr2.Print();

        var sumSort = sortArr1.Add(sortArr2);
        Console.Write("Объединение: ");
        sumSort.Print();

        sumSort.ForEach();
        Console.Write("После сортировки: ");
        sumSort.Print();

        // Демонстрация работы XorArray
        Console.WriteLine("\nXorArray демонстрация:");
        var xorArr1 = new XorArray(new int[] { 10, 20, 30 });
        var xorArr2 = new XorArray(new int[] { 5, 10, 15, 25 });

        Console.Write("Массив 1: ");
        xorArr1.Print();
        Console.Write("Массив 2: ");
        xorArr2.Print();

        var sumXor = xorArr1.Add(xorArr2);
        Console.Write("XOR: ");
        sumXor.Print();

        sumXor.ForEach();
        Console.Write("После вычисления корней: ");
        sumXor.Print();
