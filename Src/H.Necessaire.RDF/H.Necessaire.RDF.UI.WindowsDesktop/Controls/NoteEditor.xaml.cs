using H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts;
using H.Necessaire.RDF.UI.WindowsDesktop.Controls.Abstracts;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop.Controls
{
    public abstract class NoteEditorBase : UserControlBase<NoteEditorBase.ControlState>
    {
        public NoteEditorBase() : base(new ControlState()) { }
        public class ControlState : UIComponentStateBase
        {
            public Note Note { get; set; }
        }
    }

    public sealed partial class NoteEditor : NoteEditorBase
    {
        readonly Debouncer noteChangeDebouncer;
        public NoteEditor()
        {
            this.InitializeComponent();
            NoteBeingEdited = State.Note;
            noteChangeDebouncer = new Debouncer(HandleNoteChange, TimeSpan.FromSeconds(.3));
        }

        public override async Task Destroy()
        {
            await base.Destroy();
            noteChangeDebouncer.Dispose();
        }

        ReferenceNote noteBeingEdited;
        public ReferenceNote NoteBeingEdited { 
            get => noteBeingEdited;
            set {
                noteBeingEdited = value;
                NotifyStateChanged();
            }
        }

        public event EventHandler OnNoteChanged;

        private async Task HandleNoteChange()
        {
            State.Note = NoteBeingEdited;
            OnNoteChanged?.Invoke(this, EventArgs.Empty);
            await ApplyState(State);
        }

        private async void ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            NoteBeingEdited.ID = (sender as TextBox).Text; ;
            await noteChangeDebouncer.Invoke();
        }

        private async void Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            NoteBeingEdited.Value = (sender as TextBox).Text; ;
            await noteChangeDebouncer.Invoke();
        }
    }
}
