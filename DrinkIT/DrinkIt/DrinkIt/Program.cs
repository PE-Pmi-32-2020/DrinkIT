
using DrinkIt.bll;

namespace DrinkIt
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int records = 5;
            
            DataGenerator.Generate(records);
            
            DataView dv = new DataView();
            
            dv.PrintUsers();
            
            
        }
    }
}