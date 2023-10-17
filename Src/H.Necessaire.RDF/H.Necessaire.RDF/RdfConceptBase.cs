using System;
using System.Collections.Concurrent;
using System.Linq;

namespace H.Necessaire.RDF
{
    public abstract class RdfConceptBase : ImAnRdfConcept
    {
        private ConcurrentDictionary<string, Note> notes = new ConcurrentDictionary<string, Note>();
        public virtual string ID { get; set; } = Guid.NewGuid().ToString();
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
