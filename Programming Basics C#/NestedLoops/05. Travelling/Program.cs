using System;

public class Program
{
	public static void Main()
	{
		string destination = "";
		while ((destination = Console.ReadLine()) != "End")
		{
			decimal minimalBuget = decimal.Parse(Console.ReadLine());
			while (minimalBuget > 0)
			{
				decimal savedMoney = decimal.Parse(Console.ReadLine());
				minimalBuget -= savedMoney;
			}
			Console.WriteLine("Going to {0}!", destination);
		}
	}
}