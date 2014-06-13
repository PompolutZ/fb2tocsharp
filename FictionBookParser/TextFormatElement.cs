using System.Collections.Generic;
using System.Xml.Linq;

namespace FictionBookParser
{


    public class SectionFormatElement
    {
    }

    public class Paragraph : SectionFormatElement
    {
        private const string ParagraphTagName = "p";

        public Paragraph()
        {
            FormattedText = new List<TextFormatElement>();
        }

        public List<TextFormatElement> FormattedText { get; private set; }

        public string Text { get; private set; }

        public static Paragraph FromXElement(XElement element)
        {
            var paragraph = new Paragraph();
            paragraph.Text = element.Value;
            return paragraph;
        }
    }

    public class EmptyLine : SectionFormatElement
    {

    }

    public abstract class TextFormatElement
    {
        protected TextFormatElement()
        {
            FormattedText = new List<TextFormatElement>();
        }

        public string Text { get; set; }

        public List<TextFormatElement> FormattedText { get; private set; }
    }

    public class StrongText : TextFormatElement
    {
        private const string StrongTextTagName = "strong";
    }

    public class EmphasisText : TextFormatElement
    {
        private const string EmphasisTextTagName = "emphasis";
    }
}