using System.Collections.Generic;

namespace DAL.Entities
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Knowledge> Knowledges { get; set; }

        public Area()
        {
            Knowledges = new List<Knowledge>();
        }
    }
}
