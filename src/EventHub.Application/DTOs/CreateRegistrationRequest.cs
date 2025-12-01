using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.DTOs
{
    public class CreateRegistrationRequest
    {
        public Guid EventId { get; set; }
        public Guid ParticipantId { get; set; }
    }
}
