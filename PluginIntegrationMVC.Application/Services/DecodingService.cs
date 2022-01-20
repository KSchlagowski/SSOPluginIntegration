using PluginIntegrationMVC.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginIntegrationMVC.Application.Services
{
    public class DecodingService : IDecodingService
    {
        //This code was copied, but it turned out that's not working as expected
        //http://nullskull.com/faq/834/convert-string-to-hex-and-hex-to-string-in-net.aspx
        //public string EncodeStringToHex(String input, System.Text.Encoding encoding)
        //{
        //    Byte[] stringBytes = encoding.GetBytes(input);
        //    StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
        //    foreach (byte b in stringBytes)
        //    {
        //        sbBytes.AppendFormat("{0:X2}", b);
        //    }
        //    return sbBytes.ToString();
        //}

        public string EncodeStringToHex(string input)
        {
            string output = string.Empty;
            char[] values = input.ToCharArray();
            foreach (char letter in values)
            {
                int value = Convert.ToInt32(letter);
                output += $"{value:X}";
            }

            return output;
        }

        public string DecodeHexToString(string hexInput)
        {
            string output = string.Empty;

            float i = 1;
            string hex = string.Empty;
            foreach (char hexChar in hexInput)
            {
                hex += hexChar.ToString();
                if (i%2 == 0)
                {
                    int value = Convert.ToInt32(hex, 16);
                    char charValue = (char)value;
                    output += charValue.ToString();
                    hex = string.Empty;
                }
                i++;
            }
            return output;
        }
    }
}
