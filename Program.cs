using Spectre.Console;
using System.Diagnostics;

namespace Hz
{
    internal class Program
    {
        static int i = 0;
        private static int tscore = 0;
        private static int fscore = 0;

        private static bool timerSet = true;

        static void Main()
        {
            Console.CursorVisible = false;
            string txt = "Вот тут текст короче для тестов";
            //string txt = "Я в своем познании настолько преисполнился, что я как будто бы уже сто триллионов миллиардов лет проживаю на триллионах и триллионах таких же планет, как эта Земля, мне этот мир абсолютно понятен, и я здесь ищу только одного - покоя, умиротворения и вот этой гармонии, от слияния с бесконечно вечным, от созерцания великого фрактального подобия и от вот этого замечательного всеединства существа, бесконечно вечного, куда ни посмотри, хоть вглубь - бесконечно малое, хоть ввысь - бесконечное большое, понимаешь?";
            List<char> text = new(txt);
            int count = text.Count;

            Console.SetCursorPosition(37, 12);
            Console.WriteLine("-------------------------------------------");
            Console.SetCursorPosition(37, 13);
            Console.WriteLine("|");
            Console.SetCursorPosition(37, 14);
            Console.WriteLine("-------------------------------------------");
            Console.SetCursorPosition(79, 13);
            Console.WriteLine("|");

            Timer();

            Thread thread = new Thread(new ThreadStart(Panel));
            thread.Start();
            

            Thread.Sleep(10);
            for (int i = 0; i < (count) && timerSet != false; i++)
            {
                
                Console.SetCursorPosition(38, 13);
                Write(text);
            }
            Console.SetCursorPosition(38, 13);
            Console.WriteLine("                  ВСЁ!                   ");
            Console.ReadKey();
            Main();
        }

        private static void Write(List<char> text)
        {
            for (int i = 0; i < 41; i++)
            {
                if (i >= text.Count)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(text[i]);
                }
            }


            Console.WriteLine();
            IsItRight(text);
            text.RemoveAt(0);
        }

        private static void IsItRight(List<char> text)
        {
            var key = Console.ReadKey(true);
            while (key.KeyChar != text[i])
            {
                key = Console.ReadKey(true);
                fscore += 1;
            }

            tscore += 1;
        }

        private static void Panel()
        {
            while (timerSet)
            {
                Console.SetCursorPosition(0, 27);
                AnsiConsole.Write(new BreakdownChart()
                    .Width(60)
                    .AddItem("", fscore, Color.Red)
                    .AddItem("", tscore, Color.Green));
                Thread.Sleep(327);
            }
        }

        private static void Timer()
        {
            Thread t = new Thread(_ =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                while (stopwatch.ElapsedMilliseconds/1000 < 60)
                {
                    Console.SetCursorPosition(0,0);
                    Console.WriteLine(stopwatch.ElapsedMilliseconds/1000);
                    Thread.Sleep(6000);
                }

                timerSet = false;
                Console.SetCursorPosition(38, 13);
                Console.WriteLine("                  ВСЁ!                   ");
            });

            t.Start();
        }
    }
}