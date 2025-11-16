using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern.Domains
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
