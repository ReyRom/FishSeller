using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishSeller.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Fish Fish { get; set; }
        public double Amount { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
