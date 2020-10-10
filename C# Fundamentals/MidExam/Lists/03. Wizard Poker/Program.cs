using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Wizard_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(':').ToList();
            List<string> newDeck = new List<string>();
            string input = "";
            while ((input = Console.ReadLine()) != "Ready")
            {
                string[] tokens = input.Split();
                string action = tokens[0];
                if (action == "Shuffle")
                {
                    newDeck.Reverse();
                    continue;
                }
                string cardName = tokens[1];
                if (action == "Add")
                {
                    if (cards.Contains(cardName))
                    {
                        newDeck.Add(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(tokens[2]);
                    if ((!cards.Contains(cardName)) || (!IsValidIndex(newDeck, index)))
                    {
                        Console.WriteLine("Error!");
                    }
                    else
                    {
                        newDeck.Insert(index, cardName);
                    }
                }
                else if (action == "Remove")
                {
                    if (newDeck.Contains(cardName))
                    {
                        newDeck.Remove(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (action == "Swap")
                {
                    string secondCardName = tokens[2];
                    int indexFirstCard = newDeck.IndexOf(cardName);
                    int indexSecondCard = newDeck.IndexOf(secondCardName);

                    newDeck.RemoveAt(indexSecondCard);
                    newDeck.Insert(indexFirstCard, secondCardName);
                    newDeck.Insert(indexSecondCard, cardName);
                    newDeck.Remove(cardName);
                }
            }
            Console.WriteLine(string.Join(" ", newDeck));
        }
        static bool IsValidIndex(List<string> deck, int index)
        {
            if (index >= 0 && index < deck.Count)
            {
                return true;
            }
            return false;
        }
    }
}
