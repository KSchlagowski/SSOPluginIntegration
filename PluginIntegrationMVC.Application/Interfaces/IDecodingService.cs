using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginIntegrationMVC.Application.Interfaces
{
    public interface IDecodingService
    {
        //string EncodeStringToHex(String input, System.Text.Encoding encoding);
        string EncodeStringToHex(String input);
        string DecodeHexToString(String hexInput);
    }
}
