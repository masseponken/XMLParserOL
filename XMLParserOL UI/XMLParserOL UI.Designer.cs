namespace XMLParserOL_UI
{
    partial class XMLParserOL_Form
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
            btOpenXMLFile = new Button();
            tbOpenXMLFile = new TextBox();
            Errortext = new Label();
            label2 = new Label();
            label1 = new Label();
            SaveXMLFile = new Button();
            SearchSI = new Button();
            ccbClub = new CheckComboBox.CheckedComboBox();
            tbSINumbers = new TextBox();
            SuspendLayout();
            // 
            // btOpenXMLFile
            // 
            btOpenXMLFile.Location = new Point(317, 20);
            btOpenXMLFile.Name = "btOpenXMLFile";
            btOpenXMLFile.Size = new Size(108, 23);
            btOpenXMLFile.TabIndex = 0;
            btOpenXMLFile.Text = "Open XML File";
            btOpenXMLFile.UseVisualStyleBackColor = true;
            btOpenXMLFile.Click += OpenXMLFile_Click;
            // 
            // tbOpenXMLFile
            // 
            tbOpenXMLFile.Location = new Point(94, 20);
            tbOpenXMLFile.Name = "tbOpenXMLFile";
            tbOpenXMLFile.Size = new Size(207, 23);
            tbOpenXMLFile.TabIndex = 1;
            // 
            // Errortext
            // 
            Errortext.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Errortext.AutoSize = true;
            Errortext.Location = new Point(12, 300);
            Errortext.Name = "Errortext";
            Errortext.Size = new Size(55, 15);
            Errortext.TabIndex = 3;
            Errortext.Text = "Errortext:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 63);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 6;
            label2.Text = "Clubs:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 8;
            label1.Text = "IOF XML File:";
            // 
            // SaveXMLFile
            // 
            SaveXMLFile.Location = new Point(317, 61);
            SaveXMLFile.Name = "SaveXMLFile";
            SaveXMLFile.Size = new Size(108, 23);
            SaveXMLFile.TabIndex = 9;
            SaveXMLFile.Text = "Save XML File";
            SaveXMLFile.UseVisualStyleBackColor = true;
            SaveXMLFile.Click += SaveXMLFile_Click;
            // 
            // SearchSI
            // 
            SearchSI.Location = new Point(317, 101);
            SearchSI.Name = "SearchSI";
            SearchSI.Size = new Size(108, 23);
            SearchSI.TabIndex = 10;
            SearchSI.Text = "Search SI";
            SearchSI.UseVisualStyleBackColor = true;
            SearchSI.Click += SearchSI_Click;
            // 
            // ccbClub
            // 
            ccbClub.CheckOnClick = true;
            ccbClub.DrawMode = DrawMode.OwnerDrawVariable;
            ccbClub.DropDownHeight = 1;
            ccbClub.FormattingEnabled = true;
            ccbClub.IntegralHeight = false;
            ccbClub.Location = new Point(94, 60);
            ccbClub.Name = "ccbClub";
            ccbClub.Size = new Size(207, 24);
            ccbClub.TabIndex = 7;
            ccbClub.ValueSeparator = ", ";
            // 
            // tbSINumbers
            // 
            tbSINumbers.Location = new Point(94, 102);
            tbSINumbers.Multiline = true;
            tbSINumbers.Name = "tbSINumbers";
            tbSINumbers.ScrollBars = ScrollBars.Vertical;
            tbSINumbers.Size = new Size(207, 187);
            tbSINumbers.TabIndex = 11;
            tbSINumbers.WordWrap = false;
            // 
            // XMLParserOL_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 324);
            Controls.Add(tbSINumbers);
            Controls.Add(ccbClub);
            Controls.Add(SearchSI);
            Controls.Add(SaveXMLFile);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(Errortext);
            Controls.Add(tbOpenXMLFile);
            Controls.Add(btOpenXMLFile);
            Name = "XMLParserOL_Form";
            Text = "XML Parser OL";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btOpenXMLFile;
        private TextBox tbOpenXMLFile;
        private Label Errortext;
        private Label label2;
        private CheckComboBox.CheckedComboBox ccbClub;
        private Label label1;
        private Button SaveXMLFile;
        private Button SearchSI;
        private TextBox tbSINumbers;
    }
}