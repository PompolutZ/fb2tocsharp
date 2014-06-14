using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FictionBookUniversal.Utilities
{
    public static class Extensions
    {
        public static XElement Fb2Element(this XElement element, string elementName)
        {
            return element.Element(XName.Get(elementName, FictionBookConstants.FictionBookDefaultNamespace));
        }

        public static string FromFb2Tag(this XElement element, string elementName)
        {
            return element.Element(XName.Get(elementName, FictionBookConstants.FictionBookDefaultNamespace)).IfNotNull(x => x.Value);
        }

        public static IEnumerable<XElement> Fb2Elements(this XElement element, string elementName)
        {
            return element.Elements(XName.Get(elementName, FictionBookConstants.FictionBookDefaultNamespace));
        }

        public static TOut IfNotNull<TIn, TOut>(this TIn v, Func<TIn, TOut> f)
            where TIn : class
            where TOut : class
        {
            if (v == null)
                return null;

            return f(v);
        }
    }
}