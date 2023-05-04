using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.EncoderHubService
{
    public interface IEncoderHubService
    {
        Task SendEncodedTextAsync(string text);
    }
}
