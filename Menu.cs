using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenManagementSystem
{
    public class Menu
    {

        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection EstablishConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            con = new SqlConnection(cs);
            return con;
        }


        private int _foodId;
        private String _foodName;
        private double _foodPrice;

        public Menu()
        {

        }

        public Menu(int id, string name, double price)
        {
            this._foodId = id;
            this._foodName = name;
            this._foodPrice = price;
        }

        public int Id
        {
            get { return this._foodId; }

            set { this._foodId = value; }
        }

        public String Name
        {
            get { return this._foodName; }

            set { this._foodName = value; }
        }

        public double Price
        {
            get { return this._foodPrice; }

            set { this._foodPrice = value; }
        }

        public override string ToString()
        {
            return "FoodId : " + this._foodId + " FoodName : " + this._foodName + " Price : " + this._foodPrice;
        }

        //public static void PrintMenu(Menu m)
        //{
        //    Console.WriteLine(m.ToString());
        //    //Console.WriteLine("Menu");
        //    //Menu m1 = new Menu(1, "Samosa", 10.00);
        //    //Menu m2 = new Menu(2, "Paratha", 40.00);
        //    //Menu m3 = new Menu(3, "MilkShake", 80.00);
        //    //Menu m4 = new Menu(4, "Ice Cream", 50.00);
        //    //Menu m5 = new Menu(5, "Cold Drink", 30.00);
        //    //Console.WriteLine(m1.ToString());
        //    //Console.WriteLine(m2.ToString());
        //    //Console.WriteLine(m3.ToString());
        //    //Console.WriteLine(m4.ToString());
        //    //Console.WriteLine(m5.ToString());
        //}

        public Boolean ShowFullMenu()
        {

            //Console.WriteLine("Enter student id");
            //double n = Convert.ToDouble(Console.ReadLine());
            bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select * from MENU", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine("ID" + "   " + "     NAME     "+ "   "+ "PRICE");
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]+ "   "+rdr[1] +"   "+rdr[2]);
                successflag = true;
            }
            con.Close();
            return successflag;
        }

        public  Boolean ShowParticularMenu(int id)
        {

            //Console.WriteLine("Enter student id");
            //double n = Convert.ToDouble(Console.ReadLine());
            bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select * from MENU where food_id = "+id, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine("ID" + "   " + "     NAME     " + "   " + "PRICE");
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + "   " + rdr[1] + "   " + rdr[2]);
                successflag = true;
            }
            con.Close();
            return successflag;
        }

        public Double FoodPrice(int id)
        {
            double d = 0;

            //bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("select food_price from MENU where food_id = " + id, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                 d = Convert.ToDouble(rdr[0]);
            }
            //return Convert.ToDouble(rdr[0]);

            return d;
            con.Close();

        }




    }
}
