/**
    Bilai-PnP-Gui, Desktop stat viewer for Banglalion devices
    Copyright (C) 2016 Md. Minhazul Haque

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 3
    of the License, or (at your option) any later version.
*/

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
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripAboutLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._backworker = new System.ComponentModel.BackgroundWorker();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.Signal = new System.Windows.Forms.PictureBox();
            this.StatusStrip.SuspendLayout();
            this.Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Signal)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel,
            this.ToolStripAboutLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 177);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(764, 30);
            this.StatusStrip.TabIndex = 1;
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(564, 25);
            this.ToolStripStatusLabel.Spring = true;
            this.ToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToolStripAboutLabel
            // 
            this.ToolStripAboutLabel.Name = "ToolStripAboutLabel";
            this.ToolStripAboutLabel.Size = new System.Drawing.Size(185, 25);
            this.ToolStripAboutLabel.Text = "Developed by Minhaz";
            this.ToolStripAboutLabel.Click += new System.EventHandler(this.showAbout);
            // 
            // _backworker
            // 
            this._backworker.WorkerReportsProgress = true;
            this._backworker.WorkerSupportsCancellation = true;
            this._backworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnBackWorkerDoWork);
            this._backworker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnBackWorkerProgressChanged);
            // 
            // Table
            // 
            this.Table.ColumnCount = 3;
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.Table.Controls.Add(this.Signal, 2, 0);
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.Location = new System.Drawing.Point(0, 0);
            this.Table.Name = "Table";
            this.Table.RowCount = 7;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.Table.Size = new System.Drawing.Size(764, 177);
            this.Table.TabIndex = 0;
            // 
            // Signal
            // 
            this.Signal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Signal.Image = global::Bilai_PnP_Gui.Properties.Resources.signal_0;
            this.Signal.Location = new System.Drawing.Point(422, 3);
            this.Signal.Name = "Signal";
            this.Table.SetRowSpan(this.Signal, 7);
            this.Signal.Size = new System.Drawing.Size(339, 171);
            this.Signal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Signal.TabIndex = 0;
            this.Signal.TabStop = false;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 207);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.StatusStrip);
            this.Name = "App";
            this.Text = "Bilai PnP Gui";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.Table.ResumeLayout(false);
            this.Table.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Signal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripAboutLabel;

        public const int LabelUptime = 0;
        public const int LabelBSID = 1;
        public const int LabelFreq = 2;
        public const int LabelCINR = 3;
        public const int LabelRSSI = 4;
        public const int LabelULRate = 5;
        public const int LabelDLRate = 6;
        private System.ComponentModel.BackgroundWorker _backworker;
        private System.Windows.Forms.PictureBox Signal;
        private System.Windows.Forms.TableLayoutPanel Table;
    }
}

