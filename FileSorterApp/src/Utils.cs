using System.Windows.Forms;

namespace Utils
{
    public static class Util
    {
        public static int ColHeight = 18;

        public static DataGridViewRow AddGridRow(DataGridView grid)
        {
            var rowInd = grid.Rows.Add();
            return grid.Rows[rowInd];
        }

        public static string DestinationPath(string value)
        {
            return value.LastIndexOf("\\") == value.Length - 1 ? value : value + "\\";
        }
    }
}
