using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWindowsForms.Presenter
{
    public abstract class BasePresenter<TView> : IPresenter
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IAppCtrl Ctrl { get; private set; }

        protected BasePresenter(IAppCtrl ctrl, TView view)
        {
            Ctrl = ctrl;
            View = view;
        }

        public void Run()
        {
            View.Show();
        }

    }

    public abstract class BasePresenter<TView, TArg> : IPresenter<TArg>
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IAppCtrl Ctrl { get; private set; }

        protected BasePresenter(IAppCtrl ctrl, TView view)
        {
            Ctrl = ctrl;
            View = view;
        }

        public abstract void Run(TArg argument);
    }
}
