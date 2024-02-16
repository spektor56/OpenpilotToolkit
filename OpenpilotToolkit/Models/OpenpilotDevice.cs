using System.ComponentModel.DataAnnotations;
using System.Net;

namespace OpenpilotToolkit.Models
{

    public class OpenpilotDevice
    {
        [Key]
        public IPAddress IpAddress { get; set; }
        public string SSHKey { get; set; }
    }
}
