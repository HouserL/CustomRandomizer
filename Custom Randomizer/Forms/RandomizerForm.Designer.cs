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
            this.AddTableSelector = new System.Windows.Forms.Button();
            this.RerollAllFields = new System.Windows.Forms.Button();
            this.TableConfigurer = new System.Windows.Forms.Button();
            this.SaveLoadoutButton = new System.Windows.Forms.Button();
            this.LoadoutComboBox = new System.Windows.Forms.ComboBox();
            this.UseLoadOutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // RerollAllFields
            // 
            this.RerollAllFields.Location = new System.Drawing.Point(93, 12);
            this.RerollAllFields.Name = "RerollAllFields";
            this.RerollAllFields.Size = new System.Drawing.Size(75, 57);
            this.RerollAllFields.TabIndex = 2;
            this.RerollAllFields.Text = "Reroll All Fields";
            this.RerollAllFields.UseVisualStyleBackColor = true;
            this.RerollAllFields.Click += new System.EventHandler(this.RerollAllFields_Click);
            // 
            // TableConfigurer
            // 
            this.TableConfigurer.Location = new System.Drawing.Point(530, 12);
            this.TableConfigurer.Name = "TableConfigurer";
            this.TableConfigurer.Size = new System.Drawing.Size(75, 57);
            this.TableConfigurer.TabIndex = 3;
            this.TableConfigurer.Text = "Table Configurer Button";
            this.TableConfigurer.UseVisualStyleBackColor = true;
            this.TableConfigurer.Click += new System.EventHandler(this.TableConfigurer_Click);
            // 
            // SaveLoadoutButton
            // 
            this.SaveLoadoutButton.Location = new System.Drawing.Point(255, 12);
            this.SaveLoadoutButton.Name = "SaveLoadoutButton";
            this.SaveLoadoutButton.Size = new System.Drawing.Size(75, 57);
            this.SaveLoadoutButton.TabIndex = 4;
            this.SaveLoadoutButton.Text = "Save Loadout Button";
            this.SaveLoadoutButton.UseVisualStyleBackColor = true;
            this.SaveLoadoutButton.Click += new System.EventHandler(this.SaveLoadoutButton_Click);
            // 
            // LoadoutComboBox
            // 
            this.LoadoutComboBox.FormattingEnabled = true;
            this.LoadoutComboBox.Location = new System.Drawing.Point(336, 12);
            this.LoadoutComboBox.Name = "LoadoutComboBox";
            this.LoadoutComboBox.Size = new System.Drawing.Size(188, 23);
            this.LoadoutComboBox.TabIndex = 5;
            // 
            // UseLoadOutButton
            // 
            this.UseLoadOutButton.Location = new System.Drawing.Point(174, 12);
            this.UseLoadOutButton.Name = "UseLoadOutButton";
            this.UseLoadOutButton.Size = new System.Drawing.Size(75, 57);
            this.UseLoadOutButton.TabIndex = 6;
            this.UseLoadOutButton.Text = "Use Loadout Button";
            this.UseLoadOutButton.UseVisualStyleBackColor = true;
            this.UseLoadOutButton.Click += new System.EventHandler(this.UseLoadOutButton_Click);
            // 
            // RandomizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(618, 93);
            this.Controls.Add(this.UseLoadOutButton);
            this.Controls.Add(this.LoadoutComboBox);
            this.Controls.Add(this.SaveLoadoutButton);
            this.Controls.Add(this.TableConfigurer);
            this.Controls.Add(this.RerollAllFields);
            this.Controls.Add(this.AddTableSelector);
            this.Name = "RandomizerForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button AddTableSelector;
        private Button RerollAllFields;
        private Button TableConfigurer;
        private Button SaveLoadoutButton;
        private ComboBox LoadoutComboBox;
        private Button UseLoadOutButton;
    }
}