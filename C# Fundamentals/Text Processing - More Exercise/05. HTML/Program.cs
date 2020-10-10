using System;
using System.Text;

namespace _05._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();

            string title = Console.ReadLine();
            string content = Console.ReadLine();
            text.Append("<h1>" + Environment.NewLine);
            text.Append("   " + title + Environment.NewLine);
            text.Append("</h1>" + Environment.NewLine);
            text.Append("<article>" + Environment.NewLine);
            text.Append("   " + content + Environment.NewLine);
            text.Append("</article>" + Environment.NewLine);
            string comments = "";
            while ((comments = Console.ReadLine()) != "end of comments")
            {
                text.Append("<div>" + Environment.NewLine);
                text.Append("   " + comments + Environment.NewLine);
                text.Append("</div>" + Environment.NewLine);
            }
            Console.WriteLine(text);
        }
    }
}
