using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CheckComboBox;

namespace XMLParserOL_UI
{

    public partial class XMLParserOL_Form : Form
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList competitors;

        public XMLParserOL_Form()
        {
            InitializeComponent();
        }

        private void OpenXMLFile_Click(object sender, EventArgs e)
        {
            try
            {
                Errortext.Text = "";
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        XMLFile.Text = openFileDialog.FileName;
                        XMLFile.SelectionStart = XMLFile.Text.Length;

                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            //fileContent = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Errortext.Text = "General Exeption: " + ex.Message;
            }
        }

        private void Parse_Click(object sender, EventArgs e)
        {
            try
            {
                Errortext.Text = "";
                xmlDoc.Load(XMLFile.Text);

                XmlNodeList competitors = xmlDoc.GetElementsByTagName("Competitor");
            }
            catch (FileNotFoundException ex)
            {
                Errortext.Text = "FileNotFoundException: " + ex.Message;
            }
            catch (DirectoryNotFoundException ex)
            {
                Errortext.Text = "DirectoryNotFoundException: " + ex.Message;
            }
            catch (Exception ex)
            {
                Errortext.Text = "General Exeption: " + ex.Message;
            }
        }


    }
}