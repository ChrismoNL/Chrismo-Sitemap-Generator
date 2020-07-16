using System;
using System.Xml.Serialization;

namespace Chrismo.Sitemap.Models
{
    /// <summary>
    /// Een alternate link for the URL
    /// </summary>
    [Serializable]
	[XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/1999/xhtml")]
	public class Link
	{
		/// <summary>
		/// The the type of link, this is always alternate and therefor already set.
		/// </summary>
		[XmlAttribute(AttributeName = "rel")]
		public const string Rel = "alternate";

		/// <summary>
		/// The value of the hreflang attribute identifies the language (in ISO 639-1 format) and optionally a region (in ISO 3166-1 Alpha 2 format) of an alternate URL. (The language need not be related to the region.)
		/// </summary>
		[XmlAttribute(AttributeName = "hreflang")]
		public string HrefLang { get; set; }

		/// <summary>
		/// The alternate URL. It must be fully-qualified, including the transport method (http/https), so: https://example.com/foo, not //example.com/foo or /foo
		/// </summary>
		[XmlAttribute(AttributeName = "href")]
		public string Href { get; set; }
	}
}
