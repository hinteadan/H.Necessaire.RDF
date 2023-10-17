﻿using System;
using System.Collections.Concurrent;
using System.Linq;

namespace H.Necessaire.RDF
{
    public abstract class RdfConceptBase : ImAnRdfConcept
    {
        private ConcurrentDictionary<string, Note> notes = new ConcurrentDictionary<string, Note>();

        protected RdfConceptBase()
        {
            ID = $"{ConceptType}-{Guid.NewGuid()}";
        }

        public virtual string ID { get; set; }
        public abstract RdfConceptType ConceptType { get; }
        public Note[] Notes
        {
            get
            {
                return notes.Select(x => x.Value).ToArrayNullIfEmpty();
            }
            set
            {
                if (value is null)
                {
                    notes.Clear();
                    return;
                }

                foreach (var x in value)
                {
                    notes.TryAdd(x.ToString(), x);
                }
            }
        }
    }
}
