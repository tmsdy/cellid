namespace cSharpBasic
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Threading;
    public class Form1 : Form
    {
        public string basicstring = Application.StartupPath;
        private Button button1;
        private ComboBox comboBox1;
        private IContainer components = null;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NotifyIcon notifyIcon1;
        private StatusStrip statusStrip1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ToolStripMenuItem 显示ToolStripMenuItem;
        private BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem 最小化ToolStripMenuItem;

        public Form1()
        {
            this.InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            //this.textBox1.Text = FileWrite.ReadFile(this.basicstring + @"\1.txt");
            //this.textBox2.Text = FileWrite.ReadFile(this.basicstring + @"\2.txt");
            //this.textBox3.Text = FileWrite.ReadFile(this.basicstring + @"\3.txt");
            //this.textBox4.Text = FileWrite.ReadFile(this.basicstring + @"\4.txt");
           this.toolStripStatusLabel1.Text = "I'm ready!";
            //Process.Start("IEXPLORE.EXE", "http://www.pxkt.com/");  
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string sXmlMessage = this.textBox3.Text.Trim();
        //    string dsmpUrl = this.textBox1.Text.Trim();
        //    if ((sXmlMessage == "") || (dsmpUrl == ""))
        //    {
        //        MessageBox.Show("请输入网址和数据内容!", "sorry"); 
        //    }
        //    else
        //    {
        //        string bm = this.comboBox1.Text.ToString();
        //        string ua = this.textBox4.Text.ToString();
        //        this.textBox2.Text = http_request.backdata(bm, dsmpUrl, sXmlMessage, ua);
        //        //FileWrite.WriteFile(this.textBox1.Text, this.basicstring + @"\1.txt");
        //        //FileWrite.WriteFile(this.textBox2.Text, this.basicstring + @"\2.txt");
        //        //FileWrite.WriteFile(this.textBox3.Text, this.basicstring + @"\3.txt");
        //        //FileWrite.WriteFile(this.textBox4.Text, this.basicstring + @"\4.txt");
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            string dsmpUrl = this.textBox1.Text.Trim();
            string[] str = textBox3.Text.Split('\n');
            string strAllParam = "";
            if ((str[0] == "") || (dsmpUrl == ""))
            {
                MessageBox.Show("请输入网址和数据内容!", "sorry");
            }
            else
            {
                this.toolStripStatusLabel1.Text = "I'm searching";
                string bm = this.comboBox1.Text.ToString();
                string ua = this.textBox4.Text.ToString();
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Replace("\r", string.Empty);
                    //strAllParam = bm + "\r" + dsmpUrl + "\r" + str[i] + "\r" + ua;
                    //this.backgroundWorker1.RunWorkerAsync(strAllParam);

                    this.textBox2.Text += http_request.backdata(bm, dsmpUrl, str[i], ua);
                    
                    this.textBox2.AppendText("\r\n");

                }
                this.toolStripStatusLabel1.Text = "I'm ready!";
                
            }

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string strAllParam = e.Argument.ToString();
            string[] strparam = strAllParam.Split('\r');
            e.Result = http_request.backdata(strparam[0], strparam[1], strparam[2], strparam[3]);



        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.textBox2.Text += e.Result.ToString();
            this.textBox2.AppendText("\r\n");
        }
        void EventSleep(int t)
        {
            int times = t * 1000;
            for (int j = 0; j < times; j += 10)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Minimized)
            {
                base.Hide();
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最小化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(666, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(336, 85);
            this.button1.TabIndex = 0;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(117, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(467, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "http://www.cellid.cn/cidInfo.php";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "提交网址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "返回数据：";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(382, 173);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(700, 362);
            this.textBox2.TabIndex = 4;
            this.textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyUp);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(12, 173);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(353, 362);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "lac=2500&cell_id=ea8c&hex=true";
            this.textBox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "提交数据：";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Tag = "";
            this.notifyIcon1.Text = "速度！";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.最小化ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 70);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.显示ToolStripMenuItem.Text = "显示";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 最小化ToolStripMenuItem
            // 
            this.最小化ToolStripMenuItem.Name = "最小化ToolStripMenuItem";
            this.最小化ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.最小化ToolStripMenuItem.Text = "最小化";
            this.最小化ToolStripMenuItem.Click += new System.EventHandler(this.最小化ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "网页编码：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "utf-8",
            "gb2312"});
            this.comboBox1.Location = new System.Drawing.Point(117, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(117, 113);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(971, 21);
            this.textBox4.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "UserAgent:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1094, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1094, 560);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POST工具";
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.A))
            {
                ((TextBox) sender).SelectAll();
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.A))
            {
                ((TextBox) sender).SelectAll();
            }
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.A))
            {
                ((TextBox) sender).SelectAll();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Show();
        }

        private void 最小化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Hide();
        }


    }
}

