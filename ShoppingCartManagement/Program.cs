#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
#endregion Included Namespaces

namespace ShoppingCartManagement
{  
    public class product
    {
        #region Product Property
        public string Name { get; set; }
        public string Value { get; set; }
        #endregion Product Property
    }
    public class discount
    {
        #region Discount Property
        public string Name { get; set; }
        public string Value { get; set; }
        public string Percentage { get; set; }
        public string Count { get; set; }
        #endregion Discount Property
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Body
            bool flag = true;
            bool flg = true;
            List<product> cartList = new List<product>();
            List<discount> disList = new List<discount>();
            /// <summary>
            /// add products
            /// </summary>
            while (flag)
            {
                product items = new product();
                Console.WriteLine("Please enter the product name");
                items.Name = Console.ReadLine();
                Console.WriteLine("Please enter the amount");
                items.Value = Console.ReadLine();
                cartList.Add(items);
                Console.WriteLine("Do you want to add more products (Y or N)");
                var a = Console.ReadLine();
                flag = a == "Y" ? true : false;
            }
            /// <summary>
            /// add discounts
            /// </summary>
            while (flg)
            {
                discount items = new discount();
                Console.WriteLine("Please enter the product name to apply discount");
                items.Name = Console.ReadLine();
                Console.WriteLine("Number of products to get discount");
                items.Count = Console.ReadLine();
                Console.WriteLine("Please enter the discount percentage");
                items.Percentage = Console.ReadLine();
                disList.Add(items);
                Console.WriteLine("Do you want to add more products (Y or N)");
                var a = Console.ReadLine();
                flg = a == "Y" ? true : false;
            }
            /// <summary>
            /// Calculations
            /// </summary>
            var temp = cartList.GroupBy(x => x.Name = x.Name);
            //bool flag1 = false;
            foreach (var x in temp)
            {
                
                foreach (var y in disList)
                {
                    if (x.Key == y.Name && x.Count() >= Convert.ToInt32(y.Count) /*&& !flag1*/)
                    {
                        var count = 0;
                        foreach(var v in cartList)
                        {
                            if(y.Name == v.Name)
                            {
                                var discountedAmt = (Convert.ToInt32(v.Value) * (Convert.ToDecimal(y.Percentage)) / 100);
                                var actualAmt = (Convert.ToInt32(v.Value) - discountedAmt);
                                v.Value = actualAmt.ToString();
                                //flag1 = true;
                                count = count + 1;
                                if (count == Convert.ToInt32(y.Count))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    //if (flag1)
                    //{
                    //    break;
                    //} 
                }
            }
            decimal total = 0;
            foreach(var i in cartList)
            {
                total = total + Convert.ToDecimal(i.Value);
            }
            Console.WriteLine(Math.Floor(total));
            Console.ReadLine();
            #endregion Body
        }
    }
}
