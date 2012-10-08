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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NotesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.NotesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NotesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.ConversationIDColumn,
            this.DateColumn,
            this.NoteColumn});
            this.NotesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesGrid.Location = new System.Drawing.Point(0, 0);
            this.NotesGrid.MultiSelect = false;
            this.NotesGrid.Name = "NotesGrid";
            this.NotesGrid.RowHeadersWidth = 20;
            this.NotesGrid.Size = new System.Drawing.Size(755, 356);
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
            dataGridViewCellStyle5.Format = "dd-MMM-yyyy HH:mm";
            dataGridViewCellStyle5.NullValue = null;
            this.DateColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.Name = "DateColumn";
            // 
            // NoteColumn
            // 
            this.NoteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NoteColumn.DefaultCellStyle = dataGridViewCellStyle6;
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