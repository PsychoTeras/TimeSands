using ComponentOwl.BetterListView;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System;

namespace TimeSands.Controls
{
    internal static class BetterListViewGroupExtensions
    {
        public static TaskListViewSource DataSource(this BetterListViewGroup group)
        {
            return group.Tag as TaskListViewSource;
        }

        public static TaskListViewSource DataObject(this BetterListViewGroup group)
        {
            return (TaskListViewSource)(group.Tag as TaskListViewSource)?.DataObject;
        }
    }

    internal class TaskListViewSource
    {
        private Func<object, object> _funcValueMember;
        private Func<object, string> _funcDisplayMember;

        public object DataObject { get; }

        public object ValueMember { get { return _funcValueMember(DataObject); } }

        public string DisplayMember { get { return _funcDisplayMember(DataObject); } }

        public TaskListViewSource(object dataObject, Func<object, object> valueMember,
            Func<object, string> displayMember)
        {
            DataObject = dataObject;
            _funcValueMember = valueMember;
            _funcDisplayMember = displayMember;
        }

        public override string ToString()
        {
            return DisplayMember;
        }
    }

    internal class TaskListViewSource<T> : TaskListViewSource
        where T : class
    {
        public TaskListViewSource(T dataObject, Func<T, string> displayMember, Func<T, object> valueMember) : 
            base(dataObject, (Func<object, string>) displayMember, (Func<object, string>) valueMember)            
        {
        }
    }

    internal sealed class TaskListView : BetterListView
    {
        private ICollection<object> _sourceGroups;
        private ICollection<object> _sourceItems;

        public void BindGroups<T>(IReadOnlyCollection<T> sourceGroups, Func<T, string> displayMember, 
            Func<T, object> valueMember) where T : class
        {
            _sourceGroups = (ICollection<object>) sourceGroups;
            RefreshGroups();
        }

        private void RefreshGroups()
        {
            BeginUpdate();

            HashSet<object> setGroups = _sourceGroups != null
                ? new HashSet<object>(_sourceGroups)
                : new HashSet<object>();

            BetterListViewGroup[] toDelete = Groups.
                Where(g => !setGroups.Contains(g.DataObject())).
                ToArray();

            BetterListViewGroup[] toUpdate = Groups.
                Where(g => setGroups.Contains(g.DataObject())).
                ToArray();
        }

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

        public void Repaint()
        {
            base.Refresh();
        }

        public override void Refresh()
        {
            BeginUpdate();
            Bindings?.Refresh();
            EndUpdate();
        }


    }
}
