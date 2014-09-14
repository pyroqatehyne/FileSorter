using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils;

namespace FileSorter
{
    public partial class Main : Form
    {
        bool IsLastRow(int idx)
        {
            return gridDestinations.RowCount < idx + 2;
        }

        void RefreshButtonsCaption()
        {
            for (var i = 0; i < gridDestinations.RowCount; i++)
            {
                gridDestinations.Rows[i].Cells[clmnBtnRemove.Index].Value = IsLastRow(i) ? "*" : "x";
            }
        }

        /*void AssignPathByExtension()
        {
            _sourceFiles.AddDestinations(_extensions);
        }*/
    }
}
