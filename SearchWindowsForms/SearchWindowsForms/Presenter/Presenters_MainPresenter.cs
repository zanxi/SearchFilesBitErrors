using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchWindowsForms.Model;

namespace SearchWindowsForms.Presenter
{
    public class MainPresenter : BasePresenter<IMainView, Data>
    {
        private Data _data;

        public MainPresenter(IAppCtrl ctrl, IMainView view):
            base(ctrl, view)
        {
            View.ViewReportCommand += ViewReportCommand;
        }

        public override void Run(Data argument)
        {
            _data = argument;
            UpdateReport();
            View.Show();
        }

        private void ViewReportCommand()
        {
            Ctrl.Run<ViewStatisticsPresenter, Data>(_data);
            UpdateReport();
        }

        private void UpdateReport()
        {
            if (_data.fileName == null|| _data.fileName == string.Empty)
            {
                View.SetData("Empty");
            };
            View.SetData(_data.fileName);
        }
    }
}
