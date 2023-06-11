namespace teensy_winform
{
    partial class main_form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.X_parity = new System.Windows.Forms.ComboBox();
            this.X_stopbits = new System.Windows.Forms.ComboBox();
            this.X_baud_rate = new System.Windows.Forms.ComboBox();
            this.X_databits = new System.Windows.Forms.ComboBox();
            this.X_com_port = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.X_Teensy_Port = new System.IO.Ports.SerialPort(this.components);
            this.data_collect = new System.Windows.Forms.Button();
            this.groupbox2 = new System.Windows.Forms.GroupBox();
            this.k250hz = new System.Windows.Forms.RadioButton();
            this.k200hz = new System.Windows.Forms.RadioButton();
            this.k100hz = new System.Windows.Forms.RadioButton();
            this.k50hz = new System.Windows.Forms.RadioButton();
            this.k20hz = new System.Windows.Forms.RadioButton();
            this.k10hz = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.dbname = new System.Windows.Forms.TextBox();
            this.host = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.stop_collect = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Y_chart = new System.Windows.Forms.RadioButton();
            this.X_chart = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.data_amount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.view_scale = new System.Windows.Forms.TextBox();
            this.chart_button = new System.Windows.Forms.Button();
            this.FFT_data = new System.Windows.Forms.RadioButton();
            this.displacement_data = new System.Windows.Forms.RadioButton();
            this.ADC_data = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Y_parity = new System.Windows.Forms.ComboBox();
            this.Y_stopbits = new System.Windows.Forms.ComboBox();
            this.Y_baud_rate = new System.Windows.Forms.ComboBox();
            this.Y_databits = new System.Windows.Forms.ComboBox();
            this.Y_com_port = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Y_Teensy_Port = new System.IO.Ports.SerialPort(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.setting_apply = new System.Windows.Forms.CheckBox();
            this.timing_setting = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupbox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.X_parity);
            this.groupBox1.Controls.Add(this.X_stopbits);
            this.groupBox1.Controls.Add(this.X_baud_rate);
            this.groupBox1.Controls.Add(this.X_databits);
            this.groupBox1.Controls.Add(this.X_com_port);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "X-axis Setting";
            // 
            // X_parity
            // 
            this.X_parity.FormattingEnabled = true;
            this.X_parity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.X_parity.Location = new System.Drawing.Point(121, 182);
            this.X_parity.Name = "X_parity";
            this.X_parity.Size = new System.Drawing.Size(121, 23);
            this.X_parity.TabIndex = 9;
            this.X_parity.Text = "None";
            // 
            // X_stopbits
            // 
            this.X_stopbits.FormattingEnabled = true;
            this.X_stopbits.Items.AddRange(new object[] {
            "One",
            "Two",
            "OnePointFive"});
            this.X_stopbits.Location = new System.Drawing.Point(121, 142);
            this.X_stopbits.Name = "X_stopbits";
            this.X_stopbits.Size = new System.Drawing.Size(121, 23);
            this.X_stopbits.TabIndex = 8;
            this.X_stopbits.Text = "One";
            // 
            // X_baud_rate
            // 
            this.X_baud_rate.FormattingEnabled = true;
            this.X_baud_rate.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200",
            "230400",
            "250000"});
            this.X_baud_rate.Location = new System.Drawing.Point(121, 66);
            this.X_baud_rate.Name = "X_baud_rate";
            this.X_baud_rate.Size = new System.Drawing.Size(121, 23);
            this.X_baud_rate.TabIndex = 7;
            this.X_baud_rate.Text = "9600";
            // 
            // X_databits
            // 
            this.X_databits.FormattingEnabled = true;
            this.X_databits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.X_databits.Location = new System.Drawing.Point(121, 103);
            this.X_databits.Name = "X_databits";
            this.X_databits.Size = new System.Drawing.Size(121, 23);
            this.X_databits.TabIndex = 6;
            this.X_databits.Text = "8";
            // 
            // X_com_port
            // 
            this.X_com_port.FormattingEnabled = true;
            this.X_com_port.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.X_com_port.Location = new System.Drawing.Point(121, 28);
            this.X_com_port.Name = "X_com_port";
            this.X_com_port.Size = new System.Drawing.Size(121, 23);
            this.X_com_port.TabIndex = 5;
            this.X_com_port.Text = "COM5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 12F);
            this.label5.Location = new System.Drawing.Point(6, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Parity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F);
            this.label4.Location = new System.Drawing.Point(6, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stop Bits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F);
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data Bits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Com Port";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(27, 482);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(105, 33);
            this.connect.TabIndex = 1;
            this.connect.Text = "connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // disconnect
            // 
            this.disconnect.Enabled = false;
            this.disconnect.Location = new System.Drawing.Point(154, 482);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(105, 33);
            this.disconnect.TabIndex = 2;
            this.disconnect.Text = "disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // X_Teensy_Port
            // 
            this.X_Teensy_Port.DtrEnable = true;
            this.X_Teensy_Port.RtsEnable = true;
            // 
            // data_collect
            // 
            this.data_collect.Enabled = false;
            this.data_collect.Location = new System.Drawing.Point(18, 445);
            this.data_collect.Name = "data_collect";
            this.data_collect.Size = new System.Drawing.Size(110, 33);
            this.data_collect.TabIndex = 3;
            this.data_collect.Text = "START";
            this.data_collect.UseVisualStyleBackColor = true;
            this.data_collect.Click += new System.EventHandler(this.data_collect_Click);
            // 
            // groupbox2
            // 
            this.groupbox2.Controls.Add(this.k250hz);
            this.groupbox2.Controls.Add(this.k200hz);
            this.groupbox2.Controls.Add(this.k100hz);
            this.groupbox2.Controls.Add(this.k50hz);
            this.groupbox2.Controls.Add(this.k20hz);
            this.groupbox2.Controls.Add(this.k10hz);
            this.groupbox2.Controls.Add(this.label13);
            this.groupbox2.Controls.Add(this.password);
            this.groupbox2.Controls.Add(this.user);
            this.groupbox2.Controls.Add(this.port);
            this.groupbox2.Controls.Add(this.dbname);
            this.groupbox2.Controls.Add(this.host);
            this.groupbox2.Controls.Add(this.label11);
            this.groupbox2.Controls.Add(this.label10);
            this.groupbox2.Controls.Add(this.label9);
            this.groupbox2.Controls.Add(this.label8);
            this.groupbox2.Controls.Add(this.label6);
            this.groupbox2.Controls.Add(this.stop_collect);
            this.groupbox2.Controls.Add(this.data_collect);
            this.groupbox2.Location = new System.Drawing.Point(288, 17);
            this.groupbox2.Name = "groupbox2";
            this.groupbox2.Size = new System.Drawing.Size(256, 498);
            this.groupbox2.TabIndex = 4;
            this.groupbox2.TabStop = false;
            this.groupbox2.Text = "Data Collection";
            // 
            // k250hz
            // 
            this.k250hz.AutoSize = true;
            this.k250hz.ForeColor = System.Drawing.Color.Red;
            this.k250hz.Location = new System.Drawing.Point(140, 410);
            this.k250hz.Name = "k250hz";
            this.k250hz.Size = new System.Drawing.Size(75, 19);
            this.k250hz.TabIndex = 20;
            this.k250hz.Text = "250KHz";
            this.k250hz.UseVisualStyleBackColor = true;
            // 
            // k200hz
            // 
            this.k200hz.AutoSize = true;
            this.k200hz.ForeColor = System.Drawing.Color.OliveDrab;
            this.k200hz.Location = new System.Drawing.Point(19, 410);
            this.k200hz.Name = "k200hz";
            this.k200hz.Size = new System.Drawing.Size(75, 19);
            this.k200hz.TabIndex = 19;
            this.k200hz.Text = "200KHz";
            this.k200hz.UseVisualStyleBackColor = true;
            // 
            // k100hz
            // 
            this.k100hz.AutoSize = true;
            this.k100hz.ForeColor = System.Drawing.Color.OliveDrab;
            this.k100hz.Location = new System.Drawing.Point(140, 385);
            this.k100hz.Name = "k100hz";
            this.k100hz.Size = new System.Drawing.Size(75, 19);
            this.k100hz.TabIndex = 18;
            this.k100hz.Text = "100KHz";
            this.k100hz.UseVisualStyleBackColor = true;
            // 
            // k50hz
            // 
            this.k50hz.AutoSize = true;
            this.k50hz.Location = new System.Drawing.Point(18, 385);
            this.k50hz.Name = "k50hz";
            this.k50hz.Size = new System.Drawing.Size(68, 19);
            this.k50hz.TabIndex = 17;
            this.k50hz.Text = "50KHz";
            this.k50hz.UseVisualStyleBackColor = true;
            // 
            // k20hz
            // 
            this.k20hz.AutoSize = true;
            this.k20hz.Location = new System.Drawing.Point(140, 360);
            this.k20hz.Name = "k20hz";
            this.k20hz.Size = new System.Drawing.Size(68, 19);
            this.k20hz.TabIndex = 16;
            this.k20hz.Text = "20KHz";
            this.k20hz.UseVisualStyleBackColor = true;
            // 
            // k10hz
            // 
            this.k10hz.AutoSize = true;
            this.k10hz.Checked = true;
            this.k10hz.Location = new System.Drawing.Point(18, 360);
            this.k10hz.Name = "k10hz";
            this.k10hz.Size = new System.Drawing.Size(68, 19);
            this.k10hz.TabIndex = 15;
            this.k10hz.TabStop = true;
            this.k10hz.Text = "10KHz";
            this.k10hz.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("新細明體", 12F);
            this.label13.Location = new System.Drawing.Point(14, 328);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 20);
            this.label13.TabIndex = 14;
            this.label13.Text = "Sample rate";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(109, 269);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(132, 25);
            this.password.TabIndex = 13;
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(109, 102);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(132, 25);
            this.user.TabIndex = 12;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(109, 212);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(132, 25);
            this.port.TabIndex = 11;
            this.port.Text = "5432";
            // 
            // dbname
            // 
            this.dbname.Location = new System.Drawing.Point(109, 157);
            this.dbname.Name = "dbname";
            this.dbname.Size = new System.Drawing.Size(132, 25);
            this.dbname.TabIndex = 10;
            this.dbname.Text = "IOT_Project_DB112";
            // 
            // host
            // 
            this.host.Location = new System.Drawing.Point(109, 41);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(132, 25);
            this.host.TabIndex = 3;
            this.host.Text = "120.107.167.25";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 12F);
            this.label11.Location = new System.Drawing.Point(15, 271);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "Password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 12F);
            this.label10.Location = new System.Drawing.Point(15, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "Port";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 12F);
            this.label9.Location = new System.Drawing.Point(14, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "DataBase";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 12F);
            this.label8.Location = new System.Drawing.Point(14, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "User";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 12F);
            this.label6.Location = new System.Drawing.Point(14, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Host";
            // 
            // stop_collect
            // 
            this.stop_collect.Enabled = false;
            this.stop_collect.Location = new System.Drawing.Point(140, 445);
            this.stop_collect.Name = "stop_collect";
            this.stop_collect.Size = new System.Drawing.Size(110, 33);
            this.stop_collect.TabIndex = 4;
            this.stop_collect.Text = "STOP";
            this.stop_collect.UseVisualStyleBackColor = true;
            this.stop_collect.Click += new System.EventHandler(this.stop_collect_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.data_amount);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.view_scale);
            this.groupBox3.Controls.Add(this.chart_button);
            this.groupBox3.Location = new System.Drawing.Point(559, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 320);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View Data";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.Y_chart);
            this.groupBox6.Controls.Add(this.X_chart);
            this.groupBox6.Location = new System.Drawing.Point(155, 127);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(147, 128);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            // 
            // Y_chart
            // 
            this.Y_chart.AutoSize = true;
            this.Y_chart.Location = new System.Drawing.Point(8, 58);
            this.Y_chart.Name = "Y_chart";
            this.Y_chart.Size = new System.Drawing.Size(67, 19);
            this.Y_chart.TabIndex = 1;
            this.Y_chart.Text = "Y_axis";
            this.Y_chart.UseVisualStyleBackColor = true;
            // 
            // X_chart
            // 
            this.X_chart.AutoSize = true;
            this.X_chart.Checked = true;
            this.X_chart.Location = new System.Drawing.Point(8, 21);
            this.X_chart.Name = "X_chart";
            this.X_chart.Size = new System.Drawing.Size(65, 19);
            this.X_chart.TabIndex = 0;
            this.X_chart.TabStop = true;
            this.X_chart.Text = "X-axis";
            this.X_chart.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 12F);
            this.label12.Location = new System.Drawing.Point(14, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Amount of Data:";
            // 
            // data_amount
            // 
            this.data_amount.Location = new System.Drawing.Point(165, 89);
            this.data_amount.Name = "data_amount";
            this.data_amount.Size = new System.Drawing.Size(131, 25);
            this.data_amount.TabIndex = 3;
            this.data_amount.Text = "1000000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 12F);
            this.label7.Location = new System.Drawing.Point(14, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "View Scale:";
            // 
            // view_scale
            // 
            this.view_scale.Location = new System.Drawing.Point(165, 40);
            this.view_scale.Name = "view_scale";
            this.view_scale.Size = new System.Drawing.Size(131, 25);
            this.view_scale.TabIndex = 1;
            this.view_scale.Text = "300";
            // 
            // chart_button
            // 
            this.chart_button.Location = new System.Drawing.Point(99, 267);
            this.chart_button.Name = "chart_button";
            this.chart_button.Size = new System.Drawing.Size(110, 34);
            this.chart_button.TabIndex = 0;
            this.chart_button.Text = "chart";
            this.chart_button.UseVisualStyleBackColor = true;
            this.chart_button.Click += new System.EventHandler(this.chart_button_Click);
            // 
            // FFT_data
            // 
            this.FFT_data.AutoSize = true;
            this.FFT_data.Location = new System.Drawing.Point(17, 96);
            this.FFT_data.Name = "FFT_data";
            this.FFT_data.Size = new System.Drawing.Size(53, 19);
            this.FFT_data.TabIndex = 7;
            this.FFT_data.TabStop = true;
            this.FFT_data.Text = "FFT";
            this.FFT_data.UseVisualStyleBackColor = true;
            // 
            // displacement_data
            // 
            this.displacement_data.AutoSize = true;
            this.displacement_data.Location = new System.Drawing.Point(17, 59);
            this.displacement_data.Name = "displacement_data";
            this.displacement_data.Size = new System.Drawing.Size(104, 19);
            this.displacement_data.TabIndex = 6;
            this.displacement_data.Text = "Displacement";
            this.displacement_data.UseVisualStyleBackColor = true;
            // 
            // ADC_data
            // 
            this.ADC_data.AutoSize = true;
            this.ADC_data.Checked = true;
            this.ADC_data.Location = new System.Drawing.Point(17, 21);
            this.ADC_data.Name = "ADC_data";
            this.ADC_data.Size = new System.Drawing.Size(57, 19);
            this.ADC_data.TabIndex = 5;
            this.ADC_data.TabStop = true;
            this.ADC_data.Text = "ADC";
            this.ADC_data.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Y_parity);
            this.groupBox4.Controls.Add(this.Y_stopbits);
            this.groupBox4.Controls.Add(this.Y_baud_rate);
            this.groupBox4.Controls.Add(this.Y_databits);
            this.groupBox4.Controls.Add(this.Y_com_port);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Location = new System.Drawing.Point(17, 243);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 220);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Y-axis Setting";
            // 
            // Y_parity
            // 
            this.Y_parity.FormattingEnabled = true;
            this.Y_parity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.Y_parity.Location = new System.Drawing.Point(121, 182);
            this.Y_parity.Name = "Y_parity";
            this.Y_parity.Size = new System.Drawing.Size(121, 23);
            this.Y_parity.TabIndex = 9;
            this.Y_parity.Text = "None";
            // 
            // Y_stopbits
            // 
            this.Y_stopbits.FormattingEnabled = true;
            this.Y_stopbits.Items.AddRange(new object[] {
            "One",
            "Two",
            "OnePointFive"});
            this.Y_stopbits.Location = new System.Drawing.Point(121, 142);
            this.Y_stopbits.Name = "Y_stopbits";
            this.Y_stopbits.Size = new System.Drawing.Size(121, 23);
            this.Y_stopbits.TabIndex = 8;
            this.Y_stopbits.Text = "One";
            // 
            // Y_baud_rate
            // 
            this.Y_baud_rate.FormattingEnabled = true;
            this.Y_baud_rate.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200",
            "230400",
            "250000"});
            this.Y_baud_rate.Location = new System.Drawing.Point(121, 66);
            this.Y_baud_rate.Name = "Y_baud_rate";
            this.Y_baud_rate.Size = new System.Drawing.Size(121, 23);
            this.Y_baud_rate.TabIndex = 7;
            this.Y_baud_rate.Text = "9600";
            // 
            // Y_databits
            // 
            this.Y_databits.FormattingEnabled = true;
            this.Y_databits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.Y_databits.Location = new System.Drawing.Point(121, 103);
            this.Y_databits.Name = "Y_databits";
            this.Y_databits.Size = new System.Drawing.Size(121, 23);
            this.Y_databits.TabIndex = 6;
            this.Y_databits.Text = "8";
            // 
            // Y_com_port
            // 
            this.Y_com_port.FormattingEnabled = true;
            this.Y_com_port.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.Y_com_port.Location = new System.Drawing.Point(121, 28);
            this.Y_com_port.Name = "Y_com_port";
            this.Y_com_port.Size = new System.Drawing.Size(121, 23);
            this.Y_com_port.TabIndex = 5;
            this.Y_com_port.Text = "COM4";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新細明體", 12F);
            this.label14.Location = new System.Drawing.Point(6, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 20);
            this.label14.TabIndex = 4;
            this.label14.Text = "Parity";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("新細明體", 12F);
            this.label15.Location = new System.Drawing.Point(6, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 20);
            this.label15.TabIndex = 3;
            this.label15.Text = "Stop Bits";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("新細明體", 12F);
            this.label16.Location = new System.Drawing.Point(6, 103);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 2;
            this.label16.Text = "Data Bits";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("新細明體", 12F);
            this.label17.Location = new System.Drawing.Point(6, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 20);
            this.label17.TabIndex = 1;
            this.label17.Text = "Baud Rate";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("新細明體", 12F);
            this.label18.Location = new System.Drawing.Point(6, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "Com Port";
            // 
            // Y_Teensy_Port
            // 
            this.Y_Teensy_Port.DtrEnable = true;
            this.Y_Teensy_Port.RtsEnable = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ADC_data);
            this.groupBox5.Controls.Add(this.FFT_data);
            this.groupBox5.Controls.Add(this.displacement_data);
            this.groupBox5.Location = new System.Drawing.Point(559, 139);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(156, 128);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.setting_apply);
            this.groupBox7.Controls.Add(this.timing_setting);
            this.groupBox7.Location = new System.Drawing.Point(559, 345);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(302, 170);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Timing";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("新細明體", 12F);
            this.label19.Location = new System.Drawing.Point(119, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 20);
            this.label19.TabIndex = 2;
            this.label19.Text = "minute";
            // 
            // setting_apply
            // 
            this.setting_apply.AutoSize = true;
            this.setting_apply.Font = new System.Drawing.Font("新細明體", 12F);
            this.setting_apply.Location = new System.Drawing.Point(13, 99);
            this.setting_apply.Name = "setting_apply";
            this.setting_apply.Size = new System.Drawing.Size(77, 24);
            this.setting_apply.TabIndex = 1;
            this.setting_apply.Text = "Apply";
            this.setting_apply.UseVisualStyleBackColor = true;
            this.setting_apply.CheckedChanged += new System.EventHandler(this.setting_apply_CheckedChanged);
            // 
            // timing_setting
            // 
            this.timing_setting.Location = new System.Drawing.Point(13, 56);
            this.timing_setting.Name = "timing_setting";
            this.timing_setting.Size = new System.Drawing.Size(100, 25);
            this.timing_setting.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(873, 538);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupbox2);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupbox2.ResumeLayout(false);
            this.groupbox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox X_parity;
        private System.Windows.Forms.ComboBox X_stopbits;
        private System.Windows.Forms.ComboBox X_baud_rate;
        private System.Windows.Forms.ComboBox X_databits;
        private System.Windows.Forms.ComboBox X_com_port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort X_Teensy_Port;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button data_collect;
        private System.Windows.Forms.GroupBox groupbox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button stop_collect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button chart_button;
        private System.Windows.Forms.TextBox view_scale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox dbname;
        private System.Windows.Forms.TextBox host;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox data_amount;
        private System.Windows.Forms.RadioButton displacement_data;
        private System.Windows.Forms.RadioButton ADC_data;
        private System.Windows.Forms.RadioButton FFT_data;
        private System.Windows.Forms.RadioButton k10hz;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton k250hz;
        private System.Windows.Forms.RadioButton k200hz;
        private System.Windows.Forms.RadioButton k100hz;
        private System.Windows.Forms.RadioButton k50hz;
        private System.Windows.Forms.RadioButton k20hz;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox Y_parity;
        private System.Windows.Forms.ComboBox Y_stopbits;
        private System.Windows.Forms.ComboBox Y_baud_rate;
        private System.Windows.Forms.ComboBox Y_databits;
        private System.Windows.Forms.ComboBox Y_com_port;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.IO.Ports.SerialPort Y_Teensy_Port;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton Y_chart;
        private System.Windows.Forms.RadioButton X_chart;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox setting_apply;
        private System.Windows.Forms.TextBox timing_setting;
    }
}

