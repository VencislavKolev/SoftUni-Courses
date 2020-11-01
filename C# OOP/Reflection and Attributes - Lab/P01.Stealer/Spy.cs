
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P01.Stealer
{
    public class Spy
    {
        public Spy()
        {

        }
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType("P01.Stealer." + investigatedClass);
            //Type classType = typeof(Hacker);
            //Type classType = Type.GetType("Hacker");
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.NonPublic);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields
                .Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
