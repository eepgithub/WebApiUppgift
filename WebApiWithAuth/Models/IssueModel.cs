using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithAuth.Models
{
    public class IssueModel
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string status { get; set; }
    }
}
