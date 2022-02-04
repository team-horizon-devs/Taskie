﻿namespace Taskie.Domain.Entities
{
    public class AchievementEntity : BaseEntityEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority1 { get; set; }
        public int Priority2 { get; set; }
        public int Priority3 { get; set; }
    }
}