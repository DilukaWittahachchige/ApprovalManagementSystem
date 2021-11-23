using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessServices
{
    public interface IRequestInfoService
    {
        Task<IEnumerable<RequestInfoDto>> LoadAllByIdAsync(int id);


    }
}
