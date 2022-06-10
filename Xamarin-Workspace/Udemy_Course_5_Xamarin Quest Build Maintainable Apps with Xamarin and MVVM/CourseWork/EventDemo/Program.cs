using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcesBusinessLogic b1 = new ProcesBusinessLogic();

             b1.ProcessCompleted += B1_ProcessCompleted;

            b1.ProcessClosing += B1_ProcessClosing;

            b1.ProcessClosed += B1_ProcessClosed;

            b1.CompletionDetails += B1_CompletionDetails;

            b1.StartProcess();

            Console.ReadLine();
        }

        private static void B1_CompletionDetails(object sender, ProcesBusinessLogic.ProcessEventArgs e)
        {
            Console.WriteLine($"Process has  {(e.IsSuccessful? "Completed":"Failed")} at {e.CompletionTime} " );
        }

        private static void B1_ProcessClosed(object sender, bool e)
        {
            Console.WriteLine("Process " + (e ? "Completed" : "Failed"));
        }

        private static void B1_ProcessClosing(object sender, EventArgs e)
        {
            Console.WriteLine("Process Closing");
        }

        private static void B1_ProcessCompleted1(int one)
        {
            throw new NotImplementedException();
        }

        private static void B1_ProcessCompleted()
        {
            Console.WriteLine("Process Completed");
        }
    }




    public delegate void Notify(); // delegate

    public class ProcesBusinessLogic
    {
        public event Notify ProcessCompleted; // event

        public event EventHandler ProcessClosing;

        public event EventHandler<bool> ProcessClosed;

        public event EventHandler<ProcessEventArgs> CompletionDetails;

        public void StartProcess()
        {
            Console.WriteLine("Process Started");

            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();

            OnProcessClosing(EventArgs.Empty); // No Event Data
        }

        private void OnProcessClosing(EventArgs e)
        {
            var data = new ProcessEventArgs();

            try
            {
                ProcessClosing?.Invoke(this, e);

                data.IsSuccessful = true;

                data.CompletionTime = DateTime.Now;


                //throw new Exception();

                OnProcessClosed(true);

                OnCompletionInfo(data);
            }
            catch (Exception)
            {
                data.IsSuccessful = false;
                data.CompletionTime = DateTime.Now;
                OnProcessClosed(false);

                OnCompletionInfo(data);
            }
           
        }

        protected void OnCompletionInfo(ProcessEventArgs data)
        {
            CompletionDetails?.Invoke(this, data);
        }

        protected void OnProcessClosed(bool v)
        {
            ProcessClosed?.Invoke(this, v);
        }

       public class ProcessEventArgs: EventArgs
        {
            public bool IsSuccessful { get; set; }
            public DateTime CompletionTime { get; set; }
        }
    }
}
