using LoopUp.Data;
using LoopUp.Services;
using System;

namespace LoopUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter E.164 phone number");

            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber = Console.ReadLine();
            var formattedNumber = formattingService.FormatPhoneNumber(unformattedNumber);

            Console.WriteLine($"your formatted phone number is {formattedNumber}.");

            Console.ReadLine();
        }
    }
}
