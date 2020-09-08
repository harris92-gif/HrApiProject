using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Department;

namespace HrApiProject.Area.Repositories.Department
{
    public class DepartmentLogic : IDepartmentLogic
    {
        private readonly DepartmentDAL _departmentDAL;
        public DepartmentLogic(DepartmentDAL departmentDAL)
        {
            _departmentDAL = departmentDAL;
        }
        public  Task<object> AddNewDepartment(Guid BusinessId , DepartmentModel departmentModel)
        {
            return _departmentDAL.AddNewDepartment(BusinessId , departmentModel);
        }

        public  Task<object> ShowAllDepartments(Guid BusinessID)
        {
            return _departmentDAL.ShowAllDepartments(BusinessID);
        }

        public  Task<object> ShowDepartmentById(Guid BusinessID,Guid DepartmentID)
        {
            return _departmentDAL.ShowDepartmentById(BusinessID,DepartmentID);
        }

        public  Task<bool> UpdateDepartmentById(Guid BusinessID,Guid DepartmentID,DepartmentModel departmentModel )
        {
            return _departmentDAL.UpdateDepartmentById(BusinessID,DepartmentID,departmentModel); 
        }

        public  Task<bool> InActivateDepartmentById(Guid BusinessID,Guid DepartmentID)
        {
            return _departmentDAL.InActivateDepartmentById(BusinessID,DepartmentID);
        }

        public  Task<bool> ActivateDepartmentById(Guid BusinessID,Guid DepartmentID)
        {
            return _departmentDAL.ActivateDepartmentById(BusinessID,DepartmentID);
        }




        
    }
}