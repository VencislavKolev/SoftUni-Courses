
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P04.Collector
{
    public class Spy
    {
        public Spy()
        {

        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType("P04.Collector." + className);
            MethodInfo[] methodInfos = classType.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.NonPublic);

            foreach (MethodInfo getter in methodInfos
                .Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }
            foreach (MethodInfo setter in methodInfos
                .Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
