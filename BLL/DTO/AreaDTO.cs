using System.Collections.Generic;

namespace BLL.DTO
{
    public class AreaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<KnowledgeDTO> Knowledges { get; set; }

        public AreaDTO()
        {
            Knowledges = new List<KnowledgeDTO>();
        }
    }
}
