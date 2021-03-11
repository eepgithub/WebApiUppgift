using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithAuth.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
    }
}
