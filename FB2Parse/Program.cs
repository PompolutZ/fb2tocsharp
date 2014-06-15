using System.IO;
using System.Threading;
using FictionBookUniversal;

namespace FB2Parse
{
    public class Program
    {
        private const string Book1 = @"C:\Users\olo\Downloads\book.fb2";
        
        private const string DanceWithDragons = @"C:\Users\olo\Downloads\a_dance_with_dragons.fb2";

        private const string BookPath = @"..\..\BooksForTest\book.fb2";

        static void Main(string[] args)
        {
            using (var fileStream = File.OpenRead(BookPath))
            {
                var doc = FictionBookParser.Parse(fileStream);
            }
        }
    }
}
