using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApprovalManagementSystem.Models
{
    public class RequestInfoModel
    {
        public int Id { get; set; }
        public int CreateUserId { get; set; }
        public string RequestInfo { get; set; }
        public Boolean Status { get; set; }
    }
}
