using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using FlickrNet;

namespace FlickrSharp
{
    public class FlickrPlan
    {
        public List<FlickrImage> Images { get; set; }
        public List<FlickrSet> Sets { get; set; }

        public Identity User { get; set; }

        public FlickrNet.HiddenFromSearch HideFromSearch { get; set; }
        public FlickrNet.SafetyLevel Safety { get; set; }
        public FlickrNet.ContentType Type { get; set; }
        public FlickrNet.PrivacyFilter Privacy { get; set; }

        public FlickrPlan()
        {
            Images = new List<FlickrImage>();
            Sets = new List<FlickrSet>();
            User = new Identity();
        }

        public FlickrPlan (string Filename)
        {
            XmlSerializer xSer = new XmlSerializer(typeof(FlickrPlan));
            FlickrPlan plan = (FlickrPlan)xSer.Deserialize(new StreamReader(Filename).BaseStream);

            //HACK: There has to be a better way to map these properties back...
            Images = plan.Images;
            Sets = plan.Sets;
            User = plan.User;

            HideFromSearch = plan.HideFromSearch;
            Safety = plan.Safety;
            Type = plan.Type;
            Privacy = plan.Privacy;
        }


        public void WriteToFile(string Filename)
        {
            XmlSerializer xSer = new XmlSerializer(typeof(FlickrPlan));
            xSer.Serialize(new StreamWriter(Filename).BaseStream, this);
        }
    }
}
