using System.Windows.Forms;

namespace ObjMonitor
{
    class DoubleBufferedListView : ListView
    {
        int scrollIdx = 0;
        public DoubleBufferedListView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14) base.OnNotifyMessage(m);
        }

        public new void BeginUpdate()
        {
            if (TopItem != null)
            {
                scrollIdx = TopItem.Index;
            }
            base.BeginUpdate();
        }

        public new void EndUpdate()
        {
            if(Items.Count > scrollIdx)
            {
                TopItem = Items[scrollIdx];
            }
            base.EndUpdate();
        }
    }
}