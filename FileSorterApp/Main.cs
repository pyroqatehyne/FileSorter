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

        //readonly int _destColId, _destColExt, _destColPth, _destBtnPth, _destBtnDel;
        //readonly int _fileColName, _fileColExt, _fileColPth, _fileColChk, _fileColDest;

        public Main()
        {
            InitializeComponent();

            _sourceFiles = new FileList<FileData>();
            _extensions = new ExtensionList<ExtensionData>("C:\\sets.xml");
            
            /*_fileColName = gridFiles.Columns.IndexOf(clmnFileName);
            _fileColExt = gridFiles.Columns.IndexOf(clmnExt);
            _fileColPth = gridFiles.Columns.IndexOf(clmnSourcePath);
            _fileColChk = gridFiles.Columns.IndexOf(clmnCheckBox);
            _fileColDest = gridFiles.Columns.IndexOf(clmnDestPath);

            _destColId = gridDestinations.Columns.IndexOf(clmnID);
            _destColExt = gridDestinations.Columns.IndexOf(clmnExtension);
            _destColPth = gridDestinations.Columns.IndexOf(clmnDestFolder);
            _destBtnPth = gridDestinations.Columns.IndexOf(clmnBtnPath);
            _destBtnDel = gridDestinations.Columns.IndexOf(clmnBtnRemove);*/

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

        /*private void gridFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              var cell = gridFiles.CurrentCell as DataGridViewCheckBoxCell;

              var i = e.ColumnIndex;

              if (cell == null || cell.Value == null || cell.OwningColumn.Index != _fileColChk) return;
              cell.Value = cell.Value.ToString() == "False" ? "True" : "False";
        }*/

        //close application on ESCAPE
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}


