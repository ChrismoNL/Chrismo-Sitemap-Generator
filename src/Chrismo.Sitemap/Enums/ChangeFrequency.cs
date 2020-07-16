using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Chrismo.Sitemap.Enums
{
    /// <summary>
    /// The possible values for frequency an url changes.
    /// </summary>
    [Serializable]
    public enum ChangeFrequency
    {
        /// <summary>
        /// Should be used to describe url that change each time they are accessed.
        /// </summary>
        [XmlEnum(Name = "always")]
        Always,

        /// <summary>
        /// Should be used to describe url that change hourly.
        /// </summary>
        [XmlEnum(Name = "hourly")]
        Hourly,

        /// <summary>
        /// Should be used to describe url that change daily.
        /// </summary>
        [XmlEnum(Name = "daily")]
        Daily,

        /// <summary>
        /// Should be used to describe url that change weekly.
        /// </summary>
        [XmlEnum(Name = "weekly")]
        Weekly,

        /// <summary>
        /// Should be used to describe url that change monthly.
        /// </summary>
        [XmlEnum(Name = "monthly")]
        Monthly,

        /// <summary>
        /// Should be used to describe url that change yearly.
        /// </summary>
        [XmlEnum(Name = "yearly")]
        Yearly,

        /// <summary>
        /// Should be used to describe url that are archived.
        /// </summary>
        [XmlEnum(Name = "never")]
        Never
    }
}
