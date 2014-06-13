using System.Xml.Linq;

namespace FictionBookParser
{
    public class Desciption
    {
        private const string TitleInfoTagName = "title-info";

        private const string DocumentInfoTagName = "document-info";

        public TitleInfo TitleInfo { get; set; }

        public DocumentInfo DocumentInfo { get; set; }

        public static Desciption FromXElement(XElement element)
        {
            var description = new Desciption
            {
                TitleInfo = TitleInfo.FromXElement(element.Fb2Element(TitleInfoTagName))
            };
                
            return description;
        }
    }
}