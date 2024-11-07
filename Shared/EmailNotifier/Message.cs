using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EmailNotifier
{
    public class Message
    {
        public List<string> To { get; set; } = new List<string>();
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FileName { get; set; }
        public byte[] FileBytes { get; set; }

        //constructor
        public Message(List<string> to, string subject, string body = null, string fileName = null, byte[] filebytes = null)
        {
            To = to;
            Subject = subject;
            Body = body;
            FileName = fileName;
            FileBytes = filebytes;

        }
    }
}
