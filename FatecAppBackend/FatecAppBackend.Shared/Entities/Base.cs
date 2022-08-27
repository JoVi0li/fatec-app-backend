using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Shared
{
    public abstract class Base : Notifiable<Notification>
    {
        public Base()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
