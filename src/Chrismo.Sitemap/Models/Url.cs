using Chrismo.Sitemap.Enums;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chrismo.Sitemap.Models
{
    /// <summary>
    /// The model for an URL in the sitemap
    /// </summary>
    [Serializable]
    [XmlRoot("url")]
    [XmlType("url")]
    public class Url
    {
        /// <summary>
        /// URL of the page. This URL must begin with the protocol (such as http) and end with a trailing slash, if your web server requires it. This value must be less than 2,048 characters.
        /// </summary>
        [XmlElement("loc")]
        public string Location { get; set; }

        /// <summary>
        /// The date of last modification of the file.
        /// </summary>
        [XmlElement("lastmod", DataType = "date")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// How frequently the page is likely to change. This value provides general information to search engines and may not correlate exactly to how often they crawl the page.
        /// </summary>
        [XmlElement("changefreq")]
        public ChangeFrequency ChangeFrequency { get; set; }

        /// <summary>
        /// The priority of this URL relative to other URLs on your site. Valid values range from 0.0 to 1.0. This value does not affect how your pages are compared to pages on other sites—it only lets the search engines know which pages you deem most important for the crawlers.
        /// </summary>
        [XmlElement("priority")]
        public double Priority { get; set; }

        /// <summary>
        /// The alternate links for this URL.
        /// </summary>
        [XmlElement(ElementName = "link", Namespace = "http://www.w3.org/1999/xhtml")]
        public List<Link> Links { get; set; }

        /// <summary>
        /// Create an new URL
        /// </summary>
        /// <param name="location">The full URL of the page.</param>
        /// <returns>new URL</returns>
        public static Url CreateUrl(string location) => CreateUrl(location, DateTime.Now);

        /// <summary>
        /// Create an new URL
        /// </summary>
        /// <param name="url">The full URL of the page.</param>
        /// <param name="lastModified">The date the page is last modified</param>
        /// <returns>new URL</returns>
        public static Url CreateUrl(string url, DateTime lastModified) =>
            new Url
            {
                Location = url,
                ChangeFrequency = ChangeFrequency.Daily,
                Priority = 0.8d,
                LastModified = lastModified,
            };



    }
}
