
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

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
            using (StreamReader r = new StreamReader(path))
            {
                string jsonInput = r.ReadToEnd();

                return JsonSerializer.Deserialize<T>(jsonInput, IgnoreCaseWhileParsing);
            }

        }
    }
}