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
            OpenXMLFile = new Button();
            XMLFile = new TextBox();
            Parse = new Button();
            Errortext = new Label();
            ccbCountry = new CheckComboBox.CheckedComboBox();
            label1 = new Label();
            label2 = new Label();
            ccbClub = new CheckComboBox.CheckedComboBox();
            SuspendLayout();
            // 
            // OpenXMLFile
            // 
            OpenXMLFile.Location = new Point(348, 23);
            OpenXMLFile.Name = "OpenXMLFile";
            OpenXMLFile.Size = new Size(108, 23);
            OpenXMLFile.TabIndex = 0;
            OpenXMLFile.Text = "Open XML File";
            OpenXMLFile.UseVisualStyleBackColor = true;
            OpenXMLFile.Click += OpenXMLFile_Click;
            // 
            // XMLFile
            // 
            XMLFile.Location = new Point(15, 24);
            XMLFile.Name = "XMLFile";
            XMLFile.Size = new Size(327, 23);
            XMLFile.TabIndex = 1;
            // 
            // Parse
            // 
            Parse.Location = new Point(462, 24);
            Parse.Name = "Parse";
            Parse.Size = new Size(108, 23);
            Parse.TabIndex = 2;
            Parse.Text = "Parse";
            Parse.UseVisualStyleBackColor = true;
            Parse.Click += Parse_Click;
            // 
            // Errortext
            // 
            Errortext.AutoSize = true;
            Errortext.Location = new Point(35, 408);
            Errortext.Name = "Errortext";
            Errortext.Size = new Size(0, 15);
            Errortext.TabIndex = 3;
            // 
            // ccbCountry
            // 
            ccbCountry.CheckOnClick = true;
            ccbCountry.DrawMode = DrawMode.OwnerDrawVariable;
            ccbCountry.DropDownHeight = 1;
            ccbCountry.FormattingEnabled = true;
            ccbCountry.IntegralHeight = false;
            ccbCountry.Location = new Point(104, 58);
            ccbCountry.Name = "ccbCountry";
            ccbCountry.Size = new Size(121, 24);
            ccbCountry.TabIndex = 4;
            ccbCountry.ValueSeparator = ", ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 61);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 5;
            label1.Text = "Country";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(231, 61);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 6;
            label2.Text = "Club";
            // 
            // ccbClub
            // 
            ccbClub.CheckOnClick = true;
            ccbClub.DrawMode = DrawMode.OwnerDrawVariable;
            ccbClub.DropDownHeight = 1;
            ccbClub.FormattingEnabled = true;
            ccbClub.IntegralHeight = false;
            ccbClub.Location = new Point(276, 57);
            ccbClub.Name = "ccbClub";
            ccbClub.Size = new Size(121, 24);
            ccbClub.TabIndex = 7;
            ccbClub.ValueSeparator = ", ";
            // 
            // XMLParserOL_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ccbClub);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ccbCountry);
            Controls.Add(Errortext);
            Controls.Add(Parse);
            Controls.Add(XMLFile);
            Controls.Add(OpenXMLFile);
            Name = "XMLParserOL_Form";
            Text = "XML Parser OL";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OpenXMLFile;
        private TextBox XMLFile;
        private Button Parse;
        private Label Errortext;
        private CheckComboBox.CheckedComboBox ccbCountry;
        private Label label1;
        private Label label2;
        private CheckComboBox.CheckedComboBox ccbClub;
    }
}