using System;

namespace Finance.BLL.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}