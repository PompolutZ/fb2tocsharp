using System.IO;
using System.Threading;

namespace FB2Parse
{
    public class Program
    {
        private const string Book1 = @"C:\Users\olo\Downloads\book.fb2";
        
        private const string DanceWithDragons = @"C:\Users\olo\Downloads\a_dance_with_dragons.fb2";

        private const string BookPath = @"..\..\BooksForTest\book.fb2";

        static void Main(string[] args)
        {
            FictionBookParser fbParser = new FictionBookParser();
            //using (var fileStream = File.OpenRead(Book1))
            //{
            //    var doc = fbParser.Parse(fileStream);
            //}

            using (var fileStream = File.OpenRead(BookPath))
            {
                var doc = fbParser.Parse(fileStream);
            }
        }
    }
}
