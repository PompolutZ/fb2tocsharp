using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FictionBookParser
{
    public class TitleInfo
    {
        private const string BookTitleTagName = "book-title";

        private const string DateTagName = "date";

        private const string AuthorTagName = "author";

        private TitleInfo() 
        {
            Genres = new List<string>();            
            Authors = new List<Author>();
            Annotations = new List<string>();
            Keywords = new List<string>();
        }

        public string Title { get; set; }

        public string Date { get; set; }

        public string Coverpage { get; set; }

        public string Language { get; set; }

        public List<string> Genres { get; set; }

        public IEnumerable<Author> Authors { get; set; }
        
        public List<string> Annotations { get; set; }

        public List<string> Keywords { get; set; }

        public static TitleInfo FromXElement(XElement element)
        {
            var titleInfo = new TitleInfo
            {
                Title = element.FromFb2Tag(BookTitleTagName),
                Date = element.FromFb2Tag(DateTagName),
                Authors = element.Fb2Elements(AuthorTagName).IfNotNull(x => x.Select(Author.FromXElement))
            };

            return titleInfo;
        }
    }
}