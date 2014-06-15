using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace FictionBookUniversal
{
    public class FictionBookParser
    {
        public static FictionBook Parse(Stream bookStream)
        {
            XDocument xdoc = XDocument.Load(bookStream);
            //var book = xdoc.Element(XName.Get("FictionBook", FictionBookConstants.FictionBookDefaultNamespace));
            //var description = book.Fb2Element(FictionBookConstants.DescriptionTagName);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            //var desc = Desciption.FromXElement(book.Fb2Element(FictionBookConstants.DescriptionTagName));
            //var body = Body.FromXElement(book.Fb2Element(FictionBookConstants.BodyTagName));
            var book = FictionBook.FromXDocument(xdoc);
            stopwatch.Stop();
            Debug.WriteLine("Parsed in {0}", TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds));
            //var binary = book.Fb2Elements(FictionBookConstants.BinaryTagName).Count();

            return book;
        }
    }
}