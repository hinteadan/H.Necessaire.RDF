using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public static class MappingExtensions
    {
        public static RdfSubject<T> WithPayload<T>(this RdfSubjectMeta meta, Func<Task<T>> payloadAcquirer)
            => new RdfSubject<T>(payloadAcquirer, meta);

        public static RdfSubject<T> WithPayload<T>(this RdfSubjectMeta meta, T payload)
            => new RdfSubject<T>(payload, meta);

        public static RdfSubjectMeta ToRdfMeta<T>(this RdfSubject<T> subject)
            => new RdfSubjectMeta(subject);


        public static RdfPredicate<T> WithPayload<T>(this RdfPredicateMeta meta, Func<Task<T>> payloadAcquirer)
            => new RdfPredicate<T>(payloadAcquirer, meta);

        public static RdfPredicate<T> WithPayload<T>(this RdfPredicateMeta meta, T payload)
            => new RdfPredicate<T>(payload, meta);

        public static RdfPredicateMeta ToRdfMeta<T>(this RdfPredicate<T> predicate)
            => new RdfPredicateMeta(predicate);


        public static RdfObject<T> WithPayload<T>(this RdfObjectMeta meta, Func<Task<T>> payloadAcquirer)
            => new RdfObject<T>(payloadAcquirer, meta);

        public static RdfObject<T> WithPayload<T>(this RdfObjectMeta meta, T payload)
            => new RdfObject<T>(payload, meta);

        public static RdfObjectMeta ToRdfMeta<T>(this RdfObject<T> @object)
            => new RdfObjectMeta(@object);


        public static RdfTriple<TS, TP, TO> WithPayload<TS, TP, TO>(this RdfTripleMeta meta, RdfSubject<TS> subject, RdfPredicate<TP> predicate, RdfObject<TO> @object)
            => new RdfTriple<TS, TP, TO>(meta)
            {
                Subject = subject,
                Predicate = predicate,
                Object = @object,
            };

        public static RdfTriple<TS, TP, TO> WithPayload<TS, TP, TO>(this RdfTripleMeta meta, Func<Task<TS>> sPayAcquirer, Func<Task<TP>> pPayAcquirer, Func<Task<TO>> oPayAcquirer)
            => new RdfTriple<TS, TP, TO>(meta)
            {
                Subject = meta.Subject?.WithPayload(sPayAcquirer),
                Predicate = meta.Predicate?.WithPayload(pPayAcquirer),
                Object = meta.Object?.WithPayload(oPayAcquirer),
            };

        public static RdfTriple<TS, TP, TO> WithPayload<TS, TP, TO>(this RdfTripleMeta meta, TS sPayload, TP pPayload, TO oPayload)
            => new RdfTriple<TS, TP, TO>(meta)
            {
                Subject = meta.Subject?.WithPayload(sPayload),
                Predicate = meta.Predicate?.WithPayload(pPayload),
                Object = meta.Object?.WithPayload(oPayload),
            };

        public static RdfTripleMeta ToRdfMeta<TS, TP, TO>(this RdfTriple<TS, TP, TO> triple)
            => new RdfTripleMeta(triple)
            {
                Subject = triple.Subject.ToRdfMeta(),
                Predicate = triple.Predicate.ToRdfMeta(),
                Object = triple.Object.ToRdfMeta(),
            };
    }
}
