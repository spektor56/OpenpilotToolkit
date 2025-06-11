using Cereal;
using System.Text;

namespace OpenpilotSdk.OpenPilot
{
    public sealed class Firmware
    {
        static string EncodeNonAsciiCharacters(byte[] value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in value)
            {
                if (c > 0x7E || c < 0x20)
                {
                    sb.Append($"\\x{c:x2}");
                }
                else
                {
                    sb.Append((char)c);
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
            var parsedVersion = EncodeNonAsciiCharacters(version);

            RawVersion = Convert.ToHexString(version);
            Ecu = ecu.ToString();
            Version = parsedVersion;
            Address = address;
            SubAddress = subAddress;
        }
    }
}
