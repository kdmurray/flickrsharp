using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FlickrNet;

namespace FlickrSharp
{
    public class FlickrSet
    {
        public string SetID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PrimaryPhotoId { get; set; }

        // Empty constructor required for serialization operation
        public FlickrSet()
        {
        }

        public FlickrSet(Photoset set)
        {
            SetID = set.PhotosetId;
            Title = set.Title;
            Description = set.Description;
            PrimaryPhotoId = set.PrimaryPhotoId;
        }

        public Photoset ToPhotoset()
        {
            Photoset ps = new Photoset();
            ps.PhotosetId = SetID;
            ps.Title = Title;
            ps.Description = Description;
            ps.PrimaryPhotoId = PrimaryPhotoId;
            return ps;
        }
    }
}
