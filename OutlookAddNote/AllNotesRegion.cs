using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using OutlookAddNote.Data;
using System.Globalization;

namespace OutlookAddNote
{
    partial class AllNotesRegion
    {
        Outlook.Explorer currentExplorer = null;
        string ConversationID;
        private const string DATE_FORMAT = "dd-MMM-yyyy HH:mm";
        static string PreviousConversationID = string.Empty;

        public void MessageChanged(Outlook.MailItem mailItem)
        {
            ConversationID = mailItem.ConversationID;
            LoadNotes(ConversationID);
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

            BringToFront();
        }

        private void CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
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
                catch (InvalidCastException)
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

        private void UserDeletingRow(object sender, System.Windows.Forms.DataGridViewRowCancelEventArgs e)
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

        #region Form Region Factory

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)]
        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass("IPM.Message.From")]
        [Microsoft.Office.Tools.Outlook.FormRegionName("OutlookAddNote.AllNotesRegion")]
        public partial class AllNotesRegionFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void AllNotesRegionFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
            }
        }

        #endregion

        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void AllNotesRegion_FormRegionShowing(object sender, System.EventArgs e)
        {            
            Outlook.MailItem mailItem = OutlookItem as Outlook.MailItem;
            if (mailItem != null)
            {
                PreviousConversationID = mailItem.ConversationID;
                MessageChanged(mailItem);                
            }
        }

        // Occurs when the form region is closed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void AllNotesRegion_FormRegionClosed(object sender, System.EventArgs e)
        {
        }
    }
}
