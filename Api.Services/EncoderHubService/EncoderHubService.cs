using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.EncoderHubService
{
    public class EncoderHubService: Hub<IEncoderHubService>
    {
        public async Task SendEncodedTextAsync(string text)
        {
            await Clients.All.SendEncodedTextAsync(text);
        }
    }
}
