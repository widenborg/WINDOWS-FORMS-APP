using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CronusWebApplication
{
    /// <summary>
    /// Summary description for CronusService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CronusService : System.Web.Services.WebService
    {
        DataAccessLayer dataAccessLayer;
        
        public CronusService()
        {
            dataAccessLayer = new DataAccessLayer();
        }

        [WebMethod]
        public List<CRONUS_Sverige_AB_Employee> GetEmployees()
        {
            return dataAccessLayer.GetEmployees();
        }

        [WebMethod]
        public CRONUS_Sverige_AB_Employee GetEmployee(string empID)
        {
            return dataAccessLayer.GetEmployee(empID);
        }

        [WebMethod]
        public void InsertEmployee(string empID, string firstName, string lastName)
        {
            dataAccessLayer.InsertEmployee(empID, firstName, lastName);
           
        }

        [WebMethod]
        public void UpdateEmployee(string empID, string firstName, string lastName)
        {
            dataAccessLayer.UpdateEmployee(empID, firstName, lastName);
        }

        [WebMethod]
        public void DeleteEmployee(string empID)
        {
            dataAccessLayer.DeleteEmployee(empID);
        }


    }
}
