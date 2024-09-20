using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjeToken.Sonuc
{

    public class Rootobject
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string asclient_id { get; set; }
        public string userName { get; set; }
        public string firmNo { get; set; }
        public string sessionId { get; set; }
        public string dbName { get; set; }
        public string logoDB { get; set; }
        public string isLoginEx { get; set; }
        public string isLogoPlugin { get; set; }
        public string idmToken { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }
    }

}
