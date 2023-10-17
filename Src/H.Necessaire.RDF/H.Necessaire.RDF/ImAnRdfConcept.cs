namespace H.Necessaire.RDF
{
    public interface ImAnRdfConcept : IStringIdentity
    {
        RdfConceptType ConceptType { get; }
        Note[] Notes { get; }
    }
}
