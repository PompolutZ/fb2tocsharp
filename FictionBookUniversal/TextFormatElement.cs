using System.Collections.Generic;
using System.Xml.Linq;

namespace FictionBookUniversal
{
    public class SectionFormatElement
    {
        private const string ParagraphTagName = "p";

        private const string EmptyLineTagName = "empty-line";

        public static SectionFormatElement FromXElement(XElement element)
        {
            if (element.Name.LocalName == ParagraphTagName)
                return Paragraph.FromXElement(element);

            if (element.Name.LocalName == EmptyLineTagName)
                return new EmptyLine();

            return null;
        }
    }

    public class Paragraph : SectionFormatElement
    {
        public Paragraph()
        {
            FormattedText = new List<TextFormatElement>();
        }

        public List<TextFormatElement> FormattedText { get; private set; }

        public string Text { get; private set; }

        public new static Paragraph FromXElement(XElement element)
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