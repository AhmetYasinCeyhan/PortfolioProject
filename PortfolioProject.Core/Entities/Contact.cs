using System;

namespace PortfolioProject.Core.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime SubmitDate { get; set; } = DateTime.Now;
        public string IpAddress { get; set; }
        public string Response { get; set; }
        public DateTime? ResponseDate { get; set; }
    }
}
