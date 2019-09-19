using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {


            //Implication(); // импликация

            //Scops(); // укороченные логические операции

            //SideEffect(); // продемонстрировать действие побочных эффектов

            //MakeEven(); // сброс младшего разряда двоичного числа

            ShowBits(); // показать биты, составляющие байт

            Console.ReadKey(); // задержка консоли

             
        }
        //------------ Функции
        // импликация
        public static void Implication()
        {

            bool p = false, q = false;
            int i, j;

            for (i = 0; i < 2; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    if (i == 0) p = true;
                    if (i == 1) p = false;
                    if (j == 0) q = true;
                    if (j == 1) q = false;

                    Console.WriteLine("р равно " + p + ", q равно " + q);

                    if (!p | q)
                        Console.WriteLine("результат импликации " + p + " и " + q + " равен " + true);

                    Console.WriteLine();
                }
            }

        }

        // укороченные логические операторы
        public static void Scops()
        {
            int n, d;

            n = 10;
            d = 2;
            if (d != 0 && (n % d) == 0)
                Console.WriteLine(n + " делиться нацело на " + d);

            d = 0; // задать нулевое значение d

            // d = 0 поэтому второй операнд не вычисляется
            if (d != 0 && (n % d) == 0)
                Console.WriteLine(n + " делиться нацело на " + d);

            // если теперь сделать тоже самое без укороченного
            // логического оператора, то возникнет ошибка из-за деления на ноль
            try
            {
                if (d != 0 & (n % d) == 0)
                    Console.WriteLine(n + " делиться нацело на " + d);
            } 
             catch(DivideByZeroException e){

                 Console.WriteLine("Ошибка деления на ноль :" + e);
                  
             }
            
            

        } // Scops

        // продемонстрировать действие побочных эффектов
        public static void SideEffect()
        {
            int i;
            bool someCondition = false;

            i = 0;
            // Значение i инкрементируется
            // несмотря на то, что опертор if не выполняется
            if (someCondition & (++i < 100))
                Console.WriteLine("Не выводиться");
            Console.WriteLine("Опеатор if выполняется : " + i); // выводиться 1
             
            // В данном случае значение i не инкрементируется
            // поскольку инкремент в укороченном операторе опускается
            if (someCondition && (++i < 100))
                Console.WriteLine("Не выводиться");
            Console.WriteLine("Оператор if выполняется : " + i); // по прежнему 1 


        }

        // сброс младшего разряда двоичного числа
        public static void MakeEven()
        {
            ushort num;
            ushort i;

            for (i = 0; i <= 10; i++)
            {
                num = i;

                Console.WriteLine("num = " + num);
                // 0xFFFE в двоичном виде = 1111 1111 1111 1110
                // поразрядная операция И оставляет оставляет без изменений
                // все двоичные разряды в числовом значении переменной num,
                // кроме младшего разряда, который сбрасывается в нуль.
                // В итоге четные числа не претерпивают никаких изменений,
                // а нечетные уменьшаются на 1 и становятся четными
                num = (ushort)(num & 0xFFFE);

                Console.WriteLine("После сброса младшего разряда: " + num + "\n");

            }

        }

        // показать биты, составляющие байт
        public static void ShowBits()
        {
            int t;
            byte val;
            

            val = 123;
            for (t = 128; t > 0; t = t / 2)
            {
                if ((val & t) != 0) Console.Write("1");
                if ((val & t) == 0) Console.Write("0");
            }

          
        }



    }
     
}
