using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutlookAddNote.Data
{
    public class DataMethods
    {
        private readonly Context _context = new Context();

        public List<Note> GetNotes(string ConversationID)
        {
            List<Note> notes = (from dbNotes in _context.Notes
                                where dbNotes.ConversationID == ConversationID
                                orderby dbNotes.Id
                                select dbNotes).ToList();
            return notes;
        }

        public void AddNote(Note note)
        {
            _context.Notes.Add(note);
        }

        public void AddNote(string ConversationID, DateTime NoteDate, string Notes)
        {
            Note newNote = new Note();
            newNote.ConversationID = ConversationID;
            newNote.NoteDate = NoteDate;
            newNote.Notes = Notes;

            AddNote(newNote);
        }
    }
}

