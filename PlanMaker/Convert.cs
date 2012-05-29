using System;
using System.Collections.Specialized;

namespace FlickrSharp
{
    public static class Util
    {
        public static StringCollection ConvertToStringCollection(string[] array)
        {
            StringCollection retVal = new StringCollection();
            foreach (string s in array)
            {
                retVal.Add(s);
            }
            return retVal;
        }
    }
}
