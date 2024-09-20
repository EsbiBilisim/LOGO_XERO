using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obje.Hata
{
    public class Root
    {
        public string Message { get; set; }
        public Modelstate ModelState { get; set; }
    }
    public class Modelstate
    {
        [JsonProperty("_iDoCode.String")]
        public List<string> _iDoCodeString { get; set; }
        [JsonProperty("_iCyphCode.String")]
        public List<string> _iCyphCodeString { get; set; }

        [JsonProperty("_genExp4.String")]
        public List<string> _genExp4String { get; set; }

        [JsonProperty("_refs.String")]
        public List<string> _refsString { get; set; }

        [JsonProperty("LOError:")]
        public List<string> LOError { get; set; }
        public List<string> ValError0 { get; set; }
        public List<string> ValError1 { get; set; }
        public List<string> ValError2 { get; set; }
        public List<string> ValError3 { get; set; }
        public List<string> ValError4 { get; set; }
        public List<string> ValError5 { get; set; }
        public List<string> OtherError { get; set; }
        public List<string> DBError { get; set; }
    }

}
