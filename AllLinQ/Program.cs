using AllLinQ.Data;
using System.Collections;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using static AllLinQ.ListGenerator;

namespace AllLinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Session 01
            //List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            #region LINQ Syntax [fluent , query] Syntax
            #region fluent Syntax
            // Fluent Syntax
            //// 1.can call LinQ Operators as a static methods =>
            //var Result = Enumerable.Where(Numbers, nums => nums % 2 == 0);


            //// 2.calling as Extensions methods .
            //// Extensions methods [Recommended]

            //var Result = Numbers.Where(nums => nums % 2 == 0);

            #endregion

            #region Query Syntax

            /*   var Result = from nums in Numbers
                           where nums % 2 == 0
                           select nums;
   */



            #endregion

            /*
                        foreach (var item in Result)
                        {
                            Console.WriteLine(item);
                        }
            */
            #endregion


            #region Exections ways [ Deferred Execution - Immediate Execution ]
            #region Deferred Execution
            //// Deferred Execution the operator will execute when calling
            /*        var GetOddNums = Numbers.Where(nums => nums % 2 == 1);
                    Numbers.AddRange(new int[] { 11, 12, 13, 14, 15 });

                    foreach (int num in GetOddNums) 
                    {
                        Console.WriteLine(num);
                    }*/
            #endregion

            #region Immediate Execution

            //// use casting operators or aggregate operators or elemenets operators

            /*     var GetOddNums = Numbers.Where(nums => nums % 2 == 1).ToList();

                 Numbers.AddRange(new int[] { 11, 12, 13, 14, 15 });

                 foreach (int num in GetOddNums)
                 {
                     Console.WriteLine(num);
                 }
     */

            #endregion

            #endregion



            #region Local 

            //var Result = ListGenerator.CustomersList.Select(c => c);
            //foreach (var c in Result)
            //{
            //    Console.WriteLine(c);
            //}

            //Console.WriteLine(ListGenerator.ProductList[0]);
            //Console.WriteLine(ListGenerator.CustomersList[0]);

            // The ListGenerator is static class that can be using 
            //Console.WriteLine(ProductList[0]);
            //Console.WriteLine(CustomersList[0]);

            #endregion
            #region Filtration - Where 
            //// fluent syntax
            //var Result = ProductList.Where(c => c.ProductID == 22);
            ////Query syntax
            //var Result = from Pro in ProductList
            //             where Pro.ProductID == 22
            //             select Pro;


            //var Result = ProductList.Where(pro => pro.UnitsInStock <= 0);
            //   var Result = ProductList.Where(pro => pro.UnitsInStock > 0 && pro.Category == "Meat/Poultry");

            ////Query syntax
            ///
            //var Result = from pro in ProductList
            //             where pro.UnitsInStock > 0 && pro.Category == "Meat/Poultry"
            //             select pro;

            #region indexed where

            //var Result = ProductList.Where((p, i) => p.UnitsInStock == 0 && i < 10);
            //var Result = ProductList.Where((p, i) => i < 10 && p.UnitsInStock == 0);

            #endregion
            #endregion

            #region Part 09 Transformation Operators - Select , Select Many
            ////Fluent syntax
            //var Result = ProductList.Select(p => p.ProductName);

            //// Query syntax
            //var Result = from pro in ProductList
            //             select pro.ProductName;
            #region selectMany()

            ////use selectMany() with collections of something
            //var Result = CustomersList.SelectMany(c => c.Orders);


            //// query syntax
            //var Result = from c in CustomersList
            //             from order in c.Orders
            //             select order;


            #endregion
            #region select() with  anonymous  object

            // return anonymous object use [ new ]  
            ////.. the CLR will create new class in runtime and override on ToString()
            //var Result = ProductList.Select(pr => new { pr.ProductID , pr.ProductName});

            ////query syntax 
            ///if use the same var should use the same names

            //Result = from pr in ProductList
            //            select new
            //            {
            //                ProductID = pr.ProductID,
            //                ProductName = pr.ProductName,
            //            };
            #endregion


            #region Q1 select product UnitsInStock and make discount on UnitPrice 10%

            /*
             ////fluent syntax
                        var Result = ProductList.Where(p => p.UnitsInStock > 0)
                            .Select(dis => new {
                                ProductId = dis.ProductID,
                                ProductName = dis.ProductName,
                                OldPrice = dis.UnitPrice,
                                NewPrice = dis.UnitPrice - (dis.UnitPrice * 0.1m),
                                discount   = dis.UnitPrice * 0.1m
                            });
            */

            //// query syntax
            /*
                        var Result = from p in ProductList
                                     where p.UnitsInStock > 0
                                     select new
                                     {
                                         p.ProductID,
                                         p.ProductName,
                                         p.UnitPrice,
                                        OldPrice =  p.UnitPrice - (p.UnitPrice * 0.1m),
                                     };
            */
            #endregion

            #region Select overload return index with ..(indexed select is valid only with fluent syntax)
            //// indexed select is valid only with fluent syntax
            //// var Result = ProductList.Where(p => p.UnitsInStock > 0).Select((p, i) => new { Index = i, p.ProductName });

            #endregion

            #endregion


            #region Part 10 Ordering Operators

            //var Result = ProductList.OrderBy(p => p.UnitPrice); //// Ascending order   
            //var Result = ProductList.OrderByDescending(p => p.UnitPrice); //// Descending order   

            /*
            var Result = from p in ProductList
                         orderby p.UnitPrice  //// Ascending order  
                         select p;
*/
            /*
                        var Result = from p in ProductList
                                     orderby p.UnitPrice descending //// Ascending order  
                                     select p;
            */

            #region make to ordering
            //var Result = ProductList.OrderBy(p => p.UnitPrice).ThenBy(p => p.UnitsInStock);
            //var Result = ProductList.OrderBy(p => p.UnitPrice).ThenByDescending(p => p.UnitsInStock);//// ThenByDescending() order by then order by 

            // Reverse()
            //var Result = ProductList.Where(p => p.UnitsInStock > 0).Reverse();
            #endregion

            #endregion

            #region Part 11 Element Operators - Immediate Execution - valid only with fluent syntax
            List<Product> EmptyProducts = new List<Product>()
            {


            };
            #region Fluent Syntax
            #region First()
            //// like top in SQl
            //var Result = EmptyProducts.First();
            /*Unhandled exception. System.InvalidOperationException: Sequence contains no elements*/

            //// may throw exception if the collection is empty 
            //var Result = ProductList.First();
            #endregion
            #region Last()
            //// may throw exception if the collection is empty 
            //Result = ProductList.Last();// get the last element in the collection
            //// if null
            //var Result = ProductList.Last(p=>p.ProductName == "AA");
            //// if not found the condition will return exception

            /*Unhandled exception. System.InvalidOperationException: Sequence contains no matching element*/
            //Console.WriteLine(Result?.ProductName ?? "Not Found"); // not working here

            #endregion

            #region FirstOrDefault()
            //// if the collection is empty will return the default value dataType    
            //var Result = EmptyProducts.FirstOrDefault();
            //// if not found the condition will return default value dataType
            //var Result = ProductList.FirstOrDefault(p => p.ProductName == "AA");
            //Console.WriteLine(Result?.ProductName ?? "Not Found"); // will work here (OrDefault)
            #endregion
            #endregion

            #region Query syntax
            /*
             first() , last() , firstOrDefault()  , LastOrDefault() not valid with query syntax
            //// use Hybrid Syntax
             */
            #endregion
            #region Hybrid Syntax - Query Expression
            /*
              var Result = (from p in ProductList
                            where p.UnitsInStock == 0
                            select new
                            {
                                  p.ProductID,
                                  p.ProductName
                            }).FirstOrDefault();//// Hybrid Syntax
  */
            #endregion
            #endregion


            #region Part 12 Aggregate Operators - Immediate Execution
            /*
             Count() , Sum() , Min() , Max() , Average()
            */
            #region Count()
            //var Result = ProductList.Count();
            //Console.WriteLine(Result);
            //// overload with condition take Func<Product , bool>
            //Result = ProductList.Count(p => p.UnitsInStock == 0);
            //Console.WriteLine( Result); 
            #endregion
            #region Max() - min()
            //// condition on what need get the maximum value
            /*
             should implement interface ICompareble<> .
             */

            /*Unhandled exception. System.ArgumentException: At least one object must implement IComparable.*/
            //var Result = ProductList.Max();

            //// after implement ICompareble<> in Product class

            //var Result = ProductList.Max();
            //var Result = ProductList.Min();

            //var Result = ProductList.Max(p => p.UnitPrice);

            //Console.WriteLine(Result);
            #endregion

            #region Sum()
            //var Result = ProductList.Sum(p => p.UnitsInStock);
            //Console.WriteLine(Result);
            #endregion
            #region Average()

            //var Result = ProductList.Average(p => p.UnitPrice); 
            //Console.WriteLine(Result);
            #endregion



            //string[] Name = new string[] { "AA" , "BB" ,"CC","DD" };

            //var Result = Name.Aggregate((str1, str2) => $"{str1}-{str2}");
            //Console.WriteLine(Result);
            #endregion

            ///Console.WriteLine(Result?.ProductName ?? "Not Found");

            //Console.WriteLine(Result);

            //foreach (var i in Result)
            //{
            //    Console.WriteLine(i);
            //} 
            #endregion

            #region  Session 02


            #region Part 01 Casting Operators - Immediate Execution
            //// Both .ToList() and .ToArray() always return a new instance of a collection. 
            #region ToList()

            //// need casting operators when dealing with different data types
            //// take the elements from collection and return  it as new list List<T>
            //List<Product> products = ProductList.Where(p => p.UnitsInStock == 0).ToList();
            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);   
            //}

            #endregion
            #region ToArray()
            //Product[] products = ProductList.Where(p => p.UnitsInStock == 0).ToArray();
            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region ToDictionary()
            /*
              Dictionary<long , Product> keyValuePairsProduct = ProductList.Where(p=>p.UnitsInStock == 0)
                                                                             .ToDictionary(p=>p.ProductID); *//*select the key*//*

                foreach (var item in keyValuePairsProduct)
                {
                    Console.WriteLine($"Key {item.Key} Value {item.Value}");
                }
                */
            /*
                        Dictionary<long , string> keyValuePairsProductIdAndNameIsValue = ProductList.Where(p=>p.UnitsInStock==0)
                            .ToDictionary(p=>p.ProductID , p=>p.ProductName);
                        foreach (var item in keyValuePairsProductIdAndNameIsValue)
                        {
                            Console.WriteLine($"Key {item.Key} Value {item.Value}");
                        }
            */
            #endregion

            #region OfType()
            /*
                        ArrayList obj = new ArrayList()
                        {
                            "AA","BB","CC",1,2,3,4
                        };
                        //var Result = obj.OfType<int>();
                        var Result = obj.OfType<string>();
                        foreach (var item in Result)
                        {

                            Console.WriteLine(item);
                        }
            */
            #endregion
            #endregion


            #region Part 02 Generation Operators
            //// deferred execution
            //// valid only with fluent syntax 
            //// Generation Operators
            ///
            /*
                        var Result = Enumerable.Range(0, 10); //// 0 to 9 
                        foreach(var Items in Result) Console.Write(Items + " ");
            */

            /*
                        var Name = Enumerable.Repeat("A", 10);//// return IEnumerable repeat "A" 10 times
                        foreach (var Items in Name) Console.Write(Items + " ");
                        */



            #endregion

            #region Part 03 Set Operators

            var Seq1 = Enumerable.Range(0, 100); //// 0 - 99
            var Seq2 = Enumerable.Range(50, 100); //// 50 - 149
            #region Union()
            /*
             return the items in two seq without duplication
             */
            /*
                        var Result = Seq1.Union(Seq2);


                        foreach (var item in Seq1)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine("\n---------------------------------------");
                        foreach (var item in Seq2)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine("\n---------------------------------------");

                        foreach (var item in Result)
                        {
                            Console.Write(item + " ");
                        }

            */
            #endregion

            #region Concat()
            /*
             return the itmes with duplications
            like UnionAll
             */
            //var Result = Seq1.Concat(Seq2);
            #endregion

            #region Dictinct()

            /*
             remove the duplication from seq
             */

            //var Result = Seq1.Concat(Seq2);

            //Result = Result.Distinct();
            #endregion

            #region Intersect()

            /*
             return elements in seq1 and seq2
             */


            //var Result  = Seq1.Intersect(Seq2);
            #endregion

            #region Except()
            /*
             return the elements is not exist in seq1 and seq2 

             */
            //var Result = Seq1.Except(Seq2);    
            #endregion


            //foreach (var item in Result)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion


            #region Part 04 Quantifier Operators - Return Boolean

            #region Any()

            /*
             if the seq has one element will return true 
             */
            /*will return true cuz the seq has element*/
            //bool Result = ProductList.Any();

            /*with condition*/
            //bool Result = ProductList.Any(p => p.UnitsInStock > 1000); ///.. false there is no any product unitsInStock > 1000    
            #endregion


            #region All()
            /*
             if all elements has the same condition will return true 
             */
            /*           
             *           var Result1 = ProductList.Any(p=>p.ProductID == 1);
                        Console.WriteLine(Result1);
            */
            //var Result = ProductList.All(p => p.ProductID == 1);

            #endregion



            //Console.WriteLine(Result);



            #endregion

            #region Part 05 Zip Operator

            //string[] Names =
            //{

            //    "AA", "BB" , "CC"
            //};

            //int[] Nums = Enumerable.Range(0, 5).ToArray();
            //char[] chars = { 'a', 'b', 'c', 'd', 'e' };
            ////var Result = Names.Zip(Nums); 
            ///*
            //     (AA, 0)
            //    (BB, 1)
            //    (CC, 2)
            //*/
            //var Result = Names.Zip(Nums,(Names , Nums)=> new {Index = Nums , Litera = chars});

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);


            //}
            #endregion

            #region Part 06 Grouping Operators
            /*
            1.Get Products Grouped by Category
            Get Products in Stock Grouped by Category
            Get Products in Stock Grouped by Category That Contains More Than 10 Product
            Get Category Name of Products in Stock That Contains More Than 10 Product and Number of Product In Each Category

             */

            #region Query syntax
            //var Result = from pro in ProductList
            //             group pro by pro.Category;


            //var Result = from pro in ProductList
            //             where pro.UnitsInStock > 0
            //             group pro by pro.UnitsInStock;
            /*
                        //// EX 3  Get Products in Stock Grouped by Category That Contains More Than 10 Product

                        var Result = from pro in ProductList
                                     where pro.UnitsInStock > 0
                                     group pro by pro.Category
                                     into Category
                                     where Category.Count() > 10
                                     select Category;
                        */

            //// EX4 Get Products in Stock Grouped by Category That Contains More Than 10 Product
/*
            var Result = from pro in ProductList
                         where pro.UnitsInStock > 0
                         group pro by pro.Category
                                     into Category
                         where Category.Count() > 10
                         select new
                         {
                             CategoryName = Category.Key, Count = Category.Count()
                         };
*/
            #endregion

            #region Fluent syntax
            // var Result = ProductList.GroupBy(p => p.Category);
            //var Result = ProductList.Where(p => p.UnitsInStock > 0)
            //     .GroupBy(p => p.Category);


            //// EX 3  Get Products in Stock Grouped by Category That Contains More Than 10 Product
            /*
                        var Result = ProductList.Where(p => p.UnitsInStock > 0)
                            .GroupBy(p => p.Category).Where(p => p.Count() > 10);
            */


            //// EX 4  Get Products in Stock Grouped by Category That Contains More Than 10 Product

            /*
                    var Result = ProductList.Where(p => p.UnitsInStock > 0)
                        .GroupBy(p => p.Category).Where(p => p.Count() > 10).Select(x=>new {
                            CategoryName = x.Key, Count = x.Count()
                        });
*/
     /*       foreach (var item in Result)
            {
                Console.WriteLine(item);
            }*/
            #endregion
            //foreach (var Category in Result)
            //{
            //    Console.WriteLine(Category.Key); //// the is Category name 
            //    foreach (var product in Category)
            //    {
            //        Console.WriteLine($"            {product.ProductName}");
            //    }

            //}


            #endregion
            #endregion

        }
    }
}
