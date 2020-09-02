using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace CanteenManagementSystem
{
    public class Orders
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection EstablishConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            con = new SqlConnection(cs);
            return con;
        }

        private int _orderId;
        private int _foodId;
        private int _custId;
        private int _venId;
        private int _quantity;
        private double _totalAmount;
        private string _ordStatus;
        

        public Orders()
        {

        }

        public Orders(int id, int fid, int cid,int vid, int quan, double totalAmount,string status)
        {
            this._orderId = id;
            this._foodId = fid;
            this._custId = cid;
            this._venId = vid;
            //this._foodPrice = price;
            this._quantity = quan;
            this._totalAmount = totalAmount;
            this._ordStatus = status;
        }

        public int Oid
        {
            get { return this._orderId; }

            set { this._orderId = value; }
        }

        public int FoodId
        {
            get { return this._foodId; }

            set { this._foodId = value; }
        }

        public int CustId
        {
            get { return this._custId; }

            set { this._custId = value; }
        }

        public int Vid
        {
            get { return this._venId; }

            set { this._venId = value; }
        }

        public double TotalAmount
        {
            get { return this._totalAmount; }

            set { this._totalAmount = value; }
        }

        public int Quantity
        {
            get { return this._quantity; }
            set { this._quantity = value; }
        }

        public string Status
        {
            get { return this._ordStatus; }
            set { this._ordStatus = value; }
        }

        public override string ToString()
        {
            return "OrderId : " + this._orderId + " FoodId : " + this._foodId + " FoodPrice : "  + " Quantity : " + this._quantity + " TotalAmount : " + this._totalAmount;
        }



        public Boolean ShowFullOrderHistory()
        {


            bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select * from ORDERS", con);
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

        public Boolean ShowParticularOrder(int id)
        {


            bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select * from ORDERS where ord_id = "+id, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + "   " + rdr[1] + "   " + rdr[2] + "   " + rdr[3] + "   " + rdr[4] + "   " + rdr[5] + "   " + rdr[6]);
                successflag = true;
            }
            con.Close();
            return successflag;
        }


        public void AddOrder(int fid,int cid,int vid, int quantity, double tAmount)
        {

            
            con = EstablishConnection();
            cmd = new SqlCommand("insert into ORDERS(food_id,cust_id,vend_id,quantity,total_amount,ord_status) values(" + fid+","+cid + "," + vid + "," + quantity + "," + tAmount+",'PENDING')", con);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            if (n != 0)
            {
               Console.WriteLine( "Order Placed Successfully");
                Console.WriteLine("YOUR BILL AMOUNT : "+ tAmount);
                Console.WriteLine();
            }
            con.Close();
            
        }

        public void AcceptOrder(int oid)
        {
            con = EstablishConnection();
            cmd = new SqlCommand("update ORDERS set ord_status = 'ACCEPT' where ord_id = "+oid, con);
            con.Open();
             int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                Console.WriteLine("Order Accepted");
            }
            con.Close();
        }

        public void RejectOrder(int oid)
        {
            con = EstablishConnection();
            cmd = new SqlCommand("update ORDERS set ord_status = 'REJECT' where ord_id = " + oid, con);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                Console.WriteLine("Order Rejected");
            }
            con.Close();
        }

        public void CancelOrder(int oid)
        {
            con = EstablishConnection();
            cmd = new SqlCommand("update ORDERS set ord_status = 'CANCEL' where ord_id = " + oid, con);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                Console.WriteLine("Order Canceled");
            }
            con.Close();
        }

    }
}
