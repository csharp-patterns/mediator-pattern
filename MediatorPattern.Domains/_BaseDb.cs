using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediatorPattern.Domains
{
    public abstract class BaseDb
    {
        [Required]
        public int Id { get; set; }
    }
}
