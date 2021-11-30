using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApprovalManagementSystem.Models
{
    public class ApprovalInfoModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ManagerId { get; set; }
        public Boolean? IsApproved { get; set; }
        public string Comment { get; set; }
    }
}
