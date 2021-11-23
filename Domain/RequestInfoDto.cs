
using System;

namespace Domain
{
    public class RequestInfoDto
    {
        public int Id { get; set; }
        public int CreateUserId { get; set; }
        public string RequestInfo { get; set; }
        public Boolean Status { get; set; }
    }
}
