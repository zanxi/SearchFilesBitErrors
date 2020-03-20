using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchWindowsForms.Model;
using SearchWindowsForms.Presenter;

namespace SearchWindowsForms
{
    static class Program
    {
        public static readonly ApplicationContext Context
            = new ApplicationContext();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var ctrl = new AppCtrl(
                new LightInjectAdapter()).
            RegisterView<IMainView, SearchFile>().
            RegisterView<IViewStatistics, Report>().            
            RegisterInstance(new ApplicationContext());
            ctrl.Run<MainPresenter, Data>(new Data { fileName = "fileCompare"});
        }
    }
}
