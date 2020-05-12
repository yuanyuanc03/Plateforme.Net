using Bacchus.MVC.Controller;
using Bacchus.MVC.DAO;
using Bacchus.MVC.Model;
using Bacchus.MVC.View.ArticlesView;
using Bacchus.MVC.View.FamillesView;
using Bacchus.MVC.View.MarquesView;
using Bacchus.MVC.View.SousFamillesView;
using Bacchus.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.MVC.View.MainView
{
    /// <summary>
    /// The main view of Application.
    /// </summary>
    public partial class FormMain : Form
    {
        private TreeNode Node;
        private List<string> FamilleNames;
        private List<string> SousFamilleNames;
        private List<string> MarqueNames;
        private ArticlesController ArticleController;
        private FamillesController FamilleController;
        private MarquesController MarqueController;
        private SousFamillesController SousFamilleController;
        private ArticlesDao ArticleDao;
        private FamillesDao FamilleDao;
        private MarquesDao MarqueDao;
        private SousFamillesDao SousFamilleDao;
        private int ColumnIndex;
        public FileSystemWatcher FileWatch = new FileSystemWatcher();

        /// <summary>
        /// The constructor of FormMain.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            FormMain_FileSystemWatcher();
            this.Node = null;
            this.FamilleNames = new List<string>();
            this.SousFamilleNames = new List<string>();
            this.MarqueNames = new List<string>();
            this.ArticleController = new ArticlesController();
            this.FamilleController = new FamillesController();
            this.MarqueController = new MarquesController();
            this.SousFamilleController = new SousFamillesController();
            this.ArticleDao = new ArticlesDao();
            this.FamilleDao = new FamillesDao();
            this.MarqueDao = new MarquesDao();
            this.SousFamilleDao = new SousFamillesDao();
        }

        /// <summary>
        /// Refresh the main view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadListView();
        }

        /// <summary>
        /// Open the FormImport view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport FormImport = new FormImport { StartPosition = FormStartPosition.CenterParent };
            FormImport.ShowDialog(this);
        }

        /// <summary>
        /// Open the FormExport view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExport FormExport = new FormExport { StartPosition = FormStartPosition.CenterParent };
            FormExport.ShowDialog(this);
        }

        /// <summary>
        /// Using the right click to show the contextmenu of add, delete or modify an article.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ListView_MouseRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListView.ContextMenuStrip = null;
                contextMenuStrip_ListView.Show(ListView, e.Location);
            }
        }

        /// <summary>
        /// Using the double click to open the ModifyArticle view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Modify_Article();
        }

        /// <summary>
        /// Using 'F5' to refresh the main view, 'Del' to delete an article, 'Enter' to open the ModifyArticle view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    LoadListView();
                    break;
                case Keys.Delete:
                    Delete_Article();
                    LoadListView();
                    break;
                case Keys.Enter:
                    Modify_Article();
                    break;
            }
        }

        /// <summary>
        /// Click the column to group different catagroies.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.ColumnIndex = e.Column;
            SetGroups(ListView.Columns[this.ColumnIndex].Text);
        }

        /// <summary>
        /// Set the group in different conditions.
        /// </summary>
        /// <param name="ColumnName"></param>
        private void SetGroups(string ColumnName)
        {
            ModelList ModelList = new ModelList();
            this.ListView.Groups.Clear();

            if(TreeView.SelectedNode == TreeView.Nodes[0]) 
            {
                switch (ColumnName)
                {
                    case "Description":
                        for (int i = 0; i < 26; i++)
                        {
                            string Group = ((char)(65 + i)).ToString();
                            this.ListView.Groups.Add(new ListViewGroup(Group, HorizontalAlignment.Left));
                        }
                        this.ListView.Groups.Add(new ListViewGroup("Others", HorizontalAlignment.Left));
                        //foreach (var Article in ModelList.Articles)
                        //{
                        for (int k = 0; k < ModelList.Articles.Count; k++)
                        {
                            var HeadLetter = (int)Encoding.Default.GetBytes(this.ListView.Items[k].SubItems[ColumnIndex].Text.Split()[0])[0];
                            if (HeadLetter <= 90 && HeadLetter >= 65)
                                this.ListView.Items[k].Group = this.ListView.Groups[(HeadLetter - 65)];
                            else if (HeadLetter >= 97 && HeadLetter <= 122)
                                this.ListView.Items[k].Group = this.ListView.Groups[(HeadLetter - 97)];
                            else
                                this.ListView.Items[k].Group = this.ListView.Groups[26];
                        }
                        //}
                        break;

                    case "Famille":
                        for (int i = 0; i < ModelList.Familles.Count; i++)
                        {
                            this.ListView.Groups.Add(new ListViewGroup(ModelList.Familles[i].FamilleName, HorizontalAlignment.Left));
                        }
                        var j = 0;
                        foreach (var Famille in ModelList.Familles)
                        {
                            for (int k = 0; k < ModelList.Articles.Count; k++)
                            {
                                if (this.ListView.Items[k].SubItems[ColumnIndex].Text == Famille.FamilleName)
                                    this.ListView.Items[k].Group = this.ListView.Groups[j];
                            }
                            j++;
                        }
                        break;

                    case "Sous-famille":
                        for (int i = 0; i < ModelList.SousFamilles.Count; i++)
                        {
                            this.ListView.Groups.Add(new ListViewGroup(ModelList.SousFamilles[i].SousFamilleName, HorizontalAlignment.Left));
                        }
                        j = 0;
                        foreach (var SousFamille in ModelList.SousFamilles)
                        {
                            for (int k = 0; k < ModelList.Articles.Count; k++)
                            {
                                if (this.ListView.Items[k].SubItems[ColumnIndex].Text == SousFamille.SousFamilleName)
                                    this.ListView.Items[k].Group = this.ListView.Groups[j];
                            }
                            j++;
                        }
                        break;

                    case "Marque":
                        for (int i = 0; i < ModelList.Marques.Count; i++)
                        {
                            this.ListView.Groups.Add(new ListViewGroup(ModelList.Marques[i].MarqueName, HorizontalAlignment.Left));
                        }
                        j = 0;
                        foreach (var Marque in ModelList.Marques)
                        {
                            for (int k = 0; k < ModelList.Articles.Count; k++)
                            {
                                if (this.ListView.Items[k].SubItems[ColumnIndex].Text == Marque.MarqueName)
                                    this.ListView.Items[k].Group = this.ListView.Groups[j];
                            }
                            j++;
                        }
                        break;

                    default:
                        if (ListView.Sorting == SortOrder.Ascending)
                            ListView.Sorting = SortOrder.Descending;
                        else
                            ListView.Sorting = SortOrder.Ascending;

                        ListView.Sort();
                        this.ListView.ListViewItemSorter = new Util.ListViewItemComparer(ColumnIndex, ListView.Sorting);
                        break;
                }
            }

            else if (TreeView.SelectedNode == TreeView.Nodes[1] || TreeView.SelectedNode.Parent == TreeView.Nodes[1] || TreeView.SelectedNode == TreeView.Nodes[2])
            {
                if(ColumnName == "Description")
                {
                    if (ListView.Sorting == SortOrder.Ascending)
                        ListView.Sorting = SortOrder.Descending;
                    else
                        ListView.Sorting = SortOrder.Ascending;

                    ListView.Sort();
                    this.ListView.ListViewItemSorter = new Util.ListViewItemComparer(ColumnIndex, ListView.Sorting);
                }
            }

            else if(TreeView.SelectedNode.Parent.Parent == TreeView.Nodes[1])
            {
                switch (ColumnName)
                {
                    case "Description":

                        for (int i = 0; i < 26; i++)
                        {
                            string Group = ((char)(65 + i)).ToString();
                            this.ListView.Groups.Add(new ListViewGroup(Group, HorizontalAlignment.Left));
                        }

                        this.ListView.Groups.Add(new ListViewGroup("Others", HorizontalAlignment.Left));

                        for (int k = 0; k < ArticleController.FindArticlesBySousFamilleName(TreeView.SelectedNode.Text).Count; k++)
                        {
                            var HeadLetter = (int)Encoding.Default.GetBytes(this.ListView.Items[k].SubItems[ColumnIndex].Text.Split()[0])[0];
                            if (HeadLetter >= 65 && HeadLetter <= 90)
                                this.ListView.Items[k].Group = this.ListView.Groups[(HeadLetter - 65)];
                            else if (HeadLetter >= 97 && HeadLetter <= 122)
                                this.ListView.Items[k].Group = this.ListView.Groups[(HeadLetter - 97)];
                            else 
                                //change
                                this.ListView.Items[k].Group = this.ListView.Groups[26];
                        }

                        break;

                    case "Famille":

                        this.ListView.Groups.Add(new ListViewGroup(TreeView.SelectedNode.Parent.Text, HorizontalAlignment.Left));

                        for (int k = 0; k < ArticleController.FindArticlesBySousFamilleName(TreeView.SelectedNode.Text).Count; k++)
                        {
                            if (this.ListView.Items[k].SubItems[ColumnIndex].Text == TreeView.SelectedNode.Parent.Text)
                                this.ListView.Items[k].Group = this.ListView.Groups[0];
                        }

                        break;

                    case "Sous-famille":

                        this.ListView.Groups.Add(new ListViewGroup(TreeView.SelectedNode.Text, HorizontalAlignment.Left));

                        for (int k = 0; k < ArticleController.FindArticlesBySousFamilleName(TreeView.SelectedNode.Text).Count; k++)
                        {
                            if (this.ListView.Items[k].SubItems[ColumnIndex].Text == TreeView.SelectedNode.Text)
                                this.ListView.Items[k].Group = this.ListView.Groups[0];
                        }
                        break;

                    case "Marque":

                        for (int i = 0; i < MarqueController.FindMarquesBySousFamilleName(TreeView.SelectedNode.Text).Count; i++)
                        {
                            this.ListView.Groups.Add(new ListViewGroup(MarqueController.FindMarquesBySousFamilleName(TreeView.SelectedNode.Text)[i].MarqueName, HorizontalAlignment.Left));
                        }
                        var j = 0;
                        foreach (var Marque in MarqueController.FindMarquesBySousFamilleName(TreeView.SelectedNode.Text))
                        {
                            for (int k = 0; k < ArticleController.FindArticlesBySousFamilleName(TreeView.SelectedNode.Text).Count; k++)
                            {
                                if (this.ListView.Items[k].SubItems[ColumnIndex].Text == Marque.MarqueName)
                                    this.ListView.Items[k].Group = this.ListView.Groups[j];
                            }
                            j++;
                        }
                        break;

                    default:
                        if (ListView.Sorting == SortOrder.Ascending)
                            ListView.Sorting = SortOrder.Descending;
                        else
                            ListView.Sorting = SortOrder.Ascending;

                        ListView.Sort();
                        this.ListView.ListViewItemSorter = new Util.ListViewItemComparer(ColumnIndex, ListView.Sorting);
                        break;
                }
            }

            else if (TreeView.SelectedNode.Parent == TreeView.Nodes[2])
            {
                switch (ColumnName)
                {
                    case "Description":
                        for (int i = 0; i < 26; i++)
                        {
                            string Group = ((char)(65 + i)).ToString();
                            this.ListView.Groups.Add(new ListViewGroup(Group, HorizontalAlignment.Left));
                        }

                        this.ListView.Groups.Add(new ListViewGroup("Others", HorizontalAlignment.Left));

                        for (int k = 0; k < ArticleController.FindArticlesByMarqueName(TreeView.SelectedNode.Text).Count; k++)
                        {
                            var HeadLetter = (int)Encoding.Default.GetBytes(this.ListView.Items[k].SubItems[ColumnIndex].Text.Split()[0])[0];
                            if (HeadLetter <= 90 && HeadLetter >= 65)
                                this.ListView.Items[k].Group = this.ListView.Groups[(HeadLetter - 65)];
                            else if (HeadLetter >= 97 && HeadLetter <= 122)
                                this.ListView.Items[k].Group = this.ListView.Groups[(HeadLetter - 97)];
                            else
                                this.ListView.Items[k].Group = this.ListView.Groups[26];
                        }

                        break;

                    case "Famille":
                        for (int i = 0; i < FamilleController.FindFamillesByMarqueName(TreeView.SelectedNode.Text).Count; i++)
                        {
                            this.ListView.Groups.Add(new ListViewGroup(FamilleController.FindFamillesByMarqueName(TreeView.SelectedNode.Text)[i].FamilleName, HorizontalAlignment.Left));
                        }
                        var j = 0;
                        foreach (var Famille in FamilleController.FindFamillesByMarqueName(TreeView.SelectedNode.Text))
                        {
                            for (int k = 0; k < ArticleController.FindArticlesByMarqueName(TreeView.SelectedNode.Text).Count; k++)
                            {
                                if (this.ListView.Items[k].SubItems[ColumnIndex].Text == Famille.FamilleName)
                                    this.ListView.Items[k].Group = this.ListView.Groups[j];
                            }
                            j++;
                        }
                        break;

                    case "Sous-famille":
                        for (int i = 0; i < SousFamilleController.FindSousFamillesByMarqueName(TreeView.SelectedNode.Text).Count; i++)
                        {
                            this.ListView.Groups.Add(new ListViewGroup(SousFamilleController.FindSousFamillesByMarqueName(TreeView.SelectedNode.Text)[i].SousFamilleName, HorizontalAlignment.Left));
                        }
                        j = 0;
                        foreach (var SousFamille in SousFamilleController.FindSousFamillesByMarqueName(TreeView.SelectedNode.Text))
                        {
                            for (int k = 0; k < ArticleController.FindArticlesByMarqueName(TreeView.SelectedNode.Text).Count; k++)
                            {
                                if (this.ListView.Items[k].SubItems[ColumnIndex].Text == SousFamille.SousFamilleName)
                                    this.ListView.Items[k].Group = this.ListView.Groups[j];
                            }
                            j++;
                        }
                        break;

                    case "Marque":
                        this.ListView.Groups.Add(new ListViewGroup(MarqueController.FindMarquesByMarqueName(TreeView.SelectedNode.Text).MarqueName, HorizontalAlignment.Left));

                        for (int k = 0; k < ArticleController.FindArticlesByMarqueName(TreeView.SelectedNode.Text).Count; k++)
                        {
                            if (this.ListView.Items[k].SubItems[ColumnIndex].Text == MarqueController.FindMarquesByMarqueName(TreeView.SelectedNode.Text).MarqueName)
                                this.ListView.Items[k].Group = this.ListView.Groups[0];
                        }

                        break;

                    default:
                        if (ListView.Sorting == SortOrder.Ascending)
                            ListView.Sorting = SortOrder.Descending;
                        else
                            ListView.Sorting = SortOrder.Ascending;

                        ListView.Sort();
                        this.ListView.ListViewItemSorter = new Util.ListViewItemComparer(ColumnIndex, ListView.Sorting);
                        break;
                }
            }
        }

        /// <summary>
        /// When we select a node of the treeview, this method will refresh the main view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadListView();
        }

        /// <summary>
        /// Update the Treeview.
        /// </summary>
        private void UpdateTreeView()
        {
            if (TreeView.Nodes[1].Nodes.Count != 0)
                TreeView.Nodes[1].Nodes.Clear();
            if (TreeView.Nodes[2].Nodes.Count != 0)
                TreeView.Nodes[2].Nodes.Clear();
        }

        /// <summary>
        /// Using right click to show the contextmenu of add, delete or modify a famille, sousfamille or marque.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_MouseRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView.ContextMenuStrip = null;
                contextMenuStrip_TreeView.Show(TreeView, e.Location);
            }
        }

        /// <summary>
        /// Using 'F5' to refresh the main view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    UpdateTreeView();
                    break;
            }
        }

        /// <summary>
        /// Update the data in the ListView.
        /// </summary>
        public void LoadListView()
        {
            ModelList ModelList = new ModelList();
            ListView.GridLines = true;
            ListView.View = System.Windows.Forms.View.Details;

            Node = TreeView.SelectedNode;

            if (Node.Text.Equals("Tous les articles"))
            {
                ListView.Clear();

                ListView.Columns.Add("Référence", "Référence");
                ListView.Columns.Add("Description", "Description");
                ListView.Columns.Add("Famille", "Famille");
                ListView.Columns.Add("Sous-famille", "Sous-famille");
                ListView.Columns.Add("Marque", "Marque");
                ListView.Columns.Add("Prix", "Prix H.T.");
                ListView.Columns.Add("Quantité", "Quantité");
 
                foreach (var Article in ModelList.Articles)
                {
                    ListView.Items.Add(new ListViewItem(Article.InfoTable()));
                }

                ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                ListView.Text = "Articles";
                toolStripStatusLabel.Text = "Tous les articles: " + ModelList.Articles.Count;
            }

            else if (Node.Text.Equals("Familles"))
            {
                ListView.Clear();

                ListView.Columns.Add("Description", "Description");

                this.ListView.ListViewItemSorter = new Util.ListViewItemComparer(0, ListView.Sorting);

                if (Node.Nodes.Count == 0)
                {
                    foreach (var Famille in ModelList.Familles)
                    {
                        ListView.Items.Add(new ListViewItem(Famille.InfoTable()));
                        TreeView.Nodes[1].Nodes.Add(Famille.FamilleName);
                        FamilleNames.Add(Famille.FamilleName);
                    }
                }
                else
                {
                    foreach (var Famille in ModelList.Familles)
                    {
                        ListView.Items.Add(new ListViewItem(Famille.InfoTable()));
                        FamilleNames.Add(Famille.FamilleName);
                    }
                }

                ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                ListView.Text = "Familles";
                toolStripStatusLabel.Text = "Familles: " + ModelList.Familles.Count;
            }

            else if (Node.Text.Equals("Marques"))
            {
                ListView.Clear();

                ListView.Columns.Add("Description", "Description");

                this.ListView.ListViewItemSorter = new Util.ListViewItemComparer(0, ListView.Sorting);

                if (Node.Nodes.Count == 0)
                {
                    foreach (var Marque in ModelList.Marques)
                    {
                        ListView.Items.Add(new ListViewItem(Marque.InfoTable()));
                        TreeView.Nodes[2].Nodes.Add(Marque.MarqueName);
                        MarqueNames.Add(Marque.MarqueName);
                    }
                }
                else
                {
                    foreach (var Marque in ModelList.Marques)
                    {
                        ListView.Items.Add(new ListViewItem(Marque.InfoTable()));
                        MarqueNames.Add(Marque.MarqueName);
                    }
                }

                ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                ListView.Text = "Marques";
                toolStripStatusLabel.Text = "Marques: " + ModelList.Marques.Count;
            }

            else if(FamilleNames.Contains(Node.Text))
            {
                List<SousFamilles> SousFamilles = SousFamilleController.FindSousFamillesByFamilleName(Node.Text);
                ListView.Clear();
                ListView.Columns.Add("Description", "Description");

                this.ListView.ListViewItemSorter = new Util.ListViewItemComparer(0, ListView.Sorting);

                if (Node.Nodes.Count == 0)
                {
                    foreach (var SousFamille in SousFamilles)
                    {
                        TreeView.Nodes[1].Nodes[FamilleNames.IndexOf(Node.Text)].Nodes.Add(SousFamille.SousFamilleName);
                        ListView.Items.Add(new ListViewItem(SousFamille.InfoTable()));
                        SousFamilleNames.Add(SousFamille.SousFamilleName);
                    }
                }
                else
                {
                    foreach (var SousFamille in SousFamilles)
                    {
                        ListView.Items.Add(new ListViewItem(SousFamille.InfoTable()));
                        SousFamilleNames.Add(SousFamille.SousFamilleName);
                    }
                }

                ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                ListView.Text = "SousFamilles";
                toolStripStatusLabel.Text = "SousFamilles de " + Node.Text + ": " + SousFamilles.Count;
            }

            else if (MarqueNames.Contains(Node.Text))
            {
                List<Articles> Articles = ArticleController.FindArticlesByMarqueName(Node.Text);
                ListView.Clear();

                ListView.Columns.Add("Référence", "Référence");
                ListView.Columns.Add("Description", "Description");
                ListView.Columns.Add("Famille", "Famille");
                ListView.Columns.Add("Sous-famille", "Sous-famille");
                ListView.Columns.Add("Marque", "Marque");
                ListView.Columns.Add("Prix", "Prix H.T.");
                ListView.Columns.Add("Quantité", "Quantité");

                foreach (var Article in Articles)
                {
                    ListView.Items.Add(new ListViewItem(Article.InfoTable()));
                }

                ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                ListView.Text = "Articles";
                toolStripStatusLabel.Text = "Articles de Marque " + Node.Text + ": " + Articles.Count;
            }

            else if (SousFamilleNames.Contains(Node.Text))
            {
                List<Articles> Articles = ArticleController.FindArticlesBySousFamilleName(Node.Text);
                ListView.Clear();

                ListView.Columns.Add("Référence", "Référence");
                ListView.Columns.Add("Description", "Description");
                ListView.Columns.Add("Famille", "Famille");
                ListView.Columns.Add("Sous-famille", "Sous-famille");
                ListView.Columns.Add("Marque", "Marque");
                ListView.Columns.Add("Prix", "Prix H.T.");
                ListView.Columns.Add("Quantité", "Quantité");

                foreach (var Article in Articles)
                {
                    ListView.Items.Add(new ListViewItem(Article.InfoTable()));
                }

                ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                ListView.Text = "Articles";
                toolStripStatusLabel.Text = "Articles de Sous-famille " + Node.Text + ": " + Articles.Count;
            }

            TreeView.ExpandAll();
            ListView.Sort();
            ListView.Show();
        }

        /// <summary>
        /// Update the ListView after adding the article.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Article();
            LoadListView();
        }

        /// <summary>
        /// Update the ListView after deleting the article.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_Article();
            LoadListView();
        }

        /// <summary>
        /// Update the ListView after mofifying the article.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modify_Article();
            LoadListView();
        }

        /// <summary>
        /// Update the TreeView after adding a famille, marque or sousfamille.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ajouterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Node = TreeView.SelectedNode;

            if (Node.Text.Equals("Tous les articles"))
                MessageBox.Show("You can't add articles in the TreeView!");

            else if (Node.Text.Equals("Familles"))
            {
                var FamilleName = Add_Famille();
                if(FamilleName != "")
                    TreeView.Nodes[1].Nodes.Add(new TreeNode(FamilleName));
                LoadListView();
            }

            else if (Node.Text.Equals("Marques"))
            {
                var MarqueName = Add_Marque();
                if(MarqueName != "")
                    TreeView.Nodes[2].Nodes.Add(new TreeNode(MarqueName));
                LoadListView();
            }

            else if (FamilleNames.Contains(Node.Text))
            {
                var FamilleName = Add_SousFamille_CurrentNode();
                if(FamilleName != "")
                    TreeView.SelectedNode.Nodes.Add(new TreeNode(FamilleName));
                LoadListView();
            }

            else if (MarqueNames.Contains(Node.Text))
            {
                var MarqueName = Add_Marque();
                if (MarqueName != "")
                    TreeView.Nodes[2].Nodes.Add(new TreeNode(MarqueName));
                LoadListView();
            }

            else if (SousFamilleNames.Contains(Node.Text))
            {
                var SousFamilleName = Add_SousFamille_ParentNode();
                if (SousFamilleName != "")
                    TreeView.Nodes[1].Nodes[FamilleNames.IndexOf(TreeView.SelectedNode.Parent.Text)].Nodes.Add(new TreeNode(SousFamilleName));
                LoadListView();
            }

            ListView.Sort();
            ListView.Show();
        }

        /// <summary>
        /// Update the TreeView after deleting a famille, marque or sousfamille.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supprimerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Node = TreeView.SelectedNode;

            if (Node.Text.Equals("Tous les articles"))
                MessageBox.Show("You can't delete articles in the TreeView!");

            else if (Node.Text.Equals("Familles"))
                MessageBox.Show("Please select a famille!");

            else if (Node.Text.Equals("Marques"))
                MessageBox.Show("Please select a marque!");

            else if (FamilleNames.Contains(Node.Text))
            {
                Delete_Famille();
                TreeView.Nodes[1].Nodes.Remove(TreeView.SelectedNode);
                LoadListView();
            }

            else if (MarqueNames.Contains(Node.Text))
            {
                Delete_Marque();
                TreeView.Nodes[2].Nodes.Remove(TreeView.SelectedNode);
                LoadListView();
            }

            else if (SousFamilleNames.Contains(Node.Text))
            {
                Delete_SousFamille();
                TreeView.SelectedNode.Parent.Nodes.Remove(TreeView.SelectedNode);
                LoadListView();
            }

            ListView.Sort();
            ListView.Show();
        }

        /// <summary>
        /// Update the TreeView after mofifying the famille, marque or sousfamille.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Node = TreeView.SelectedNode;

            if (Node.Text.Equals("Tous les articles"))
                MessageBox.Show("You can't modify articles in the TreeView!");

            else if (Node.Text.Equals("Familles"))
                MessageBox.Show("Please select a famille!");

            else if (Node.Text.Equals("Marques"))
                MessageBox.Show("Please select a marque!");

            else if (FamilleNames.Contains(Node.Text))
            {
                var FamilleName = Modify_Famille();
                if(FamilleName != "")
                    TreeView.SelectedNode.Text = FamilleName;
                LoadListView();
            }

            else if (MarqueNames.Contains(Node.Text))
            {
                var MarqueName = Modify_Marque();
                if(MarqueName != "")
                    TreeView.SelectedNode.Text = MarqueName;
                LoadListView();
            }

            else if (SousFamilleNames.Contains(Node.Text))
            {
                var SousFamilleName = Modify_SousFamille();
                if (SousFamilleName != "")
                    TreeView.SelectedNode.Text = SousFamilleName;
                LoadListView();
            }

            ListView.Sort();
            ListView.Show();
        }

        /// <summary>
        /// Open the AddArticle view.
        /// </summary>
        private void Add_Article()
        {
            AddArticle AddArticle = new AddArticle() { StartPosition = FormStartPosition.CenterParent };
            AddArticle.ShowDialog(this);
        }

        /// <summary>
        /// Open the AddFamille view.
        /// </summary>
        /// <returns></returns>
        private string Add_Famille()
        {
            AddFamille AddFamille = new AddFamille() { StartPosition = FormStartPosition.CenterParent };
            AddFamille.ShowDialog(this);

            if(AddFamille.textBox_FamilleName.Text != "")
                FamilleNames.Add(AddFamille.textBox_FamilleName.Text);

            return AddFamille.textBox_FamilleName.Text;
        }

        /// <summary>
        /// Open the AddMarque view.
        /// </summary>
        /// <returns></returns>
        private string Add_Marque()
        {
            AddMarque AddMarque = new AddMarque() { StartPosition = FormStartPosition.CenterParent };
            AddMarque.ShowDialog(this);

            if(AddMarque.textBox_MarqueName.Text != "")
                MarqueNames.Add(AddMarque.textBox_MarqueName.Text);

            return AddMarque.textBox_MarqueName.Text;
        }

        /// <summary>
        /// Open the AddSousFamille view.
        /// </summary>
        /// <returns></returns>
        private string Add_SousFamille_CurrentNode()
        {
            AddSousFamille AddSousFamille = new AddSousFamille() { StartPosition = FormStartPosition.CenterParent };
            AddSousFamille.label_Famille_Name.Text = TreeView.SelectedNode.Text;
            AddSousFamille.ShowDialog(this);

            if(AddSousFamille.textBox_SousFamilleName.Text != "")
                SousFamilleNames.Add(AddSousFamille.textBox_SousFamilleName.Text);

            return AddSousFamille.textBox_SousFamilleName.Text;
        }

        /// <summary>
        /// Open the AddSousFamille view.
        /// </summary>
        /// <returns></returns>
        private string Add_SousFamille_ParentNode()
        {
            AddSousFamille AddSousFamille = new AddSousFamille() { StartPosition = FormStartPosition.CenterParent };
            AddSousFamille.label_Famille_Name.Text = TreeView.SelectedNode.Parent.Text;
            AddSousFamille.ShowDialog(this);

            if(AddSousFamille.textBox_SousFamilleName.Text != "")
                SousFamilleNames.Add(AddSousFamille.textBox_SousFamilleName.Text);

            return AddSousFamille.textBox_SousFamilleName.Text;
        }

        /// <summary>
        /// Delete an article.
        /// </summary>
        private void Delete_Article()
        {
            if (ListView.FocusedItem == null)
                MessageBox.Show("Please select an article!");
            else
            {
                var RefArticle = ListView.FocusedItem.Text;
                if (ArticleController.FindArticleByRefArticle(RefArticle))
                {
                    ArticleDao.DeleteArticle(ArticleController.FindArticlesByRefArticle(RefArticle));
                    if (!ArticleController.FindArticleByRefArticle(RefArticle))
                        MessageBox.Show("Delete succeed!");
                }
                else
                    MessageBox.Show("Article doesn't exist!");
            }
        }

        /// <summary>
        /// Delete a famille.
        /// </summary>
        private void Delete_Famille() 
        {
            var FamilleName = TreeView.SelectedNode.Text;

            if (FamilleController.FindFamilleByFamilleName(FamilleName))
            {
                FamilleDao.DeleteFamille(FamilleController.FindFamillesByFamilleName(FamilleName));
                FamilleNames.Remove(FamilleName);
                if (!FamilleController.FindFamilleByFamilleName(FamilleName))
                    MessageBox.Show("Delete succeed!");
            }
            else
                MessageBox.Show("Famille doesn't exist!");
        }

        /// <summary>
        /// Delete a marque.
        /// </summary>
        private void Delete_Marque() 
        {
            var MarqueName = TreeView.SelectedNode.Text;

            if (MarqueController.FindMarqueByMarqueName(MarqueName))
            {
                MarqueDao.DeleteMarque(MarqueController.FindMarquesByMarqueName(MarqueName));
                MarqueNames.Remove(MarqueName);
                if (!MarqueController.FindMarqueByMarqueName(MarqueName))
                    MessageBox.Show("Delete succeed!");
            }
            else
                MessageBox.Show("Marque doesn't exist!");
        }

        /// <summary>
        /// Delete a sousfamille.
        /// </summary>
        private void Delete_SousFamille() 
        {
            var SousFamilleName = TreeView.SelectedNode.Text;

            if (SousFamilleController.FindSousFamilleBySousFamilleName(SousFamilleName))
            {
                SousFamilleDao.DeleteSousFamille(SousFamilleController.FindSousFamillesBySousFamilleName(SousFamilleName));
                SousFamilleNames.Remove(SousFamilleName);
                if (!SousFamilleController.FindSousFamilleBySousFamilleName(SousFamilleName))
                    MessageBox.Show("Delete succeed!");
            }
            else
                MessageBox.Show("SousFamille doesn't exist!");
        }

        /// <summary>
        /// Open the ModifyArticle view.
        /// </summary>
        private void Modify_Article()
        {
            if (ListView.FocusedItem == null)
                MessageBox.Show("Please select an article!");
            else
            {
                var RefArticle = ListView.FocusedItem.Text;

                Articles Article = ArticleController.FindArticlesByRefArticle(RefArticle);
                if (ArticleController.FindArticleByRefArticle(RefArticle))
                {
                    ModifyArticle ModifyArticle = new ModifyArticle(Article) { StartPosition = FormStartPosition.CenterParent };
                    ModifyArticle.ShowDialog(this);
                }
                else
                    MessageBox.Show("Article doesn't exist!");
            }
        }

        /// <summary>
        /// Open the ModifyFamille view.
        /// </summary>
        /// <returns></returns>
        private string Modify_Famille() 
        {
            var FamilleName = TreeView.SelectedNode.Text;

            if (FamilleController.FindFamilleByFamilleName(FamilleName))
            {
                ModifyFamille ModifyFamille = new ModifyFamille(TreeView.SelectedNode.Text) { StartPosition = FormStartPosition.CenterParent };
                ModifyFamille.ShowDialog(this);

                if (ModifyFamille.textBox_NewFamilleName.Text != "")
                {
                    var Index = FamilleNames.IndexOf(FamilleName);
                    FamilleNames.Remove(FamilleName);
                    FamilleNames.Insert(Index, ModifyFamille.textBox_NewFamilleName.Text);
                    FamilleName = ModifyFamille.textBox_NewFamilleName.Text;
                }
            }
            else
                MessageBox.Show("Famille doesn't exist!");

            return FamilleName;
        }

        /// <summary>
        /// Open the ModifyMarque view.
        /// </summary>
        /// <returns></returns>
        private string Modify_Marque() 
        {
            var MarqueName = TreeView.SelectedNode.Text;

            if (MarqueController.FindMarqueByMarqueName(MarqueName))
            {
                ModifyMarque ModifyMarque = new ModifyMarque(TreeView.SelectedNode.Text) { StartPosition = FormStartPosition.CenterParent };
                ModifyMarque.ShowDialog(this);

                if(ModifyMarque.textBox_NewMarqueName.Text != "")
                {
                    var Index = MarqueNames.IndexOf(MarqueName);
                    MarqueNames.Remove(MarqueName);
                    MarqueNames.Insert(Index, ModifyMarque.textBox_NewMarqueName.Text);
                    MarqueName = ModifyMarque.textBox_NewMarqueName.Text;
                }
            }
            else
                MessageBox.Show("Marque doesn't exist!");

            return MarqueName;
        }

        /// <summary>
        /// Open the ModifySousFamille view.
        /// </summary>
        /// <returns></returns>
        private string Modify_SousFamille() 
        {
            var SousFamilleName = TreeView.SelectedNode.Text;

            if (SousFamilleController.FindSousFamilleBySousFamilleName(SousFamilleName))
            {
                ModifySousFamilles ModifySousFamille = new ModifySousFamilles(TreeView.SelectedNode.Parent.Text, TreeView.SelectedNode.Text) { StartPosition = FormStartPosition.CenterParent };
                ModifySousFamille.ShowDialog(this);

                if(ModifySousFamille.textBox_NewSousFamilleName.Text != "")
                {
                    var Index = SousFamilleNames.IndexOf(SousFamilleName);
                    SousFamilleNames.Remove(SousFamilleName);
                    SousFamilleNames.Insert(Index, ModifySousFamille.textBox_NewSousFamilleName.Text);
                    SousFamilleName = ModifySousFamille.textBox_NewSousFamilleName.Text;
                }
            }
            else
                MessageBox.Show("Famille doesn't exist!");

            return SousFamilleName;
        }

        /// <summary>
        /// Empty the data in the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viderLaBaseDeDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelListDao.EmptyDataBase();
            LoadListView();
            UpdateTreeView();
        }

        /// <summary>
        /// Load the initial state of the FormMain.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            if (Bacchus.Properties.Settings.Default.FormMainSize.Width == 0) 
                Bacchus.Properties.Settings.Default.Upgrade();

            if (Bacchus.Properties.Settings.Default.FormMainSize.Width == 0 || Bacchus.Properties.Settings.Default.FormMainSize.Height == 0)
            {
                this.Size = new Size(800, 550);
            }
            else
            {
                this.WindowState = Bacchus.Properties.Settings.Default.FormMainState;

                if (this.WindowState == FormWindowState.Minimized) 
                    this.WindowState = FormWindowState.Normal;

                this.Location = Properties.Settings.Default.FormMainLocation;
                this.Size = Properties.Settings.Default.FormMainSize;
            }
        }

        /// <summary>
        /// Verify to quit the process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close the window?", "Quit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Dispose();

                Bacchus.Properties.Settings.Default.FormMainState = this.WindowState;

                if(this.WindowState == FormWindowState.Normal)
                {
                    Bacchus.Properties.Settings.Default.FormMainLocation = this.Location;
                    Bacchus.Properties.Settings.Default.FormMainSize = this.Size;
                }
                else
                {
                    Bacchus.Properties.Settings.Default.FormMainLocation = this.RestoreBounds.Location;
                    Bacchus.Properties.Settings.Default.FormMainSize = this.RestoreBounds.Size;
                }

                Bacchus.Properties.Settings.Default.Save();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }


        /// <summary>
        /// Settings of the watcher of the filesystem.
        /// </summary>
        private void FormMain_FileSystemWatcher()
        {
            FileWatch.Path = System.Environment.CurrentDirectory;
            FileWatch.NotifyFilter = NotifyFilters.LastWrite;
            FileWatch.Filter = "Bacchus.SQLite";
            FileWatch.IncludeSubdirectories = false;
            FileWatch.Changed += new FileSystemEventHandler(Watch_Changed);
            FileWatch.EnableRaisingEvents = true;
        }

        /// <summary>
        /// When the database <c>Bacchus.SQLite</c> has been changed, this method will save the file to the output directory.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void Watch_Changed(object source, FileSystemEventArgs e)
        {
            if (FileWatch != null)
            {
                try
                {
                    FileWatch.EnableRaisingEvents = false;
                    string DestPath;
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\Output\\Bacchus.SQLite"))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "\\Output\\Bacchus.SQLite");  
                    }
                    else
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Output");
                    }
                    DestPath = Path.Combine(Directory.GetCurrentDirectory() + "\\Output", "Bacchus.SQLite");
                    System.IO.File.Copy(System.Environment.CurrentDirectory + "\\Bacchus.SQLite", DestPath);

                }
                finally
                {
                    FileWatch.EnableRaisingEvents = true;
                }
            }
        }
    }
}
