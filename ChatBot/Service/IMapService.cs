using ChatBot.Models;
using System.Collections;
using System.Collections.Generic;

namespace ChatBot.Service
{
    public interface IMapService
    {
        public List<Map> Maps { get; set; }
        public void SaveChanges();
        public void Update(Map map);

    }
}
