using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.Employee
{
    public class EmployeeResponse
    {
        [Key]
        [Column("theemp_id")]
        public Guid EmployeeID {get; set;}
        [Column("theempfullname")]
        public string  EmployeeName {get; set;}
        [Column("theempgender")]
        public string  EmployeeGender {get; set;}
        [Column("theempssn")]
        public string  EmployeeSSN {get; set;}
        [Column("thedeptid")]

        public Guid  DepartmentID {get; set;}
        [Column("creationdate")]
        public DateTime  EmployeeCreationDate {get; set;}
        [Column("status")]
        public string  EmployeeStatus {get; set;}
        [Column("theempdetails_id")]
        public Guid  EmployeeDetailsId {get; set;}
        [Column("bps")]
         public decimal  BPS {get; set;}
         [Column("theempdesignation")]
        public string  EmpDesignation {get; set;}  
        [Column("theemppacountry")]              
        public string  PACountry {get; set;}
        [Column("theemppacity")]
        public string  PACity {get; set;}
        [Column("theemppaprovince")]
        public string  PAProvince {get; set;}
        [Column("theemppazip")]
        public string  PAZip {get; set;}
        [Column("theempmacountry")]
        public string  MACountry {get; set;}
        [Column("theempmacity")]
        public string  MACity {get; set;}
        [Column("theempmaprovince")]
        public string  MAProvince {get; set;}
        [Column("theempmazip")]
        public string  MAZip {get; set;}
        [Column("theempemail")]
        public string  EmpEmail {get; set;}
        [Column("theempjoiningdate")]
        public string  EmpJoiningDate {get; set;}
        [Column("theempappointmentdate")]
        public string  EmpAppointmentDate {get; set;}
        [Column("thedescription")]
        public string  Description {get; set;}
        [Column("thephoto")]
        public string  Photo {get; set;}
        [Column("theskypeusername")]
        public string  SkypeUserName {get; set;}
        [Column("theempofficephoneno")]
        public string  EmpOfficeNo {get; set;}
        [Column("theempcellno")]
        public string  EmpCellNo {get; set;}

       
        
    }
}