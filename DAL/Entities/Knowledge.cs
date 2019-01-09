namespace DAL.Entities
{
    public class Knowledge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int Rate { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
