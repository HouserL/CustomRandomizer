namespace CustomRandomizer.Forms
{
    partial class RandomizerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableSelecterUserControl1 = new Custom_Randomizer.UserControls.TableSelecterUserControl();
            this.AddTableSelector = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tableSelecterUserControl1
            // 
            this.tableSelecterUserControl1.BackColor = System.Drawing.Color.Transparent;
            this.tableSelecterUserControl1.Location = new System.Drawing.Point(7, 94);
            this.tableSelecterUserControl1.Name = "tableSelecterUserControl1";
            this.tableSelecterUserControl1.Size = new System.Drawing.Size(516, 70);
            this.tableSelecterUserControl1.TabIndex = 0;
            // 
            // AddTableSelector
            // 
            this.AddTableSelector.Location = new System.Drawing.Point(12, 12);
            this.AddTableSelector.Name = "AddTableSelector";
            this.AddTableSelector.Size = new System.Drawing.Size(75, 57);
            this.AddTableSelector.TabIndex = 1;
            this.AddTableSelector.Text = "Add Table to Roll";
            this.AddTableSelector.UseVisualStyleBackColor = true;
            this.AddTableSelector.Click += new System.EventHandler(this.AddTableSelector_Click);
            // 
            // RandomizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 478);
            this.Controls.Add(this.AddTableSelector);
            this.Controls.Add(this.tableSelecterUserControl1);
            this.Name = "RandomizerForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TableSelecterUserControl tableSelecterUserControl1;
        private Button AddTableSelector;
    }
}