using System.Collections.Generic;

namespace Bilai_PnP_Gui
{
    partial class App
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.Signal = new System.Windows.Forms.PictureBox();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripAboutLabel = new System.Windows.Forms.ToolStripStatusLabel();            
            this.StatusStrip.SuspendLayout();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar and About
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ToolStripStatusLabel, this.ToolStripAboutLabel });
            this.ToolStripStatusLabel.Spring = true;
            this.ToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripAboutLabel.Text = "Developed by Minhaz";
            this.ToolStripAboutLabel.Click += new System.EventHandler(this.showAbout);
            // 
            // Table
            // 
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.Location = new System.Drawing.Point(0, 0);
            this.Table.Name = "Table";
            this.Table.RowCount = 8;
            this.Table.ColumnCount = 3;
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.Table.Size = new System.Drawing.Size(300, 200);
            this.Table.TabIndex = 0;
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
                label.Dock = System.Windows.Forms.DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F / labels.Count));
                this.Table.Controls.Add(label, 0, i);
            }
            //
            // Dynamic Lables
            //
            Labels = new List<System.Windows.Forms.Label>();

            for (int i = 0; i < labels.Count; i++)
            {
                var label = new System.Windows.Forms.Label();
                label.Text = "Loading...";
                label.Dock = System.Windows.Forms.DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                label.TabIndex = i + 1;
                
                Labels.Add(label);
                
                this.Table.Controls.Add(label, 1, i);
            }
            //
            // Status Bar
            //
            Signal.Image = Properties.Resources.signal_0;
            Signal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            Signal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.Controls.Add(Signal, 2, 0);
            this.Table.SetRowSpan(Signal, 7);

            // 
            // App
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.StatusStrip);
            this.Text = "Bilai PnP Gui";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.Table.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel Table;
        private List<System.Windows.Forms.Label> Labels;

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripAboutLabel;
        private System.Windows.Forms.PictureBox Signal;

        public const int LabelUptime = 0;
        public const int LabelBSID = 1;
        public const int LabelFreq = 2;
        public const int LabelCINR = 3;
        public const int LabelRSSI = 4;
        public const int LabelULRate = 5;
        public const int LabelDLRate = 6;
    }
}

