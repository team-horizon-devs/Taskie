namespace Taskie.Domain.Entities
{
    class Trophy : BaseEntity

    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PricePoints { get; set; }
    }
}
