using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cereal;

namespace OpenpilotSdk.OpenPilot
{
    public class Firmware
    {
        static string EncodeNonAsciiCharacters(string value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (c > 126 || c < 32)
                {
                    string encodedValue = "\\x" + ((long)c).ToString("x2");
                    sb.Append(encodedValue);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public string Ecu { get; set; }
        public string Version { get; set; }
        public string RawVersion { get; set; }
        public uint Address { get; set; }
        public byte SubAddress { get; set; }

        public Firmware(CarParams.Ecu ecu, byte[] version, uint address, byte subAddress)
        {
            var unparsedVersion = Encoding.UTF8.GetString(version);
            var parsedVersion = unparsedVersion.Replace("\'", "\\x27")
                .Replace("\"", "\\x22")
                .Replace("\\", "\\x5C")
                .Replace("\0", "\\x00")
                .Replace("\a", "\\x07")
                .Replace("\b", "\\x08")
                .Replace("\f", "\\x0C")
                .Replace("\n", "\\x0A")
                .Replace("\r", "\\x0D")
                .Replace("\t", "\\x09")
                .Replace("\v", "\\x0B");
            parsedVersion = EncodeNonAsciiCharacters(parsedVersion);
            
            RawVersion = BitConverter.ToString(version);
            Ecu = ecu.ToString();
            Version = parsedVersion;
            Address = address;
            SubAddress = subAddress;
        }
    }
}
