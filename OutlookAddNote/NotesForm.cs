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
        private const string DATE_FORMAT = "dd-MMM-yyyy HH:mm";

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

            DateTime noteDate = InsertDateOnNote(rowIndex);

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

        /// <summary>
        /// Insert the date in the DateColumn of a row in NotesGrid if it is null, empty or can't be converted to a date otherwise leave the date as it is.
        /// </summary>
        /// <param name="rowIndex">The row to insert the date into</param>
        /// <returns>The date in the DateColumn of the NoteGrid. If a date already exists return the current value without updating the field</returns>
        private DateTime InsertDateOnNote(int rowIndex)
        {            
            object tmpNoteDate = NotesGrid.Rows[rowIndex].Cells["DateColumn"].Value;
            DateTime noteDate;

            if (tmpNoteDate == null)
            {
                noteDate = DateTime.Now;
            }
            else
            {
                try
                {
                    noteDate = (DateTime)NotesGrid.Rows[rowIndex].Cells["DateColumn"].Value;
                }
                catch (InvalidCastException e)
                {
                    // user has probably typed the date in try and parse it otherwise just use the current datetime
                    bool isDate = DateTime.TryParseExact(tmpNoteDate.ToString(), DATE_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out noteDate);
                    if (!isDate)
                    {
                        noteDate = DateTime.Now;
                    }
                }
            }

            NotesGrid.Rows[rowIndex].Cells["DateColumn"].Value = noteDate;
            
            return noteDate;
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
