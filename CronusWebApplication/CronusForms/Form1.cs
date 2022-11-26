using CronusWebApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CronusForms
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            string newEmpID = empIDTxtBox.Text;
            string newFirstName = firstNameTxtBox.Text;
            string newLastName = lastNameTxtBox.Text;

            using (CronusEntities proxy = new CronusEntities())
            {
                using (CronusService service = new CronusService())
                {
                    if (string.IsNullOrEmpty(newEmpID) && string.IsNullOrEmpty(newFirstName) && string.IsNullOrEmpty(newLastName))
                    {
                        responseTxtBox.Text = "Please fill in all required fields";
                    }
                    else if (string.IsNullOrEmpty(newEmpID) && string.IsNullOrEmpty(newFirstName))
                    {
                        responseTxtBox.Text = "Please fill in Emp ID and First name";
                    }
                    else if (string.IsNullOrEmpty(newEmpID) && string.IsNullOrEmpty(newLastName))
                    {
                        responseTxtBox.Text = "Please fill in Emp ID and Last Name";
                    }
                    else if (string.IsNullOrEmpty(newFirstName) && string.IsNullOrEmpty(newLastName))
                    {
                        responseTxtBox.Text = "Please fill in first and last name";
                    }
                    else if (string.IsNullOrEmpty(newEmpID))
                    {
                        responseTxtBox.Text = "Please fill in the Emp ID";
                    }
                    else if (string.IsNullOrEmpty(newFirstName))
                    {
                        responseTxtBox.Text = "Please fill in the first name";
                    }
                    else if (string.IsNullOrEmpty(newLastName))
                    {
                        responseTxtBox.Text = "Please fill in the last name";
                    }
                    else
                    {
                        try
                        {
                            service.InsertEmployee(newEmpID, newFirstName, newLastName);
                            PopulateDataGridView();
                            responseTxtBox.Text = "Employee added successfully";
                        }
                        catch (SqlException ex)
                        {
                            if(ex.Number == 2627)
                            {
                                responseTxtBox.Text = "This EmpID is already in use, please pick another";
                            }
                            else if(ex.Number == 0)
                            {
                                responseTxtBox.Text = "No connection to server";
                            }
                            else
                            {
                                responseTxtBox.Text = "We dont know what is wrong";
                            }                            
                        }
                        catch(Exception exx)
                        {
                            responseTxtBox.AppendText(exx.Message);
                        }

                        empIDTxtBox.Clear();
                        firstNameTxtBox.Clear();
                        lastNameTxtBox.Clear();

                    }
                }
            }
        }
        public void UpdateButton_Click(object sender, EventArgs e)
        {
            string newEmpID = empIDTxtBox.Text;
            string newFirstName = firstNameTxtBox.Text;
            string newLastName = lastNameTxtBox.Text;

            using (CronusEntities proxy = new CronusEntities())
            {
                using (CronusService service = new CronusService())
                {
                    if (string.IsNullOrEmpty(newEmpID) && string.IsNullOrEmpty(newFirstName) && string.IsNullOrEmpty(newLastName))
                    {
                        responseTxtBox.Text = "Please fill in all required fields";
                    }
                    else if (string.IsNullOrEmpty(newEmpID) && string.IsNullOrEmpty(newFirstName))
                    {
                        responseTxtBox.Text = "Please fill in Emp ID and First name";
                    }
                    else if (string.IsNullOrEmpty(newEmpID) && string.IsNullOrEmpty(newLastName))
                    {
                        responseTxtBox.Text = "Please fill in Emp ID and Last Name";
                    }
                    else if (string.IsNullOrEmpty(newFirstName) && string.IsNullOrEmpty(newLastName))
                    {
                        responseTxtBox.Text = "Please fill in first and last name";
                    }
                    else if (string.IsNullOrEmpty(newEmpID))
                    {
                        responseTxtBox.Text = "Please fill in the Emp ID";
                    }
                    else if (string.IsNullOrEmpty(newFirstName))
                    {
                        responseTxtBox.Text = "Please fill in the first name";
                    }
                    else if (string.IsNullOrEmpty(newLastName))
                    {
                        responseTxtBox.Text = "Please fill in the last name";
                    }
                    else
                    {
                        try
                        {
                            service.UpdateEmployee(newEmpID, newFirstName, newLastName);

                            PopulateDataGridView();
                            responseTxtBox.Text = "Employee successfully updated";
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 0)
                            {
                                responseTxtBox.AppendText("No connection");
                            }
                            
                        }
                    }
                }
            }
        }

        public void DeleteButton_Click(object sender, EventArgs e)
        {
            string newEmpID = empIDTxtBox.Text;

            using (CronusEntities proxy = new CronusEntities())
            {
                using (CronusService service = new CronusService())
                {
                    if (string.IsNullOrEmpty(newEmpID))
                    {
                        responseTxtBox.Text = "Please fill in the Emp ID of the employee you want to remove";
                    }
                    else
                    {
                        try
                        {
                            service.DeleteEmployee(newEmpID);
                            PopulateDataGridView();
                            responseTxtBox.Text = "Employees successfully removed";

                            empIDTxtBox.Clear();
                        }
                        catch (Exception ex)
                        {
                            responseTxtBox.AppendText("Something went wrong");
                        }
                    }
                }
            }
        }
        public void PopulateDataGridView()
        {
            using (CronusEntities proxy = new CronusEntities())
            {
                using (CronusService service = new CronusService())
                {
                    dataGridView.AutoGenerateColumns = false;
                    dataGridView.DataSource = service.GetEmployees();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

    }
}
