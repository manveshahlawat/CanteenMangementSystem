using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace CanteenManagementSystem
{
    public class Vendor
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection EstablishConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            con = new SqlConnection(cs);
            return con;
        }

        private int _vendorId;
        private string _vendorName;
        private string _phoneNo;
        private string _venPassword;

        public Vendor()
        { }

        public Vendor(int vid, string vname, string pno,string password)
        {
            this._vendorId = vid;
            this._vendorName = vname;
            this._phoneNo = pno;
            this._venPassword = password;
        }

        public int VID
        {
            get { return this._vendorId; }

            set { this._vendorId = value; }
        }

        public string VName
        {
            get { return this._vendorName; }

            set { this._vendorName = value; }

        }

        public string VNO
        {
            get { return this._phoneNo; }

            set { this._phoneNo = value; }
        }

        public string VenPassword
        {
            get { return this._venPassword; }

            set { this.VenPassword = value; }
        }

        public override string ToString()
        {
            return "Vendor Id " + this._vendorId + " Vendor Name " + this._vendorName + " Vendor Phone " + this._phoneNo;
        }

        public Boolean ShowAllVendors()
        {


            bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select * from VENDOR", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + "   " + rdr[1] + "   " + rdr[2] + "   " + rdr[3] );
                successflag = true;
            }
            con.Close();
            return successflag;
        }

        public Boolean ShowParticularVendor(int id)
        {


            bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select * from VENDOR where vend_id = " + id, con);
            con.Open();
            Console.WriteLine("VEND ID" + "   " + "  NAME  " + "   " + "PHONE NO.");
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("   "+rdr[0] + "      " + rdr[1] + "    " + rdr[2]  );
                successflag = true;
            }
            con.Close();
            return successflag;
        }

        public Boolean ShowVendorOrderHistory(int id)
        {


            bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select * from ORDERS where vend_id = " + id, con);
            con.Open();
            Console.WriteLine("ORDER ID" + "   " + "FOOD ID" + "   " + "CUST ID" + "   " + "VEND ID" + "   " + "QUANTITY" + "   " + "TOTAL AMOUNT" + "   " + "STATUS");
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("    " + rdr[0] + "         " + rdr[1] + "          " + rdr[2] + "         " + rdr[3] + "        " + rdr[4] + "        " + rdr[5] + "        " + rdr[6]);
                successflag = true;
            }
            con.Close();
            return successflag;
        }

    }
}
