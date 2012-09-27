using System;

namespace OutlookAddNote.Data
{
    public class Note : Entity
    {
        public string ConversationID { get; set; }
        public DateTime NoteDate { get; set; }
        public string Notes { get; set; }        
    }
}
