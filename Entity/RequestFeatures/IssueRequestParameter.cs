using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.RequestFeatures
{
    public class IssueRequestParameter : RequestParameters
    {
        public List<IssueType>? IssueTypes { get; init; }
        public IssueStatus? IssueStatus { get; init; }

        public DateTime? MinCreatedAt { get; init; }
        public DateTime? MaxCreatedAt { get; init; }

      


    }
}
