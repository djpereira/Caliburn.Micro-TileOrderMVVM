namespace TileOrderSample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using Caliburn.Micro;
    using ViewModels;

    public class AppBootstrapper : Bootstrapper<IShell>
    {
        CompositionContainer _container;

        /// <summary>
        /// Sets up the IoC container and performs any other framework configuration
        /// </summary>
        protected override void Configure()
        {

            // Catalog to be populated with assemblies that will be used by Caliburn.Micro to look for views
            var catalog = new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)));

            _container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            // Add specific services
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());

            batch.AddExportedValue(_container);
            batch.AddExportedValue(catalog);

            _container.Compose(batch);
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = _container.GetExportedValues<object>(contract);

            var enumerable = exports as object[] ?? exports.ToArray();
            if (enumerable.Any()) return enumerable.First();

            throw new Exception($"Could not locate any instances of contract {contract}.");
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }
    }
}
