using ComponentOwl.BetterListView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TimeSands.Controls
{
    internal static class BetterListViewGroupExtensions
    {
        public static void BindDataSource(this BetterListViewGroup group, TaskListViewSourceGroup source)
        {
            group.Tag = source;
            group.Refresh();
        }

        public static TaskListViewSourceGroup DataSource(this BetterListViewGroup group)
        {
            return group.Tag as TaskListViewSourceGroup;
        }

        public static object DataObject(this BetterListViewGroup group)
        {
            return (group.Tag as TaskListViewSourceGroup)?.DataObject;
        }

        public static T DataObject<T>(this BetterListViewGroup group) where T: class
        {
            return group.DataObject() as T;
        }

        public static void Refresh(this BetterListViewGroup group)
        {
            TaskListViewSourceGroup source = group.DataSource();
            group.Header = source?.ToString();
        }
    }

    internal static class BetterListViewItemExtensions
    {
        private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> _itemDataObjectProps = 
            new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        private static Dictionary<string, PropertyInfo> GetDataObjectProps(object dataObject)
        {
            Type dataObjectType = dataObject.GetType();

            if (!_itemDataObjectProps.TryGetValue(dataObjectType, out var props))
            {
                lock (_itemDataObjectProps)
                {
                    PropertyInfo[] objProps = dataObjectType.GetProperties(
                        BindingFlags.Instance | 
                        BindingFlags.FlattenHierarchy | 
                        BindingFlags.Public).
                        Where(p => p.CanRead).
                        ToArray();
                    props = objProps.ToDictionary(p => p.Name, p => p);
                    _itemDataObjectProps.Add(dataObjectType, props);
                }
            }

            return props;
        }

        public static void BindDataSource(this BetterListViewItem item, TaskListViewSourceItem source,
            BetterListView owner)
        {
            item.Tag = source;
            Refresh(item, owner);
            item.Group = source.Group;
        }

        public static TaskListViewSourceItem DataSource(this BetterListViewItem item)
        {
            return item.Tag as TaskListViewSourceItem;
        }

        public static object DataObject(this BetterListViewItem item)
        {
            return (item.Tag as TaskListViewSourceItem)?.DataObject;
        }

        public static T DataObject<T>(this BetterListViewItem item) where T : class
        {
            return item.DataObject() as T;
        }

        public static void Refresh(this BetterListViewItem item)
        {
            Refresh(item, item.ListView);
        }

        private static void Refresh(BetterListViewItem item, BetterListView owner)
        {
            TaskListViewSourceItem source = item.DataSource();
            object dataObject = source.DataObject;

            IEnumerable<BetterListViewColumnHeader> columns = owner.Columns;
            Dictionary<string, PropertyInfo> props = GetDataObjectProps(dataObject);

            int colCount = columns.Count(), subCount = item.SubItems.Count, subDiff = colCount - subCount;
            if (subDiff > 0)
            {
                List<BetterListViewSubItem> subItems = new List<BetterListViewSubItem>(subDiff);
                for (int i = 0; i < subDiff; i++)
                {
                    subItems.Add(new BetterListViewSubItem());
                }
                item.SubItems.AddRange(subItems);
            }

            int idx = -1;
            foreach (BetterListViewColumnHeader column in columns)
            {
                idx++;
                if (column.DisplayMember == string.Empty ||
                    !props.TryGetValue(column.DisplayMember, out var propertyInfo))
                {
                    continue;
                }

                BetterListViewSubItem subItem = item.SubItems[idx];
                string displayText = propertyInfo.GetValue(dataObject)?.ToString();
                if (subItem.Text != displayText)
                {
                    subItem.Text = displayText;
                }

                if (!string.IsNullOrEmpty(column.ValueMember) &&
                    props.TryGetValue(column.ValueMember, out propertyInfo))
                {
                    subItem.Key = (IComparable) propertyInfo.GetValue(dataObject);
                }
            }
        }
    }

    internal class TaskListViewSourceGroup
    {
        private Func<object, object> _funcValueMember;
        private Func<object, string> _funcDisplayMember;

        public object DataObject { get; }

        public object ValueMember { get { return _funcValueMember?.Invoke(DataObject); } }

        public string DisplayMember { get { return _funcDisplayMember?.Invoke(DataObject); } }

        public TaskListViewSourceGroup(object dataObject, Func<object, object> valueMember,
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

    internal class TaskListViewSourceItem
    {
        private Func<object, BetterListViewGroup> _funcItemFindGroup;

        public object DataObject { get; }

        public BetterListViewGroup Group
        {
            get { return _funcItemFindGroup(DataObject); }
        }

        public TaskListViewSourceItem(object dataObject, Func<object, BetterListViewGroup> funcItemFindGroup)
        {
            DataObject = dataObject;
            _funcItemFindGroup = funcItemFindGroup;
        }
    }

    internal sealed class TaskListView : BetterListView
    {
        private IReadOnlyCollection<object> _sourceGroups;
        private Func<object, object> _funcGroupValueMember;
        private Func<object, string> _funcGroupDisplayMember;

        private IReadOnlyCollection<object> _sourceItems;
        private Func<object, BetterListViewGroup> _funcItemFindGroup;

        public new object SelectedValue
        {
            get { return SelectedItems.FirstOrDefault()?.DataObject(); }
        }

        public void BindGroups<T>(IReadOnlyCollection<T> sourceGroups, Func<T, object> valueMember,
            Func<T, string> displayMember) where T : class
        {
            _sourceGroups = sourceGroups;
            _funcGroupValueMember = o => valueMember((T) o);
            _funcGroupDisplayMember = o => displayMember((T) o);

            RebindGroups();
        }

        public void RebindGroups()
        {
            BeginUpdate();

            HashSet<object> setGroups = _sourceGroups != null
                ? new HashSet<object>(_sourceGroups)
                : new HashSet<object>();

            BetterListViewGroup[] toDelete = Groups.
                Where(g => !setGroups.Contains(g.DataObject())).
                ToArray();
            foreach (BetterListViewGroup group in toDelete)
            {
                Groups.Remove(group);
            }

            BetterListViewGroup[] toUpdate = Groups.
                Where(g => setGroups.Contains(g.DataObject())).
                ToArray();
            foreach (BetterListViewGroup group in toUpdate)
            {
                group.Refresh();
            }

            IEnumerable<object> toAdd = setGroups.Except(Groups.Select(g => g.DataObject()));
            List<BetterListViewGroup> groupsToAdd = new List<BetterListViewGroup>();
            foreach (object dataObject in toAdd)
            {
                TaskListViewSourceGroup source = new TaskListViewSourceGroup(dataObject, 
                    _funcGroupValueMember, _funcGroupDisplayMember);
                BetterListViewGroup group = new BetterListViewGroup();
                group.BindDataSource(source);
                groupsToAdd.Add(group);
            }
            Groups.AddRange(groupsToAdd);

            EndUpdate();
        }

        public void BindItems<TI, TG>(IReadOnlyCollection<TI> sourceItems, Func<TI, TG> findGroupObject)
            where TI : class where TG : class
        {
            _sourceItems = sourceItems;
            _funcItemFindGroup = i =>
            {
                TG groupDataObject = findGroupObject((TI) i);
                return Groups.FirstOrDefault(g => g.DataObject() == groupDataObject);
            };

            RebindItems();
        }

        public void RebindItems()
        {
            BeginUpdate();

            HashSet<object> setItems = _sourceItems != null
                ? new HashSet<object>(_sourceItems)
                : new HashSet<object>();

            BetterListViewItem[] toDelete = Items.
                Where(i => !setItems.Contains(i.DataObject())).
                ToArray();
            foreach (BetterListViewItem item in toDelete)
            {
                Items.Remove(item);
            }

            BetterListViewItem[] toUpdate = Items.
                Where(i => setItems.Contains(i.DataObject())).
                ToArray();
            foreach (BetterListViewItem item in toUpdate)
            {
                item.Refresh();
            }

            IEnumerable<object> toAdd = setItems.Except(Items.Select(i => i.DataObject()));
            List<BetterListViewItem> itemsToAdd = new List<BetterListViewItem>();
            foreach (object dataObject in toAdd)
            {
                BetterListViewItem item = new BetterListViewItem();
                TaskListViewSourceItem source = new TaskListViewSourceItem(dataObject, _funcItemFindGroup);
                item.BindDataSource(source, this);
                itemsToAdd.Add(item);
            }
            Items.AddRange(itemsToAdd);

            EndUpdate();
        }

        public void Rebind()
        {
            RebindGroups();
            RebindItems();
        }

        public void RefreshItems()
        {
            BeginUpdate();
            foreach (BetterListViewItem item in Items.ToArray())
            {
                item.Refresh();
            }
            EndUpdate();
        }

        public void RefreshSelectedItem()
        {
            BeginUpdate();
            SelectedItems.FirstOrDefault()?.Refresh();
            EndUpdate();
        }
    }
}
