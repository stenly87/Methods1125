using System.Text.Json;
using System.Text.Json.Serialization;

namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {/*
            int a = 10;
            Test1(ref a);
            Console.WriteLine(a); // в переменной осталось
            // значение, полученное ей в методе

            Test2(out a); // можно так
            Test2(out int b); // или так
            Console.WriteLine(a);
            Console.WriteLine(b);

            Test3(1,2,3,4,5,6,7,8,9); // агрументы будут свернуты
            // в один массив за счет слова params

            Test4(); // вызов без аргументов

            Test5(10); // необязательный аргумент пропущен
            Test5(10, 100); // y назначен

            Test6(0);

            Action<int> action = Test6;
            action(10);// вызов метода через делегает
            Func<int, int, int> func = Sum;
            var result = func(10, 10); // вызов метода через делегает

            Action action1 = () => Console.WriteLine("лямбда");
            Func<int> func2 = () => 10 + 10;
            args = new string[] { "привет", "привет", "мир" };
            var resultArray = args.Where(s => s == "привет");
            // в resultArray будет 2 ячейки со значением "привет"
            // то же самое без лябмд
            List<string> strings = new List<string>();
            for(int i =0; i < args.Length; i++) 
            {
                if (args[i] == "привет")
                    strings.Add(args[i]);
            }
            resultArray = strings;

            int[] array = new int[] { 1, 2, 33, 4, 56, 6, 7, 89, 895, 54 };
            int max = array.Max();
            int min = array.Min();
            int[] chetnie = array.Where(s => s % 2 == 0).ToArray();
            int countChetnie = array.Count(s => s % 2 == 0);
            int firstNegative = array.FirstOrDefault(s => s < 0);
            */

            // Тема 6.1 Задание 1
            // кортеж это анонимный тип данных, состоящий из нескольких
            // значений
            (int, int) A, B, C;
            A = InputPoint();
            B = InputPoint();
            C = InputPoint();
            double ab, bc, ac;
            ab = CalcSide(A, B);
            bc = CalcSide(B, C);
            ac = CalcSide(A, C);
            double p = (ab + bc + ac) / 2;
            double s = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
            Console.WriteLine(s);
        }

        private static double CalcSide((int x, int y) a, (int x, int y) b)
        {
            return Math.Sqrt(Math.Pow(b.x - a.x, 2)+ Math.Pow(b.y - a.y, 2));
        }

        static (int, int) InputPoint()
        {
            (int, int) result;
            Console.WriteLine("Введите х");
            int.TryParse(Console.ReadLine(), out result.Item1);
            Console.WriteLine("Введите y");
            int.TryParse(Console.ReadLine(), out result.Item2);
            return result;
        }

        // void - означает, что метод не возвращает результат

        static int Sum(int x, int y)
        {
            if (x > 0)
                return x + y;
            return x - y;
        }
        // если метод имеет тип, отличный от void,
        // то любой исход метода должен завершаться 
        // возвратом значения с помощью return
        // возвращаемое значение должно соответствовать
        // указанному типу метода
        // в ООП есть разные подходы к использованию 
        // методов, один из них гласит, что следует
        // создавать методы либо с аргументами, либо
        // с типом возвращаемого значения
        // Любые подходы рекомендуют создавать методы
        // которые выполняют одну задачу

        // ref - позволяет передать переменную в виде
        // ссылки, это означает, что переменная сохранит
        // значение из метода (если будет изменена в 
        // методе)
        static void Test1(ref int x)
        {
            x = 100;
        }

        // out - позволяет передать значение через аргумент
        // из метода в окружающий код
        static void Test2(out int x)
        {
            // аргументы, помеченные out, обязательно
            // должны получить значение внутри метода
            x = -100;
        }

        // params - указывается только для последнего аргумента
        // требует массив. Такой метод можно вызвать с любым
        // кол-вом аргументов заданного типа
        static void Test3(params int[] x)
        {// вывод массива, сериализованного в формат json
            Console.WriteLine(JsonSerializer.Serialize(x));
        }

        // если аргументов нет, то метод все равно вызывается
        // с указанием скобок, например Test4()
        static void Test4() { }
        // аргументы могут иметь значение по умолчанию
        // в таком случае, аргументы со значением должны быть
        // в конце списка аргументов
        // значение по умолчанию используется, если методу
        // при вызыве не был передан соответствующий аргумент
        static void Test5(int x, int y = 10)
        { 
            Console.WriteLine($"{x} {y}");
        }

        // методы можно объявить только внутри класса

        // метод может вызывать сам себя, это называется
        // рекурсия. Рекурсия должна завершаться как можно
        // раньше, либо произойдет переполнение стека
        static void Test6(int x)
        {
            if (x < 10) // ограничение на кол-во рекурсий
                Test6(++x); // рекурсивный вызов
            Console.WriteLine(x);
        }

        // лямбда-выражения
        // делегаты в c#
        //Action<> 
        //Func<>
        // лямда-выражение это сокращенный вариант метода
        // без имени, использующийся через делегаты
        // общий синтаксис
        // аргумент => значение;
        // () => Console.WriteLine("лямбда");
    }
}