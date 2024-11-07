using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Extension
{
    public static class EmailTemplate
    {
        private static object synclock = new object();
        
        /// </summary>
        /// <param name="messageTemplate">The Message template formatted with tokens</param>
        /// <param name="tokens">A collection of tokens to use for replacement.</param>
        /// <returns>A parsed string.</returns>
        public static string ParseTemplate(this string messageTemplate, Dictionary<string, string> tokens)
        {
            lock (synclock)
            {
                //tokens may be in format {Email} or {Amount:n} or {VCN:n|Mask:x,3,4}
                foreach (KeyValuePair<string, string> item in tokens)
                {
                    messageTemplate = messageTemplate.Replace(item.Key, item.Value);
                }
                return messageTemplate;
            }
        }
    }
}
