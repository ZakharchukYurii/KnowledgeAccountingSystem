namespace DAL.Entities
{
    public class KnowledgeRate
    {
        public int Id { get; set; }
        public int Rate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int KnowledgeId { get; set; }
        public Knowledge Knowledge { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
