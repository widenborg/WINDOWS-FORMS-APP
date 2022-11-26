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
using Assignment5Forms.ServiceReference1;


namespace Assignment5Forms
{
    public partial class Form1 : Form
    {
        ServiceReference1.CronusServiceSoapClient client = new ServiceReference1.CronusServiceSoapClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGetAllConstraints_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = client.ReadAllConstraints();
                dataGridViewDataBase.DataSource = ds.Tables[0];
                dataGridViewDataBase.AutoGenerateColumns = true;
                dataGridViewDataBase.AutoResizeColumns();
                dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch(SqlException exx)
            {
                if(exx.Number == 0)
                {
                    MessageBox.Show("No connection to server");
                }
                else
                {
                    MessageBox.Show("Error, unhandled");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void BtnGetAllKeys_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = client.ReadAllKeys();
                dataGridViewDataBase.DataSource = ds.Tables[0];
                dataGridViewDataBase.AutoGenerateColumns = true;
                dataGridViewDataBase.AutoResizeColumns();
                dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (SqlException exx)
            {
                if (exx.Number == 0)
                {
                    MessageBox.Show("No connection to server");
                }
                else
                {
                    MessageBox.Show("Error, unhandled");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void BtnReadAllIndexes_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = client.ReadAllIndexes();
                dataGridViewDataBase.DataSource = ds.Tables[0];
                dataGridViewDataBase.AutoGenerateColumns = true;
                dataGridViewDataBase.AutoResizeColumns();
                dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (SqlException exx)
            {
                if (exx.Number == 0)
                {
                    MessageBox.Show("No connection to server");
                }
                else
                {
                    MessageBox.Show("Error, unhandled");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }


        private void BtnReadEmployeeAndRelatedTables_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = client.ReadEmployeeAndRelatedTables();
                dataGridViewDataBase.DataSource = ds.Tables[0];
                dataGridViewDataBase.AutoGenerateColumns = true;
                dataGridViewDataBase.AutoResizeColumns();
                dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (SqlException exx)
            {
                if (exx.Number == 0)
                {
                    MessageBox.Show("No connection to server");
                }
                else
                {
                    MessageBox.Show("Error, unhandled");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void BtnSickEmployees2004_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = client.ReadAllSickEmployees2004();
                dataGridViewDataBase.DataSource = ds.Tables[0];
                dataGridViewDataBase.AutoGenerateColumns = true;
                dataGridViewDataBase.AutoResizeColumns();
                dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (SqlException exx)
            {
                if (exx.Number == 0)
                {
                    MessageBox.Show("No connection to server");
                }
                else
                {
                    MessageBox.Show("Error, unhandled");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void BtnMostAbsentEmployee_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
               
 
                ds = client.ReadHighestAbsence();
                dataGridViewDataBase.DataSource = ds.Tables[0];
                dataGridViewDataBase.AutoGenerateColumns = true;
                dataGridViewDataBase.AutoResizeColumns();
                dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (SqlException exx)
            {
                if (exx.Number == 0)
                {
                    MessageBox.Show("No connection to server");
                }
                else
                {
                    MessageBox.Show("Error, unhandled");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void BtnGetAllTables1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = client.ReadAllTables1();
                dataGridViewDataBase.DataSource = ds.Tables[0];
                dataGridViewDataBase.AutoGenerateColumns = true;
                dataGridViewDataBase.AutoResizeColumns();
                dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (SqlException exx)
            {
                if (exx.Number == 0)
                {
                    MessageBox.Show("No connection to server");
                }
                else
                {
                    MessageBox.Show("Error, unhandled");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void BtnGetAllTables2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = client.ReadAllTables2();
                dataGridViewDataBase.DataSource = ds.Tables[0];
                dataGridViewDataBase.AutoGenerateColumns = true;
                dataGridViewDataBase.AutoResizeColumns();
                dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (SqlException exx)
            {
                if (exx.Number == 0)
                {
                    MessageBox.Show("No connection to server");
                }
                else
                {
                    MessageBox.Show("Error, unhandled");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void BtnGetEmployeeAndRelatives_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = client.ReadEmployeesAndRelatives();
                dataGridViewDataBase.DataSource = ds.Tables[0];
                dataGridViewDataBase.AutoGenerateColumns = true;
                dataGridViewDataBase.AutoResizeColumns();
                dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (SqlException exx)
            {
                if (exx.Number == 0)
                {
                    MessageBox.Show("No connection to server");
                }
                else
                {
                    MessageBox.Show("Error, unhandled");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void BtnGetEmployeeColumns1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = client.ReadEmployeeColumns1();
                dataGridViewDataBase.DataSource = ds.Tables[0];
                dataGridViewDataBase.AutoGenerateColumns = true;
                dataGridViewDataBase.AutoResizeColumns();
                dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (SqlException exx)
            {
                if (exx.Number == 0)
                {
                    MessageBox.Show("No connection to server");
                }
                else
                {
                    MessageBox.Show("Error, unhandled");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void BtnGetEmployeeColumns2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = client.ReadEmployeeColumns2();
                dataGridViewDataBase.DataSource = ds.Tables[0];
                dataGridViewDataBase.AutoGenerateColumns = true;
                dataGridViewDataBase.AutoResizeColumns();
                dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (SqlException exx)
            {
                if (exx.Number == 0)
                {
                    MessageBox.Show("No connection to server");
                }
                else
                {
                    MessageBox.Show("Error, unhandled");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}
