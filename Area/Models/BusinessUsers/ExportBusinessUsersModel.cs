using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.BusinessUsers
{
    public class ExportBusinessUsersModel
    {
        [Column("businessname")]
        public string BusinessName {get; set;}

        [Column("username")]
        public string UserName {get; set;}

    }
}