using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenpilotToolkit.Models
{

    public class OpenpilotDevice
    {
        [Key]
        public IPAddress IpAddress { get; set; }
        public string SSHKey { get; set; }
    }
}
