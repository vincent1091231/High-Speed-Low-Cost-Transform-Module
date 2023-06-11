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
    public partial class Form2 : Form
    {
        /******************************************************************
        data_type --> true -- adc data
                  --> false -- displacement data
        scale view --> the points in the chart at the beginning
        host, user, dbname, password, port --> postgresql setting
        data_amount --> max data amount
        *******************************************************************/
        public Form2(int data_type, int axis, string scale_view,string host,string user, string dbname, string password, string port, int data_amount)
        {
            InitializeComponent();

            
            // 設定ChartArea
            ChartArea chtArea = new ChartArea("ViewArea");
            chtArea.AxisX.Minimum = 0; //X軸數值從0開始
            try
            {
                int view_scale = Int32.Parse(scale_view);
                chtArea.AxisX.ScaleView.Size = view_scale; //設定視窗範圍內一開始顯示多少點
                chtArea.AxisX.Interval = view_scale / 15;
                chtArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
                chtArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All; //設定scrollbar
                if(data_type == 1)
                {
                    this.Text = "adc data";
                    chtArea.AxisY.Maximum = 1024;
                }
                else if(data_type == 2)
                {
                    this.Text = "displacement data";
                    chtArea.AxisY.Maximum = 17;
                    chtArea.AxisY.Minimum = -17;
                    chtArea.AxisY.Title = "mm";
                }

                data_value.ChartAreas[0] = chtArea; // chart new 出來時就有內建第一個chartarea
                if(axis ==1)
                {
                    X_get_value(data_type, host, user, dbname, password, port, data_amount);
                }
                else if(axis ==2)
                {
                    Y_get_value(data_type, host, user, dbname, password, port, data_amount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            
        }
        

        private void X_get_value(int data_type, string host, string user, string dbname, string password, string port, int data_amount)
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
                int count = data_amount;

                if (data_type == 1)
                {
                    ////////////////////// ADC_data display //////////////////////
                    using (var reader = conn.BeginTextExport("COPY (SELECT head_a from x_lk_g3001 order by no asc) TO STDOUT"))
                    {                  
                        for (int i = 0; i < count; i++)
                        {
                            int ADC_data;
                            try
                            {
                                ADC_data = int.Parse(reader.ReadLine());
                            }
                            catch
                            {
                                break;
                            }
                            try
                            {
                                data_value.Series[0].Points.AddXY(i + 1, ADC_data);
                            }
                            catch { }
                        }
                    }
                }
                else if (data_type == 2)
                {
                    ////////////////////// displacement_data display //////////////////////
                    using (var reader = conn.BeginTextExport("COPY (SELECT head_a from x_lk_g3001 order by no asc) TO STDOUT"))
                    {

                        
                        for (int i = 0; i < count; i++)
                        {
                            float displacement;
                            try
                            {
                                displacement = float.Parse(reader.ReadLine()) / 1023 * 34 - 17;
                            }
                            catch
                            {
                               break;
                            }
                            try
                            {
                                data_value.Series[0].Points.AddXY(i + 1, displacement);
                            }
                            catch
                            {
                                
                            }                          
                        }                                            
                    }
                }
            }
        }



        private void Y_get_value(int data_type, string host, string user, string dbname, string password, string port, int data_amount)
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
                int count = data_amount;

                if (data_type == 1)
                {
                    ////////////////////// ADC_data display //////////////////////
                    using (var reader = conn.BeginTextExport("COPY (SELECT head_b from y_lk_g3001 order by no asc) TO STDOUT"))
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int ADC_data;
                            try
                            {
                                ADC_data = int.Parse(reader.ReadLine());
                            }
                            catch
                            {
                                break;
                            }
                            try
                            {
                                data_value.Series[0].Points.AddXY(i + 1, ADC_data);
                            }
                            catch { }
                        }
                    }
                }
                else if (data_type == 2)
                {
                    ////////////////////// displacement_data display //////////////////////
                    using (var reader = conn.BeginTextExport("COPY (SELECT head_b from y_lk_g3001 order by no asc) TO STDOUT"))
                    {


                        for (int i = 0; i < count; i++)
                        {
                            float displacement;
                            try
                            {
                                displacement = float.Parse(reader.ReadLine()) / 1023 * 34 - 17;
                            }
                            catch
                            {
                                break;
                            }
                            try
                            {
                                data_value.Series[0].Points.AddXY(i + 1, displacement);
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
        }
    }
}
