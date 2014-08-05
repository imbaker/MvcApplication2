namespace MvcApplication2.Database.Entities
{
    public class Link : BaseEntity
    {
        public int Id { get; set; }
        public Application ToApplication { get; set; }
        public string LinkType { get; set; }
    }
}