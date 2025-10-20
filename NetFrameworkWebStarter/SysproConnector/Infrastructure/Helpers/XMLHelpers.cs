using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SysproConnector.Infrastructure.Helpers
{
    public static class XMLHelpers
    {
        public static void Sort(XDocument xDoc, string parent, string child, string sortPropertyName)
        {
            var children = xDoc.Descendants(child).OrderBy(x => (int)(x.Element(sortPropertyName)));
            xDoc.Descendants(parent).First().ReplaceNodes(children);
        }
        //public static void Sort<TKey>(this XElement input, Func<XElement, TKey> selector)
        //{
        //    input.Elements().ToList().ForEach(el => el.Sort(selector));
        //    input.ReplaceNodes(input.Elements().OrderBy(selector));
        //}
    }
}
