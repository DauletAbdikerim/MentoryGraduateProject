using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Domain.Core
{
    public class Order
    {
        public Guid Id { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}
