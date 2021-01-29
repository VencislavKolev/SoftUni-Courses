using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var priorityQueue = new OrderedBag<int>();

            foreach (var cookie in cookies)
            {
                priorityQueue.Add(cookie);
            }

            int count = 0;
            int currLeastSweetCookie = priorityQueue.GetFirst();

            while (currLeastSweetCookie < k && priorityQueue.Count > 1)
            {
                int firstLeastSweet = priorityQueue.RemoveFirst();
                int secondLeastSweet = priorityQueue.RemoveFirst();

                int combined = firstLeastSweet + 2 * secondLeastSweet;
                priorityQueue.Add(combined);

                currLeastSweetCookie = priorityQueue.GetFirst();
                count++;
            }

            return currLeastSweetCookie < k ? -1 : count;
        }
    }
}
