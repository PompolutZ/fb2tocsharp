using System.Xml.Linq;
using FictionBookUniversal.Utilities;

namespace FictionBookUniversal
{
    public class FictionBook
    {
        public Desciption Desciption { get; private set; }

        public Body Body { get; private set; }

        public static FictionBook FromXDocument(XDocument doc)
        {
            var book = doc.Element(XName.Get("FictionBook", FictionBookConstants.FictionBookDefaultNamespace));
            return new FictionBook
            {
                Desciption = book.FromFb2Tag(FictionBookConstants.DescriptionTagName, Desciption.FromXElement),
                Body = book.FromFb2Tag(FictionBookConstants.BodyTagName, Body.FromXElement)
            };
        }
    }
}