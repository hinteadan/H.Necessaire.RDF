using System;
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
        protected RdfConceptBase(ImAnRdfConcept meta) : this()
        {
            this.ID = meta?.ID.NullIfEmpty() is null ? this.ID : meta.ID;
            this.Notes = meta?.Notes;
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
                    notes.AddOrUpdate(x.ID, x, (key, existing) => x);
                }
            }
        }

        public string Value() => Notes.Get(WellKnownRdfNote.Value);
        public void Value(string value) => Notes = value.NoteAs(WellKnownRdfNote.Value).AsArray();
    }
}
