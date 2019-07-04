using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Full Dll Path");
            string assemblyPath = Console.ReadLine();
            Console.WriteLine("Enter RunTime Class Name");
            string className = Console.ReadLine();
            Console.WriteLine("Enter Method Name in Class");
            string methodName = Console.ReadLine();
            // dynamically load assembly
            Assembly testAssembly =
            //  Assembly.LoadFile(@"D:\My Learnings\.Net Core\Calculator\bin\Debug\netcoreapp2.2\Calculator.dll");
            Assembly.LoadFile(@assemblyPath);
            // get type of class from just loaded assembly
            Type classType = testAssembly.GetType(className);
            // System.Console.WriteLine(testAssembly.ExportedTypes);

            // create instance of class Class
            object classInstance = Activator.CreateInstance(classType);

            // get info about property: public string Message
            // PropertyInfo messagePropertyInfo = calcType.GetProperty("Message");

            // // get value of property: public string Message
            // string value = (string)messagePropertyInfo.GetValue(calcInstance, null);
            // Console.WriteLine(value);
            // Get info about method
            MethodInfo methodInfo = classType.GetMethod(methodName);
            // Call Method
            methodInfo.Invoke(classInstance, null);

        }
    }
}
