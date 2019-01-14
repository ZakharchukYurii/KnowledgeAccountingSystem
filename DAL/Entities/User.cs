using System.Collections.Generic;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }

        public ICollection<Area> KnowledgeAreas { get; set; }

        public User()
        {
            KnowledgeAreas = new List<Area>();
        }
    }
}
