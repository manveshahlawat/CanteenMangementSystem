using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace CanteenManagementSystem
{
    public class Customer
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection EstablishConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            con = new SqlConnection(cs);
            return con;
        }

        private int _custId;
        private string _custName;
        private string _custPhoneNo;
        private string _custPassword;
        private double _custWalletBalance;

        public Customer()
        {

        }

        public Customer(int id, string name, string phNo,string password, double balance)
        {
            this._custId = id;
            this._custName = name;
            this._custPhoneNo = phNo;
            this._custPassword = password;
            this._custWalletBalance = balance;
        }

        public int Id
        {
            get { return this._custId; }

            set { this._custId = value; }
        }

        public string Name
        {
            get { return this._custName; }

            set { this._custName = value; }

        }

        public String PhoneNo
        {
            get { return this._custPhoneNo; }

            set { this._custPhoneNo = value; }
        }

        public string Password
        {
            get { return this._custPassword; }

            set { this._custPassword = value; }
        }

        public double Balance
        {
            get { return this._custWalletBalance; }

            set { this._custWalletBalance = value; }
        }

        public override string ToString()
        {
            return "cust id : " + this._custId + " Name : " + this._custName + " Phone Number : " + this._custPhoneNo + " Wallet Balance : " + this._custWalletBalance;
        }


        public Boolean ShowAllCustomers()
        {


            bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select * from CUSTOMER", con);
            con.Open();
            Console.WriteLine("CUST ID" + "   " + " NAME " + "   " + "PHONE NO.");
            SqlDataReader rdr = cmd.ExecuteReader();          
            while (rdr.Read())
            {
                Console.WriteLine("   "+rdr[0] + "      " + rdr[1] + "   " + rdr[2]);
                successflag = true;
            }
            con.Close();
            return successflag;
        }

        public Boolean ShowParticularCustomer(int id)
        {


            bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select * from CUSTOMER where cust_id = " + id, con);
            con.Open();
            Console.WriteLine("CUST ID" + "   " + " NAME " + "   " + "PHONE NO.");
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("   " + rdr[0] + "       " + rdr[1] + "   " + rdr[2] );
                successflag = true;
            }
            con.Close();
            return successflag;
        }

        public Boolean ShowCustomerOrderHistory(int id)
        {


            bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select * from ORDERS where cust_id = " + id, con);
            con.Open();
            Console.WriteLine("ORDER ID"+ "   "+"FOOD ID"+ "   "+"CUST ID"+ "   "+"VEND ID"+ "   "+"QUANTITY"+ "   "+"TOTAL AMOUNT" + "   "+"STATUS");
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("    "+rdr[0] + "         " + rdr[1] + "          " + rdr[2] + "         " + rdr[3] + "        " + rdr[4] + "        " + rdr[5] + "        " + rdr[6]);
                successflag = true;
            }
            con.Close();
            return successflag;
        }

        public Boolean customerLogin(string name,string password)
        {


            bool successflag = false;
            bool b = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select cust_id,cust_name,cust_ph_no,cust_wallet from CUSTOMER where cust_name = '" + name+"' and cust_password = '"+password+"'", con);
            con.Open();
            
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("CUST ID" + "   " + " NAME " + "   " + "PHONE NO.");
                Console.WriteLine("   " + rdr[0] + "       " + rdr[1] + "   " + rdr[2]);
                successflag = true;
            }
            con.Close();
            //return successflag;
            if (successflag == true)
            {

                b = successflag;
            }
            else
            {
                b = false;
                Console.WriteLine("INVALID CUSTOMER");
            }
            return b;
        }
    }
}
