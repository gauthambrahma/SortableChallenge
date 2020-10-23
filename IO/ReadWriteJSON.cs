using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System;
using System.Text;

namespace SortableChallenge
{
    public class ReadWriteJSON
    {
        private readonly JsonSerializerOptions IgnoreCaseWhileParsing = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public bool PrintResult(string jsonOutput)
        {
            Console.WriteLine(jsonOutput);
            return true;
        }

        public T ReadAndParseJSON<T>(string path)
        {
            return JsonSerializer.Deserialize<T>(ReadJSONTextFromFile(path), IgnoreCaseWhileParsing);
        }

        public List<T> ReadAndParseJSONList<T>()
        {

            return JsonSerializer.Deserialize<List<T>>(ReadJSONTextFromScreen(), IgnoreCaseWhileParsing);
        }

        private string ReadJSONTextFromFile(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                return r.ReadToEnd();
            }
        }

        private string ReadJSONTextFromScreen()
        {
            StringBuilder s = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                s.AppendLine(line);
            }
            return s.ToString();
        }
    }
}