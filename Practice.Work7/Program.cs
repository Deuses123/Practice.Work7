using System.Diagnostics;
using Library;
using Array = Library.Array;

public class Program
{
    public static void Main(string[] args)
    {
        
        //Task1 
        //todo Сравнивание обьектов с перегруженными операторами
        Console.WriteLine("Task 1: сравнивание обьектов с перегруженными операторами");
        var a = new Class("a", "b");
        var b = new Class("a", "b");
        Console.WriteLine("A: " + a + "\n" + "B: "+ b);
        Console.WriteLine("B==A -> "+(b==a));
        Console.WriteLine("A.Equals(B) -> "+a.Equals(b));
        Console.WriteLine("A!=B -> "+(a!=b)+"\n");

        //Task2
        Console.WriteLine("Task 2: сравнивание ручных массивов с перегруженными операторами");
        var obj1 = new Array(new [] { 1, 2, 3 });
        var obj2 = new Array(new [] { 4, 5, 6 });
        Console.WriteLine("o1: "+obj1);
        Console.WriteLine("o2: "+obj2);
        Console.WriteLine("o1>o2 -> "+(obj1 < obj2));         // Проверка суммы элементов
        Console.WriteLine("o2<o1 -> "+(obj1 > obj2));



        //Task3 
        Console.WriteLine("\nTask 3: класс Money");
        
        
        var money1 = new Money(100, "KZT");
        var money2 = new Money(75, "EUR");

        var sum = money1 + money2;
        Console.WriteLine($"Сумма: {sum.Amount} {sum.Currency}");

        Console.WriteLine("money1=money2: "+(money1 == money2));
        Console.WriteLine("money1!=money2: "+(money1 != money2));


        //Task 4 - 5

        Console.WriteLine("\nTask 4 - 5 собственный Decimal с перегруженными операторами");
        var array1 = new Array(new [] { 1, 2, 3 });
        var array2 = new Array(new [] { 4, 5, 6 });
        Console.WriteLine("Array1: " + array1);
        Console.WriteLine("Array2: " + array2);
        //todo Умножение
        var result = array1 * array2;
        Console.Write("Результат умножения: ");
        foreach (var item in result.array) Console.Write(item + " ");

        //todo Получение элемента по индексу
        Console.WriteLine("Получение элемента по индексу 0 "+array1[0]);

        //todo Сравнивание массивов
        var size = (int)array1;
        Console.WriteLine("\nРазмер первого массива: " + size);
        Console.WriteLine(array1 == array2);
        Console.WriteLine(array1 != array2);
        Console.WriteLine(array1 <= array2);
        Console.WriteLine(array1 >= array2);


        //todo Concat массивов
        var res = array1 + array2;
        Console.WriteLine("Обьеденение массивов: ");
        foreach (var i in res.array)
        {
            Console.Write(i + " ");
        }


        //Task6
        Console.WriteLine("\nTask 6 Проверка ручного Decimal ");
        var num1 = new Library.Decimal("10000002000000");
        var num2 = new Library.Decimal("20000003000000");
        Console.WriteLine($"num1 = {num1}");
        Console.WriteLine($"num2 = {num2}");

        Console.WriteLine("num1 < num2 :" + (num1 < num2));
        Console.WriteLine("num1 > num2 :" + (num1 > num2));
        Console.WriteLine("num1 >= num2 :" + (num1 >= num2));
        Console.WriteLine("num1 <= num2 :" + (num1 <= num2));

        //todo Арифметические операции
        Console.WriteLine("num2-num1="+(num2-num1));
        Console.WriteLine("num2+num1="+(num2+num1));
        Console.WriteLine("num2*num1="+(num2*num1));
        Console.WriteLine("num2/num1="+(num2/num1));


        //Task 7 todo комплексные числа сравнение производительности класса и структуры
        testComplexStructVsClass();
        
        //Task 8 todo тестируем структуру против класса Frac
        testFractStructVsClass();
    }

    private static void testComplexStructVsClass()
    {
        int iterations = 1000000;       // Количество итераций для теста
        Console.WriteLine("\nTask-7\nНачинаем тест структуры Комплекса против Класса Комплекса\n");
        ComplexStruct structA = new ComplexStruct(3.0, 4.0);
        ComplexStruct structB = new ComplexStruct(1.0, 2.0);

        ComplexClass classA = new ComplexClass(3.0, 4.0);
        ComplexClass classB = new ComplexClass(1.0, 2.0);

        // Тест производительности для ComplexStruct
        var structWatch = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            ComplexStruct result = structA + structB;
        }
        structWatch.Stop();
        Console.WriteLine($"Время для ComplexStruct: {structWatch.ElapsedMilliseconds} миллисекунд");
        
        // Тест производительности для ComplexClass
        var classWatch = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            ComplexClass result = classA + classB;
        }
        classWatch.Stop();
        Console.WriteLine($"Время для ComplexClass: {classWatch.ElapsedMilliseconds} миллисекунд");
        Console.WriteLine(
            structWatch.ElapsedMilliseconds > classWatch.ElapsedMilliseconds 
                ? "Класс быстрее на "+(structWatch.ElapsedMilliseconds-classWatch.ElapsedMilliseconds) + " мс " 
                : "Cтруктура быстрее на " + (classWatch.ElapsedMilliseconds - structWatch.ElapsedMilliseconds)+ " мс ");
    }
    private static void testFractStructVsClass()
    {
        Console.WriteLine("\nTask-8\nНачинаем тест структуры Fract против Класса Fract\n");
        
        
        int iterations = 1000000; // Количество итераций для теста

        Frac fracA = new Frac(1, 2);
        Frac fracB = new Frac(3, 4);

        // Тест производительности для класса Frac
        var classWatch = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            Frac result = fracA + fracB;
        }
        classWatch.Stop();
        Console.WriteLine($"Время для класса Frac: {classWatch.ElapsedMilliseconds} миллисекунд");


        FracStruct fracStructA = new FracStruct(1, 2);
        FracStruct fracStructB = new FracStruct(1,4);
        // Тест производительности для структуры FracStruct
        var structWatch = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            FracStruct result = fracStructA + fracStructB; // Аналогичный код для структуры
        }
        structWatch.Stop();
        Console.WriteLine($"Время для структуры FracStruct: {structWatch.ElapsedMilliseconds} миллисекунд");

        
        
        Console.WriteLine(
            structWatch.ElapsedMilliseconds > classWatch.ElapsedMilliseconds 
                ? "Класс быстрее на "+(structWatch.ElapsedMilliseconds-classWatch.ElapsedMilliseconds) + " мс " 
                : "Cтруктура быстрее на " + (classWatch.ElapsedMilliseconds - structWatch.ElapsedMilliseconds)+ " мс ");
    }
}