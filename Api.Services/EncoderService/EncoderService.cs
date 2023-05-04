using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.EncoderService
{
    public class EncoderService : IEncoderService
    {
        public async Task<string> EncodeTextToBase64Async(string text)
        {
            var data = ASCIIEncoding.ASCII.GetBytes(text);
            return Convert.ToBase64String(data);
        }
    }
}
