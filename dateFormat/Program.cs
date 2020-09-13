using System;

namespace dateFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            Console.WriteLine("1. {0:M}, {0:yyyy}",today);
            Console.WriteLine("1. {0:MMMM, dd}, {0:yyyy}",today);
            Console.WriteLine("2. {0:yyyy}.{0:MM}.{0:dd}",today); //2019.01.22
            Console.WriteLine("3. Day {0:dd} of {0:MMMM}, {0:yyyy}",today); //Day 22 of January, 2019
            Console.WriteLine("4. Year:{0:yyyy},Month:{0:MM},Day:{0:dd}",today); //Year:2019,Month:01,Day:22
            Console.WriteLine("5. {0:dddd}",today); //Tuesday
            Console.WriteLine("6. {0:hh}:{0:mm}{0:tt}",today); //11:01PM
            Console.WriteLine("7. h:{0:hh},m:{0:mm},s:{0:ss}",today); //h:11,m:01,s:27
            Console.WriteLine("8. {0:yyyy}.{0:MM}.{0:dd}.{0:hh}.{0:mm}.{0:ss}",today); //2019.01.22.11.01.27

            //interpilation use $ to put code into a string
            Console.WriteLine($"1. {today:MMMM, dd, yyyy}");
            Console.WriteLine($"2. {today:yyyy, MM, dd}");
            Console.WriteLine($"3. Day {today:dd} of {today:MMMM, yyyy}");
            Console.WriteLine($"4. Year:{today:yyyy}, Month:{today:MM},Day:{today:dd}");
            Console.WriteLine($"5. {today:dddd}");
            Console.WriteLine($"6. {today:hh:mmtt}");
            //Console.WriteLine($"7. {today:M yyyy}");
            //Console.WriteLine($"8. {today:M yyyy}");
        }
    }
}
