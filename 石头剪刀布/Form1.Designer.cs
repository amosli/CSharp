namespace 石头剪刀布
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbPlayer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbComputer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbJudge = new System.Windows.Forms.Label();
            this.btnStone = new System.Windows.Forms.Button();
            this.btnScissors = new System.Windows.Forms.Button();
            this.btnCloth = new System.Windows.Forms.Button();
            this.lbStatistics = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(270, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "玩家：";
            // 
            // lbPlayer
            // 
            this.lbPlayer.AutoSize = true;
            this.lbPlayer.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPlayer.Location = new System.Drawing.Point(342, 63);
            this.lbPlayer.Name = "lbPlayer";
            this.lbPlayer.Size = new System.Drawing.Size(66, 19);
            this.lbPlayer.TabIndex = 1;
            this.lbPlayer.Text = "未开赛";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(552, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "电脑：";
            // 
            // lbComputer
            // 
            this.lbComputer.AutoSize = true;
            this.lbComputer.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbComputer.Location = new System.Drawing.Point(624, 63);
            this.lbComputer.Name = "lbComputer";
            this.lbComputer.Size = new System.Drawing.Size(66, 19);
            this.lbComputer.TabIndex = 3;
            this.lbComputer.Text = "未开赛";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(381, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "裁判：";
            // 
            // lbJudge
            // 
            this.lbJudge.AutoSize = true;
            this.lbJudge.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbJudge.Location = new System.Drawing.Point(453, 187);
            this.lbJudge.Name = "lbJudge";
            this.lbJudge.Size = new System.Drawing.Size(66, 19);
            this.lbJudge.TabIndex = 5;
            this.lbJudge.Text = "未开赛";
            // 
            // btnStone
            // 
            this.btnStone.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStone.Location = new System.Drawing.Point(284, 367);
            this.btnStone.Name = "btnStone";
            this.btnStone.Size = new System.Drawing.Size(83, 36);
            this.btnStone.TabIndex = 6;
            this.btnStone.Text = "石头";
            this.btnStone.UseVisualStyleBackColor = true;
            this.btnStone.Click += new System.EventHandler(this.btnStone_Click);
            // 
            // btnScissors
            // 
            this.btnScissors.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScissors.Location = new System.Drawing.Point(430, 367);
            this.btnScissors.Name = "btnScissors";
            this.btnScissors.Size = new System.Drawing.Size(89, 36);
            this.btnScissors.TabIndex = 7;
            this.btnScissors.Text = "剪刀";
            this.btnScissors.UseVisualStyleBackColor = true;
            this.btnScissors.Click += new System.EventHandler(this.btnScissors_Click);
            // 
            // btnCloth
            // 
            this.btnCloth.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloth.Location = new System.Drawing.Point(570, 367);
            this.btnCloth.Name = "btnCloth";
            this.btnCloth.Size = new System.Drawing.Size(94, 36);
            this.btnCloth.TabIndex = 8;
            this.btnCloth.Text = "布";
            this.btnCloth.UseVisualStyleBackColor = true;
            this.btnCloth.Click += new System.EventHandler(this.btnCloth_Click);
            // 
            // lbStatistics
            // 
            this.lbStatistics.AutoSize = true;
            this.lbStatistics.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStatistics.Location = new System.Drawing.Point(26, 156);
            this.lbStatistics.Name = "lbStatistics";
            this.lbStatistics.Size = new System.Drawing.Size(65, 12);
            this.lbStatistics.TabIndex = 9;
            this.lbStatistics.Text = "统计信息：";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(970, 473);
            this.Controls.Add(this.lbStatistics);
            this.Controls.Add(this.btnCloth);
            this.Controls.Add(this.btnScissors);
            this.Controls.Add(this.btnStone);
            this.Controls.Add(this.lbJudge);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbComputer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbPlayer);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.timer1_Tick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPlayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbComputer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbJudge;
        private System.Windows.Forms.Button btnStone;
        private System.Windows.Forms.Button btnScissors;
        private System.Windows.Forms.Button btnCloth;
        private System.Windows.Forms.Label lbStatistics;
        private System.Windows.Forms.Timer timer1;
    }
}

