using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace base_trainer
{
    public partial class Main : Form
    {

        Mem memory = new Mem();
        bool processRuning = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                processRuning = memory.OpenProcess(Def.PROCESS_NAME);
                if (!processRuning)
                {
                    Thread.Sleep(Def.REFRESH_DELAY);
                    return;
                }

                // TODO: Infinity function

                Thread.Sleep(Def.REFRESH_DELAY);
                backgroundWorker.ReportProgress(0);
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (processRuning)
            {
                // TODO: OnChange function
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
}
