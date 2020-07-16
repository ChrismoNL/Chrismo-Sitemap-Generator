using System;
using System.Collections.Generic;
using System.Text;

namespace Chrismo.Sitemap.Exceptions
{
    public class ToBigException : Exception
    {
        public ToBigException() : base ("The sitemap is to big to be generated in an valid sitemap.")
        {

        }
    }
}
