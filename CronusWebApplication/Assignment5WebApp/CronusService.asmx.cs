using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Assignment5WebApp;

namespace Assignment5WebApp
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
        DataAccessLayer dataAccessLayer = new DataAccessLayer();

        // WebMethods for C# Client

        [WebMethod]
        public DataSet ReadEmployeeAndRelatedTables()
        {
            DataTable table = dataAccessLayer.GetEmployeeAndRelatedTables();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;
        }

        [WebMethod]
        public DataSet ReadEmployeesAndRelatives()
        {
            DataTable table = dataAccessLayer.GetEmployeesAndRelatives();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;
        }

        [WebMethod]
        public DataSet ReadAllSickEmployees2004()
        {
            DataTable table = dataAccessLayer.GetAllSickEmployees2004();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;
        }

        [WebMethod]
        public DataSet ReadHighestAbsence()
        {
            DataTable table = dataAccessLayer.GetHighestAbsence();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;
        }


        [WebMethod]
        public DataSet ReadAllKeys()
        {

            DataTable table = dataAccessLayer.GetAllKeys();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;
        }

        [WebMethod]
        public DataSet ReadAllIndexes()
        {
            DataTable table = dataAccessLayer.GetAllIndexes();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;
        }

        [WebMethod]
        public DataSet ReadAllConstraints()
        {

            DataTable table = dataAccessLayer.GetAllTableConstraints();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;
        }

        [WebMethod]
        public DataSet ReadAllTables1()
        {
            DataTable table = dataAccessLayer.GetAllTables1();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;
        }

        [WebMethod]
        public DataSet ReadAllTables2()
        {
            DataTable table = dataAccessLayer.GetAllTables2();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;
        }

        [WebMethod]
        public DataSet ReadEmployeeColumns1()
        {
            DataTable table = dataAccessLayer.GetEmployeeColumns1();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;
        }

        [WebMethod]
        public DataSet ReadEmployeeColumns2()
        {
            DataTable table = dataAccessLayer.GetEmployeeColumns2();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;
        }

        // WebMethods for Java Client

        [WebMethod]
        public List<List<string>> ReadEmployeeAndRelatedTablesJava()
        {
            return dataAccessLayer.GetEmployeeAndRelatedTablesJava();

        }
        [WebMethod]
        public List<List<string>> ReadEmployeesAndRelativesJava()
        {
            return dataAccessLayer.GetEmployeesAndRelativesJava();

        }
        [WebMethod]
        public List<List<string>> ReadAllSickEmployees2004Java()
        {
            return dataAccessLayer.GetAllSickEmployees2004Java();

        }
        [WebMethod]
        public List<List<string>> ReadHighestAbsenceJava()
        {
            return dataAccessLayer.GetHighestAbsenceJava();

        }
        [WebMethod]
        public List<List<string>> ReadAllKeysJava()
        {
            return dataAccessLayer.GetAllKeysJava();

        }
        [WebMethod]
        public List<List<string>> ReadAllIndexesJava()
        {
            return dataAccessLayer.GetAllIndexesJava();

        }
        [WebMethod]
        public List<List<string>> ReadAllTableConstraintsJava()
        {
            return dataAccessLayer.GetAllTableConstraintsJava();

        }
        [WebMethod]
        public List<List<string>> ReadAllTables1Java()
        {
            return dataAccessLayer.GetAllTables1Java();

        }
        [WebMethod]
        public List<List<string>> ReadAllTables2Java()
        {
            return dataAccessLayer.GetAllTables2Java();

        }
        [WebMethod]
        public List<List<string>> ReadEmployeeColumns1Java()
        {
            return dataAccessLayer.GetEmployeeColumns1Java();

        }
        [WebMethod]
        public List<List<string>> ReadEmployeeColumns2Java()
        {
            return dataAccessLayer.GetEmployeeColumns2Java();

        }

    }
}
