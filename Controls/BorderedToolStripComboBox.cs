using System;
using System.Windows.Forms;

namespace TimeSands.Controls
{
    public class BorderedToolStripComboBox : ToolStripComboBox
    {
        private object _dataSource;
        private Func<object> _getSelectedItem;
        private bool _refreshing;

        public BorderedToolStripComboBox()
        {
            AutoSize = false;
        }

        public object DataSource
        {
            get { return ComboBox?.DataSource; }
            set
            {
                if (ComboBox != null)
                {
                    ComboBox.DataSource = value;
                }
            }
        }

        public void SetDataSource(object dataSource, string displayMember = null,
            Func<object> getSelectedItem = null)
        {
            if (ComboBox != null)
            {
                _getSelectedItem = getSelectedItem;
                _dataSource = dataSource;
                ComboBox.DisplayMember = displayMember;
                Refresh();
            }
        }

        public void Refresh()
        {
            if (ComboBox != null)
            {
                ComboBox.DataSource = null;
                ComboBox.DataSource = _dataSource;
                if (_getSelectedItem != null)
                {
                    _refreshing = true;
                    SelectedItem = _getSelectedItem();
                    _refreshing = false;
                }
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (!_refreshing)
            {
                base.OnSelectedIndexChanged(e);
            }
        }
    }
}
