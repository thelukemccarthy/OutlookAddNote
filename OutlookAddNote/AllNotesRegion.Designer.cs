namespace OutlookAddNote
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    partial class AllNotesRegion : Microsoft.Office.Tools.Outlook.FormRegionBase
    {
        public AllNotesRegion(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
            : base(Globals.Factory, formRegion)
        {
            this.InitializeComponent();
        }

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NotesGrid = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConversationIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.NotesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // NotesGrid
            // 
            this.NotesGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NotesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.NotesGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.NotesGrid.BackgroundColor = System.Drawing.Color.White;
            this.NotesGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NotesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NotesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.ConversationIDColumn,
            this.DateColumn,
            this.NoteColumn});
            this.NotesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesGrid.Location = new System.Drawing.Point(0, 0);
            this.NotesGrid.Name = "NotesGrid";
            this.NotesGrid.RowHeadersWidth = 20;
            this.NotesGrid.Size = new System.Drawing.Size(551, 93);
            this.NotesGrid.TabIndex = 0;
            this.NotesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellEndEdit);
            this.NotesGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellEndEdit);
            this.NotesGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.UserDeletingRow);
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "Note ID";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.Visible = false;
            // 
            // ConversationIDColumn
            // 
            this.ConversationIDColumn.HeaderText = "Conversation ID";
            this.ConversationIDColumn.Name = "ConversationIDColumn";
            this.ConversationIDColumn.Visible = false;
            // 
            // DateColumn
            // 
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy HH:mm";
            dataGridViewCellStyle2.NullValue = null;
            this.DateColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.Name = "DateColumn";
            // 
            // NoteColumn
            // 
            this.NoteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NoteColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.NoteColumn.HeaderText = "Note";
            this.NoteColumn.Name = "NoteColumn";
            // 
            // AllNotesRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NotesGrid);
            this.Name = "AllNotesRegion";
            this.Size = new System.Drawing.Size(551, 93);
            this.FormRegionShowing += new System.EventHandler(this.AllNotesRegion_FormRegionShowing);
            this.FormRegionClosed += new System.EventHandler(this.AllNotesRegion_FormRegionClosed);
            ((System.ComponentModel.ISupportInitialize)(this.NotesGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Form Region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private static void InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest manifest, Microsoft.Office.Tools.Outlook.Factory factory)
        {
            manifest.FormRegionName = "Notes";
            manifest.FormRegionType = Microsoft.Office.Tools.Outlook.FormRegionType.Adjoining;

        }

        #endregion

        private System.Windows.Forms.DataGridView NotesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConversationIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteColumn;

        public partial class AllNotesRegionFactory : Microsoft.Office.Tools.Outlook.IFormRegionFactory
        {
            public event Microsoft.Office.Tools.Outlook.FormRegionInitializingEventHandler FormRegionInitializing;

            private Microsoft.Office.Tools.Outlook.FormRegionManifest _Manifest;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public AllNotesRegionFactory()
            {
                this._Manifest = Globals.Factory.CreateFormRegionManifest();
                AllNotesRegion.InitializeManifest(this._Manifest, Globals.Factory);
                this.FormRegionInitializing += new Microsoft.Office.Tools.Outlook.FormRegionInitializingEventHandler(this.AllNotesRegionFactory_FormRegionInitializing);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public Microsoft.Office.Tools.Outlook.FormRegionManifest Manifest
            {
                get
                {
                    return this._Manifest;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            Microsoft.Office.Tools.Outlook.IFormRegion Microsoft.Office.Tools.Outlook.IFormRegionFactory.CreateFormRegion(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
            {
                AllNotesRegion form = new AllNotesRegion(formRegion);
                form.Factory = this;
                return form;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            byte[] Microsoft.Office.Tools.Outlook.IFormRegionFactory.GetFormRegionStorage(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
            {
                throw new System.NotSupportedException();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            bool Microsoft.Office.Tools.Outlook.IFormRegionFactory.IsDisplayedForItem(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
            {
                if (this.FormRegionInitializing != null)
                {
                    Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs cancelArgs = Globals.Factory.CreateFormRegionInitializingEventArgs(outlookItem, formRegionMode, formRegionSize, false);
                    this.FormRegionInitializing(this, cancelArgs);
                    return !cancelArgs.Cancel;
                }
                else
                {
                    return true;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            Microsoft.Office.Tools.Outlook.FormRegionKindConstants Microsoft.Office.Tools.Outlook.IFormRegionFactory.Kind
            {
                get
                {
                    return Microsoft.Office.Tools.Outlook.FormRegionKindConstants.WindowsForms;
                }
            }
        }
    }

    partial class WindowFormRegionCollection
    {
        internal AllNotesRegion AllNotesRegion
        {
            get
            {
                foreach (var item in this)
                {
                    if (item.GetType() == typeof(AllNotesRegion))
                        return (AllNotesRegion)item;
                }
                return null;
            }
        }
    }
}
