using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Program pmain = new Program();
            pmain.MainMenu();

 
            Console.ReadLine();
        }

        void MainMenu()
        {
            Console.WriteLine("*********** !! WLCOME TO CanteenX !! ***********");
            Console.WriteLine("\n\n" +
                "*************** !! MAIN  MENU !! ***************");

            Console.WriteLine("1. SHOW MENU \n2. CUSTOMER DETAILS \n3. VENDOR DETAILS \n4. ORDER HISTORY\n5. EXIT\n\n");
            MainMenuDetails();

        }


        void MainMenuDetails()
        {
            Console.WriteLine("\n\nENTER YOUR CHOICE");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    ShowMenu();
                    break;
                case 2:
                    ShowCustomer();
                    break;
                case 3:
                    ShowVendor();
                    break;
                case 4:
                    OrderHistory();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("ENTER VALID CHOICE");
                    MainMenu();
                    break;
            }
        }




        void ShowMenu()
        {
            Menu m = new Menu();
            m.ShowFullMenu();
            Console.WriteLine("\n\nENTER YOUR CHOICE \n\n1.PLACE ORDER\n2.BACK TO MAIN MENU");
            int ch1 = Convert.ToInt32(Console.ReadLine());
            switch (ch1)
            {
                case 1:
                    PlaceOrder();
                    MainMenu();
                    break;
                case 2:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("ENTER VALID CHOICE");
                    ShowMenu();
                    break;
            }
        }

        void ShowCustomer()
        {
            Customer c = new Customer();
            Console.WriteLine("ENTER CUSTOMER ID");
            int cid = Convert.ToInt32(Console.ReadLine());
            c.ShowParticularCustomer(cid);
            Console.WriteLine("\n\n");
            MainMenu();
        }

        void ShowVendor()
        {
            Vendor v = new Vendor();
            Console.WriteLine("ENTER YOUR VENDOR ID");
            int vid = Convert.ToInt32(Console.ReadLine());
            v.ShowParticularVendor(vid);
            Console.WriteLine("\n\n");
            MainMenu();
        }

        void OrderHistory()
        {
            Customer c = new Customer();
            Vendor v = new Vendor();
            Orders o = new Orders();
            Console.WriteLine("\n\n1. ALL ORDER HISTORY\n2. CUSTOMER ORDER HISTORY\n3. VENDOR ORDER HISTORY\n4. EXIT \n\nENTER YOUR CHOICE");
            int ch3 = Convert.ToInt32(Console.ReadLine());
            switch (ch3)
            {
                case 1:
                    o.ShowFullOrderHistory();
                    OrderHistory();
                    break;
                case 2:
                    Console.WriteLine("ENTER CUSTOMER ID");
                    int cId = Convert.ToInt32(Console.ReadLine());
                    c.ShowCustomerOrderHistory(cId);
                    Console.WriteLine();
                    Console.WriteLine();
                    Cancel();
                    OrderHistory();
                    break;

                case 3:
                    Console.WriteLine("ENTER VENDOR ID");
                    int vId = Convert.ToInt32(Console.ReadLine());
                    v.ShowVendorOrderHistory(vId);
                    AcceptReject();
                    OrderHistory();
                    break;

                case 4:
                    MainMenu();
                    break;

                default:
                    Console.WriteLine("ENTER VALID CHOICE");
                    OrderHistory();
                    break;
            }

        }


        void PlaceOrder()
        {
            Orders o = new Orders();
            Console.WriteLine("ENTER FOOD ID");
            int fid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("ENTER CUSTOER ID");
            int cid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("ENTER VENDOR ID");
            int vid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("ENTER FOOD QUANTITY");
            int qty = Convert.ToInt32(Console.ReadLine());

            Menu m = new Menu();

            //m.Id = fid;
            double price = m.FoodPrice(fid);

            double total = qty * price;

            o.AddOrder(fid, cid, vid, qty, total);

        }

        void Cancel()
        {
            Orders o = new Orders();
            Console.WriteLine("\n\n1. CANCEL ORDER\n2.EXIT\n\nENTER YOUR CHOICE");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("ENTER ORDER ID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    o.CancelOrder(id);
                    break;

                case 2:
                    OrderHistory();
                    break;

                default:
                    Console.WriteLine("\n\nENTER VALID CHOICE");
                    Cancel();
                    break;
            }

        }

        void AcceptReject()
        {
            Orders o = new Orders();
            Console.WriteLine("\n\nENTER YOUR CHOICE\n\n1. ACCEPT ORDER\n2. REJECT ORDER\n3. EXIT");
            int a = Convert.ToInt32(Console.ReadLine());

            switch (a)
            {
                case 1:
                    Console.WriteLine("ENTER ORDER ID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    o.AcceptOrder(id);
                    break;
                case 2:
                    Console.WriteLine("ENTER ORDER ID");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    o.RejectOrder(id1);
                    break;
                case 3:
                    OrderHistory();
                    break;
                default:
                    Console.WriteLine("\n\nENTER VALID CHOICE");
                    AcceptReject();
                    break;

            }
        }


    }
}
