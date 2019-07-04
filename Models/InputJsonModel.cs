using System.Collections.Generic;

namespace Reflection
{
    public class InputJsonModel
    {
        public string DllPath { get; set; }
        public string ClassName { get; set; }
        public ICollection<MethodModel> Methods { get; set; } = new List<MethodModel>();
    }
}