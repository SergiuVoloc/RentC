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
            reservationDataTable.Columns.Add("Model");
            reservationDataTable.Columns.Add("StartDate");
            reservationDataTable.Columns.Add("EndDate");
            reservationDataTable.Columns.Add("Location");

            reservationDataTable.Rows.Add("DJ WP ORE", "Audi", "30/08/2020", "31/08/2020", "Craiova");


            return JsonConvert.SerializeObject(reservationDataTable);
        }

        [WebMethod]
        public string dataTableForUsers()
        {
            string query = "select Cars.Plate = @searchPlate, Cars.Model= @searchModel, Reservations.StartDate = searchStartDate, Reservations.EndDate = searchEndDate, Reservations.Location = searchLocation from Reservations INNER JOIN  Cars ON Reservations.CarID = Cars.CarID";

            DBAccess.readDatathroughAdapter(query,reservationDataTable);

            return JsonConvert.SerializeObject(reservationDataTable);
        }
     
    }
}
