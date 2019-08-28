using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Semana03_ejemplo2WPF
{
    class DataAccess
    {
        public SqlConnection LeerCadena()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["kotoha"].ConnectionString);
        }

        public DataTable getYearofOrders()
        {
            SqlConnection connection = LeerCadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("usp_year_list", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable getMonthofOrdersByYear(Int32 year)
        {
            SqlConnection connection = LeerCadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("usp_month_orders_2", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@orderYear", year);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable getEmployeesByYearAndMonth(string month, string year)
        {
            SqlConnection connection = LeerCadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("usp_employee_by_month_and_year", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@year", year);
            sqlData.SelectCommand.Parameters.AddWithValue("@month", month);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable getClientsByCustomerperYearAndMonth(string month, string year, int employeeId)
        {
            SqlConnection connection = LeerCadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("usp_list_client_by_employee_and_date4", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@year", year);
            sqlData.SelectCommand.Parameters.AddWithValue("@month", month);
            sqlData.SelectCommand.Parameters.AddWithValue("@employeeId", employeeId);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
        
         public DataTable getOrderByClientSelected(string month, string year, int employeeId, string CustomerId)
        {
            //usp_list_orders_by_client_and_employee_and_date
            SqlConnection connection = LeerCadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("usp_list_orders_by_client_and_employee_and_dateV21", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@month", month);
            sqlData.SelectCommand.Parameters.AddWithValue("@year", year);
            sqlData.SelectCommand.Parameters.AddWithValue("@employeeId", employeeId);
            sqlData.SelectCommand.Parameters.AddWithValue("@clientId", CustomerId);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable getOrderDetailsByClient(int employeeId, string customerId, int orderId)
        {
            SqlConnection connection = LeerCadena();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("usp_show_order_details_by_client", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@employeeId", employeeId);
            adapter.SelectCommand.Parameters.AddWithValue("@clientId", customerId);
            adapter.SelectCommand.Parameters.AddWithValue("@orderId", orderId);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
    }
}
