using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;
using Npgsql;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics.IntegralTransforms;

namespace teensy_winform
{
    public partial class Form3 : Form
    {
        public Form3(int axis, int hz, string scale_view, string host, string user, string dbname, string password, string port, int data_amount)
        {
            InitializeComponent();

            // 設定ChartArea
            ChartArea chtArea = new ChartArea("ViewArea");
            chtArea.AxisX.Minimum = 0; //X軸數值從0開始
            try
            {
                int view_scale = Int32.Parse(scale_view);
                if (view_scale < 5000000)
                {
                    view_scale = 5000000;
                }
                chtArea.AxisX.ScaleView.Size = view_scale; //設定視窗範圍內一開始顯示多少點
                chtArea.AxisX.Interval = view_scale / 20;
                chtArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
                chtArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All; //設定scrollbar
                //chtArea.AxisX.Maximum = 5000000;
                chtArea.AxisX.Title = "Hz";
                chtArea.AxisY.Title = "db";
                
                this.Text = "FFT data";

                FFT_value.Series[0]["PointWidth"] = "0.1";
                FFT_value.ChartAreas[0] = chtArea; // chart new 出來時就有內建第一個chartarea
                
                if(axis == 1)
                {
                    X_get_value(hz, data_amount, host, user, dbname, password, port);
                }
                else if(axis == 2)
                {
                    Y_get_value(hz, data_amount, host, user, dbname, password, port);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }

        }


        private void X_get_value(int hz, int data_amount,  string host, string user, string dbname, string password, string port)
        {
            string Host = host;
            string User = user;
            string DBname = dbname;
            string Password = password;
            string Port = port;

            string connString = String.Format("Server={0};User Id={1};Password={2};Database={3};Port={4};KeepAlive=300;Timeout=300;CommandTimeout=300;",
                                               Host, User, Password, DBname, Port);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                ////////////////////// FFT_data display //////////////////////
                using (var reader = conn.BeginTextExport("COPY x_lk_g3001 (head_a) TO STDOUT"))
                {
                    double Hz = 0;
                    if (hz == 1)
                    {
                        Hz = 10000;
                    }
                    else if (hz == 2)
                    {
                        Hz = 20000;
                    }
                    else if (hz == 3)
                    {
                        Hz = 50000;
                    }
                    else if (hz == 4)
                    {
                        Hz = 100000;
                    }
                    else if (hz == 5)
                    {
                        Hz = 200000;
                    }
                    else if (hz == 6)
                    {
                        Hz = 250000;
                    }
                    Complex[] FFT_data = new Complex[data_amount];
                    for (int i = 0; i < data_amount; i++)
                    {
                        try
                        {
                            FFT_data[i] = Int32.Parse(reader.ReadLine());
                        }
                        catch
                        {
                            break;
                        }
                    }
                    Fourier.Forward(FFT_data);
                    for (int i = 0; i < data_amount; i++)
                    {
                        double magnitude = 20 * Math.Log10((Math.Abs(Math.Sqrt(Math.Pow(FFT_data[i].Real, 2) + Math.Pow(FFT_data[i].Imaginary, 2)))));
                        FFT_value.Series[0].Points.AddXY(Hz * i, magnitude);
                    }
                }
            }
        }


        private void Y_get_value(int hz, int data_amount, string host, string user, string dbname, string password, string port)
        {
            string Host = host;
            string User = user;
            string DBname = dbname;
            string Password = password;
            string Port = port;

            string connString = String.Format("Server={0};User Id={1};Password={2};Database={3};Port={4};KeepAlive=300;Timeout=300;CommandTimeout=300;",
                                               Host, User, Password, DBname, Port);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                ////////////////////// FFT_data display //////////////////////
                using (var reader = conn.BeginTextExport("COPY y_lk_g3001 (head_b) TO STDOUT"))
                {
                    double Hz = 0;
                    if (hz == 1)
                    {
                        Hz = 10000;
                    }
                    else if (hz == 2)
                    {
                        Hz = 20000;
                    }
                    else if (hz == 3)
                    {
                        Hz = 50000;
                    }
                    else if (hz == 4)
                    {
                        Hz = 100000;
                    }
                    else if (hz == 5)
                    {
                        Hz = 200000;
                    }
                    else if (hz == 6)
                    {
                        Hz = 250000;
                    }
                    Complex[] FFT_data = new Complex[data_amount];
                    for (int i = 0; i < data_amount; i++)
                    {
                        try
                        {
                            FFT_data[i] = Int32.Parse(reader.ReadLine());
                        }
                        catch
                        {
                            break;
                        }
                    }
                    Fourier.Forward(FFT_data);
                    for (int i = 0; i < data_amount; i++)
                    {
                        double magnitude = 20 * Math.Log10((Math.Abs(Math.Sqrt(Math.Pow(FFT_data[i].Real, 2) + Math.Pow(FFT_data[i].Imaginary, 2)))));
                        FFT_value.Series[0].Points.AddXY(Hz * i, magnitude);
                    }
                }
            }
        }
    }
}


