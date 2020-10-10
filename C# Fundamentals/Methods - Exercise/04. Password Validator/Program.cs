using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            if (IsValidLength(password) == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (IsLettersAndDigit(password) == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (IsAtleastTwoDigits(password) == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (IsValidLength(password) && IsLettersAndDigit(password) && IsAtleastTwoDigits(password))
            {
                Console.WriteLine("Password is valid");
            }
        }
        static bool IsValidLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }
        static bool IsLettersAndDigit(string password)
        {
            foreach (char symbol in password)
            {
                //Ако не е число или буква
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }
        static bool IsAtleastTwoDigits(string password)
        {
            int digitCounter = 0;
            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digitCounter++;
                }
            }
            return digitCounter >= 2;
        }
    }
}
