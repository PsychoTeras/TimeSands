using System.Windows.Forms;
using ComponentOwl.BetterListView;

namespace TimeSands.Controls
{
    internal sealed class TaskListView : BetterListView
    {
        private CurrencyManager Bindings
        {
            get { return DataSource != null ? (CurrencyManager)BindingContext[DataSource] : null; }
        }

        public object SelectedItem
        {
            get { return Bindings?.Current; }
        }

        public T GetItem<T>(int idx) where T: class
        {
            return Bindings.List[idx] as T;
        }

        public override void Refresh()
        {
            Bindings?.Refresh();
        }
    }
}
