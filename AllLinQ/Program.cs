using AllLinQ.Data;
using System.Net.Http.Headers;
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

        }
    }
}
