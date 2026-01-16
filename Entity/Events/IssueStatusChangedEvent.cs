using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;
using MediatR;

namespace Entity.Events
{
    public record IssueStatusChangedEvent(string UserId, IssueType Type, IssueStatus Status, DateTime? LastUpdatedAt) : INotification
    {
    }
}
