using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorHandlerandAuthetication.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Account { get; set; }
        public string? Password { get; set; }

        public string? GroupId { get; set; }
    }

    public class Group
    {
        [Key]
        public string? GroupId { get; set; }

        public string? GroupName { get; set; }
    }

    public class MenuCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FunctionSeq { get; set; }
        
        public string? MainFuncionName { get; set; }
        public string? DetailFunctionName { get; set; }

        public string? GroupId { get; set; }
    }
}
