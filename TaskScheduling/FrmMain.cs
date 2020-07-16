using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using T1.plg;
using TestApp.Utils;
using TestApp.Utils.Worker;

namespace TestApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            //LoadPlugin();
        }

        //private void LoadPlugin()
        //{
        //    PluginManager.Init(null);
        //}

        private async void EnqueueWorkButton_Click(object sender, EventArgs e)
        {

            CancellationToken cancellationToken = new CancellationToken();

            var worker = new Worker(new LoginUserTest());
            WorkerResult result = await worker.Run("Login", 10, cancellationToken);

            Console.WriteLine(ResultString,
                result.Count,
                result.Elapsed.TotalSeconds,
                result.RequestsPerSecond,
                result.Bandwidth,
                result.Errors,
                result.Median,
                result.StdDev,
                result.Min,
                result.Max,
                GetAsciiHistogram(result));
        }

        private static string GetAsciiHistogram(WorkerResult workerResult)
        {
            if (workerResult.Histogram.Length == 0)
            {
                return string.Empty;
            }

            const string filled = "█";
            const string empty = " ";
            var histogramText = new string[7];
            var max = workerResult.Histogram.Max();

            foreach (var t in workerResult.Histogram)
            {
                for (var j = 0; j < histogramText.Length; j++)
                {
                    histogramText[j] += t > max / histogramText.Length * (histogramText.Length - j - 1) ? filled : empty;
                }
            }

            var text = string.Join("\r\n", histogramText);
            var minText = string.Format("{0:0.000} ms ", workerResult.Min);
            var maxText = string.Format(" {0:0.000} ms", workerResult.Max);
            text += "\r\n" + minText + new string('=', workerResult.Histogram.Length - minText.Length - maxText.Length) + maxText;
            return text;
        }
        private const string ResultString = @"
{0} requests in {1:0.##}s
    Requests/sec:   {2:0}
    Bandwidth:      {3:0} mbit
    Errors:         {4:0}
Latency
    Median:         {5:0.000} ms
    StdDev:         {6:0.000} ms
    Min:            {7:0.000} ms
    Max:            {8:0.000} ms
{9}
";
    }
}
