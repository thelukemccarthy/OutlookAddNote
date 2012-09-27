using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using OutlookAddNote.Data;
using System.Globalization;

namespace OutlookAddNote
{
    public partial class NotesForm : Form
    {
        string ConversationID;

        public NotesForm()
        {
            InitializeComponent();
        }

        public NotesForm(Outlook.MailItem mailItem) : this()
        {
            MessageChanged(mailItem);
        }

        public void MessageChanged(Outlook.MailItem mailItem)
        {
            ConversationID = mailItem.ConversationID;
            SetWindowTitleText(mailItem);
            LoadNotes(ConversationID);
            Show();
        }

        private void SetWindowTitleText(Outlook.MailItem mailItem)
        {
            if (mailItem.Sender != null)
            {
                Text = mailItem.Sender.Name + " - ";
            }

            if (mailItem.Subject != null)
            {
                Text += mailItem.Subject;
            }
        }

        private void LoadNotes(string conversationId)
        {
            NotesGrid.Rows.Clear();
            DataMethods tmp = new DataMethods();
            List<Note> notes = tmp.GetNotes(conversationId);

            foreach (Note note in notes)
            {
                int newRowIndex = NotesGrid.Rows.Add();
                NotesGrid.Rows[newRowIndex].Cells["IDColumn"].Value = note.Id;
                NotesGrid.Rows[newRowIndex].Cells["ConversationIDColumn"].Value = note.ConversationID;
                NotesGrid.Rows[newRowIndex].Cells["DateColumn"].Value = note.NoteDate;
                NotesGrid.Rows[newRowIndex].Cells["NoteColumn"].Value = note.Notes;
            }
        }

        private void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            InsertDateOnNote(e.RowIndex);
            SaveNote(e.RowIndex);
        }

        private void SaveNote(int rowIndex)
        {
            object note = NotesGrid.Rows[rowIndex].Cells["NoteColumn"].Value;
            if (note == null || note.ToString().Trim() == string.Empty)
            {
                return;
            }

            DateTime noteDate;
            object tmpNoteDate = NotesGrid.Rows[rowIndex].Cells["DateColumn"].Value;
            if(tmpNoteDate == null)
            {
                noteDate = DateTime.Now;
            }


            bool isDate = DateTime.TryParseExact(tmpNoteDate.ToString(), "dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out noteDate);
            if(!isDate)
            {
                noteDate = DateTime.Now;
            }
            
            DataMethods tmp = new DataMethods();
            tmp.AddNote(ConversationID, noteDate, note.ToString());
        }

        private void InsertDateOnNote(int rowIndex)
        {
            string noteDate = NotesGrid.Rows[rowIndex].Cells["DateColumn"].Value as string;

            if (noteDate == null || noteDate.Trim() == string.Empty)
            {
                NotesGrid.Rows[rowIndex].Cells["DateColumn"].Value = DateTime.Now;
            }
        }
    }
}
