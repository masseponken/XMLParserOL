using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CheckComboBox;
using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace XMLParserOL_UI
{

    public partial class XMLParserOL_Form : Form
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList competitors;
        Stopwatch timer = new Stopwatch();

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
                        XMLFile.Text = openFileDialog.FileName;
                        XMLFile.SelectionStart = XMLFile.Text.Length;

                        timer.Reset();
                        timer.Start();

                        Errortext.Text = "";
                        xmlDoc.Load(XMLFile.Text);
                        List<String> coutries = new List<String>();
                        List<String> clubs = new List<String>();

                        Cursor.Current = Cursors.WaitCursor;
                        competitors = xmlDoc.GetElementsByTagName("Competitor");
                        foreach (XmlNode competitor in competitors)
                        {
                            foreach (XmlNode competitorChildnodes in competitor.ChildNodes)
                            {
                                if (competitorChildnodes.Name == "Organisation")
                                {
                                    foreach (XmlNode childnode in competitorChildnodes.ChildNodes)
                                    {
                                        if (childnode.Name == "Id")
                                        {

                                            var country = childnode.Attributes["type"];
                                            if (!coutries.Contains(country.Value))
                                            {
                                                coutries.Add(country.Value);
                                            }
                                        }
                                        if (childnode.Name == "Name")
                                        {
                                            var club = childnode.InnerText;
                                            if (!clubs.Contains(club))
                                            {
                                                clubs.Add(club);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //clubs = clubs.OrderBy(c => c).ToList();
                        ccbClub.Items.AddRange(clubs.OrderBy(c => c).ToArray());
                        timer.Stop();
                        Errortext.Text = "Found and read " + ccbClub.Items.Count + " clubs in: " + timer.ElapsedMilliseconds.ToString() + " ms.";

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
                List<XmlNode> filteredList = new List<XmlNode>();
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
                        XMLFile.Text = saveFileDialog.FileName;
                        XMLFile.SelectionStart = XMLFile.Text.Length;

                        int x = 0;
                        Errortext.Text = "Found " + x + " competitors";

                        foreach (XmlNode competitor in competitors)
                        {
                            foreach (XmlNode competitorChildnodes in competitor.ChildNodes)
                            {
                                if (competitorChildnodes.Name == "Organisation")
                                {
                                    foreach (XmlNode childnode in competitorChildnodes.ChildNodes)
                                    {
                                        if (childnode.Name == "Name")
                                        {
                                            foreach (var checkedItem in ccbClub.CheckedItems)
                                            {
                                                if (childnode.FirstChild.Value.ToLower() == checkedItem.ToString().ToLower())
                                                {
                                                    filteredList.Add(competitor);
                                                    x++;
                                                    Errortext.Text = ("Found " + x + " competitors from " + ccbClub.CheckedItems.Count + " club(s)");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        XmlDocument outDoc = new XmlDocument();
                        XmlNode header = outDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        outDoc.AppendChild(header);

                        XmlNode competitorList = outDoc.ImportNode(xmlDoc.LastChild, false);

                        foreach (XmlNode competitor in filteredList)
                        {
                            competitorList.AppendChild(outDoc.ImportNode(competitor, true));
                        }

                        outDoc.AppendChild(competitorList);

                        outDoc.Save(XMLFile.Text);
                        timer.Stop();
                        Errortext.Text = "Saved " + filteredList.Count + " competitors from " + ccbClub.CheckedItems.Count + " clubs in: " + timer.ElapsedMilliseconds.ToString() + " ms.";
                    }
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
    }
}