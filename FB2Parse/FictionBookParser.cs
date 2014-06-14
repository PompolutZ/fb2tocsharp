using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FictionBookUniversal;
using FictionBookUniversal.Utilities;

namespace FB2Parse
{
    public class FictionBookParser
    {
        public string Parse(Stream bookStream)
        {
            XDocument xdoc = XDocument.Load(bookStream);
            var book = xdoc.Element(XName.Get("FictionBook", FictionBookConstants.FictionBookDefaultNamespace));
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