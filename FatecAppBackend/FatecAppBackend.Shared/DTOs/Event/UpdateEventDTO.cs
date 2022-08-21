using FatecAppBackend.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Shared.DTOs.Event
{
    public class UpdateEventDTO
    {
        public UpdateEventDTO(Guid id, string? from, string? to, string? route, bool? onlyWomen, DateTime? timeToGo, EnStatus? status)
        {
            Id = id;
            From = from;
            To = to;
            Route = route;
            OnlyWomen = onlyWomen;
            TimeToGo = timeToGo;
            Status = status;
        }

        public Guid Id { get; private set; }

        public string? From { get; private set; }

        public string? To { get; private set; }

        public string? Route { get; private set; }

        public bool? OnlyWomen { get; private set; }

        public DateTime? TimeToGo { get; private set; }

        public EnStatus? Status { get; private set; }
    }
}
