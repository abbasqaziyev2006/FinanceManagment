using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.DAL.DataContext.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }

 
}


