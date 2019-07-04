using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Enter Full Dll Path");
            // string assemblyPath = Console.ReadLine();
            // Console.WriteLine("Enter RunTime Class Name");
            // string className = Console.ReadLine();
            // Console.WriteLine("Enter Method Name in Class");
            // string methodName = Console.ReadLine();
            InputJsonModel inputJsonModel;
            using (StreamReader r = new StreamReader("InputData/data.json"))
            {
                string json = r.ReadToEnd();
                inputJsonModel = JsonConvert.DeserializeObject<InputJsonModel>(json);
            }
            // dynamically load assembly
            Assembly testAssembly =
            //  Assembly.LoadFile(@"D:\My Learnings\.Net Core\Calculator\bin\Debug\netcoreapp2.2\Calculator.dll");
            Assembly.LoadFile(@inputJsonModel.DllPath);
            // get type of class from just loaded assembly
            Type classType = testAssembly.GetType(inputJsonModel.ClassName);
            // System.Console.WriteLine(testAssembly.ExportedTypes);

            // create instance of class Class
            object classInstance = Activator.CreateInstance(classType);

            // get info about property: public string Message
            // PropertyInfo messagePropertyInfo = calcType.GetProperty("Message");

            // // get value of property: public string Message
            // string value = (string)messagePropertyInfo.GetValue(calcInstance, null);
            // Console.WriteLine(value);
            // Get info about method
            foreach (var method in inputJsonModel.Methods)
            {
                MethodInfo methodInfo = classType.GetMethod(method.Name);
                // ParameterInfo[] parameters = methodInfo.GetParameters();
                // foreach (string param in method.Params)
                // {
                //     foreach (ParameterInfo parameter in parameters)
                //     {
                //         method.Params = Convert.ChangeType(param, parameter.ParameterType);
                //     }
                // }
                // Call Method
                var returnValue = methodInfo.Invoke(classInstance, method.Params);
                if (returnValue != null)
                    Console.WriteLine($"Return Value of {method.Name} is : {returnValue}");
            }
        }
    }
}
