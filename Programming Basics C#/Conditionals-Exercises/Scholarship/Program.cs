using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine()); // четем доход от конзолата
            double grade = double.Parse(Console.ReadLine()); // четем среден успех от конзолата
            double minimalSalary = double.Parse(Console.ReadLine()); // четем минимална работна заплата от конзолата

            double minGradeSocial = 4.50; // минимален успех за социална стипендия
            double minGradeExcellent = 5.50; // минимален успех за отлична стипендия
            double coefficient = 25.0; // коефицент
            double socialScholarship, excellenScholarship; // празни променливи, които ще ползваме по-надолу

            bool enoughMoney = (income < minimalSalary); // boolean който дава true, ако дохода е по-малък от минималната работна заплата, или false ако това не е вярно
            bool canGetSocialScholarship = (enoughMoney && grade >= minGradeSocial); // boolean който дава true, ако можем да вземем социална стипендия, в противен случай, false
            bool canGetExcellentScholarship = (grade >= minGradeExcellent); // boolean който дава true, ако можем да вземем отлична стипендия, в противен случай, false
            bool cannotGetBoth = (!canGetSocialScholarship && !canGetExcellentScholarship); // boolean който дава true, ако не можем да вземем социалната стипендия и отличната стипендия, в противен случай, false

            if (canGetSocialScholarship) // ако можем да вземем социална стипендия
                socialScholarship = Math.Floor(0.35 * minimalSalary); //социална стипендия 35% от минималната работна заплата, закръглена до по-малкото цяло число
            else
                socialScholarship = 0;

            if (canGetExcellentScholarship) // ако можем да вземем отличната стипендия
                excellenScholarship = Math.Floor(grade * coefficient); // стипендия за отличен успех, закръглена до по-малкото цяло число
            else
                excellenScholarship = 0;

            if (cannotGetBoth) // ако не можем да вземем 2-те стипендии
                Console.WriteLine("You cannot get a scholarship!");
            else if (socialScholarship > excellenScholarship) // ако социалната стипендия е по-голяма от отличната, тогава ученикът получава по-голямата сума
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            else // ако ли не, получава отличната стипендия
                Console.WriteLine($"You get a scholarship for excellent results {excellenScholarship} BGN");

        }
    }
}