using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Assignment5WebApp
{
    public class DataAccessLayer
    {
        private string connectionString;
        private DataTable dataTable = new DataTable();
        private DataSet ds = new DataSet();

        public DataAccessLayer()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.InitialCatalog = "Cronus";
            //builder.UserID = "CronusAdmin";
            builder.IntegratedSecurity = true;

            connectionString = builder.ConnectionString;
        }

        // DAL Methods for C#

        public DataTable GetEmployeeAndRelatedTables()
        {
            string query = @"SELECT * 
            FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME LIKE '%Employee%'";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            // Create Adapter

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable GetEmployeesAndRelatives()
        {
            string query = @"SELECT E.[First Name] +' '+ E.[Last Name] AS 'Employee full name',E.No_ AS 'Employee number', ER.[First Name] +' '+ ER.[Last Name] AS 'Relatives full name'
            FROM [CRONUS Sverige AB$Employee] E
            INNER JOIN [CRONUS Sverige AB$Employee Relative] ER ON E.No_ = ER.[Employee No_]";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            // Create Adapter

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable GetAllSickEmployees2004()
        {
            string query = @"SELECT  SUM (EA.[Quantity (Base)] ) AS 'Sick days', EA.[Employee No_], E.[First Name] +' '+E.[Last Name] AS 'Employees full name'
            FROM [CRONUS Sverige AB$Employee Absence] EA
            INNER JOIN [CRONUS Sverige AB$Employee] E ON E.No_ = EA.[Employee No_]
            WHERE EA.[From Date] LIKE '%2004%'
            AND EA.[Cause of Absence Code] LIKE 'SJUK'
            GROUP BY EA.[Employee No_], E.[First Name], E.[Last Name]";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            // Create Adapter

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable GetHighestAbsence()
        {
            string query = @" SELECT TOP 1 EA.[Employee No_], SUM (EA.[Quantity (Base)] ) AS 'Absent days', E.[First Name]
            FROM [CRONUS Sverige AB$Employee Absence] EA
            INNER JOIN [CRONUS Sverige AB$Employee] E ON E.No_ = EA.[Employee No_]
            GROUP BY EA.[Employee No_], E.[First Name]
            ORDER BY 2 DESC";   

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            // Create Adapter

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
        public DataTable GetAllKeys()
        {
            string query = @"SELECT TABLE_NAME, COLUMN_NAME, CONSTRAINT_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            // Create Adapter

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable GetAllIndexes()
        {
            string query = @"SELECT
    substring(column_names, 1, len(column_names)-1) as [columns],
    case when i.[type] = 1 then 'Clustered index'
        when i.[type] = 2 then 'Nonclustered unique index'
        when i.[type] = 3 then 'XML index'
        when i.[type] = 4 then 'Spatial index'
        when i.[type] = 5 then 'Clustered columnstore index'
        when i.[type] = 6 then 'Nonclustered columnstore index'
        when i.[type] = 7 then 'Nonclustered hash index'
        end as index_type,
    case when i.is_unique = 1 then 'Unique'
        else 'Not unique' end as [unique],
    schema_name(t.schema_id) + '.' + t.[name] as table_view, 
    case when t.[type] = 'U' then 'Table'
        when t.[type] = 'V' then 'View'
        end as [object_type]
     from sys.objects t
        inner join sys.indexes i
        on t.object_id = i.object_id
        cross apply (select col.[name] + ', '
                    from sys.index_columns ic
                        inner join sys.columns col
                            on ic.object_id = col.object_id
                            and ic.column_id = col.column_id
                    where ic.object_id = t.object_id
                        and ic.index_id = i.index_id
                            order by key_ordinal
                            for xml path ('') ) D (column_names)
        where t.is_ms_shipped <> 1
        and index_id > 0
        order by i.[name]";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            // Create Adapter

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable GetAllTableConstraints()
        {
            string query = @"SELECT table_view,
    object_type, 
    constraint_type,
    constraint_name,
    details
from(
    select schema_name(t.schema_id) + '.' + t.[name] as table_view,
        case when t.[type] = 'U' then 'Table'
            when t.[type] = 'V' then 'View'
            end as [object_type],
        case when c.[type] = 'PK' then 'Primary key'
            when c.[type] = 'UQ' then 'Unique constraint'
            when i.[type] = 1 then 'Unique clustered index'
            when i.type = 2 then 'Unique index'
            end as constraint_type,
        isnull(c.[name], i.[name]) as constraint_name,
        substring(column_names, 1, len(column_names) - 1) as [details]
    from sys.objects t
        left outer join sys.indexes i
            on t.object_id = i.object_id
        left outer join sys.key_constraints c
            on i.object_id = c.parent_object_id
            and i.index_id = c.unique_index_id
       cross apply(select col.[name] + ', '
                        from sys.index_columns ic
                            inner
                        join sys.columns col

                      on ic.object_id = col.object_id

                      and ic.column_id = col.column_id
                        where ic.object_id = t.object_id
                            and ic.index_id = i.index_id
                                order by col.column_id
                                for xml path ('') ) D(column_names)
    where is_unique = 1
    and t.is_ms_shipped <> 1
    union all
    select schema_name(fk_tab.schema_id) +'.' + fk_tab.name as foreign_table,
        'Table',
        'Foreign key',
        fk.name as fk_constraint_name,
        schema_name(pk_tab.schema_id) + '.' + pk_tab.name
    from sys.foreign_keys fk
        inner
    join sys.tables fk_tab

  on fk_tab.object_id = fk.parent_object_id

inner
    join sys.tables pk_tab

  on pk_tab.object_id = fk.referenced_object_id

inner
    join sys.foreign_key_columns fk_cols

  on fk_cols.constraint_object_id = fk.object_id

union all
select schema_name(t.schema_id) + '.' + t.[name],
        'Table',
        'Check constraint',
        con.[name] as constraint_name,
        con.[definition]
    from sys.check_constraints con
        left outer join sys.objects t
            on con.parent_object_id = t.object_id
        left outer join sys.all_columns col
            on con.parent_column_id = col.column_id
            and con.parent_object_id = col.object_id
    union all
    select schema_name(t.schema_id) +'.' + t.[name],
        'Table',
        'Default constraint',
        con.[name],
        col.[name] + ' = ' + con.[definition]
    from sys.default_constraints con
        left outer join sys.objects t
            on con.parent_object_id = t.object_id
        left outer join sys.all_columns col
            on con.parent_column_id = col.column_id
            and con.parent_object_id = col.object_id) a
order by table_view, constraint_type, constraint_name";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            // Create Adapter

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }


        public DataTable GetAllTables1()
        {
            string query = @"SELECT TABLE_NAME 
            FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE = 'BASE TABLE'";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            // Create Adapter

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable GetAllTables2()
        {
            //string query = @"SELECT name AS 'Column Name'
            //FROM sys.columns 
            //WHERE object_id = OBJECT_ID('CRONUS Sverige AB$Employee')";
            string query = @"SELECT name AS 'Table name'
            FROM sys.objects    
            WHERE type = 'U' ";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            // Create Adapter

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable GetEmployeeColumns1()
        {
            string query = @"SELECT name AS 'Column Name'
            FROM sys.columns 
            WHERE object_id = OBJECT_ID('CRONUS Sverige AB$Employee')";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            // Create Adapter

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable GetEmployeeColumns2()
        {
            string query = @"
            SELECT COLUMN_NAME AS 'Column Name'
            FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = 'CRONUS Sverige AB$Employee'";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            // Create Adapter

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        // DAL Methods for Java

        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            return dataTable;
                        }
                    }


                }
            }
        }

        public List<List<string>> GetContent(string query)
        {
            List<List<string>> content = new List<List<string>>();

            foreach (DataRow row in ExecuteQuery(query).Rows)
            {
                List<string> contentRow = new List<string>();

                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    contentRow.Add(row[i].ToString());
                }

                content.Add(contentRow);
            }
            return content;
        }

        public List<List<string>> GetEmployeeAndRelatedTablesJava()
        {
            string query = @"SELECT * 
            FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME LIKE '%Employee%'";

            return GetContent(query);
        }

        public List<List<string>> GetEmployeesAndRelativesJava()
        {
            string query = @"SELECT E.[First Name] +' '+ E.[Last Name] AS 'Employee full name',E.No_ AS 'Employee number', ER.[First Name] +' '+ ER.[Last Name] AS 'Relatives full name'
            FROM [CRONUS Sverige AB$Employee] E
            INNER JOIN [CRONUS Sverige AB$Employee Relative] ER ON E.No_ = ER.[Employee No_]";

            return GetContent(query);
        }

        public List<List<string>> GetAllSickEmployees2004Java()
        {
            string query = @"SELECT  SUM (EA.[Quantity (Base)] ) AS 'Sick days', EA.[Employee No_], E.[First Name] +' '+E.[Last Name] AS 'Employees full name'
            FROM [CRONUS Sverige AB$Employee Absence] EA
            INNER JOIN [CRONUS Sverige AB$Employee] E ON E.No_ = EA.[Employee No_]
            WHERE EA.[From Date] LIKE '%2004%'
            AND EA.[Cause of Absence Code] LIKE 'SJUK'
            GROUP BY EA.[Employee No_], E.[First Name], E.[Last Name]";

            return GetContent(query);

        }

        public List<List<string>> GetHighestAbsenceJava()
        {
            string query = @" SELECT TOP 1 EA.[Employee No_], SUM (EA.[Quantity (Base)] ) AS 'Absent days', E.[First Name]
            FROM [CRONUS Sverige AB$Employee Absence] EA
            INNER JOIN [CRONUS Sverige AB$Employee] E ON E.No_ = EA.[Employee No_]
            GROUP BY EA.[Employee No_], E.[First Name]
            ORDER BY 2 DESC";

            return GetContent(query);
        }
        public List<List<string>> GetAllKeysJava()
        {
            string query = @"SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE";

            return GetContent(query);
        }
        public List<List<string>> GetAllIndexesJava()
        {
            string query = @"select i.[name] as index_name,
            substring(column_names, 1, len(column_names)-1) as [columns],
            case when i.[type] = 1 then 'Clustered index'
            when i.[type] = 2 then 'Nonclustered unique index'
            when i.[type] = 3 then 'XML index'
            when i.[type] = 4 then 'Spatial index'
            when i.[type] = 5 then 'Clustered columnstore index'
            when i.[type] = 6 then 'Nonclustered columnstore index'
            when i.[type] = 7 then 'Nonclustered hash index'
            end as index_type,
            case when i.is_unique = 1 then 'Unique'
            else 'Not unique' end as [unique],
            schema_name(t.schema_id) + '.' + t.[name] as table_view, 
            case when t.[type] = 'U' then 'Table'
            when t.[type] = 'V' then 'View'
            end as [object_type]
            from sys.objects t
            inner join sys.indexes i
            on t.object_id = i.object_id
            cross apply (select col.[name] + ', '
                    from sys.index_columns ic
                        inner join sys.columns col
                            on ic.object_id = col.object_id
                            and ic.column_id = col.column_id
                    where ic.object_id = t.object_id
                        and ic.index_id = i.index_id
                            order by key_ordinal
                            for xml path ('') ) D (column_names)
            where t.is_ms_shipped <> 1
            and index_id > 0
            order by i.[name]";

            return GetContent(query);
        }
        public List<List<string>> GetAllTableConstraintsJava()
        {
            string query = @"select table_view,
            object_type, 
            constraint_type,
            constraint_name,
            details
            from(
            select schema_name(t.schema_id) + '.' + t.[name] as table_view,
            case when t.[type] = 'U' then 'Table'
            when t.[type] = 'V' then 'View'
            end as [object_type],
            case when c.[type] = 'PK' then 'Primary key'
            when c.[type] = 'UQ' then 'Unique constraint'
            when i.[type] = 1 then 'Unique clustered index'
            when i.type = 2 then 'Unique index'
            end as constraint_type,
            isnull(c.[name], i.[name]) as constraint_name,
            substring(column_names, 1, len(column_names) - 1) as [details]
            from sys.objects t
            left outer join sys.indexes i
            on t.object_id = i.object_id
            left outer join sys.key_constraints c
            on i.object_id = c.parent_object_id
            and i.index_id = c.unique_index_id
            cross apply(select col.[name] + ', '
                        from sys.index_columns ic
                            inner
                        join sys.columns col

                      on ic.object_id = col.object_id

                      and ic.column_id = col.column_id
                        where ic.object_id = t.object_id
                            and ic.index_id = i.index_id
                                order by col.column_id
                                for xml path ('') ) D(column_names)
            where is_unique = 1
            and t.is_ms_shipped <> 1
            union all
            select schema_name(fk_tab.schema_id) +'.' + fk_tab.name as foreign_table,
            'Table',
            'Foreign key',
            fk.name as fk_constraint_name,
            schema_name(pk_tab.schema_id) + '.' + pk_tab.name
            from sys.foreign_keys fk
            inner
            join sys.tables fk_tab

            on fk_tab.object_id = fk.parent_object_id

            inner
            join sys.tables pk_tab

            on pk_tab.object_id = fk.referenced_object_id

            inner
            join sys.foreign_key_columns fk_cols

            on fk_cols.constraint_object_id = fk.object_id

            union all
            select schema_name(t.schema_id) + '.' + t.[name],
            'Table',
            'Check constraint',
            con.[name] as constraint_name,
            con.[definition]
            from sys.check_constraints con
            left outer join sys.objects t
            on con.parent_object_id = t.object_id
            left outer join sys.all_columns col
            on con.parent_column_id = col.column_id
            and con.parent_object_id = col.object_id
            union all
            select schema_name(t.schema_id) +'.' + t.[name],
            'Table',
            'Default constraint',
            con.[name],
            col.[name] + ' = ' + con.[definition]
            from sys.default_constraints con
            left outer join sys.objects t
            on con.parent_object_id = t.object_id
            left outer join sys.all_columns col
            on con.parent_column_id = col.column_id
            and con.parent_object_id = col.object_id) a
            order by table_view, constraint_type, constraint_name";

            return GetContent(query);
        }
        public List<List<string>> GetAllTables1Java()
        {
            string query = @"SELECT TABLE_NAME 
            FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE = 'BASE TABLE'";

            return GetContent(query);
        }
        public List<List<string>> GetAllTables2Java()
        {
            string query = @"SELECT name 
            FROM sysobjects 
            WHERE xtype='U' ";

            return GetContent(query);
        }
        public List<List<string>> GetEmployeeColumns1Java()
        {
            string query = @"SELECT name AS 'Column Name'
            FROM sys.columns 
            WHERE object_id = OBJECT_ID('CRONUS Sverige AB$Employee')";

            return GetContent(query);
        }
        public List<List<string>> GetEmployeeColumns2Java()
        {
            string query = @"
            SELECT COLUMN_NAME AS 'Column Name'
            FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = 'CRONUS Sverige AB$Employee'";

            return GetContent(query);
        }




    }
}