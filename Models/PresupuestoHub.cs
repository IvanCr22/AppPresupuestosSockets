using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AppPresupuestosSockets.Models
{
    public class PresupuestoHub : Hub
    {
        public async Task UnirseAlPresupuesto(string presupuestoId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, presupuestoId);
        }
    }
}