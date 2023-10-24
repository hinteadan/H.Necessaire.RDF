﻿using System;

namespace H.Necessaire.RDF
{
    public class RdfAspect : IGuidIdentity
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public string DisplayLabel { get; set; }

        public RdfNode Object { get; set; }

        public RdfAspect[] Aspects { get; set; }

        public Note[] Notes { get; set; }


        public override string ToString()
        {
            return
                DisplayLabel.NullIfEmpty()
                ??
                ID.ToString()
                ;
        }
    }
}