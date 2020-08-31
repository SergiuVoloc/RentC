using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace RentC_WebServer
{
    /// <summary>
    /// Summary description for WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {

        DataTable reservationDataTable = new DataTable();
        DBAccess DBAccess = new DBAccess();
        

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
            reservationDataTable.Columns.Add("Manufacturer");
            reservationDataTable.Columns.Add("Model");
            reservationDataTable.Columns.Add("PricePerDay");

            reservationDataTable.Rows.Add("DA 98 LFG", "Porsche", "Cayenne", "65.12");


            return JsonConvert.SerializeObject(reservationDataTable);
        }



        //[WebMethod]
        //public string dataTableForUsers()
        //{
        //    var location = "Craiova";
        //    var endDate = "10/09/2020";
        //    var startDate = "05/09/2020";

        //     string query = "select * from Cars WHERE Location = " + location + "AND CarID NOT IN" + "(SELECT CarID FROM Reservations WHERE NOT (StartDate < " + endDate + " ) OR (EndDate > " + startDate + "))  ";

        //    DBAccess.readDatathroughAdapter(query,reservationDataTable);

        //    return JsonConvert.SerializeObject(reservationDataTable);
        //}
     
    }
}
