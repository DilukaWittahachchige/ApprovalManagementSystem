using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    /// <summary>
    ///  Exam entity  
    /// </summary>
    public class ApprovaInfoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public int RequestId { get; set; }
        public Boolean IsApproved { get; set; }
        public string Comment { get; set; }
    }
}
