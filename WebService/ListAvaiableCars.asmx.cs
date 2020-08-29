using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        DataTable reservationDataTable = new DataTable();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public int sum(int a, int b)
        {
            return a + b;
        }


        [WebMethod]
        public string ListAvailableCars()
        {
            reservationDataTable.Columns.Add("Plate");
            reservationDataTable.Columns.Add("Model");
            reservationDataTable.Columns.Add("StartDate");
            reservationDataTable.Columns.Add("EndDate");
            reservationDataTable.Columns.Add("Location");

            reservationDataTable.Rows.Add("DJ WP ORE", "Audi", "30/08/2020", "31/08/2020", "Craiova");


            return JsonConvert.SerializeObject(reservationDataTable);
        }
    }
}
