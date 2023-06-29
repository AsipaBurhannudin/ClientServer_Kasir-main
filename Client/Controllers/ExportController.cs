using API.Context;
using API.Models;
using Client.Repositories;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Client.Controllers
{
    [Authorize]
    public class ExportController : Controller
    {
        private readonly MyContext MyContext;

        public ExportController(MyContext dbContext)
        {
            MyContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Export()
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                DataTable dt = GetPurchaseDetails().Tables[0];
                wb.Worksheets.Add(dt);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employee.xlsx");
                }
            }
        }
        public IActionResult ExportToExcel()
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                DataTable dt = GetPurchaseDetails().Tables[0];
                wb.Worksheets.Add(dt);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PurchaseD.xlsx");
                }
            }
        }

        private DataSet GetPurchaseDetails()
        {
            DataSet ds = new DataSet();
            string constr = @"Data Source = DESKTOP-K0PBB23; Initial Catalog = db_kasir; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False;";

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM purchasedetails";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }

            return ds;

        }
    }
}
