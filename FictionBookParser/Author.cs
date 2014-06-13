using System.Xml.Linq;

namespace FictionBookParser
{
    public class Author
    {
        private const string FirstNameTagName = "first-name";

        private const string MiddleNameTagName = "middle-name";

        private const string LastNameTagName = "last-name";

        private const string NicknameTagName = "nickname";

        private const string EmailTagName = "email";

        public string FirstName { get; private set; }
        
        public string MiddleName { get; private set; }
        
        public string LastName { get; private set; }

        public string Nickname { get; private set; }

        public string Email { get; private set; }

        public static Author FromXElement(XElement element)
        {
            var author = new Author
            {
                FirstName = element.FromFb2Tag(FirstNameTagName),
                MiddleName = element.FromFb2Tag(MiddleNameTagName),
                LastName = element.FromFb2Tag(LastNameTagName),
                Nickname = element.FromFb2Tag(NicknameTagName),
                Email = element.FromFb2Tag(EmailTagName)
            };

            return author;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
        }
    }
}