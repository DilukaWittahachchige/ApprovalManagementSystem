using System;

namespace Domain
{
    public class ApprovaInfoDto
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public int RequestId { get; set; }
        public Boolean IsApproved { get; set; }
        public string Comment { get; set; }
    }
}