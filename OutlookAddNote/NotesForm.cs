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
                DisplayNoteInGrid(newRowIndex, note);
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

            int noteId;
            if (NotesGrid.Rows[rowIndex].Cells["IDColumn"].Value == null)
            {
                noteId = 0;
            }
            else
            {
                bool isInt = int.TryParse(NotesGrid.Rows[rowIndex].Cells["IDColumn"].Value.ToString(), out noteId);
                if (!isInt)
                {
                    noteId = 0;
                }
            }
            
            DataMethods tmp = new DataMethods();
            Note savedNote = tmp.AddNote(noteId, ConversationID, noteDate, note.ToString());

            DisplayNoteInGrid(rowIndex, savedNote);
        }

        private void DisplayNoteInGrid(int rowIndex, Note note)
        {
            NotesGrid.Rows[rowIndex].Cells["IDColumn"].Value = note.Id;
            NotesGrid.Rows[rowIndex].Cells["ConversationIDColumn"].Value = note.ConversationID;
            NotesGrid.Rows[rowIndex].Cells["DateColumn"].Value = note.NoteDate;
            NotesGrid.Rows[rowIndex].Cells["NoteColumn"].Value = note.Notes;
        }

        private void InsertDateOnNote(int rowIndex)
        {
            string noteDate = NotesGrid.Rows[rowIndex].Cells["DateColumn"].Value as string;

            if (noteDate == null || noteDate.Trim() == string.Empty)
            {
                NotesGrid.Rows[rowIndex].Cells["DateColumn"].Value = DateTime.Now;
            }
        }

        private void UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int noteId = GetNoteIdFromGrid(e.Row.Index);

            if (noteId <= 0)
            {
                // Note not in DB nothing to do.
                return;
            }

            var tmp = new DataMethods();
            tmp.DeleteNote(noteId);
        }

        private int GetNoteIdFromGrid(int rowIndex)
        {
            int noteId;

            if (NotesGrid.Rows.Count <= rowIndex || NotesGrid.Rows[rowIndex].Cells["IDColumn"].Value == null)
            {
                noteId = 0;
            }
            else
            {
                bool isInt = int.TryParse(NotesGrid.Rows[rowIndex].Cells["IDColumn"].Value.ToString(), out noteId);
                if (!isInt)
                {
                    noteId = 0;
                }
            }

            return noteId;
        }
    }
}
