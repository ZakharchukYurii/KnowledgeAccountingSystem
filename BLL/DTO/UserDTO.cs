using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public IEnumerable<AreaDTO> KnowledgeAreas { get; set; }

        public UserDTO()
        {
            KnowledgeAreas = new List<AreaDTO>();
        }
    }
}
