using System;
using System.Collections.Generic;
using System.Text;

namespace GameManagement.Domain
{
    public class UserInfo
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public DateTime TokenExp { get; set; }
    }
}
