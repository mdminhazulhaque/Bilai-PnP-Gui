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
            this.Signal = new System.Windows.Forms.PictureBox();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Signal)).BeginInit();
            this.Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel,
            this.ToolStripAboutLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 220);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(450, 30);
            this.StatusStrip.TabIndex = 1;
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(250, 25);
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
            // Signal
            // 
            this.Signal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Signal.Image = global::Bilai_PnP_Gui.Properties.Resources.signal_0;
            this.Signal.Location = new System.Drawing.Point(250, 3);
            this.Signal.Name = "Signal";
            this.Table.SetRowSpan(this.Signal, 7);
            this.Signal.Size = new System.Drawing.Size(197, 134);
            this.Signal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Signal.TabIndex = 0;
            this.Signal.TabStop = false;
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
            this.Table.RowCount = 8;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Table.Size = new System.Drawing.Size(450, 220);
            this.Table.TabIndex = 0;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.StatusStrip);
            this.Name = "App";
            this.Text = "Bilai PnP Gui";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Signal)).EndInit();
            this.Table.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
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

