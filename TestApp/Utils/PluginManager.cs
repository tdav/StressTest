using Apteka.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TestApp.Utils.Worker;

namespace TestApp.Utils
{
    public class PluginManager
    {
        [ImportMany(typeof(IWorkerJob))]
        private IEnumerable<Lazy<IWorkerJob>> Plgs { get; set; }

        private static readonly Lazy<PluginManager> lazy = new Lazy<PluginManager>(() => new PluginManager());

        private PluginManager() => LoadPlugins();

        public static PluginManager GetInstance() => lazy.Value;

        private void LoadPlugins()
        {
            try
            {
                var catalog = new DirectoryCatalog(@".\", "*.plg.dll");

                var container = new CompositionContainer(catalog);
                var batch = new CompositionBatch();
                batch.AddPart(this);
                container.Compose(batch);
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Interfaces",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "PluginManager.LoadPlugins"
                };
                CLogJson.Write(li);
            }
        }

        public static void Init(int index, WorkerThreadResult workerThreadResult)
        {
                if (lazy.Value != null)
                {
                    var plgs = lazy.Value.Plgs;
                    if (plgs == null) return;

                    foreach (var item in plgs)
                    {
                       item.Value.Init(index, workerThreadResult);
                    }
                }
        }
    }
}
