using System;
using System.Collections.Generic;

namespace GameManagement.Domain
{
    public class UserInfo
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public DateTime TokenExp { get; set; }

        public IList<string> Roles { get; set; }
    }
}
