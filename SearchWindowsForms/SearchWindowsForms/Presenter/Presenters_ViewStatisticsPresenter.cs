using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchWindowsForms.Model;

namespace SearchWindowsForms.Presenter
{
    public class ViewStatisticsPresenter : BasePresenter<IViewStatistics, Data>
    {
        private Data _data;

        public ViewStatisticsPresenter(IAppCtrl ctrl, IViewStatistics view):
            base(ctrl, view)
        {
            View.Save += () => ChangeReport(View.fileName);
        }

        private void ChangeReport(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            if (fileName != string.Empty)
            {
                _data.fileName = fileName;
                View.Close();
            }
        }

        public override void Run(Data argument)
        {
            _data = argument;
            View.Show();
        }
    }    
}
