using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestApprovalApp
{
    public class request
    {
        public int reqid { get; set; }
        public string reqdesc { get; set; }
        public string emailid { get; set; }
        public string reqstatus { get; set; }
    }
}