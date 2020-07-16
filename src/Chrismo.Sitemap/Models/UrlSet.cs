using Chrismo.Sitemap.Exceptions;
using Chrismo.Sitemap.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Chrismo.Sitemap.Models
{
    [Serializable]
    [XmlRoot(ElementName = "urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class UrlSet : List<Url>
    {
        // Max sizes as given by sitemaps.orgs (https://www.sitemaps.org/faq.html#:~:text=Sitemaps%20should%20be%20no%20larger,down%20serving%20very%20large%20files.)
        public const int MaxNumberOfUrlsPerSitemap = 50000;
        public const int MaxBytesPerSitemap = 52428800;

        /// <summary>
        /// Generate the XML file
        /// </summary>
        /// <returns>The XML file as an string</returns>
        public virtual string ToXml()
        {
            if(this.Count >= MaxNumberOfUrlsPerSitemap)
            {
                throw new ToBigException();
            }

            var serializer = new XmlSerializer(typeof(UrlSet));
            var ns = new XmlSerializerNamespaces();
            ns.Add("xhtml", "http://www.w3.org/1999/xhtml");
            string result = string.Empty;
            using (var writer = new StringWriterUtf8())
            {
                serializer.Serialize(writer, this, ns);
                result = writer.ToString();
            }

            if (Encoding.UTF8.GetByteCount(result) >= MaxBytesPerSitemap)
            {
                throw new ToBigException();
            }

            return result;
        }

        /// <summary>
        /// Parse an XML file to model
        /// </summary>
        /// <param name="xml">The XML file in string format</param>
        /// <returns>The sitemap model</returns>
        public static UrlSet Parse(string xml)
        {
            using (TextReader textReader = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(UrlSet));
                return serializer.Deserialize(textReader) as UrlSet;
            }
        }

        /// <summary>
        /// Parse an XML file to model
        /// </summary>
        /// <param name="xml">The XML file in string format</param>
        /// <param name="sitemap">The sitemap model</param>
        /// <returns>True if we could sucessfully map the site map and an false if we could not.</returns>
        public static bool TryParse(string xml, out UrlSet sitemap)
        {
            try
            {
                sitemap = Parse(xml);
                return true;
            }
            catch
            {
                sitemap = null;
                return false;
            }
        }
    }
}
