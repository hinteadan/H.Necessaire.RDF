using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public static class MappingExtensions
    {
        public static RdfSubject<T> WithBody<T>(this RdfSubjectMeta meta, Func<Task<T>> bodyAcquirer)
            => new RdfSubject<T>(bodyAcquirer, meta);

        public static RdfSubject<T> WithBody<T>(this RdfSubjectMeta meta, T body)
            => new RdfSubject<T>(body, meta);

        public static RdfSubjectMeta ToRdfMeta<T>(this RdfSubject<T> subject)
            => new RdfSubjectMeta(subject);


        public static RdfPredicate<T> WithBody<T>(this RdfPredicateMeta meta, Func<Task<T>> bodyAcquirer)
            => new RdfPredicate<T>(bodyAcquirer, meta);

        public static RdfPredicate<T> WithBody<T>(this RdfPredicateMeta meta, T body)
            => new RdfPredicate<T>(body, meta);

        public static RdfPredicateMeta ToRdfMeta<T>(this RdfPredicate<T> predicate)
            => new RdfPredicateMeta(predicate);


        public static RdfObject<T> WithBody<T>(this RdfObjectMeta meta, Func<Task<T>> bodyAcquirer)
            => new RdfObject<T>(bodyAcquirer, meta);

        public static RdfObject<T> WithBody<T>(this RdfObjectMeta meta, T body)
            => new RdfObject<T>(body, meta);

        public static RdfObjectMeta ToRdfMeta<T>(this RdfObject<T> @object)
            => new RdfObjectMeta(@object);


        public static RdfTriple<TS, TP, TO> WithBody<TS, TP, TO>(this RdfTripleMeta meta, RdfSubject<TS> subject, RdfPredicate<TP> predicate, RdfObject<TO> @object)
            => new RdfTriple<TS, TP, TO>(meta)
            {
                Subject = subject,
                Predicate = predicate,
                Object = @object,
            };

        public static RdfTriple<TS, TP, TO> WithBody<TS, TP, TO>(this RdfTripleMeta meta, Func<Task<TS>> sBodAcquirer, Func<Task<TP>> pBodAcquirer, Func<Task<TO>> oBodAcquirer)
            => new RdfTriple<TS, TP, TO>(meta)
            {
                Subject = meta.Subject?.WithBody(sBodAcquirer),
                Predicate = meta.Predicate?.WithBody(pBodAcquirer),
                Object = meta.Object?.WithBody(oBodAcquirer),
            };

        public static RdfTriple<TS, TP, TO> WithBody<TS, TP, TO>(this RdfTripleMeta meta, TS sBody, TP pBody, TO oBody)
            => new RdfTriple<TS, TP, TO>(meta)
            {
                Subject = meta.Subject?.WithBody(sBody),
                Predicate = meta.Predicate?.WithBody(pBody),
                Object = meta.Object?.WithBody(oBody),
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
