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

        private Note GetNote(int noteId)
        {
            if (noteId <= 0)
            {
                return null;
            }

            return (from note in _context.Notes
                    where note.Id == noteId
                    select note).First() ?? null;
        }

        public Note AddNote(Note note)
        {
            if (note.Id <= 0)
            {
                _context.Notes.Add(note);
            }
            _context.SaveChanges();

            return note;
        }

        public Note AddNote(int noteId, string ConversationID, DateTime NoteDate, string Notes)
        {
            Note newNote;
            if (noteId <= 0)
            {
                newNote = new Note();
            }
            else
            {
                newNote = (from note in _context.Notes
                          where note.Id == noteId
                          select note).FirstOrDefault();
            }

            newNote.ConversationID = ConversationID;
            newNote.NoteDate = NoteDate;
            newNote.Notes = Notes;

            return AddNote(newNote);
        }

        public void DeleteNote(int noteId)
        {          
            Note note = GetNote(noteId);

            if (note == null)
            {
                // nothing to delete
                return;
            }

            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
    }
}

