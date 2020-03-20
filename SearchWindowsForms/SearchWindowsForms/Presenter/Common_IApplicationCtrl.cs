﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWindowsForms.Presenter
{
    public interface IAppCtrl
    {
        IAppCtrl RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView;

        IAppCtrl RegisterInstance<TArgument>(TArgument instance);

        IAppCtrl RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        void Run<TPresenter, TArgument>(TArgument argument)
            where TPresenter : class, IPresenter<TArgument>;
    }
}
