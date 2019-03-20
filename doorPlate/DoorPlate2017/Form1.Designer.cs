namespace DoorPlate2017
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.rTB_info = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tB_tablePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_tcount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_dcount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_rows = new System.Windows.Forms.TextBox();
            this.tb_cols = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_qrcount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(287, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "部署超级批量算法";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(596, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "测试专用按钮";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // rTB_info
            // 
            this.rTB_info.Location = new System.Drawing.Point(596, 194);
            this.rTB_info.Name = "rTB_info";
            this.rTB_info.Size = new System.Drawing.Size(192, 186);
            this.rTB_info.TabIndex = 3;
            this.rTB_info.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(702, 400);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "测试二";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(446, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 22);
            this.button2.TabIndex = 5;
            this.button2.Text = "浏览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tB_tablePath
            // 
            this.tB_tablePath.Location = new System.Drawing.Point(82, 27);
            this.tB_tablePath.Name = "tB_tablePath";
            this.tB_tablePath.Size = new System.Drawing.Size(354, 20);
            this.tB_tablePath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "加载表格";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(82, 68);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "添加模版";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "加载模版";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "已加载：";
            // 
            // lb_tcount
            // 
            this.lb_tcount.AutoSize = true;
            this.lb_tcount.Location = new System.Drawing.Point(242, 73);
            this.lb_tcount.Name = "lb_tcount";
            this.lb_tcount.Size = new System.Drawing.Size(13, 13);
            this.lb_tcount.TabIndex = 11;
            this.lb_tcount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(512, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "已加载数据：";
            // 
            // lb_dcount
            // 
            this.lb_dcount.AutoSize = true;
            this.lb_dcount.Location = new System.Drawing.Point(593, 30);
            this.lb_dcount.Name = "lb_dcount";
            this.lb_dcount.Size = new System.Drawing.Size(13, 13);
            this.lb_dcount.TabIndex = 13;
            this.lb_dcount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "每页生成行列数";
            // 
            // tb_rows
            // 
            this.tb_rows.HideSelection = false;
            this.tb_rows.Location = new System.Drawing.Point(158, 109);
            this.tb_rows.Name = "tb_rows";
            this.tb_rows.Size = new System.Drawing.Size(42, 20);
            this.tb_rows.TabIndex = 15;
            this.tb_rows.Text = "4";
            // 
            // tb_cols
            // 
            this.tb_cols.Location = new System.Drawing.Point(231, 109);
            this.tb_cols.Name = "tb_cols";
            this.tb_cols.Size = new System.Drawing.Size(46, 20);
            this.tb_cols.TabIndex = 16;
            this.tb_cols.Text = "4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "行";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(206, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "列";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(630, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "成功加载图片：";
            // 
            // lb_qrcount
            // 
            this.lb_qrcount.AutoSize = true;
            this.lb_qrcount.Location = new System.Drawing.Point(727, 30);
            this.lb_qrcount.Name = "lb_qrcount";
            this.lb_qrcount.Size = new System.Drawing.Size(13, 13);
            this.lb_qrcount.TabIndex = 20;
            this.lb_qrcount.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_qrcount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_cols);
            this.Controls.Add(this.tb_rows);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_dcount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_tcount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tB_tablePath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.rTB_info);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "摸金插件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox rTB_info;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tB_tablePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_tcount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_dcount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_rows;
        private System.Windows.Forms.TextBox tb_cols;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_qrcount;
    }
}