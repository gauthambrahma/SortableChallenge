using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace SortableChallenge
{
    public class ReadWriteJSON
    {
        private JsonSerializerOptions IgnoreCaseWhileParsing = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public bool WriteJSON()
        {
            //Todo: Implement
            return true;
        }

        public T ReadAndParseJSON<T>(string path)
        {
            return JsonSerializer.Deserialize<T>(ReadJSONText(path), IgnoreCaseWhileParsing);
        }

        public List<T> ReadAndParseJSONList<T>(string path)
        {

            return JsonSerializer.Deserialize<List<T>>(ReadJSONText(path), IgnoreCaseWhileParsing);
        }

        private string ReadJSONText(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                return r.ReadToEnd();
            }
        }
    }
}