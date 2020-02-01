using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAuth.Util
{
    public interface IHttpWrapper
    {
        Task<string> Get(string Url, List<KeyValuePair<string, string>> Headers = null);
        Task<string> Post(string Url, object body, List<KeyValuePair<string, string>> Headers = null);
        Task<string> Put(string Url, object body, List<KeyValuePair<string, string>> Headers = null);
        Task<string> Delete(string Url, List<KeyValuePair<string, string>> Headers = null);
    }
}
