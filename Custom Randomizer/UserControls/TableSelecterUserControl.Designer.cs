namespace CustomRandomizer.UserControls;

partial class TableSelecterUserControl
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
            this.TableNamesComboBox = new System.Windows.Forms.ComboBox();
            this.RerollButton = new System.Windows.Forms.Button();
            this.RemoveControlButton = new System.Windows.Forms.Button();
            this.ResultsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TableNamesComboBox
            // 
            this.TableNamesComboBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TableNamesComboBox.FormattingEnabled = true;
            this.TableNamesComboBox.Location = new System.Drawing.Point(3, 3);
            this.TableNamesComboBox.Name = "TableNamesComboBox";
            this.TableNamesComboBox.Size = new System.Drawing.Size(238, 33);
            this.TableNamesComboBox.TabIndex = 0;
            // 
            // RerollButton
            // 
            this.RerollButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RerollButton.Location = new System.Drawing.Point(247, 3);
            this.RerollButton.Name = "RerollButton";
            this.RerollButton.Size = new System.Drawing.Size(84, 33);
            this.RerollButton.TabIndex = 1;
            this.RerollButton.Text = "Reroll";
            this.RerollButton.UseVisualStyleBackColor = true;
            this.RerollButton.Click += new System.EventHandler(this.RerollButton_Click);
            // 
            // RemoveControlButton
            // 
            this.RemoveControlButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemoveControlButton.Location = new System.Drawing.Point(337, 3);
            this.RemoveControlButton.Name = "RemoveControlButton";
            this.RemoveControlButton.Size = new System.Drawing.Size(95, 34);
            this.RemoveControlButton.TabIndex = 2;
            this.RemoveControlButton.Text = "Remove";
            this.RemoveControlButton.UseVisualStyleBackColor = true;
            this.RemoveControlButton.Click += new System.EventHandler(this.RemoveControlButton_Click);
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResultsLabel.Location = new System.Drawing.Point(3, 39);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(512, 25);
            this.ResultsLabel.TabIndex = 3;
            this.ResultsLabel.Text = "12345678901234567890123456789012345678901234567890";
            // 
            // TableSelecterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ResultsLabel);
            this.Controls.Add(this.RemoveControlButton);
            this.Controls.Add(this.RerollButton);
            this.Controls.Add(this.TableNamesComboBox);
            this.Name = "TableSelecterUserControl";
            this.Size = new System.Drawing.Size(516, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private ComboBox TableNamesComboBox;
    private Button RerollButton;
    private Button RemoveControlButton;
    private Label ResultsLabel;
}
