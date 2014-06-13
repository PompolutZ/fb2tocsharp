using System;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using FictionBookParser;

namespace FB2Parse
{
    public class Program
    {
        private const string Book1 = @"C:\Users\olo\Downloads\book.fb2";
        
        private const string DanceWithDragons = @"C:\Users\olo\Downloads\a_dance_with_dragons.fb2";

        static void Main(string[] args)
        {
            FictionBookParser fbParser = new FictionBookParser();
            using (var fileStream = File.OpenRead(Book1))
            {
                var doc = fbParser.Parse(fileStream);
            }

            using (var fileStream = File.OpenRead(DanceWithDragons))
            {
                var doc = fbParser.Parse(fileStream);
            }
        }
    }

    public class FictionBookParser
    {
        private const string FictionBookDefaultNamespace = "http://www.gribuser.ru/xml/fictionbook/2.0";

        public string Parse(Stream bookStream)
        {
            XDocument xdoc = XDocument.Load(bookStream);
            var book = xdoc.Element(XName.Get("FictionBook", FictionBookDefaultNamespace));
            var description = book.Fb2Element(FictionBookConstants.DescriptionTagName);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var desc = Desciption.FromXElement(book.Fb2Element(FictionBookConstants.DescriptionTagName));

            var body = Body.FromXElement(book.Fb2Element(FictionBookConstants.BodyTagName));
            stopwatch.Stop();
            Console.WriteLine(TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds));
            var binary = book.Fb2Elements(FictionBookConstants.BinaryTagName).Count();

            return book.ToString();
        }
    }
}
