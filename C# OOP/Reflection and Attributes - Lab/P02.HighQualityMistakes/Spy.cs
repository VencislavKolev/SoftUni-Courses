
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P02.HighQualityMistakes
{
    public class Spy
    {
        public Spy()
        {

        }

        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType("P02.HighQualityMistakes." + className);
            FieldInfo[] privateFields = classType.GetFields(
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.Static);

            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance |
               BindingFlags.Public);

            MethodInfo[] classNonPublicMethods = classType.GetMethods(
                BindingFlags.Instance |
                BindingFlags.NonPublic);

            foreach (FieldInfo field in privateFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo privateMethod in classNonPublicMethods
               .Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{privateMethod.Name} have to be public!");
            }
            foreach (MethodInfo publicMethod in classPublicMethods
                .Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethod.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
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
