using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;


namespace JsonSerializer
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //字符串发序列化为对象
            string jsonStr = "[{Name:'苹果',Price:5.5},{Name:'橘子',Price:2.5},{Name:'柿子',Price:16}]";
            List<Product> products = new List<Product>();
            products = JSONToList.JSONStringToList<Product>(jsonStr);

            foreach (var item in products)
            {
                Console.WriteLine(item.Name + ":" + item.Price + "<br />");
                
            }
            //对象序列化成json字符串
            Console.WriteLine(GetJsonString());
            Console.ReadKey();
        }

        public static string GetJsonString()         
        {
              List<Product> products = new List<Product>() { 
              new Product(){Name="苹果",Price=3.9},
              new Product(){Name="橘子",Price=2.5},  
              new Product(){Name="干柿子",Price=16.00}
            };
              ProductList productlist = new ProductList();
              productlist.GetProducts = products;
              return new JavaScriptSerializer().Serialize(productlist);
        }
        public class ProductList
        {
            public List<Product> GetProducts { get; set; }
        } 
       
    }
}
