using Common.Enum;
using System;

namespace Domain
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserType Position { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
    }
}