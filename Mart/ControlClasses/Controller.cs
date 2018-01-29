using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstTime
{
    public class Controller
    {
        /*public static void d(DataGridViewColumn col)
        {
            DataGridView data = new DataGridView();          
            col.Resizable = DataGridViewTriState.False;
        }*/

        public static void NonSortableDataGridView(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        
        public static void SetImageLayout(DataGridViewColumn colImage)
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img = (DataGridViewImageColumn) colImage;
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        public static void AlignHeaderTextCenter(params DataGridViewColumn[] col)
        {
            foreach (DataGridViewColumn c in col)
            {
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }            
        }

    }
}
