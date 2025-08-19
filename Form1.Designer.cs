
namespace MODBUS_teaching
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPLCCode = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbSimulator = new System.Windows.Forms.ComboBox();
            this.cmbRW = new System.Windows.Forms.ComboBox();
            this.txtIP1 = new System.Windows.Forms.TextBox();
            this.txtPort1 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.reg = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnServo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Servo = new System.Windows.Forms.TextBox();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.PR01 = new System.Windows.Forms.TextBox();
            this.btnM2 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textM2 = new System.Windows.Forms.TextBox();
            this.btnSwitch03 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.PR03 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPLCCode
            // 
            this.txtPLCCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPLCCode.Location = new System.Drawing.Point(722, 1);
            this.txtPLCCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPLCCode.Multiline = true;
            this.txtPLCCode.Name = "txtPLCCode";
            this.txtPLCCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPLCCode.Size = new System.Drawing.Size(626, 569);
            this.txtPLCCode.TabIndex = 13;
            this.txtPLCCode.TextChanged += new System.EventHandler(this.txtPLCCode_TextChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel3.Controls.Add(this.button2);
            this.flowLayoutPanel3.Controls.Add(this.button1);
            this.flowLayoutPanel3.Controls.Add(this.reg);
            this.flowLayoutPanel3.Controls.Add(this.button11);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(12, 16);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(704, 116);
            this.flowLayoutPanel3.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "SERVO_MOTOR_PLC";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.cmbSimulator);
            this.flowLayoutPanel6.Controls.Add(this.cmbRW);
            this.flowLayoutPanel6.Controls.Add(this.txtIP1);
            this.flowLayoutPanel6.Controls.Add(this.txtPort1);
            this.flowLayoutPanel6.Controls.Add(this.textBox6);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(673, 42);
            this.flowLayoutPanel6.TabIndex = 21;
            // 
            // cmbSimulator
            // 
            this.cmbSimulator.FormattingEnabled = true;
            this.cmbSimulator.Items.AddRange(new object[] {
            "AS",
            "DVP"});
            this.cmbSimulator.Location = new System.Drawing.Point(3, 2);
            this.cmbSimulator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSimulator.Name = "cmbSimulator";
            this.cmbSimulator.Size = new System.Drawing.Size(108, 23);
            this.cmbSimulator.TabIndex = 10;
            // 
            // cmbRW
            // 
            this.cmbRW.FormattingEnabled = true;
            this.cmbRW.Items.AddRange(new object[] {
            "READ",
            "WRITE"});
            this.cmbRW.Location = new System.Drawing.Point(117, 2);
            this.cmbRW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRW.Name = "cmbRW";
            this.cmbRW.Size = new System.Drawing.Size(108, 23);
            this.cmbRW.TabIndex = 16;
            // 
            // txtIP1
            // 
            this.txtIP1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP1.Location = new System.Drawing.Point(231, 2);
            this.txtIP1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIP1.Name = "txtIP1";
            this.txtIP1.Size = new System.Drawing.Size(137, 30);
            this.txtIP1.TabIndex = 13;
            this.txtIP1.Text = "127.0.0.1";
            // 
            // txtPort1
            // 
            this.txtPort1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort1.Location = new System.Drawing.Point(374, 2);
            this.txtPort1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPort1.Name = "txtPort1";
            this.txtPort1.Size = new System.Drawing.Size(137, 30);
            this.txtPort1.TabIndex = 15;
            this.txtPort1.Text = "10002";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(517, 2);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(137, 30);
            this.textBox6.TabIndex = 17;
            this.textBox6.Text = "10003";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(3, 74);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 36);
            this.button2.TabIndex = 18;
            this.button2.Text = "Connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.PLC_Connect);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(108, 74);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 36);
            this.button1.TabIndex = 17;
            this.button1.Text = "Coils";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.MultiCoil);
            // 
            // reg
            // 
            this.reg.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg.Location = new System.Drawing.Point(213, 74);
            this.reg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reg.Name = "reg";
            this.reg.Size = new System.Drawing.Size(96, 36);
            this.reg.TabIndex = 19;
            this.reg.Text = "Registers";
            this.reg.UseVisualStyleBackColor = true;
            this.reg.Click += new System.EventHandler(this.registers_Info);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(315, 75);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(107, 35);
            this.button11.TabIndex = 26;
            this.button11.Text = "disconnect";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 143);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(338, 374);
            this.flowLayoutPanel2.TabIndex = 24;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 4);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 35);
            this.label9.TabIndex = 0;
            this.label9.Text = "PLC-1";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.btnServo);
            this.flowLayoutPanel5.Controls.Add(this.label5);
            this.flowLayoutPanel5.Controls.Add(this.Servo);
            this.flowLayoutPanel5.Controls.Add(this.btnSwitch);
            this.flowLayoutPanel5.Controls.Add(this.label8);
            this.flowLayoutPanel5.Controls.Add(this.PR01);
            this.flowLayoutPanel5.Controls.Add(this.btnM2);
            this.flowLayoutPanel5.Controls.Add(this.label15);
            this.flowLayoutPanel5.Controls.Add(this.textM2);
            this.flowLayoutPanel5.Controls.Add(this.btnSwitch03);
            this.flowLayoutPanel5.Controls.Add(this.label17);
            this.flowLayoutPanel5.Controls.Add(this.PR03);
            this.flowLayoutPanel5.Controls.Add(this.button8);
            this.flowLayoutPanel5.Controls.Add(this.button10);
            this.flowLayoutPanel5.Controls.Add(this.button9);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 39);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(338, 318);
            this.flowLayoutPanel5.TabIndex = 1;
            // 
            // btnServo
            // 
            this.btnServo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServo.Location = new System.Drawing.Point(4, 4);
            this.btnServo.Margin = new System.Windows.Forms.Padding(4);
            this.btnServo.Name = "btnServo";
            this.btnServo.Size = new System.Drawing.Size(98, 57);
            this.btnServo.TabIndex = 3;
            this.btnServo.Text = "M0 On";
            this.btnServo.UseVisualStyleBackColor = true;
            this.btnServo.Click += new System.EventHandler(this.M0_writecoil);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(110, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "Coil Status";
            // 
            // Servo
            // 
            this.Servo.Location = new System.Drawing.Point(215, 4);
            this.Servo.Margin = new System.Windows.Forms.Padding(4);
            this.Servo.Name = "Servo";
            this.Servo.Size = new System.Drawing.Size(106, 25);
            this.Servo.TabIndex = 16;
            // 
            // btnSwitch
            // 
            this.btnSwitch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch.Location = new System.Drawing.Point(4, 69);
            this.btnSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(101, 54);
            this.btnSwitch.TabIndex = 6;
            this.btnSwitch.Text = "M1 On";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.M1_writecoil);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(113, 65);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 22);
            this.label8.TabIndex = 18;
            this.label8.Text = "Coil Status";
            // 
            // PR01
            // 
            this.PR01.Location = new System.Drawing.Point(218, 69);
            this.PR01.Margin = new System.Windows.Forms.Padding(4);
            this.PR01.Name = "PR01";
            this.PR01.Size = new System.Drawing.Size(106, 25);
            this.PR01.TabIndex = 7;
            // 
            // btnM2
            // 
            this.btnM2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnM2.Location = new System.Drawing.Point(4, 131);
            this.btnM2.Margin = new System.Windows.Forms.Padding(4);
            this.btnM2.Name = "btnM2";
            this.btnM2.Size = new System.Drawing.Size(101, 55);
            this.btnM2.TabIndex = 24;
            this.btnM2.Text = "M2 On";
            this.btnM2.UseVisualStyleBackColor = true;
            this.btnM2.Click += new System.EventHandler(this.M2_writecoil);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(113, 127);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 22);
            this.label15.TabIndex = 25;
            this.label15.Text = "Coil Status";
            // 
            // textM2
            // 
            this.textM2.Location = new System.Drawing.Point(218, 131);
            this.textM2.Margin = new System.Windows.Forms.Padding(4);
            this.textM2.Name = "textM2";
            this.textM2.Size = new System.Drawing.Size(106, 25);
            this.textM2.TabIndex = 26;
            // 
            // btnSwitch03
            // 
            this.btnSwitch03.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch03.Location = new System.Drawing.Point(4, 194);
            this.btnSwitch03.Margin = new System.Windows.Forms.Padding(4);
            this.btnSwitch03.Name = "btnSwitch03";
            this.btnSwitch03.Size = new System.Drawing.Size(101, 58);
            this.btnSwitch03.TabIndex = 29;
            this.btnSwitch03.Text = "M3 On";
            this.btnSwitch03.UseVisualStyleBackColor = true;
            this.btnSwitch03.Click += new System.EventHandler(this.M3_writecoil);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(113, 190);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 22);
            this.label17.TabIndex = 30;
            this.label17.Text = "Coil Status";
            // 
            // PR03
            // 
            this.PR03.Location = new System.Drawing.Point(218, 194);
            this.PR03.Margin = new System.Windows.Forms.Padding(4);
            this.PR03.Name = "PR03";
            this.PR03.Size = new System.Drawing.Size(106, 25);
            this.PR03.TabIndex = 31;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button8.Location = new System.Drawing.Point(3, 259);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(99, 57);
            this.button8.TabIndex = 26;
            this.button8.Text = "M:單筆讀取";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button10.Location = new System.Drawing.Point(108, 259);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(96, 57);
            this.button10.TabIndex = 26;
            this.button10.Text = "D:單筆寫入";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button9.Location = new System.Drawing.Point(210, 259);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(99, 57);
            this.button9.TabIndex = 26;
            this.button9.Text = "D:單筆讀取";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.SynchronizingObject = this;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(353, 143);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(369, 374);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "PLC-2";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.button3);
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Controls.Add(this.textBox1);
            this.flowLayoutPanel4.Controls.Add(this.button4);
            this.flowLayoutPanel4.Controls.Add(this.label4);
            this.flowLayoutPanel4.Controls.Add(this.textBox2);
            this.flowLayoutPanel4.Controls.Add(this.button5);
            this.flowLayoutPanel4.Controls.Add(this.label6);
            this.flowLayoutPanel4.Controls.Add(this.textBox3);
            this.flowLayoutPanel4.Controls.Add(this.button6);
            this.flowLayoutPanel4.Controls.Add(this.label7);
            this.flowLayoutPanel4.Controls.Add(this.textBox4);
            this.flowLayoutPanel4.Controls.Add(this.button7);
            this.flowLayoutPanel4.Controls.Add(this.label10);
            this.flowLayoutPanel4.Controls.Add(this.textBox5);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 38);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(360, 319);
            this.flowLayoutPanel4.TabIndex = 1;
            this.flowLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel4_Paint);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 57);
            this.button3.TabIndex = 0;
            this.button3.Text = "M:多筆寫入";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Coil Status";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(223, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 25);
            this.textBox1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(3, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 57);
            this.button4.TabIndex = 3;
            this.button4.Text = "M:多筆讀取";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(120, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Coil Status";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(223, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(106, 25);
            this.textBox2.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button5.Location = new System.Drawing.Point(3, 129);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(111, 57);
            this.button5.TabIndex = 6;
            this.button5.Text = "Y:多筆讀取";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(120, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 22);
            this.label6.TabIndex = 7;
            this.label6.Text = "Coil Status";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(223, 129);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(106, 25);
            this.textBox3.TabIndex = 8;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button6.Location = new System.Drawing.Point(3, 192);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(111, 57);
            this.button6.TabIndex = 9;
            this.button6.Text = "D:多筆寫入";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(120, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "Coil Status";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(223, 192);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(106, 25);
            this.textBox4.TabIndex = 11;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button7.Location = new System.Drawing.Point(3, 255);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(111, 57);
            this.button7.TabIndex = 12;
            this.button7.Text = "D:多筆讀取";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(120, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 22);
            this.label10.TabIndex = 13;
            this.label10.Text = "Coil Status";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(223, 255);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(106, 25);
            this.textBox5.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 768);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.txtPLCCode);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPLCCode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.ComboBox cmbSimulator;
        private System.Windows.Forms.TextBox txtIP1;
        private System.Windows.Forms.TextBox txtPort1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button reg;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Button btnServo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Servo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PR01;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textM2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox PR03;
        private System.Windows.Forms.ComboBox cmbRW;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.IO.FileSystemWatcher fileSystemWatcher2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.Button btnM2;
        private System.Windows.Forms.Button btnSwitch03;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox textBox6;
    }
}

