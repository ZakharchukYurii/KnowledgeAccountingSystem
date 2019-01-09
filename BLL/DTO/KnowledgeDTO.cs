namespace BLL.DTO
{
    public class KnowledgeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int Rate { get; set; }

        public int AreaId { get; set; }
        public AreaDTO Area { get; set; }
    }
}
