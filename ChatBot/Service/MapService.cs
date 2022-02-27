using ChatBot.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ChatBot.Service
{
    public class MapService : IMapService
    {
        public List<Map> Maps { get; set; }
        public MapService()
        {
            try
            {
                string fileName = "Resources\\Maps.json";
                string jsonString = File.ReadAllText(fileName);
                Maps = JsonSerializer.Deserialize<List<Map>>(jsonString);
            }
            catch
            {
                using (File.Create("Resources\\Maps.json"))
                { };
                Maps = new List<Map>();
                Normalize();
            }

        }
        public void SaveChanges()
        {
            Normalize();

            string fileName = "Resources\\Maps.json";
            string jsonString = JsonSerializer.Serialize(Maps);
            File.WriteAllText(fileName, jsonString);
        }

        public void Update(Map map)
        {
            var tmp = Maps.FirstOrDefault(x => x.Id == map.Id);
            if (tmp != null)
                Maps.Remove(tmp);

            Maps.Add(map);
        }


        void Normalize()
        {
            for (int i = 0; i < Maps.Count; i++)
            {
                Maps[i].Id = i + 1; 
            }
        }
    }
}
