using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace OutlookAddNote
{
    public partial class ThisAddIn
    {
        Outlook.Explorer currentExplorer = null;
        NotesForm MyNotesForm = null;
        static string PreviousConversationID = string.Empty;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            currentExplorer = this.Application.ActiveExplorer();
            currentExplorer.SelectionChange += 
                new Outlook.ExplorerEvents_10_SelectionChangeEventHandler(CurrentExplorer_Event);
            
            if (MyNotesForm == null)
            {
                MyNotesForm = new NotesForm();
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            MyNotesForm.Dispose();
        }

        void CurrentExplorer_Event()
        {
            if (this.Application.ActiveExplorer().Selection.Count == 1)
            {
                Outlook.MailItem mailItem = this.Application.ActiveExplorer().Selection[1] as Outlook.MailItem;

                if (mailItem != null && PreviousConversationID != mailItem.ConversationID)
                {
                    PreviousConversationID = mailItem.ConversationID;
                    MyNotesForm.MessageChanged(mailItem);
                }
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
