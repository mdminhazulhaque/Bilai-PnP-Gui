using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Bilai_PnP_Gui
{
    public partial class App : Form
    {
        private Bilai bilai;

        public App()
        {
            try
            {
                PingReply PingReply = new Ping().Send("192.168.2.1", 1000);
            }
            catch (PingException e)
            {
                MessageBox.Show(
                    "Cannot detect Bilai device at 192.168.2.1.\n"
                    + "Make sure that it is plugged in or accessible\n"
                    + "through the network/router you are using.", "Error", MessageBoxButtons.OK);
                System.Environment.Exit(1);
            }

            InitializeComponent();

            bilai = new Bilai();
            ToolStripStatusLabel.Text = "Device detected. Logging in...";

            Task.Factory.StartNew(() => work());
        }

        private void work()
        {
            while (!bilai.Login())
            {
                System.Threading.Thread.Sleep(2000);
            }

            ToolStripStatusLabel.Text = "Connected";

            while (true)
            {
                bilai.Update();

                this.Invoke((MethodInvoker)delegate
               {
                   Labels[LabelBSID].Text = bilai.BSID;
                   Labels[LabelFreq].Text = bilai.Freq;
                   Labels[LabelCINR].Text = bilai.CINR;
                   Labels[LabelRSSI].Text = bilai.RSSI;
                   Labels[LabelULRate].Text = bilai.ULRate;
                   Labels[LabelDLRate].Text = bilai.DLRate;
                   Labels[LabelUptime].Text = bilai.Uptime;

                   switch (bilai.Signal)
                   {
                       case 5:
                           Signal.Image = Properties.Resources.signal_5;
                           break;
                       case 4:
                           Signal.Image = Properties.Resources.signal_4;
                           break;
                       case 3:
                           Signal.Image = Properties.Resources.signal_3;
                           break;
                       case 2:
                           Signal.Image = Properties.Resources.signal_2;
                           break;
                       case 1:
                           Signal.Image = Properties.Resources.signal_1;
                           break;
                       case 0:
                           Signal.Image = Properties.Resources.signal_0;
                           break;
                   }
               });
                
                System.Threading.Thread.Sleep(2000);
            }
            
        }

        private void showAbout(object sender, System.EventArgs e)
        {
            MessageBox.Show(
                "Developed by\n"+
                "Md. Minhazul Haque\n"+
                "Web: https://minhazulhaque.com\n"+
                "Mail: minhaz@linux.com",
                "About Bilai PnP Gui",
                MessageBoxButtons.OK);
        }
    }
}
