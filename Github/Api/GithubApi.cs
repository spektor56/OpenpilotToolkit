using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.Api
{
    public class GithubApi
    {

        internal static string DevId = ""; // devKey goes here
        internal static string AuthKey = ""; // authKey goes here 

        private readonly RestClient _client = new RestClient("http://api.smitegame.com/smiteapi.svc/");
        

        public RestClient Client => _client;

        public GithubApi(string devId, string authKey)
        {
            DevId = devId;
            AuthKey = authKey;
            _session = CreateSession();
        }
        public static string Timestamp => DateTime.UtcNow.ToString("yyyyMMddHHmmss");

        public bool Connected => _session.Success;

        private Session CreateSession()
        {
            var request = new SmiteRequest("/createsessionjson/{developerId}/{signature}/{timestamp}");
            var result = _client.Execute(request).Content;
            var session = JsonConvert.DeserializeObject<Session>(result);
            return session;
        }

    }
}
