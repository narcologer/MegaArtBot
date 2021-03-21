using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaArtBot
{
    partial class Functions
    {
        public static IEnumerable<string> ImgParser(AngleSharp.Dom.IDocument document, String Addition)
        {
            var fileExtensions = new string[] { ".jpg", ".png" };

            IEnumerable<string> imgcol = from element in document.All
                                         from attribute in element.Attributes
                                         where fileExtensions.Any(ee => attribute.Value.Contains(ee)) && (attribute.Value.Contains(Addition))
                                         select attribute.Value;
            return imgcol;
        }
    }
}
