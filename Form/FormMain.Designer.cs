namespace SerialPortDebugger
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            toolStrip1 = new ToolStrip();
            tsBtnTopMost = new ToolStripButton();
            tslblPortSelect = new ToolStripLabel();
            tscmbxPortSelect = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            tslblBaudrateInput = new ToolStripLabel();
            tscmbxBaudrateInput = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            tslblDataBitsSelect = new ToolStripLabel();
            tscmbxDataBitsSelect = new ToolStripComboBox();
            toolStripSeparator3 = new ToolStripSeparator();
            tslblStopbitSelect = new ToolStripLabel();
            tscmbxStopBitSelect = new ToolStripComboBox();
            toolStripSeparator4 = new ToolStripSeparator();
            tslblParitySelect = new ToolStripLabel();
            tscmbxParitySelect = new ToolStripComboBox();
            tsbtnStart = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsBtnTopMost, tslblPortSelect, tscmbxPortSelect, toolStripSeparator1, tslblBaudrateInput, tscmbxBaudrateInput, toolStripSeparator2, tslblDataBitsSelect, tscmbxDataBitsSelect, toolStripSeparator3, tslblStopbitSelect, tscmbxStopBitSelect, toolStripSeparator4, tslblParitySelect, tscmbxParitySelect, tsbtnStart });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(984, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnTopMost
            // 
            tsBtnTopMost.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsBtnTopMost.Image = (Image)resources.GetObject("tsBtnTopMost.Image");
            tsBtnTopMost.ImageTransparentColor = Color.Magenta;
            tsBtnTopMost.Name = "tsBtnTopMost";
            tsBtnTopMost.Size = new Size(23, 22);
            tsBtnTopMost.Text = "↑";
            tsBtnTopMost.Click += tsBtnTopMost_Click;
            // 
            // tslblPortSelect
            // 
            tslblPortSelect.Name = "tslblPortSelect";
            tslblPortSelect.Size = new Size(32, 22);
            tslblPortSelect.Text = "端口";
            // 
            // tscmbxPortSelect
            // 
            tscmbxPortSelect.Name = "tscmbxPortSelect";
            tscmbxPortSelect.Size = new Size(200, 25);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // tslblBaudrateInput
            // 
            tslblBaudrateInput.Name = "tslblBaudrateInput";
            tslblBaudrateInput.Size = new Size(44, 22);
            tslblBaudrateInput.Text = "波特率";
            // 
            // tscmbxBaudrateInput
            // 
            tscmbxBaudrateInput.Name = "tscmbxBaudrateInput";
            tscmbxBaudrateInput.Size = new Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // tslblDataBitsSelect
            // 
            tslblDataBitsSelect.Name = "tslblDataBitsSelect";
            tslblDataBitsSelect.Size = new Size(44, 22);
            tslblDataBitsSelect.Text = "数据位";
            // 
            // tscmbxDataBitsSelect
            // 
            tscmbxDataBitsSelect.Name = "tscmbxDataBitsSelect";
            tscmbxDataBitsSelect.Size = new Size(100, 25);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // tslblStopbitSelect
            // 
            tslblStopbitSelect.Name = "tslblStopbitSelect";
            tslblStopbitSelect.Size = new Size(44, 22);
            tslblStopbitSelect.Text = "停止位";
            // 
            // tscmbxStopBitSelect
            // 
            tscmbxStopBitSelect.Name = "tscmbxStopBitSelect";
            tscmbxStopBitSelect.Size = new Size(100, 25);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // tslblParitySelect
            // 
            tslblParitySelect.Name = "tslblParitySelect";
            tslblParitySelect.Size = new Size(44, 22);
            tslblParitySelect.Text = "校验位";
            // 
            // tscmbxParitySelect
            // 
            tscmbxParitySelect.Name = "tscmbxParitySelect";
            tscmbxParitySelect.Size = new Size(121, 25);
            // 
            // tsbtnStart
            // 
            tsbtnStart.Alignment = ToolStripItemAlignment.Right;
            tsbtnStart.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbtnStart.Image = (Image)resources.GetObject("tsbtnStart.Image");
            tsbtnStart.ImageTransparentColor = Color.Magenta;
            tsbtnStart.Name = "tsbtnStart";
            tsbtnStart.Size = new Size(60, 22);
            tsbtnStart.Text = "开始连接";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(toolStrip1);
            Font = new Font("黑体", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "串口调试助手V1.0.0";
            Load += FormMain_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel tslblPortSelect;
        private ToolStripComboBox tscmbxPortSelect;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel tslblBaudrateInput;
        private ToolStripComboBox tscmbxBaudrateInput;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel tslblDataBitsSelect;
        private ToolStripComboBox tscmbxDataBitsSelect;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel tslblStopbitSelect;
        private ToolStripComboBox tscmbxStopBitSelect;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripLabel tslblParitySelect;
        private ToolStripComboBox tscmbxParitySelect;
        private ToolStripButton tsBtnTopMost;
        private ToolStripButton tsbtnStart;
    }
}
