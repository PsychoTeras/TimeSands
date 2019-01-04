using System.Windows.Forms;
using ComponentOwl.BetterListView;

namespace TimeSands.Controls
{
    internal sealed class TaskListView : BetterListView
    {
        public override void Refresh()
        {
            if (DataSource != null)
            {
                ((CurrencyManager) BindingContext[DataSource]).Refresh();
            }
        }
    }
}
