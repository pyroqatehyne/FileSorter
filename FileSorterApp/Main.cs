using System;
using System.Windows.Forms;
using System.IO;
using Utils;

namespace FileSorter
{
    public partial class Main : Form
    {
        readonly FileList<FileData> _sourceFiles;
        readonly ExtensionList<ExtensionData> _extensions;

        public Main()
        {
            InitializeComponent();

            _sourceFiles = new FileList<FileData>();
            _extensions = new ExtensionList<ExtensionData>("C:\\sets.xml");
            
            gridDestinations.RowTemplate.Height = Util.ColHeight;
            gridDestinations.CellValueChanged += OnCellvalueChanged;


            clmnCheckBox.DataPropertyName = "Checked";
            clmnFileName.DataPropertyName = "FileName";
            clmnExt.DataPropertyName = "Extension";
            clmnSourcePath.DataPropertyName = "FullPath";
            clmnDestPath.DataPropertyName = "DestinationPath";
            gridFiles.DataSource = _sourceFiles;

            clmnID.DataPropertyName = "Id";
            clmnExtension.DataPropertyName = "Extension";
            clmnDestFolder.DataPropertyName = "FullPath";
            gridDestinations.DataSource = _extensions;

            RefreshButtonsCaption();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void MoveSelected()
        {
            foreach (var t in _sourceFiles)
            {
                if (!t.Checked) continue;
                var fInfo = new FileInfo(t.FullPath);
                //fInfo.MoveTo(t.DestinationPath);
                fInfo.CopyTo(t.DestinationPath);
            }
        }
        
        private void btnMove_Click(object sender, EventArgs e)
        {
            MoveSelected();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;

            _sourceFiles.Clear();

            var selectedPathFiles = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
            _sourceFiles.FillListWithFiles(selectedPathFiles);

            _sourceFiles.AddDestinations(_extensions);
        }

        private void gridDestinations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var col = gridDestinations.CurrentCell.OwningColumn;
            var rowIdx = gridDestinations.CurrentRow.Index;

            if (col == clmnBtnPath)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    //_extensions[rowIdx].FullPath = Util.DestinationPath(folderBrowserDialog1.SelectedPath);
                    //gridDestinations.Refresh();

                    gridDestinations.CurrentRow.Cells[gridDestinations.Columns.IndexOf(clmnDestFolder)].Value = Util.DestinationPath(folderBrowserDialog1.SelectedPath);
                }                
            }
            else
                if (col == clmnBtnRemove) 
                {
                    if (!IsLastRow(rowIdx))
                    {
                        if (_extensions[rowIdx].Extension != "default")
                        {
                            _extensions.RemoveAt(rowIdx);
                        }
                        else
                            _extensions[rowIdx].FullPath = "";
                        gridDestinations.Refresh();
                    }
                }
        }

        void OnCellvalueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridDestinations.CurrentRow == null || e.ColumnIndex == clmnBtnRemove.Index) return;
            var rowIdx = gridDestinations.CurrentRow.Index;

            _sourceFiles.AddDestinations(_extensions);

            if (!IsLastRow(rowIdx)) return;

            _extensions.AddElement(Guid.NewGuid().ToString(), "", "");
            RefreshButtonsCaption();
        }

        //close application on ESCAPE
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}


