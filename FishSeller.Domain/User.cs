﻿namespace FishSeller.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long ChatId { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}