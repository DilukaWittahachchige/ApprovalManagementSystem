using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Email
{
    public interface IEmailService
    {
        Task<bool> SendApprovalRequestAsync(int managerId, int requestId, string managerEmail);
        ApprovaInfoDto LoadReplyByRequestIdAsync(int managerId, int requestId);
    }
}
