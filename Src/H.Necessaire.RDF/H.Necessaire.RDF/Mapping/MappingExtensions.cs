using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public static class MappingExtensions
    {
        public static RdfSubject<T> ToRdfSubject<T>(this RdfSubjectMeta meta, Func<Task<T>> payloadAcquirer)
            => new RdfSubject<T>(payloadAcquirer, meta);

        public static RdfSubject<T> ToRdfSubject<T>(this RdfSubjectMeta meta, T payload)
            => new RdfSubject<T>(payload, meta);

        public static RdfPredicate<T> ToRdfPredicate<T>(this RdfPredicateMeta meta, Func<Task<T>> payloadAcquirer)
            => new RdfPredicate<T>(payloadAcquirer, meta);

        public static RdfPredicate<T> ToRdfPredicate<T>(this RdfPredicateMeta meta, T payload)
            => new RdfPredicate<T>(payload, meta);

        public static RdfObject<T> ToRdfObject<T>(this RdfObjectMeta meta, Func<Task<T>> payloadAcquirer)
            => new RdfObject<T>(payloadAcquirer, meta);

        public static RdfObject<T> ToRdfObject<T>(this RdfObjectMeta meta, T payload)
            => new RdfObject<T>(payload, meta);

        public static RdfTriple<TS, TP, TO> ToRdfTriple<TS, TP, TO>(this RdfTripleMeta meta, RdfSubject<TS> subject, RdfPredicate<TP> predicate, RdfObject<TO> @object)
            => new RdfTriple<TS, TP, TO>(meta) { Subject = subject, Predicate = predicate, Object = @object };
    }
}
