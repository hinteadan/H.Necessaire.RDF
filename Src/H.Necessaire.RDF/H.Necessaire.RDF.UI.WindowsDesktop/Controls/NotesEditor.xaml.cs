using H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts;
using H.Necessaire.RDF.UI.WindowsDesktop.Controls.Abstracts;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop.Controls
{
    public abstract class NotesEditorBase : UserControlBase<NotesEditorBase.ControlState>
    {
        public NotesEditorBase() : base(new ControlState { }) { }
        public class ControlState : UIComponentStateBase
        {
            public Note[] Notes { get; set; }
        }
    }

    public sealed partial class NotesEditor : NotesEditorBase
    {
        public NotesEditor()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<ReferenceNote> Notes { get; } = new ObservableCollection<ReferenceNote>();

        public event EventHandler OnNotesChanged;

        private async void NoteEditor_OnNoteChanged(object sender, EventArgs e)
        {
            using ((sender as Control).DisabledScope())
            {
                await HandleNotesChanged();
            }
        }

        private async void AddNote_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            using ((sender as Button).DisabledScope())
            {
                Notes.Add(new ReferenceNote());
                await HandleNotesChanged();
            }
        }

        private async void RemoveNote_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            using ((sender as Button).DisabledScope())
            {
                ReferenceNote noteToRemove = (sender as Button).DataContext as ReferenceNote;
                bool isConfirmed = (await Confirm($"Are you sure you want to remove note {noteToRemove.ID} ?", "Remove Note")).IsSuccessful;
                if (!isConfirmed)
                    return;

                Notes.Remove(noteToRemove);

                await HandleNotesChanged();
            }
        }

        private async Task HandleNotesChanged()
        {
            State.Notes = Notes.Select(x => (Note)x).ToArrayNullIfEmpty();
            OnNotesChanged?.Invoke(this, EventArgs.Empty);
            await ApplyState(State);
        }
    }
}
