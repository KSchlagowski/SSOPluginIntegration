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
                    //string stringValue = Char.ConvertFromUtf32(value);
                    char charValue = (char)value;
                    //Console.WriteLine("hexadecimal value = {0}, int value = {1}, char value = {2} or {3}",
                    // hex, value, stringValue, charValue);
                    output += charValue.ToString();
                    hex = string.Empty;
                }
                i++;
            }
            return output;
        }
    }
}
