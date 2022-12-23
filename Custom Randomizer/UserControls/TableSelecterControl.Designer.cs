namespace CustomRandomizer.UserControls
{
    partial class TableSelecterControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ResultsLabel = new System.Windows.Forms.Label();
            this.RemoveControlButton = new System.Windows.Forms.Button();
            this.RerollButton = new System.Windows.Forms.Button();
            this.TableNamesComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResultsLabel.Location = new System.Drawing.Point(3, 39);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(460, 21);
            this.ResultsLabel.TabIndex = 7;
            this.ResultsLabel.Text = "12345678901234567890123456789012345678901234567890";
            // 
            // RemoveControlButton
            // 
            this.RemoveControlButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemoveControlButton.Location = new System.Drawing.Point(415, 3);
            this.RemoveControlButton.Name = "RemoveControlButton";
            this.RemoveControlButton.Size = new System.Drawing.Size(95, 34);
            this.RemoveControlButton.TabIndex = 6;
            this.RemoveControlButton.Text = "Remove";
            this.RemoveControlButton.UseVisualStyleBackColor = true;
            // 
            // RerollButton
            // 
            this.RerollButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RerollButton.Location = new System.Drawing.Point(247, 3);
            this.RerollButton.Name = "RerollButton";
            this.RerollButton.Size = new System.Drawing.Size(84, 33);
            this.RerollButton.TabIndex = 5;
            this.RerollButton.Text = "Reroll";
            this.RerollButton.UseVisualStyleBackColor = true;
            this.RerollButton.Click += new System.EventHandler(this.RerollButton_Click);
            // 
            // TableNamesComboBox
            // 
            this.TableNamesComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TableNamesComboBox.FormattingEnabled = true;
            this.TableNamesComboBox.Location = new System.Drawing.Point(3, 3);
            this.TableNamesComboBox.Name = "TableNamesComboBox";
            this.TableNamesComboBox.Size = new System.Drawing.Size(238, 29);
            this.TableNamesComboBox.TabIndex = 4;
            this.TableNamesComboBox.SelectedIndexChanged += new System.EventHandler(this.TableNamesComboBox_SelectedIndexChanged);
            // 
            // TableSelecterControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ResultsLabel);
            this.Controls.Add(this.RemoveControlButton);
            this.Controls.Add(this.RerollButton);
            this.Controls.Add(this.TableNamesComboBox);
            this.Name = "TableSelecterControl";
            this.Size = new System.Drawing.Size(513, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ResultsLabel;
        public Button RemoveControlButton;
        private Button RerollButton;
        public ComboBox TableNamesComboBox;
    }
}
