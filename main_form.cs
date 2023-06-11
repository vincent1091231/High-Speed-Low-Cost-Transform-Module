using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using Npgsql;

namespace teensy_winform
{
    delegate void Buttonchange();
    public partial class main_form : Form
    {

        delegate void exportCallback();
        delegate void Callback(object sender, DoWorkEventArgs e);
        delegate void X_port_callback(object sender, DoWorkEventArgs e);
        delegate void Y_port_callback(object sender, DoWorkEventArgs e);
        public Form1()
        {
            InitializeComponent();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            //X軸設備基礎設定
            X_Teensy_Port.PortName = X_com_port.Text;                                              //選擇com port
            X_Teensy_Port.BaudRate = Convert.ToInt32(X_baud_rate.Text);                            //選擇baud rate
            X_Teensy_Port.DataBits = Convert.ToInt32(X_databits.Text);                            //選擇data bits
            X_Teensy_Port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), X_stopbits.Text);      //選擇stop bits
            X_Teensy_Port.Parity = (Parity)Enum.Parse(typeof(Parity), X_parity.Text);              //選擇parity

            Y_Teensy_Port.PortName = Y_com_port.Text;                                              //選擇com port
            Y_Teensy_Port.BaudRate = Convert.ToInt32(Y_baud_rate.Text);                            //選擇baud rate
            Y_Teensy_Port.DataBits = Convert.ToInt32(Y_databits.Text);                            //選擇data bits
            Y_Teensy_Port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Y_stopbits.Text);      //選擇stop bits
            Y_Teensy_Port.Parity = (Parity)Enum.Parse(typeof(Parity), Y_parity.Text);              //選擇parity

            if (!X_Teensy_Port.IsOpen)
            {
                try
                {
                    X_Teensy_Port.Open();                                //開啟port
                    connect.Enabled = false;
                    disconnect.Enabled = true;
                    data_collect.Enabled = true;
                    
                    MessageBox.Show("X-axis connect successful");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (!Y_Teensy_Port.IsOpen)
            {
                try
                {                             
                    Y_Teensy_Port.Open();                               //開啟port
                    connect.Enabled = false;
                    disconnect.Enabled = true;
                    data_collect.Enabled = true;

                    MessageBox.Show("Y-axis connect successful");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            if (X_Teensy_Port.IsOpen)
            {
                try
                {
                    X_Teensy_Port.Close();           //關閉port

                    MessageBox.Show("X-axis disconnect successful");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (Y_Teensy_Port.IsOpen)
            {
                try
                {
                    Y_Teensy_Port.Close();           //關閉port

                    MessageBox.Show("Y-axis disconnect successful");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            data_collect.Enabled=false;
            stop_collect.Enabled=false;
            connect.Enabled = true;
            disconnect.Enabled = false;
        }

        BackgroundWorker X_bw = new BackgroundWorker();
        BackgroundWorker Y_bw = new BackgroundWorker();
        BackgroundWorker ALL_bw = new BackgroundWorker();

        private void data_collect_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(X_Teensy_Port.IsOpen && !Y_Teensy_Port.IsOpen)
                {
                    X_bw.DoWork += new DoWorkEventHandler(X_export_db);
                    X_bw.WorkerSupportsCancellation = true;
                    X_bw.WorkerReportsProgress = true;
                    X_bw.RunWorkerAsync();
                }
               
            }
            catch { }

            try
            {
                if(Y_Teensy_Port.IsOpen && !X_Teensy_Port.IsOpen)
                {
                    Y_bw.DoWork += new DoWorkEventHandler(Y_export_db);
                    Y_bw.WorkerSupportsCancellation = true;
                    Y_bw.WorkerReportsProgress = true;
                    Y_bw.RunWorkerAsync();
                }
                
            }
            catch { }

            try
            {
                if (Y_Teensy_Port.IsOpen && X_Teensy_Port.IsOpen)
                {
                    X_bw.DoWork += new DoWorkEventHandler(X_export_db);
                    X_bw.WorkerSupportsCancellation = true;
                    X_bw.WorkerReportsProgress = true;
                    Y_bw.DoWork += new DoWorkEventHandler(Y_export_db);
                    Y_bw.WorkerSupportsCancellation = true;
                    Y_bw.WorkerReportsProgress = true;

                    Y_bw.RunWorkerAsync();
                    X_bw.RunWorkerAsync();

                }

            }
            catch { }

            try 
            {
                if(setting_apply.Checked)
                {
                    timer1.Interval = 1000 * 60 * Int16.Parse(timing_setting.Text);
                    timer1.Start();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            data_collect.Enabled = false;
            stop_collect.Enabled = true;
            
            
        }

        private void export_db(object sender, DoWorkEventArgs e)
        {
            string Host = host.Text;
            string User = user.Text;
            string DBname = dbname.Text;
            string Password = password.Text;
            string Port = port.Text;

            X_Teensy_Port.DiscardInBuffer();
            Y_Teensy_Port.DiscardInBuffer();
            
            try
            {
                try
                {
                    if (k10hz.Checked)
                    {
                        X_Teensy_Port.Write("1");
                        Y_Teensy_Port.Write("1");
                    }
                    else if (k20hz.Checked)
                    {
                        X_Teensy_Port.Write("2");
                        Y_Teensy_Port.Write("2");
                    }
                    else if (k50hz.Checked)
                    {
                        X_Teensy_Port.Write("3");
                        Y_Teensy_Port.Write("3");
                    }
                    else if (k100hz.Checked)
                    {
                        X_Teensy_Port.Write("4");
                        Y_Teensy_Port.Write("4");
                    }
                    else if (k200hz.Checked)
                    {
                        X_Teensy_Port.Write("5");
                        Y_Teensy_Port.Write("5");
                    }
                    else if (k250hz.Checked)
                    {
                        X_Teensy_Port.Write("6");
                        Y_Teensy_Port.Write("6");
                    }
                }
                catch { }

               
                

                string connString = String.Format("Server={0};User Id={1};Password={2};Database={3};Port={4}",
                                               Host, User, Password, DBname, Port);

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string X_remain = "";
                    string Y_remain = "";

                    while (true)
                    {
                        string X_existing = X_Teensy_Port.ReadExisting();
                        string Y_existing = Y_Teensy_Port.ReadExisting();

                        X_existing = X_remain + X_existing;
                        X_existing = X_existing.Replace("\r", "");
                        X_existing = X_existing.Replace("\u0000", "");
                        while (X_existing.IndexOf("\n\n") != -1)
                        {
                            X_existing = X_existing.Replace("\n\n", "\n");
                        }

                        int X_last = X_existing.LastIndexOf("\n");

                        try
                        {
                            X_remain = X_existing.Substring(X_last + 1);
                            X_existing = X_existing.Remove(X_last + 1);
                        }
                        catch
                        {
                            X_remain = "";
                        }


                        Y_existing = Y_remain + Y_existing;
                        Y_existing = Y_existing.Replace("\r", "");
                        Y_existing = Y_existing.Replace("\u0000", "");
                        while (Y_existing.IndexOf("\n\n") != -1)
                        {
                            Y_existing = Y_existing.Replace("\n\n", "\n");
                        }

                        int Y_last = Y_existing.LastIndexOf("\n");

                        try
                        {
                            Y_remain = Y_existing.Substring(Y_last);
                            Y_existing = Y_existing.Remove(Y_last);
                        }
                        catch
                        {
                            Y_remain = "";
                        }

                        X_existing = X_existing.TrimStart('\n');
                        Y_existing = Y_existing.TrimStart('\n');

                        string total_data = "";
                        int total_data_size = X_existing.Length + Y_existing.Length;
                        int counter = 0;
                        int X_index = 0;
                        int Y_index = 0;
                        int X_Y_switch = 0;


                        while (counter < total_data_size)
                        {
                            if (X_Y_switch % 2 == 0)
                            {
                                while (true)
                                {
                                    try
                                    {
                                        if (X_existing[X_index] == '\n')
                                        {
                                            total_data += "\t";
                                            X_Y_switch++;
                                            X_index++;
                                            counter++;
                                            break;
                                        }
                                        total_data += X_existing[X_index];
                                        X_index++;
                                        counter++;
                                    }
                                    catch
                                    {
                                        Y_remain = Y_existing.Substring(Y_index) + Y_remain;
                                        counter = total_data_size;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                while (true)
                                {
                                    try
                                    {
                                        if (Y_existing[Y_index] == '\n')
                                        {
                                            total_data += "\n";
                                            X_Y_switch++;
                                            Y_index++;
                                            counter++;
                                            break;
                                        }
                                        total_data += Y_existing[Y_index];
                                        Y_index++;
                                        counter++;
                                    }
                                    catch
                                    {
                                        X_remain = X_existing.Substring(X_index) + X_remain;
                                        counter = total_data_size;
                                        break;
                                    }
                                }
                            }
                        }
                        total_data = total_data.Trim('\n');

                        using (var writer = conn.BeginTextImport("COPY lk_g3001 (head_a, head_b) FROM STDIN"))
                        {
                            writer.Write(total_data); 
                         
                        }
                        if (ALL_bw.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                button_change();
            }
        }

        private void X_export_db(object sender, DoWorkEventArgs e)
        {            
            string Host = host.Text;
            string User = user.Text;
            string DBname = dbname.Text;
            string Password = password.Text;
            string Port = port.Text;

            X_Teensy_Port.DiscardInBuffer(); 

            try
            {          
                string connString = String.Format("Server={0};User Id={1};Password={2};Database={3};Port={4}",
                                               Host, User, Password, DBname, Port);
            
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    if(k10hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 RENAME COLUMN \"interval(μs)\" TO \"interval(ms)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 ALTER COLUMN \"interval(ms)\" SET DEFAULT (nextval('\"x_interval.interval\"'::regclass)::numeric * 0.1::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }

                            X_Teensy_Port.Write("1");
                    }
                    else if (k20hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 RENAME COLUMN \"interval(μs)\" TO \"interval(ms)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 ALTER COLUMN \"interval(ms)\" SET DEFAULT (nextval('\"x_interval.interval\"'::regclass)::numeric * 0.05::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        X_Teensy_Port.Write("2");
                    }
                    else if (k50hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 RENAME COLUMN \"interval(μs)\" TO \"interval(ms)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 ALTER COLUMN \"interval(ms)\" SET DEFAULT (nextval('\"x_interval.interval\"'::regclass)::numeric * 0.02::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        X_Teensy_Port.Write("3");
                    }
                    else if (k100hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 RENAME COLUMN \"interval(ms)\" TO \"interval(μs)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 ALTER COLUMN \"interval(μs)\" SET DEFAULT (nextval('\"x_interval.interval\"'::regclass)::numeric * 10::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        X_Teensy_Port.Write("4");
                    }
                    else if (k200hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 RENAME COLUMN \"interval(ms)\" TO \"interval(μs)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 ALTER COLUMN \"interval(μs)\" SET DEFAULT (nextval('\"x_interval.interval\"'::regclass)::numeric * 5::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        X_Teensy_Port.Write("5");
                    }
                    else if (k250hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 RENAME COLUMN \"interval(ms)\" TO \"interval(μs)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.x_lk_g3001 ALTER COLUMN \"interval(μs)\" SET DEFAULT (nextval('\"x_interval.interval\"'::regclass)::numeric * 4::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        X_Teensy_Port.Write("6");
                    }                  

                    string X_remain = "";

                    while (true)
                    {
                        string X_existing = X_Teensy_Port.ReadExisting();
                        X_existing = X_remain + X_existing;
                        X_existing = X_existing.Replace("\r", "");
                        X_existing = X_existing.Replace("\u0000", "");
                        while (X_existing.IndexOf("\n\n") != -1)
                        {
                            X_existing = X_existing.Replace("\n\n", "\n");
                        }
                        
                        int last = X_existing.LastIndexOf("\n");

                        try
                        {
                            X_remain = X_existing.Substring(last + 1);
                            X_existing = X_existing.Remove(last + 1);
                        }
                        catch 
                        {
                            X_remain = "";
                        }

                        using (var writer = conn.BeginTextImport("COPY lk_g3001 (head_a) FROM STDIN"))
                        {
                            writer.Write(X_existing);
                        }
                        if (X_bw.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                button_change();
            }            
        }

        private void Y_export_db(object sender, DoWorkEventArgs e)
        {
            string Host = host.Text;
            string User = user.Text;
            string DBname = dbname.Text;
            string Password = password.Text;
            string Port = port.Text;

            Y_Teensy_Port.DiscardInBuffer();

            try
            {

                string connString = String.Format("Server={0};User Id={1};Password={2};Database={3};Port={4}",
                                               Host, User, Password, DBname, Port);

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    if (k10hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 RENAME COLUMN \"interval(μs)\" TO \"interval(ms)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 ALTER COLUMN \"interval(ms)\" SET DEFAULT (nextval('\"y_interval.interval\"'::regclass)::numeric * 0.1::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        Y_Teensy_Port.Write("1");
                    }
                    else if (k20hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 RENAME COLUMN \"interval(μs)\" TO \"interval(ms)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 ALTER COLUMN \"interval(ms)\" SET DEFAULT (nextval('\"y_interval.interval\"'::regclass)::numeric * 0.05::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Y_Teensy_Port.Write("2");
                    }
                    else if (k50hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 RENAME COLUMN \"interval(μs)\" TO \"interval(ms)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 ALTER COLUMN \"interval(ms)\" SET DEFAULT (nextval('\"y_interval.interval\"'::regclass)::numeric * 0.02::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Y_Teensy_Port.Write("3");
                    }
                    else if (k100hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 RENAME COLUMN \"interval(ms)\" TO \"interval(μs)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 ALTER COLUMN \"interval(μs)\" SET DEFAULT (nextval('\"y_interval.interval\"'::regclass)::numeric * 10::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Y_Teensy_Port.Write("4");
                    }
                    else if (k200hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 RENAME COLUMN \"interval(ms)\" TO \"interval(μs)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 ALTER COLUMN \"interval(μs)\" SET DEFAULT (nextval('\"y_interval.interval\"'::regclass)::numeric * 5::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Y_Teensy_Port.Write("5");
                    }
                    else if (k250hz.Checked)
                    {
                        try
                        {
                            using (var name_cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 RENAME COLUMN \"interval(ms)\" TO \"interval(μs)\";", conn))
                            {
                                name_cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        using (var cmd = new NpgsqlCommand("ALTER TABLE public.y_lk_g3001 ALTER COLUMN \"interval(μs)\" SET DEFAULT (nextval('\"y_interval.interval\"'::regclass)::numeric * 4::numeric);", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Y_Teensy_Port.Write("6");
                    }

                    string Y_remain = "";

                    while (true)
                    {
                        string Y_existing = Y_Teensy_Port.ReadExisting();
                        Y_existing = Y_remain + Y_existing;
                        Y_existing = Y_existing.Replace("\r", "");
                        Y_existing = Y_existing.Replace("\u0000", "");
                        while (Y_existing.IndexOf("\n\n") != -1)
                        {
                            Y_existing = Y_existing.Replace("\n\n", "\n");
                        }

                        int last = Y_existing.LastIndexOf("\n");

                        try
                        {
                            Y_remain = Y_existing.Substring(last + 1);
                            Y_existing = Y_existing.Remove(last + 1);
                        }
                        catch
                        {
                            Y_remain = "";
                        }

                        using (var writer = conn.BeginTextImport("COPY lk_g3001 (head_b) FROM STDIN"))
                        {
                            writer.Write(Y_existing);
                        }
                        if (Y_bw.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                button_change();
            }
        }


        private void button_change()
        {
            if(this.data_collect.InvokeRequired || this.stop_collect.InvokeRequired)
            {
                Buttonchange buttonchange = new Buttonchange(button_change);
                try
                {
                    this.Invoke(buttonchange);
                }
                catch { }
            }
            else 
            {
                try
                {
                    X_Teensy_Port.Write("7");
                }
                catch { }

                try
                {
                    Y_Teensy_Port.Write("7");
                }
                catch { }


                try
                {
                    X_bw.CancelAsync();
                }
                catch { }
                try
                {
                    Y_bw.CancelAsync();
                }
                catch { }
                data_collect.Enabled = true;
                stop_collect.Enabled = false;
                if(timer1.Enabled)
                {
                    timer1.Stop();
                }
                
            }
            
        }

        private void stop_collect_Click(object sender, EventArgs e)
        {           
            button_change();
        }

        private void chart_button_Click(object sender, EventArgs e)
        {
            int axis;
            if(X_chart.Checked)
            {
                axis = 1;
            }
            else
            {
                axis = 2;
            }

            if (ADC_data.Checked)
            {
                Form2 form2 = new Form2(1, axis, view_scale.Text, host.Text, user.Text, dbname.Text, password.Text, port.Text, Int32.Parse(data_amount.Text));
                try 
                {
                    form2.Show();
                }
                catch { }
            }
            else if(displacement_data.Checked)
            {
                Data_Form data_form = new Data_Form(2, axis, view_scale.Text, host.Text, user.Text, dbname.Text, password.Text, port.Text, Int32.Parse(data_amount.Text));
                try
                {
                    data_form.Show();
                }
                catch { }
            }
            else if (FFT_data.Checked)
            {
                int hz_choose = 0;
                if(k10hz.Checked)
                {
                    hz_choose = 1;
                }
                else if(k20hz.Checked)
                {
                    hz_choose = 2;
                }
                else if (k50hz.Checked)
                {
                    hz_choose = 3;
                }
                else if (k100hz.Checked)
                {
                    hz_choose = 4;
                }
                else if (k200hz.Checked)
                {
                    hz_choose = 5;
                }
                else if (k250hz.Checked)
                {
                    hz_choose = 6;
                }
                FFT_Form fft_form = new FFT_Form(axis, hz_choose, view_scale.Text, host.Text, user.Text, dbname.Text, password.Text, port.Text, Int32.Parse(data_amount.Text));
                try
                {
                    fft_form.Show();
                }
                catch { }
            }


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Host = host.Text;
            Properties.Settings.Default.User = user.Text;
            Properties.Settings.Default.DataBase = dbname.Text;
            Properties.Settings.Default.Port = port.Text;
            Properties.Settings.Default.Password = password.Text;
            Properties.Settings.Default.Save();
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            host.Text = Properties.Settings.Default.Host;
            user.Text = Properties.Settings.Default.User;
            dbname.Text = Properties.Settings.Default.DataBase;
            port.Text = Properties.Settings.Default.Port;
            password.Text = Properties.Settings.Default.Password;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            button_change();           
        }

        private void setting_apply_CheckedChanged(object sender, EventArgs e)
        {
            if(setting_apply.Checked)
            {
                timing_setting.Enabled = false;
            }
            else
            {
                timing_setting.Enabled = true;
            }
        }
    }
}
