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
        Task<IEnumerable<POPEmail>> LoadEmailInfo(int employeeId);
        Task SendEmailInfo(int employeeId, int requestId);
    }
}
