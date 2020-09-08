    using System;
    using System.Data;
    using System.Threading.Tasks;
    using HrApiProject.Area.Models;
    using Microsoft.EntityFrameworkCore;
    using NpgsqlTypes;

    namespace HrApiProject.Area.Repositories.Business
    {
        public class BusinessDAL
        {
            private readonly ProjectContextDB _projectContextDB;

            public BusinessDAL(ProjectContextDB projectContext)
            {
                _projectContextDB = projectContext;
            }

            public async Task<object> AddNewBusiness(BusinessModel businessModel)
            {
                try
                {
                    var banme = new Npgsql.NpgsqlParameter("@thebusinessname",businessModel.BusinessName);
                    var blogo = new Npgsql.NpgsqlParameter("@thelogo",businessModel.BusinessLogo);
                    var bcurrency = new Npgsql.NpgsqlParameter("@thedefaultcurrency",businessModel.BusinessDefaultCurrency);
                    
                    var bAddressDetails = new Npgsql.NpgsqlParameter("@theaddressdetails",NpgsqlDbType.Json)
                    {
                        Direction= ParameterDirection.InputOutput,
                        Value = businessModel.BusinessAddressDetails != null ? businessModel.BusinessAddressDetails : (object)DBNull.Value
                    };

                    var bContactDetails = new Npgsql.NpgsqlParameter("@thecontactdetails",NpgsqlDbType.Json)
                    {
                        Direction = ParameterDirection.InputOutput,
                        Value = businessModel.BusinessContactDetails !=null ? businessModel.BusinessContactDetails : (Object)DBNull.Value
                    };
                    
                    var bOwner = new Npgsql.NpgsqlParameter("@thebusinessowner",businessModel.BusinessOwner);

                    await Task.Run(()=>_projectContextDB.Database.ExecuteSqlRaw("call addbusinesswithdetailsandcreateschema(@thebusinessname,@thelogo,@thedefaultcurrency,@theaddressdetails,@thecontactdetails,@thebusinessowner)",banme,blogo,bcurrency,bAddressDetails,bContactDetails,
                    bOwner));

                    return true;
                }
                catch(Exception ex)
                {
                    return null;
                }

            }
        }
    }