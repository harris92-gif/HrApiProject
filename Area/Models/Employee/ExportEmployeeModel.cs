using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.Employee
{
    public class ExportEmployeeModel
    {
       [Column("empfullname")]
        public string  EmployeeName {get; set;}
        [Column("empgender")]
        public string  EmployeeGender {get; set;}
        [Column("empssn")]
        public string  EmployeeSSN {get; set;}
        
         [Column("departmentname")]
        public string  DepartmentName {get; set;}
        [Column("creationdate")]

        public string  CreationDate {get; set;}
         [Column("status")]

        public string  Status {get; set;}

       
        [Column("bps")]
         public decimal  BPS {get; set;}
         [Column("empdesignation")]
        public string  EmpDesignation {get; set;}  
        [Column("emppacountry")]              
        public string  PACountry {get; set;}
        [Column("emppacity")]
        public string  PACity {get; set;}
        [Column("emppaprovince")]
        public string  PAProvince {get; set;}
        [Column("emppazip")]
        public string  PAZip {get; set;}
        [Column("empmacountry")]
        public string  MACountry {get; set;}
        [Column("empmacity")]
        public string  MACity {get; set;}
        [Column("empmaprovince")]
        public string  MAProvince {get; set;}
        [Column("empmazip")]
        public string  MAZip {get; set;}
        [Column("empemail")]
        public string  EmpEmail {get; set;}
        [Column("empjoiningdate")]
        public string  EmpJoiningDate {get; set;}
        [Column("empappointmentdate")]
        public string  EmpAppointmentDate {get; set;}
        [Column("description")]
        public string  Description {get; set;}
        [Column("photo")]
        public string  Photo {get; set;}
        [Column("skypeusername")]
       
        public string  SkypeUserName {get; set;}
        [Column("empofficephoneno")]
        public string  EmpOfficeNo {get; set;}
        [Column("empcellno")]
     
        public string  EmpCellNo {get; set;}
       
    }
}