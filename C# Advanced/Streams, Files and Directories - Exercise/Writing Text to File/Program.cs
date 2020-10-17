using System;
using System.IO;
using System.Text;

namespace Writing_Text_to_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Кирилица";
            // First option
            using (FileStream fs = new FileStream("log.txt", FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                fs.Write(buffer, 0, buffer.Length);
            }
            // Second option
            FileStream fileStream = new FileStream("../../../log.txt", FileMode.Create);
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                fileStream.Write(bytes, 0, bytes.Length);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
