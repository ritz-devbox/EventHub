using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventHub.Application.DTOs;

namespace EventHub.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventDto> CreateEventAsync(CreateEventRequest request);
        Task<EventDto> GetEventByIdAsync(Guid id);
        Task<EventDto> UpdateEventAsync(Guid id, UpdateEventRequest request);
        Task DeleteEventAsync(Guid id);
        Task<IEnumerable<EventDto>> GetAllEventsAsync();
    }
}
