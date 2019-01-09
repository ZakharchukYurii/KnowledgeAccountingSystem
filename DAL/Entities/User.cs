using System.Collections.Generic;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public IEnumerable<Area> KnowledgeAreas { get; set; }

        public User()
        {
            KnowledgeAreas = new List<Area>();
        }
    }
}
