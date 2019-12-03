using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace InputHelper
{
    public static class InputService
    {
        public static List<string> GetDataFromResource(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var path = $"InputHelper.Inputs.{fileName}";
            var file = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);

            var result = new List<string>();
            using (var stream = new StreamReader(file))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }

            return result;
        }
    }
}
