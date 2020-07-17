using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading.Tasks;
using T1.plg.Models;
using TestApp.Utils;
using TestApp.Utils.Worker;

namespace T1.plg
{

    [Export(typeof(IWorkerJob))]
    public class LoginUserTest : IWorkerJob
    {

        private RestClient client;
        private string Url = "http://192.168.0.114:25002/";
        private string Path => "api/Users/login";

        private List<LoginRequest> param;

        private readonly int _index;
        private readonly Stopwatch _stopwatch;
        private readonly Stopwatch _localStopwatch;
        private readonly WorkerThreadResult _workerThreadResult;

        public LoginUserTest()
        {
        }

        public LoginUserTest(int index, WorkerThreadResult workerThreadResult)
        {
            _index = index;
            _stopwatch = Stopwatch.StartNew();
            _localStopwatch = new Stopwatch();
            _workerThreadResult = workerThreadResult;

            client = new RestClient(Url);
            param = new List<LoginRequest>
                {
                    new LoginRequest() { Username = "admin", Password = "2010" },
                    new LoginRequest() { Username = "admin", Password = "2010" },

                };
        }

        public WorkerThreadResult GetResults()
        {
            return _workerThreadResult;
        }

        public ValueTask<IWorkerJob> Init(int index, WorkerThreadResult workerThreadResult)
        {
            return new ValueTask<IWorkerJob>(new LoginUserTest(index, workerThreadResult));
        }


        public async ValueTask DoWorkAsync()
        {
            var rnd = new Random();
            var inx = rnd.Next(0, 1);

            _localStopwatch.Restart();


            var response = await client.PostApi<LoginRequest, LoginResponse>(param[inx], Path);
            var responseTime = (float)_localStopwatch.ElapsedTicks / Stopwatch.Frequency * 1000;


            if (response.Status == 0)
            {
                _workerThreadResult.Add((int)_stopwatch.ElapsedMilliseconds / 1000, 1, responseTime, response.Status, _index < 10);
            }
            else
            {
                _workerThreadResult.AddError((int)_stopwatch.ElapsedMilliseconds / 1000, responseTime, response.Status, _index < 10);
            }
        }
    }
}
