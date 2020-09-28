using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace HrApiProject.Area.Repositories.Common
{
    public class CommonLogic : ICommonLogic
    {
        private readonly CommonDAL _commonDAL;
        private readonly HttpContext _httpContextAccessor;

        public CommonLogic(CommonDAL commonDAL, IHttpContextAccessor httpContextAccessor)
        {
            _commonDAL = commonDAL;
            _httpContextAccessor= httpContextAccessor.HttpContext;
        }

        public Task<bool> CheckBusinessID(Guid businessID)
        {
            return _commonDAL.CheckBusinessID(businessID);
        }

        

        public Task<bool> CheckEmployeeID(Guid businessID, Guid employeeID)
        {
            return _commonDAL.CheckEmployeeID(businessID,employeeID);
        }

        public Task<bool> CheckSalaryID(Guid businessID, Guid salaryID)
        {
            return _commonDAL.CheckSalaryID(businessID , salaryID);
        }

        public Task<bool> CheckUserID(Guid userID)
        {
            return _commonDAL.CheckUserID(userID);
        }

        public Task<bool> CheckBusinessUserID(Guid businessID, Guid businessUserID)
        {
            return _commonDAL.CheckBusinessUserID(businessID,businessUserID);
        }

        public Task<bool> CheckDeductionID(Guid businessID, Guid deductionID)
        {
            return _commonDAL.CheckDeductionID(businessID , deductionID);
        }

        public Task<bool> CheckIncrementID(Guid businessID, Guid incrementID)
        {
            return _commonDAL.CheckIncrementID(businessID,incrementID);
        }


         public string ExportToExcel(dynamic data , string folderName)
        {
            string excelFileName =  $"List-{DateTime.Now.ToString("yyyy-MM-dd,HH:mm:ss")}.xlsx"; 
            string downloadUrl = string.Format("{0}://{1}/{2}", _httpContextAccessor.Request.Scheme, _httpContextAccessor.Request.Host, folderName + "/" + excelFileName);  

            if(!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            FileInfo file = new FileInfo(Path.Combine(folderName,excelFileName));

            if(file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(folderName,excelFileName));

            }

            using(var package = new ExcelPackage(file))
            {
                var workSheet = package.Workbook.Worksheets.Add("sheet1");
                workSheet.Cells.LoadFromCollection(data,true);
                package.Save();
            }

            return downloadUrl;

            
        }

        public DataTable ToDataTable<T>(List<T> listOfData)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //get all the properties
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach(var property in properties)
            {
                //setting properties names as columns names
                dataTable.Columns.Add(property.Name);
            }

            foreach(T data in listOfData)
            {
                var values = new object[properties.Length];

                //inserting property values to datatable rows
                for(int i = 0 ; i<properties.Length; i++)
                {                    
                    values[i] = properties[i].GetValue(data,null);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public string ExportToCsv(DataTable dataTable, string folderName)
        {
            string csvName = $"List-{DateTime.Now.ToString("yyyy-MM-dd,hh:mm:ss")}.csv";
            string downloadUrl = string.Format("{0}://{1}/{2}",_httpContextAccessor.Request.Scheme,_httpContextAccessor.Request.Host,folderName + "/" + csvName);

            if(!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            FileInfo csvFile = new FileInfo(Path.Combine(folderName,csvName));
            if(csvFile.Exists)
            {
                csvFile.Delete();
                csvFile = new FileInfo(Path.Combine(folderName,csvName));   
            }

            //writing to csv file
            StreamWriter sw = new StreamWriter(Convert.ToString(csvFile),false);

            //writing headers columns
            for(int i=0 ; i<dataTable.Columns.Count; i++)
            {
                sw.Write(dataTable.Columns[i]);
                if(i<dataTable.Columns.Count-1)
                {
                    sw.Write(",");
                }
            }

            sw.Write(sw.NewLine);

            //writing data 

            foreach(DataRow dr in dataTable.Rows)
            {
                for(int i=0 ; i<dataTable.Columns.Count; i++)
                {
                    if(!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();

                        if(value.Contains(","))
                        {
                            value=string.Format("\"{0}\"",value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }

                    if(i<dataTable.Columns.Count -1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();

            return downloadUrl;
        }

        public string ExportToPdf(DataTable dataTable, string folderName)
        {
            string pdfName = $"List-{DateTime.Now.ToString("yyyy-MM-dd,hh:mm:ss")}.pdf";
            string downloadUrl = string.Format("{0}://{1}/{2}", _httpContextAccessor.Request.Scheme, _httpContextAccessor.Request.Host,folderName + "/" + pdfName);

            if(!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName); 
            }

            FileInfo pdfFile = new FileInfo(Path.Combine(folderName,pdfName));

            if(pdfFile.Exists)
            {
                pdfFile.Delete();
                pdfFile = new FileInfo(Path.Combine(folderName,pdfName));
            }

            Document document = new Document(iTextSharp.text.PageSize.A1);

            PdfWriter pdfWriter = PdfWriter.GetInstance(document,new FileStream(Convert.ToString(pdfFile),FileMode.Create));

            document.Open();

            PdfPTable pdfTable = new  PdfPTable(dataTable.Columns.Count);

            pdfTable.WidthPercentage =100;


            //setting pdf columns names
            for(int k=0;k<dataTable.Columns.Count;k++)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(dataTable.Columns[k].ColumnName));
                pdfCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                pdfCell.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                //cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);

                pdfTable.AddCell(pdfCell);
            }

            //inserting data of datatabls to pdf file

            for(int i=0; i<dataTable.Rows.Count; i++)
            {
                for(int j=0;j<dataTable.Columns.Count;j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(dataTable.Rows[i][j].ToString()));

                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    pdfTable.AddCell(cell);
                }
            }

            document.Add(pdfTable);
            document.Close();

            return downloadUrl;

        }

        public Task<bool> CheckAttendaceID(Guid businessID, Guid attendanceID)
        {
            return _commonDAL.CheckAttendaceID(businessID,attendanceID);
        }
    }
}