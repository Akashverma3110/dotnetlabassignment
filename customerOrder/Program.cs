using System.Collections;
using System.Diagnostics;
using static customerOrder.Products;

namespace customerOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool exit = false;
                List<Customer> cust = new List<Customer>();
                List<Products> products = new List<Products>();
                
                while(!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                    Console.WriteLine("0:Add Product, 1:Register Customer, 2:Login Customer, 3:Exit");
                    int choice=Convert.ToInt32(Console.ReadLine());
                    switch(choice) 
                    {
                        case 0:
                            Console.WriteLine("Enter Product details");
                            Console.WriteLine("ItemId, ItemName, Quantity, Price per Item");
                            int itemid=Convert.ToInt32(Console.ReadLine()); 
                            String nameProduct=Console.ReadLine();
                            int qty = Convert.ToInt32(Console.ReadLine());
                            int rate = Convert.ToInt32(Console.ReadLine());
                            products.Add(new Products(itemid,nameProduct,qty,rate));
                            Console.WriteLine("Product added successfull");
                            break;
                        case 1:
                            Console.WriteLine("Enter the Custemer details");
                            Console.WriteLine("Customer ID: Name: Password: Age:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            String name=Console.ReadLine();
                            String pass = Console.ReadLine();
                            int age = Convert.ToInt32(Console.ReadLine());
                            cust.Add(new Customer(id, name, pass, age));
                            Console.WriteLine("Customer Added!!");
                            break;
                        case 2:
                            int cId=0;
                            bool logout = false;
                            Console.WriteLine("Enter the username and password");
                            String uname=Console.ReadLine();
                            String pass1=Console.ReadLine();
                            foreach(Customer obj in cust)
                            {
                                if (obj.Name == uname && obj.Password == pass1)
                                {
                                
                                    cId = obj.CustId; break;
                                }
                            }
                            if (cId == 0)
                            {
                                Console.WriteLine("Invalid credentials!! Try again");

                            }
                            else
                            {
                                Console.WriteLine("Login Successfull");
                                while (!logout)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("-------------------------------------------------------------");
                                    Console.WriteLine("1:Display the products, 2:Place the order, 3:Display the Order List, 4:logout");
                                    int custChoice = Convert.ToInt32(Console.ReadLine());
                                    switch(custChoice)
                                    {
                                        case 1:
                                            foreach(Products prod in products)
                                            {
                                                Console.WriteLine(prod);
                                            }
                                            break;
                                        case 2:
                                            //int ItemId, int ItemPrice, int ItemQuantity
                                            bool isProdAvailable = false;
                                            int qnty=0;
                                            string confOrder = null;
                                            bool isQuntAvailable = false;
                                            Products produc=null;
                                            int prodPrice=0;
                                            Console.WriteLine("Enter the Id of Product");
                                            int itemID=Convert.ToInt32(Console.ReadLine());
                                            foreach(Products prod in products)
                                            {
                                                if (prod.ItemId == itemID)
                                                {
                                                    isProdAvailable = true;
                                                    produc= prod;
                                                    break;
                                                }
                                            }
                                            if (isProdAvailable)
                                            {
                                                Console.WriteLine("Enter the Quantity");
                                                qnty = Convert.ToInt32(Console.ReadLine());
                                                if (produc.Quantity >= qnty)
                                                {
                                                    Console.WriteLine("Quantity available");
                                                    isQuntAvailable= true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Quantity not available");
                                                    break;
                                                }
                                                Console.WriteLine("Type YES to confirm order");
                                                confOrder=Console.ReadLine().ToUpper();
                                                if (confOrder == "YES")
                                                {
                                                    for(int i=0;i<products.Count; i++)
                                                    {
                                                        if(products[i].ItemId== itemID)
                                                        {
                                                            products[i].Quantity -= qnty;
                                                            prodPrice = products[i].Price;
                                                            break;
                                                        }
                                                    }
                                                    for (int i = 0; i < cust.Count; i++)
                                                    {
                                                        if (cust[i].CustId == cId)
                                                        {
                                                            // ItemId, int ItemPrice, int ItemQuantity
                                                            cust[i].orders.Add(new Order(itemID, prodPrice, qnty));
                                                            Console.WriteLine("Order Placed Successfully");
                                                            break;
                                                        }
                                                    }


                                                }


                                            }
                                            break;
                                        case 3:
                                            foreach(Customer c in cust)
                                            {
                                                if (c.CustId == cId)
                                                {
                                                    foreach(Order o in c.orders)
                                                    {
                                                        Console.WriteLine(o);
                                                    }
                                                }
                                            }
                                            break;
                                        case 4:
                                            logout = true;
                                            Console.WriteLine("Logout Successfull");
                                            break;
                                    }
                                }
                            }


                            break;
                        case 3:
                            exit = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

    public class Customer
    {
        private int custId;
        private string name;
        private string password;
        private int age;
        public List<Order> orders;
        

        public Customer(int CustId, String Name, string Password, int Age)
        {
            this.CustId = CustId;
            this.Name = Name;
            this.Password = Password;
            this.Age = Age;
            orders = new List<Order>();
        }

        public override string ToString()
        {
            return "Customer ID:" + CustId + ",  Name:" + Name + ",  Age:" + Age;
        }

        public int CustId
        {
            get { return custId; }
            set
            {
                custId = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value.Trim();
                }
                else
                {
                    throw new Exception("Name must not be null or Empty");
                }

            }
        }

        public String Password
        {
            get { return password; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    password = value.Trim();
                }
                else
                {
                    throw new Exception("Password must not be null or Empty");
                }

            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    throw new Exception("Age should be greater then zero");
                }
            }
        }
    }

    public class Products
    {
        private int itemId;
        private string itemName;
        private int price;
        private int quantity;

        public Products(int ItemId, string ItemName, int Quantity, int Price)
        {
            this.ItemId = ItemId;
            this.ItemName = ItemName;
            this.Quantity = Quantity;
            this.price = Price;
        }

        public override string ToString()
        {
            return "Item ID:" + ItemId + ",  Item Name:" + ItemName + ",  Quantity:" + Quantity + ",  Price:" + Price;
        }

        public int ItemId
        {
            get { return itemId; }
            set
            {
                if (value > 0)
                {
                    itemId = value;
                }
                else
                {
                    throw new Exception("Item ID must be positive");
                }

            }
        }


        public string ItemName { get { return itemName; } set { itemName = value; } }
        public int Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
                else
                {
                    throw new Exception("Price cannot be negative");
                }
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value >= 0)
                {
                    quantity = value;
                }
                else
                {
                    throw new Exception("Quantity must be greater then zero");
                }

            }
        }

        public class Order
        {
            private int orderId;
            private int itemId;
            private int itemPrice;
            private int quantity;
            private int amount;
            static int oId = 0;

            public Order(int ItemId, int ItemPrice, int ItemQuantity)
            {
                this.OrderId = ++oId;
                this.ItemId = ItemId;
                this.ItemPrice = ItemPrice;
                this.ItemQuantity = ItemQuantity;
                this.Amount = ItemPrice* ItemQuantity;
            }

            public override string ToString()
            {
                return "Order ID:" + OrderId + ",  Item ID:" + ItemId + ",  Quantity:" + ItemQuantity + ",  Total Amount:" + Amount;
            }

            public int OrderId
            {
                get { return orderId; }
                set
                {

                    orderId = value;
                }
            }
            public int ItemId
            {
                get { return itemId; }
                set
                {

                    itemId = value;
                }
            }
            public int ItemPrice
            {
                get { return itemPrice; }
                set
                {
                    itemPrice = value;
                }
            }

            public int ItemQuantity
            {
                get { return quantity; }
                set
                {
                    quantity = value;
                }
            }
            public int Amount
            {
                get { return amount; }
                set
                {
                    amount = value;
                }
            }
        }
    }
}