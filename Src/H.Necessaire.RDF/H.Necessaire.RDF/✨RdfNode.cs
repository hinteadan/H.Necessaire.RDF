using System;
using System.Linq;

namespace H.Necessaire.RDF
{
    public class RdfNode : IGuidIdentity
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string IDTag { get; set; }

        public string DisplayLabel { get; set; }

        public RdfAspect[] Aspects { get; set; }

        public Note[] Notes { get; set; }

        public DataBin Data { get; set; }

        public RdfTriple TripleFor(Guid aspectID, params RdfAspect[] quotes)
        {
            RdfAspect aspect = Aspects?.LastOrDefault(x => x.ID == aspectID);
            if (aspect is null)
                return null;

            return
                new RdfTriple
                {
                    Subject = this,
                    Aspect = aspect,
                    Aspects = quotes.ToNoNullsArray(),
                };
        }

        public RdfTriple[] TriplesFor(params Guid[] ids)
        {
            if (ids?.Any() != true)
                return null;

            RdfAspect[] aspects = Aspects?.Where(x => x.ID.In(ids)).ToArrayNullIfEmpty();

            if (aspects?.Any() != true)
                return null;

            return
                aspects
                .Select(aspect =>
                    new RdfTriple
                    {
                        Subject = this,
                        Aspect = aspect,
                    }
                )
                .ToArray();
        }

        public RdfTriple[] TriplesFor(params string[] idTags)
        {
            if (idTags.ToNoNullsArray()?.Any() != true)
                return null;

            RdfAspect[] aspects = Aspects?.Where(x => x.IDTag.In(idTags)).ToNoNullsArray();

            if (aspects?.Any() != true)
                return null;

            return
                aspects
                .Select(aspect =>
                    new RdfTriple
                    {
                        Subject = this,
                        Aspect = aspect,
                    }
                )
                .ToArray();
        }

        public override string ToString()
        {
            return
                DisplayLabel.NullIfEmpty()
                ??
                IDTag.NullIfEmpty()
                ??
                ID.ToString()
                ;
        }


        public static implicit operator RdfNode(string idTag)
        {
            return new RdfNode { IDTag = idTag };
        }
    }
}
