/**
    Bilai-PnP-Gui, Desktop stat viewer for Banglalion devices
    Copyright (C) 2016 Md. Minhazul Haque

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 3
    of the License, or (at your option) any later version.
*/

using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Bilai_PnP_Gui
{
    public partial class App : Form
    {
        private Bilai _bilai;
        private List<System.Windows.Forms.Label> _labels;

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
            InitializeLabels();

            _bilai = new Bilai();
            ToolStripStatusLabel.Text = "Device detected. Logging in...";

            _backworker.RunWorkerAsync();
        }

        private void InitializeLabels()
        {
            //
            // Fixed Labels
            //
            var labels = new List<string> {
                "Uptime", "BSID", "Frequency", "CINR", "RSSI", "DL Rate", "UL Rate"
            };
            
            for (int i = 0; i < labels.Count; i++)
            {
                var label = new System.Windows.Forms.Label();
                label.Text = labels[i];
                //label.Anchor = AnchorStyles.
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F / labels.Count));
                this.Table.Controls.Add(label, 0, i);
            }
            //
            // Dynamic Lables
            //
            _labels = new List<System.Windows.Forms.Label>();

            for (int i = 0; i < labels.Count; i++)
            {
                var label = new System.Windows.Forms.Label();
                label.Text = "...";
                label.Dock = System.Windows.Forms.DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                label.TabIndex = i + 1;

                _labels.Add(label);

                this.Table.Controls.Add(label, 1, i);
            }
        }


        private void OnBackWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Work();
        }


         enum StatusCode : int
        {
            LoginError = 0,
            LoginSuccess,
            ShowInfo,
            UpdateError,
            UpdateSuccess
        }

        private void Work()
        {
            while (true)
            {
                _backworker.ReportProgress((int)StatusCode.ShowInfo, "Attempting to login to server...");
                String errMsg = _bilai.Login();
                StatusCode sc = String.IsNullOrEmpty(errMsg) ? StatusCode.LoginSuccess : StatusCode.LoginError;
                _backworker.ReportProgress((int)sc, errMsg);
                System.Threading.Thread.Sleep(2000);
                if (sc == StatusCode.LoginSuccess)
                {
                    break;
                }
            }

            while (true)
            {
                _backworker.ReportProgress((int)StatusCode.ShowInfo, "Fetching data from server...");
                String errMsg = _bilai.Update();
                StatusCode sc = String.IsNullOrEmpty(errMsg) ? StatusCode.UpdateSuccess : StatusCode.UpdateError;
                _backworker.ReportProgress((int)sc, errMsg);
                System.Threading.Thread.Sleep(2000);
            }
        }


        private void OnBackWorkerProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            StatusCode code = (StatusCode)(e.ProgressPercentage);
            switch (code)
            {
                case StatusCode.ShowInfo:
                    ToolStripStatusLabel.Text =  e.UserState.ToString();
                    break;
                case StatusCode.LoginError:
                    ToolStripStatusLabel.Text = "Login Error: " + e.UserState.ToString();
                    break;
                case StatusCode.LoginSuccess:
                    ToolStripStatusLabel.Text = "Login Success: Connected" ;
                    break;
                case StatusCode.UpdateError:
                    ToolStripStatusLabel.Text = "Update Error: " + e.UserState.ToString();
                    break;
                case StatusCode.UpdateSuccess:
                    UpdateInfo();
                    break;
            }
        }

        private void UpdateInfo()
        {
            _labels[LabelBSID].Text = _bilai.BSID;
            _labels[LabelFreq].Text = _bilai.Freq;
            _labels[LabelCINR].Text = _bilai.CINR;
            _labels[LabelRSSI].Text = _bilai.RSSI;
            _labels[LabelULRate].Text = _bilai.ULRate;
            _labels[LabelDLRate].Text = _bilai.DLRate;
            _labels[LabelUptime].Text = _bilai.Uptime;

            switch (_bilai.Signal)
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
