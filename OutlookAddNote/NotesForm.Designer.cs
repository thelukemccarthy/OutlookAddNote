namespace OutlookAddNote
{
    partial class NotesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.NotesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NotesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.ConversationIDColumn,
            this.DateColumn,
            this.NoteColumn});
            this.NotesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesGrid.Location = new System.Drawing.Point(0, 0);
            this.NotesGrid.Name = "NotesGrid";
            this.NotesGrid.Size = new System.Drawing.Size(755, 356);
            this.NotesGrid.TabIndex = 0;
            this.NotesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellEndEdit);
            this.NotesGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellEndEdit);
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "Note ID";
            this.IDColumn.Name = "IDColumn";
            // 
            // ConversationIDColumn
            // 
            this.ConversationIDColumn.HeaderText = "Conversation ID";
            this.ConversationIDColumn.Name = "ConversationIDColumn";
            // 
            // DateColumn
            // 
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy HH:mm";
            dataGridViewCellStyle1.NullValue = null;
            this.DateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.Name = "DateColumn";
            // 
            // NoteColumn
            // 
            this.NoteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NoteColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.NoteColumn.HeaderText = "Note";
            this.NoteColumn.Name = "NoteColumn";
            // 
            // NotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 356);
            this.Controls.Add(this.NotesGrid);
            this.Name = "NotesForm";
            this.Text = "Notes";
            ((System.ComponentModel.ISupportInitialize)(this.NotesGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView NotesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConversationIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteColumn;
    }
}