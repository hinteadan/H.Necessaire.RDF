using H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts;
using H.Necessaire.RDF.UI.WindowsDesktop.Controls.Abstracts;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop.Controls
{
    public abstract class NotesEditorBase : UserControlBase<NotesEditorBase.ControlState>
    {
        public NotesEditorBase() : base(new ControlState { }) { }
        public class ControlState : UIComponentStateBase
        {
            public IList<Note> Notes { get; set; } = new List<Note>();
        }
    }

    public sealed partial class NotesEditor : NotesEditorBase
    {
        public NotesEditor()
        {
            this.InitializeComponent();
        }
    }
}
