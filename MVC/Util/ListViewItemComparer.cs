using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.MVC.Util
{
    /// <summary>
    /// Compare the ListViewItems.
    /// </summary>
    public class ListViewItemComparer : System.Collections.IComparer
    { 
        private int ColumnNumber;
        private SortOrder SortingOrder;

        /// <summary>
        /// The constructor of ListViewComparer.
        /// </summary>
        /// <param name="ColumnIndex"></param>
        /// <param name="SortOrder"></param>
        public ListViewItemComparer(int ColumnIndex, SortOrder SortOrder)
        {
            this.ColumnNumber = ColumnIndex;
            this.SortingOrder = SortOrder;
        }

        /// <summary>
        /// Compare two ListViewItems.
        /// </summary>
        /// <param name="ObjectX"></param>
        /// <param name="ObjectY"></param>
        /// <returns>Return the correct result depending on whether we're sorting ascending or descending.</returns>
        public int Compare(object ObjectX, object ObjectY)
        {
            int Result;
            /* if (SortingOrder == SortOrder.Ascending)
             {
                 if(float.TryParse(((ListViewItem)ObjectX).SubItems[ColumnNumber].Text, out var X) && float.TryParse(((ListViewItem)ObjectY).SubItems[ColumnNumber].Text, out var Y))
                 {
                     Result = X.CompareTo(Y);
                 }
                 else 
                     Result = String.Compare(((ListViewItem)ObjectX).SubItems[ColumnNumber].Text, ((ListViewItem)ObjectY).SubItems[ColumnNumber].Text);
             }
             else
             {
                 if (float.TryParse(((ListViewItem)ObjectX).SubItems[ColumnNumber].Text, out var X) && float.TryParse(((ListViewItem)ObjectY).SubItems[ColumnNumber].Text, out var Y))
                 {
                     Result = -X.CompareTo(Y);
                 }
                 else
                     Result = -String.Compare(((ListViewItem)ObjectX).SubItems[ColumnNumber].Text, ((ListViewItem)ObjectY).SubItems[ColumnNumber].Text);
             }*/

            string StringX = ((ListViewItem)ObjectX).SubItems[ColumnNumber].Text;
            string StringY = ((ListViewItem)ObjectY).SubItems[ColumnNumber].Text;

            if (ColumnNumber == 5)
            {
                StringX = StringX.Replace(".", ",");
                StringY = StringY.Replace(".", ",");
                Console.WriteLine(StringX);
                float X = float.Parse(StringX);
                float Y = float.Parse(StringY);
                Result = X.CompareTo(Y);
                if (this.SortingOrder == SortOrder.Descending)
                    Result *= -1;
            }
            else if(ColumnNumber == 6)
            {
                int X = int.Parse(StringX);
                int Y = int.Parse(StringY);
                Result = X.CompareTo(Y);
                if (this.SortingOrder == SortOrder.Descending)
                    Result *= -1;
            }
            else
            {
                Result = String.Compare(StringX, StringY);
                if (this.SortingOrder == SortOrder.Descending)
                    Result *= -1;
            }

            return Result;
        }
    }
}
