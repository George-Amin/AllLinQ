namespace AllLinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
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
        }
    }
}
