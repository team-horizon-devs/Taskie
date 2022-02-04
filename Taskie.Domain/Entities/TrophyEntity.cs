namespace Taskie.Domain.Entities
{
    public class TrophyEntity : BaseEntityEntity

    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PricePoints { get; set; }
    }
}
