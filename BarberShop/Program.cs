using System;

namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            var seats = new List<string>();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key != ConsoleKey.Spacebar) break;

                var dice = GenerateRandomNum();
                
                if (dice == 0)
                {
                    if (seats.Count == 0) continue;
                    var removedClient = seats[0];
                    seats.RemoveAt(0);
                    seats = seats.GetRange(0, seats.Count);
                    DisplayEvent(dice,EventSymbols.Decrement,removedClient,seats);
                }
                else if (dice == 1)
                {
                    Console.WriteLine("VIP Entered");
                }
                else if (dice == 2 || dice == 3)
                {
                    Console.WriteLine("Ordinary Entered");
                }
            }
        }
        private static int GenerateRandomNum()
        {
            Random rand = new Random();
            return rand.Next(0, 4);
        }

        private static void DisplayEvent(int dice,string eventSymbol,string clientName,List<string> seats)
        {
            Console.WriteLine($"{dice} ---->    ( {eventSymbol} {clientName} )     {seats}");
        }

        public static class EventSymbols
        {
            public static string Increment = "++";

            public static string Decrement = "--";

            public static string Nothing = "+-";
        }
    }
}



