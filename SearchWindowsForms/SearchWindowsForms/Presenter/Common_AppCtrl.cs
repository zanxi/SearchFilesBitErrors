﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWindowsForms.Presenter
{
    public class AppCtrl : IAppCtrl
    {
        private readonly IContainer _container;

        public AppCtrl(IContainer container)
        {
            _container = container;
            _container.RegisterInstance<IAppCtrl>(this);
        }

        public IAppCtrl RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView
        {
            _container.Register<TView, TImplementation>();
            return this;
        }

        public IAppCtrl RegisterInstance<TInstance>(TInstance instance)
        {
            _container.RegisterInstance(instance);
            return this;
        }

        public IAppCtrl RegisterService<TModel, TImplementation>()
            where TImplementation : class, TModel
        {
            _container.Register<TModel, TImplementation>();
            return this;
        }

        public void Run<TPresenter>() 
            where TPresenter : class, IPresenter
        {
            if (!_container.IsRegistered<TPresenter>())
                _container.Register<TPresenter>();
            var presenter = _container.Resolve<TPresenter>();
            presenter.Run();

        }

        public void Run<TPresenter, TArgument>(TArgument argument)
            where TPresenter : class, IPresenter<TArgument>
        {
            if (!_container.IsRegistered<TPresenter>())
                _container.Register<TPresenter>();
            var presenter = _container.Resolve<TPresenter>();
            presenter.Run(argument);

        }


    }
}
