
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P03.MissionPrivateImpossible
{
    public class Spy
    {
        public Spy()
        {

        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType("P03.MissionPrivateImpossible." + className);
            MethodInfo[] nonPublicMethods = classType.GetMethods(
                BindingFlags.Instance |
                BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {className}")
                .AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in nonPublicMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
