using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.User
{
    public class GetUserQuery : Notifiable<Notification>, IQuery
    {
        public void Execute()
        {
            
        }
    }
}
