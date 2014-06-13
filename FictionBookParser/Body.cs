using System.Collections.Generic;
using System.Xml.Linq;

namespace FictionBookParser
{
    public class Body
    {
        private const string SectionTagName = "section";

        public Body()
        {
            Sections = new List<Section>();
        }

        public List<Section> Sections { get; private set; }

        public static Body FromXElement(XElement element)
        {
            var body = new Body();
            var sections = element.Fb2Elements(SectionTagName);
            foreach (var section in sections)
            {
                var s = Section.FromXElement(section);
                body.Sections.Add(s);
            }

            return body;
        }
    }
}