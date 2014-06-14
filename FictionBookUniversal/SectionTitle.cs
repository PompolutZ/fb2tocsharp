using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FictionBookUniversal
{
    public class SectionTitle
    {
        public SectionTitle()
        {
            TitleElements = new List<SectionFormatElement>();
        }

        public List<SectionFormatElement> TitleElements { get; private set; }

        public static SectionTitle FromXElement(XElement element)
        {
            var sectionTitle = new SectionTitle();

            var nodes = element.Elements().ToList();
            foreach (var node in nodes)
            {
                var el = SectionFormatElement.FromXElement(node);
                if (el != null)
                    sectionTitle.TitleElements.Add(el);
            }

            return sectionTitle;
        } 
    }
}