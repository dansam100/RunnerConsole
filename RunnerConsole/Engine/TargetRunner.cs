using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Runner.Components;
using RunnerConsole;

namespace Runner.Engine
{
    public partial class RunnerControl
    {
        public class TargetRunner
        {
            public ManualResetEvent _doneEvent = null;
            private Collection<Target> targets = null;
            private Collection<Parameter> parameters = null;
            private Process nantrun = null;
            private const string processName = "nant.exe";
            private readonly string nantPath = null;
            
            public TargetRunner(Collection<Target> targets, Collection<Parameter> parameters, TextConsole console, ManualResetEvent doneEvent)
            {
                this._doneEvent = doneEvent;
                this.targets = targets;
                this.parameters = parameters;
                this.nantPath = "";
                nantrun = new Process();
                Console = console;

                //
                //nantrun
                //
                nantrun.OutputDataReceived += new DataReceivedEventHandler(nantrun_OutputDataReceived);
                nantrun.ErrorDataReceived += new DataReceivedEventHandler(nantrun_OutputDataReceived);
            }

            void nantrun_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                Console.WriteLine(e.Data);
            }

            public TargetRunner()
            {
            }

            public bool StartSuccessful { get; set; }
            public TextConsole Console { get; set; }

            // Wrapper method for use with thread pool.
            public void ThreadPoolCallback(Object threadContext, bool timedOut)
            {
                ThreadPoolCallback(threadContext);
            }

            public void ThreadPoolCallback(Object threadContext)
            {
                int threadIndex = (int)threadContext;
                StringBuilder Result = new StringBuilder();

                Result.AppendLine("ThreadContext: " + threadIndex);
                Result.AppendFormat("Param: {0}", BuildParameterArgument());
                Result.AppendFormat("Target: {0}", BuildTargetArgument());
                this.RunBuild();

                //System.Windows.Forms.MessageBox.Show(Result.ToString());
                /*
                    Console.WriteLine("thread {0} started...", threadIndex);
                    _fibOfN = Calculate(_n);
                    Console.WriteLine("thread {0} result calculated...", threadIndex);
                */

                _doneEvent.Set();
            }

            private string BuildTargetArgument()
            {
                string target = string.Empty;
                foreach (Target targ in targets)
                {
                    if (!string.IsNullOrEmpty(targ.Name))
                    {
                        target += string.Format("{0} ", targ.Name);
                    }
                }
                return target;
            }

            private string BuildParameterArgument()
            {
                string parameter = string.Empty;
                foreach (Parameter param in parameters)
                {
                    if (!string.IsNullOrEmpty(param.ParamString))
                    {
                        parameter += string.Format("-D:{0} ", param.ParamString);
                    }
                }
                return parameter;
            }

            public string NantPath
            {
                get
                {
                    if (string.IsNullOrEmpty(nantPath))
                    {
                        return processName;
                    }
                    return Path.Combine(nantPath, processName);
                }
            }


            public void RunBuild()
            {
                Console.Show();
                string fileName = this.NantPath;
                string output = string.Empty;
                string parameter = BuildParameterArgument();
                string target = this.BuildTargetArgument();
                string buildFile = string.Format("-buildfile:{0}", fileName);

                System.IO.StreamReader rStream = null;
                System.IO.StreamWriter wStream = null;

                try
                {
                    nantrun.StartInfo.FileName = this.NantPath;
                    nantrun.StartInfo.RedirectStandardOutput = true;
                    nantrun.StartInfo.UseShellExecute = false;
                    nantrun.StartInfo.ErrorDialog = true;
                    nantrun.StartInfo.CreateNoWindow = true;
                    nantrun.StartInfo.Arguments = string.Format("{0} {1}{2}", buildFile, parameter, target);
                    try
                    {
                        nantrun.Start();

                        //rStream = nantrun.StandardOutput;

                        nantrun.BeginOutputReadLine();
                        //nantrun.BeginErrorReadLine();
                        nantrun.WaitForExit();

                        //nantrun.Close();
                        //output = rStream.ReadToEnd();
                        /*
                          Console.WriteLine(output);
                         */

                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                catch (System.Exception e)
                {
                    //Console.WriteLine("FAILED: {0}" + e);
                }
            }
        }
    }
}
