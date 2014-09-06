namespace 时钟
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lalTime = new System.Windows.Forms.Label();
            this.panDrawTimer = new System.Windows.Forms.Panel();
            this.tmControl = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lalTime
            // 
            this.lalTime.AutoSize = true;
            this.lalTime.Font = new System.Drawing.Font("宋体", 30F);
            this.lalTime.Location = new System.Drawing.Point(15, 13);
            this.lalTime.Name = "lalTime";
            this.lalTime.Size = new System.Drawing.Size(217, 40);
            this.lalTime.TabIndex = 0;
            this.lalTime.Text = "11：11：11";
            // 
            // panDrawTimer
            // 
            this.panDrawTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDrawTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDrawTimer.Location = new System.Drawing.Point(22, 56);
            this.panDrawTimer.Name = "panDrawTimer";
            this.panDrawTimer.Size = new System.Drawing.Size(543, 352);
            this.panDrawTimer.TabIndex = 1;
            this.panDrawTimer.SizeChanged += new System.EventHandler(this.panDrawTimer_SizeChanged);
            // 
            // tmControl
            // 
            this.tmControl.Enabled = true;
            this.tmControl.Interval = 1000;
            this.tmControl.Tick += new System.EventHandler(this.tmControl_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 433);
            this.Controls.Add(this.panDrawTimer);
            this.Controls.Add(this.lalTime);
            this.Name = "FormMain";
            this.Text = "时钟";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lalTime;
        private System.Windows.Forms.Panel panDrawTimer;
        private System.Windows.Forms.Timer tmControl;
    }
}

