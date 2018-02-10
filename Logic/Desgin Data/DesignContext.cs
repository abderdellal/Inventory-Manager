using Logic.Core.Domain;
using System;
using System.Collections.Generic;

namespace Logic.Desgin_Data
{
    public class DesignContext
    {
        public List<Product> Products { get; set; }
        public List<Store> Stores { get; set; }

        public DesignContext()
        {
            Products = new List<Product>();
            Stores = new List<Store>();

            Product p1 = new Product(0, "F1s", 15000, 1900, null, "OPPO F1s");
            Product p2 = new Product(1, "Galaxy S8", 80000, 95000, null, "Samsung Galaxy S9");
            Product p3 = new Product(2, "Iphone 7", 70000, 81000, null, "apple Iphone 7");
            Product p4 = new Product(3, "Nokia 5200", 25000, 32000, null, "Nokia Lumia ...");
            Product p5 = new Product(4, "Motorola 2", 12000, 15000, null, "Motorola abcd efgh opui");
            Products.Add(p1);
            Products.Add(p2);
            Products.Add(p3);
            Products.Add(p4);
            Products.Add(p5);

            Store s1 = new Store(0, "Deniro", "Robbert", "Phone Store", "0124578952", null, "phones, ssomthing something");
            Store s2 = new Store(1, "brad", "pit", "Apple Store", "0124578952", null, "phones, ssomthing something");
            Store s3 = new Store(2, "Cruz", "Tom", "Windows Store", "0124578952", null, "phones, ssomthing something");
            Store s4 = new Store(3, "Smith", "Will", "Some Store", "0124578952", null, "phones, ssomthing something");
            Store s5 = new Store(4, "Leonardo", "Decaprio", "play Store", "0124578952", null, "phones, ssomthing something");
            Stores.Add(s1);
            Stores.Add(s2);
            Stores.Add(s3);
            Stores.Add(s4);
            Stores.Add(s5);

            Stock stk1 = new Stock(4, p1, s1);
            p1.Stocks.Add(stk1);
            s1.Stocks.Add(stk1);
            Stock stk2 = new Stock(2, p2, s1);
            p2.Stocks.Add(stk2);
            s1.Stocks.Add(stk2);
            Stock stk3 = new Stock(4, p3, s1);
            p3.Stocks.Add(stk3);
            s1.Stocks.Add(stk3);
            Stock stk4 = new Stock(4, p4, s1);
            p4.Stocks.Add(stk4);
            s1.Stocks.Add(stk4);
            Stock stk5 = new Stock(4, p2, s2);
            p2.Stocks.Add(stk5);
            s2.Stocks.Add(stk5);
            Stock stk6 = new Stock(4, p5, s2);
            p5.Stocks.Add(stk6);
            s1.Stocks.Add(stk6);
            Stock stk7 = new Stock(4, p4, s3);
            p4.Stocks.Add(stk7);
            s3.Stocks.Add(stk7);
            Stock stk8 = new Stock(4, p5, s3);
            p5.Stocks.Add(stk8);
            s3.Stocks.Add(stk8);
            Stock stk9 = new Stock(4, p3, s3);
            p3.Stocks.Add(stk9);
            s3.Stocks.Add(stk9);
            Stock stk10 = new Stock(4, p2, s4);
            p2.Stocks.Add(stk10);
            s4.Stocks.Add(stk10);

            Purchase pr1 = new Purchase(0, "28-10-2017", s1, p1, 5);
            s1.Purchases.Add(pr1);
            p1.Purchases.Add(pr1);
            Purchase pr2 = new Purchase(0, "29-10-2017", s1, p2, 6);
            s1.Purchases.Add(pr2);
            p2.Purchases.Add(pr2);
            Purchase pr3 = new Purchase(0, "29-10-2017", s1, p3, 2);
            s1.Purchases.Add(pr3);
            p3.Purchases.Add(pr3);
            Purchase pr4 = new Purchase(0, "30-10-2017", s2, p2, 3);
            s2.Purchases.Add(pr4);
            p2.Purchases.Add(pr4);
            Purchase pr5 = new Purchase(0, "31-10-2017", s2, p1, 3);
            s2.Purchases.Add(pr5);
            p1.Purchases.Add(pr5);
            Purchase pr6 = new Purchase(0, "31-10-2017", s4, p1, 2);
            s4.Purchases.Add(pr6);
            p1.Purchases.Add(pr6);
            Purchase pr7 = new Purchase(0, "31-10-2017", s5, p1, 5);
            s5.Purchases.Add(pr7);
            p1.Purchases.Add(pr7);

            Sale sl1 = new Sale(0, "28-10-2017", s1, p1, 5);
            s1.Sales.Add(sl1);
            p1.Sales.Add(sl1);
            Sale sl2 = new Sale(0, "29-10-2017", s1, p2, 6);
            s1.Sales.Add(sl2);
            p2.Sales.Add(sl2);
            Sale sl3 = new Sale(0, "29-10-2017", s1, p3, 2);
            s1.Sales.Add(sl3);
            p3.Sales.Add(sl3);
            Sale sl4 = new Sale(0, "30-10-2017", s2, p2, 3);
            s2.Sales.Add(sl4);
            p2.Sales.Add(sl4);
            Sale sl5 = new Sale(0, "31-10-2017", s2, p1, 3);
            s2.Sales.Add(sl5);
            p1.Sales.Add(sl5);
            Sale sl6 = new Sale(0, "31-10-2017", s4, p1, 2);
            s4.Sales.Add(sl6);
            p1.Sales.Add(sl6);
            Sale sl7 = new Sale(0, "31-10-2017", s5, p1, 5);
            s5.Sales.Add(sl7);
            p1.Sales.Add(sl7);

        }
    }
}