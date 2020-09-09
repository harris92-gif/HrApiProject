using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.Employee
{
    public class EmployeeModel
    {
        [Key]        
        [Column("emp_id")]
        public Guid EmployeeID {get; set;}
        public string  EmployeeName {get; set;}
        public string  EmployeeGender {get; set;}
        public string  EmployeeSSN {get; set;}
        public Guid  DepartmentID {get; set;}

        [NotMapped]
        public List<EmployeeDetails> EmployeeDetails {get; set;}
        
    }

    public class EmployeeDetails
    {
        public decimal  BPS {get; set;}
        public string  EmpDesignation {get; set;}                
        public string  PACountry {get; set;}
        public string  PACity {get; set;}
        public string  PAProvince {get; set;}
        public string  PAZip {get; set;}
        public string  MACountry {get; set;}
        public string  MACity {get; set;}
        public string  MAProvince {get; set;}
        public string  MAZip {get; set;}
        public string  EmpEmail {get; set;}
        public string  EmpJoiningDate {get; set;}
        public string  EmpAppointmentDate {get; set;}
        public string  Description {get; set;}
        public string  Photo {get; set;}
        public string  SkypeUserName {get; set;}
        public string  EmpOfficeNo {get; set;}
        public string  EmpCellNo {get; set;}



    }
}