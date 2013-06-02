using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skype_Bot
{
    public class TempUser
    {
        public string handler;
        public int respect;
        public int voteKick;
        public List<string> voters = new List<string>();
        public List<string> respecters = new List<string>();

        public TempUser(string handler)
        {
            this.handler = handler;
        }
    }
}
