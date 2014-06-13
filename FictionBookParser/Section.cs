using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FictionBookParser
{
    public class Section
    {
        private const string TitleTagName = "title";

        private const string EpigraphTagName = "epigraph";

        private const string AnnotationTagName = "annotation";

        public Section()
        {
            SectionElements = new List<SectionFormatElement>();
        }

        public List<SectionFormatElement> SectionElements { get; private set; }

        public static Section FromXElement(XElement element)
        {
            var section = new Section();
            var nodes = element.Elements().ToList();

            var subSections = element.Fb2Elements("section");
            var ps = element.Fb2Elements("p");
            foreach (var p in ps)
            {
            }

            return section;
        }
    }
}