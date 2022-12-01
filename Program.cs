using System;
using System.Diagnostics.Metrics;

namespace Top_Typing
{
    internal class Program
    {
        static int i = 0;
        //private static int count;
        static void Main()
        {
            Console.CursorVisible = false;
            string txt = "Вот тут текст короче для тестов ";
                //string txt = "Я в своем познании настолько преисполнился, что я как будто бы уже сто триллионов миллиардов лет проживаю на триллионах и триллионах таких же планет, как эта Земля, мне этот мир абсолютно понятен, и я здесь ищу только одного - покоя, умиротворения и вот этой гармонии, от слияния с бесконечно вечным, от созерцания великого фрактального подобия и от вот этого замечательного всеединства существа, бесконечно вечного, куда ни посмотри, хоть вглубь - бесконечно малое, хоть ввысь - бесконечное большое, понимаешь?";
            List<char> text = new(txt);
            int count = text.Count;

            for (int i = 0; i < (count); i++)
            {
                Console.SetCursorPosition(38, 13);
                Write(text);
            }
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

            text.RemoveAt(0);
            Console.WriteLine();
            /*if (i == count)
            {
                Environment.Exit(0);
            }*/
            IsItRight(text);
        }

        private static void IsItRight(List<char> text)
        {
            var key = Console.ReadKey(true);
            while (key.KeyChar != text[i])
            {
                key = Console.ReadKey(true);
            }
            //Write(text);
        }
    }
}