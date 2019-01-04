using System;
using System.Windows.Forms;

namespace TimeSands.Controls
{
    public class BorderedComboBox : ComboBox
    {
        private object _dataSource;
        private Func<object> _getSelectedItem;
        private bool _refreshing;

        public BorderedComboBox()
        {
            AutoSize = false;
        }

        public void SetDataSource(object dataSource, string displayMember = null,
            Func<object> getSelectedItem = null)
        {
            _getSelectedItem = getSelectedItem;
            _dataSource = dataSource;
            DisplayMember = displayMember;
            Refresh();
        }

        public override void Refresh()
        {
            DataSource = null;
            DataSource = _dataSource;
            if (_getSelectedItem != null)
            {
                _refreshing = true;
                SelectedItem = _getSelectedItem();
                _refreshing = false;
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (!_refreshing)
            {
                base.OnSelectedIndexChanged(e);
            }
        }

        //public BorderedComboBox()
        //{
        //    FlatStyle = FlatStyle.Flat;
        //}

        //protected override void WndProc(ref Message m)
        //{
        //    if (DesignMode || !DrawingHelper.WndProcTextBoxControl(this, m, true))
        //    {
        //        base.WndProc(ref m);
        //    }
        //}
    }
}
