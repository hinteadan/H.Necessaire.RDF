namespace H.Necessaire.RDF.UI.WindowsDesktop.Controls
{
    public class ReferenceNote
    {
        public string ID { get; set; }
        public string Value { get; set; }

        public static implicit operator ReferenceNote(Note note)
        {
            return
                new ReferenceNote { ID = note.ID, Value = note.Value };
        }

        public static implicit operator Note(ReferenceNote note)
        {
            return
                new Note { ID = note.ID, Value = note.Value };
        }

        public override string ToString()
        {
            return ((Note)this).ToString();
        }
    }
}
