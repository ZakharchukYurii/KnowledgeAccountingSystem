namespace BLL.DTO
{
    public class KnowledgeRateDTO
    {
        public int Id { get; set; }
        public int Rate { get; set; }

        public int UserId { get; set; }
        public UserDTO User { get; set; }

        public int KnowledgeId { get; set; }
        public KnowledgeDTO Knowledge { get; set; }

        public int AreaId { get; set; }
        public AreaDTO Area { get; set; }
    }
}
