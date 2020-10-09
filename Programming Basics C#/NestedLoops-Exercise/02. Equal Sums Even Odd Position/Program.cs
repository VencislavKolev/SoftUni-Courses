using System;

namespace _02._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine()); // 6 цифрено число
            int end = int.Parse(Console.ReadLine());    // 6 цифрено число
            for (int i = start; i <= end; i++)
            {
                int number = i;
                bool isEven = true;
                int evenSum = 0;
                int oddSum = 0;

                int temp = number;   //временна променлива със стойност самото число
                while (temp>0)
                {
                    int digit = temp % 10; //взимаме последната цифра от числото
                    temp /= 10; //и я премахваме като разделим на 10
                    if (isEven)
                    {
                        evenSum += digit; //добавяме последната цифра на четна позиция от числото
                        isEven = false;
                    }
                    else
                    {
                        oddSum += digit; //добавяме последната цифра на нечетна позиция от числото
                        isEven = true;
                    }
                }
                if (evenSum==oddSum)
                {
                    Console.Write(number + " "); 
                }
            }
        }
    }
}
