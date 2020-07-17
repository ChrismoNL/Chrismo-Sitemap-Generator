using Xunit;
using Chrismo.Sitemap.Models;
using System;
using Chrismo.Sitemap.Enums;
using System.Collections.Generic;

namespace Chrismo.Sitemap.Tests
{
    public class UrlSetTests
    {
        [Fact]
        public void Can_Serialize_Simple_Sitemap_Correctly()
        {
            // arrange
            UrlSet urlSet = new UrlSet();
            urlSet.Add(Url.CreateUrl("https://www.chrismo.nl"));
            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");

            // act
            var result = urlSet.ToXml();

            // assert
            Assert.Equal($"<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<urlset xmlns:xhtml=\"http://www.w3.org/1999/xhtml\" xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">\r\n  <url>\r\n    <loc>https://www.chrismo.nl</loc>\r\n    <lastmod>{todayDate}</lastmod>\r\n    <changefreq>daily</changefreq>\r\n    <priority>0.8</priority>\r\n  </url>\r\n</urlset>", result);
        }

        [Fact]
        public void Can_Serialize_Multilanguage_Sitemap_Correctly()
        {
            // arrange
            UrlSet urlSet = new UrlSet();
            urlSet.Add(new Url
            {
                Location = "https://www.chrismo.nl/nl",
                LastModified = new DateTime(2008, 1, 8),
                ChangeFrequency = ChangeFrequency.Daily,
                Priority = 1,
                Links = new List<Link>
                {
                    new Link
                    {
                        Href = "https://www.chrismo.nl/en",
                        HrefLang = "en"
                    },
                    new Link
                    {
                        Href = "https://www.chrismo.nl/de",
                        HrefLang = "de"
                    },
                    new Link
                    {
                        Href = "https://www.chrismo.nl/fr",
                        HrefLang = "fr"
                    }
                }
            });

            // act
            var result = urlSet.ToXml();

            // assert
            Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<urlset xmlns:xhtml=\"http://www.w3.org/1999/xhtml\" xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">\r\n  <url>\r\n    <loc>https://www.chrismo.nl/nl</loc>\r\n    <lastmod>2008-01-08</lastmod>\r\n    <changefreq>daily</changefreq>\r\n    <priority>1</priority>\r\n    <xhtml:link hreflang=\"en\" href=\"https://www.chrismo.nl/en\" />\r\n    <xhtml:link hreflang=\"de\" href=\"https://www.chrismo.nl/de\" />\r\n    <xhtml:link hreflang=\"fr\" href=\"https://www.chrismo.nl/fr\" />\r\n  </url>\r\n</urlset>", result);
        }
    }
}