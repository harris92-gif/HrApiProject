using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.User
{
    public class ExportUserModel
    {
        
        [Column("user_name")]
        public string UserName { get; set; }

        [Column("first_name")]
        public string UserFirstName { get; set; }

        [Column("last_name")]
        public string UserLastName { get; set; }

        [Column("user_email")]
        public string UserEmail { get; set; }

        [Column("thecontact")]
        public string UserContact { get; set; } 
    }
}