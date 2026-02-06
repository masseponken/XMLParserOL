using CheckComboBox;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XMLParserOL_UI
{

    public partial class XMLParserOL_Form : Form
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList? competitors;
        Stopwatch timer = new Stopwatch();
        private XDocument? loadedDoc;
        private XNamespace ns = "http://www.orienteering.org/datastandard/3.0";


        public XMLParserOL_Form()
        {
            InitializeComponent();
            Errortext.Text = "";
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
                        tbOpenXMLFile.Text = openFileDialog.FileName;
                        tbOpenXMLFile.SelectionStart = tbOpenXMLFile.Text.Length;


                        timer.Reset();
                        timer.Start();

                        loadedDoc = XDocument.Load(tbOpenXMLFile.Text);

                        var clubs = loadedDoc.Root?
                            .Elements(ns + "Competitor")
                            .Elements(ns + "Organisation")
                            .Elements(ns + "Name")
                            .Select(name => name.Value.Trim())
                            .Distinct()
                            .OrderBy(name => name)
                            .ToList();

                        ccbClub.Items.Clear();
                        ccbClub.Items.AddRange(clubs?.ToArray() ?? Array.Empty<string>());

                        timer.Stop();
                        Errortext.Text = $"Found and read {ccbClub.Items.Count} clubs in: {timer.ElapsedMilliseconds} ms.";
                    }
                }
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
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }



        private void SaveXMLFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (loadedDoc?.Root != null)
                {
                    var selectedClubs = ccbClub.CheckedItems.Cast<string>().ToHashSet();

                    Errortext.Text = "";
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            timer.Reset();
                            timer.Start();
                            Cursor.Current = Cursors.WaitCursor;
                            //Get the path of specified file


                            var filteredCompetitors = loadedDoc.Root
                                            .Elements(ns + "Competitor")
                                            .Where(comp =>
                                                comp.Elements(ns + "Organisation")
                                                    .Elements(ns + "Name")
                                                    .Any(name => selectedClubs.Contains(name.Value.Trim()))
                                            )
                                            .ToList();

                            var newRoot = new XElement(ns + "CompetitorList",
                                loadedDoc.Root.Attributes(),
                                filteredCompetitors
                            );

                            var newDoc = new XDocument(new XDeclaration("1.0", "UTF-8", null), newRoot);
                            newDoc.Save(saveFileDialog.FileName);

                        }
                        else
                        {
                            Errortext.Text = "No XML file name to save.";
                        }
                    }
                }
                else
                {
                    Errortext.Text = "No XML file loaded.";
                }
            }
            catch (Exception ex)
            {
                Errortext.Text = "General Exeption: " + ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void SearchSI_Click(object sender, EventArgs e)
        {

            if (loadedDoc?.Root != null)
            {

                var lines = tbSINumbers.Text
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);


                var siNumbers = tbSINumbers.Text
                        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(line => line.Trim())
                        .ToHashSet();

                Errortext.Text = "";
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        timer.Reset();
                        timer.Start();
                        Cursor.Current = Cursors.WaitCursor;
                        //Get the path of specified file



                        var filteredCompetitors = loadedDoc.Root
                                        .Elements(ns + "Competitor")
                                        .Where(comp =>
                                            comp.Elements(ns + "ControlCard")
                                                .Any(card =>
                                                    (string?)card.Attribute("punchingSystem") == "SI" &&
                                                    siNumbers.Contains(card.Value.Trim()))
                                        )
                                        .ToList();

                        var newRoot = new XElement(ns + "CompetitorList",
                            loadedDoc.Root.Attributes(),
                            filteredCompetitors
                        );

                        var newDoc = new XDocument(new XDeclaration("1.0", "UTF-8", null), newRoot);
                        newDoc.Save(saveFileDialog.FileName);

                        timer.Stop();
                        Errortext.Text = $"Saved {filteredCompetitors.Count} competitors with matching SI numbers in: {timer.ElapsedMilliseconds} ms.";
                    }
                }
            }
            else
            {
                Errortext.Text = "No XML file loaded.";
            }
        }
    }
}