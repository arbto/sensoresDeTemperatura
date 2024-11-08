using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using System.Diagnostics;
using System.Threading;



namespace graficoDeTemperatura_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void teste()
        {
            Console.WriteLine("teste");
        }

        public void plotarApenasUmGrafico(String nomeDoGrafico, int larguraDoGrafico, int numeroDePontos, decimal[] dadosY, DateTime[] dadosX  )
        {

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            chart1.Series.Add("Temperatura do Forno");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            for (int i = 0; i < numeroDePontos; i++){
                //chart1.Series[0].Points.AddXY(i.ToString(), dadosY[i]);
                //chart1.Series[0].Points.AddXY(dadosX[i].ToString("t"), dadosY[i]); //t minúsculo mostra formato hh:mm
                chart1.Series[0].Points.AddXY(dadosX[i].ToString("T"), dadosY[i]); //T maiúsculo mostra formato hh:mm:ss
            }

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            chart1.Series[0].BorderWidth = larguraDoGrafico;
            chart1.Series[0].Color = System.Drawing.Color.Red;
            //chart1.Series[0].Color = Color.FromArgb(128, 255, 0, 0);
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;

            chart1.Size = new Size(1920 , 1080);





            this.chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            this.chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;

            this.chart1.ChartAreas[0].AxisX.IntervalOffset = 0;
            //this.chart1.ChartAreas[0].AxisX.Maximum = 2000;
            //this.chart1.ChartAreas[0].AxisX.Minimum = 0;

            this.chart1.ChartAreas[0].AxisY.IntervalOffset = 0;
            //this.chart1.ChartAreas[0].AxisY.Maximum = 175;
            //this.chart1.ChartAreas[0].AxisY.Minimum = 18;

            this.chart1.Titles.Add(nomeDoGrafico);

            this.chart1.ChartAreas[0].AxisX.Title = "hora";
            this.chart1.ChartAreas[0].AxisY.Title = "temperatura ºC ";
            this.chart1.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 10; //tamanho dos números nos eixos
            this.chart1.ChartAreas[0].AxisY.LabelAutoFitMaxFontSize = 10; //tamanho dos números nos eixos


            this.chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            this.chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;

            this.chart1.ChartAreas[0].AxisX.MinorGrid.LineWidth = 1; //obs linha espessa pinta o fundo

            this.chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
            this.chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
            //this.chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;  //50
            //this.chart1.ChartAreas[0].AxisY.MinorGrid.Interval = 15;  //15
            this.chart1.ChartAreas[0].AxisX.MinorGrid.Interval = this.chart1.ChartAreas[0].AxisX.Interval / 10;
            this.chart1.ChartAreas[0].AxisY.MinorGrid.Interval = this.chart1.ChartAreas[0].AxisY.Interval / 10;


            //this.chart1.Series[0].
            this.chart1.BackColor = System.Drawing.Color.Gray;
            chart1.Width = this.Width-50;
            chart1.Height = this.Height-80;

            chart1.SaveImage("C:\\Users\\i5\\Documents\\projetosWindowsForms\\graficoDeTemperatura_2\\graficoDeTemperatura_2\\bin\\Debug\\graficoDeTemperatura_2.png", ChartImageFormat.Png);



            //--------------- TRECHO DE CÓDIGO PARA CRIAR UM ARQUIVO .TXT NA PASTA DO PYTHON PARA QUE O PYTHON CRIE O GRAFICO------------
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(@"C:\Users\i5\Documents\projetosPython\projeto_grafico_11\dados11.txt")){
                for(int i=0; i<numeroDePontos; i++){
                    sw.WriteLine(dadosX[i].TimeOfDay.ToString() + "    " + dadosY[i].ToString().Replace(",", ".")); //Troca vírgula por ponto para que não dê erro no python
                }
            }
            //---------------------------------------------------------------------------------------------------------------------------


        }

        public void plotarDoisGraficos(String nomeDoGrafico1, String nomeDoGrafico2, int larguraDoGrafico, int numeroDePontos, 
            decimal[] dadosY1, DateTime[] dadosX1, decimal[] dadosY2, DateTime[] dadosX2)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            chart1.Series.Add(nomeDoGrafico1);
            chart1.Series.Add(nomeDoGrafico2);
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            for (int i = 0; i < numeroDePontos; i++){
                chart1.Series[0].Points.AddXY(dadosX1[i].ToString("T"), dadosY1[i]); //T maiúsculo mostra formato hh:mm:ss
                chart1.Series[1].Points.AddXY(dadosX2[i].ToString("T"), dadosY2[i]); //T maiúsculo mostra formato hh:mm:ss
            }

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            chart1.Series[0].BorderWidth = larguraDoGrafico;
            chart1.Series[0].Color = System.Drawing.Color.Red;
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;

            chart1.Series[1].BorderWidth = larguraDoGrafico;
            chart1.Series[1].Color = System.Drawing.Color.Blue;

            chart1.Size = new Size(1920, 1080);

            this.chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            this.chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            this.chart1.ChartAreas[0].AxisX.IntervalOffset = 0;
            this.chart1.ChartAreas[0].AxisY.IntervalOffset = 0;

            this.chart1.Titles.Add(nomeDoGrafico1 + " e " + nomeDoGrafico2);

            this.chart1.ChartAreas[0].AxisX.Title = "hora";
            this.chart1.ChartAreas[0].AxisY.Title = "temperatura ºC ";
            this.chart1.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 10; //tamanho dos números nos eixos
            this.chart1.ChartAreas[0].AxisY.LabelAutoFitMaxFontSize = 10; //tamanho dos números nos eixos
            this.chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            this.chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            this.chart1.ChartAreas[0].AxisX.MinorGrid.LineWidth = 1; //obs linha espessa pinta o fundo
            this.chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
            this.chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
            this.chart1.ChartAreas[0].AxisX.MinorGrid.Interval = this.chart1.ChartAreas[0].AxisX.Interval / 10;
            this.chart1.ChartAreas[0].AxisY.MinorGrid.Interval = this.chart1.ChartAreas[0].AxisY.Interval / 10;

            this.chart1.BackColor = System.Drawing.Color.Gray;
            chart1.Width = this.Width - 50;
            chart1.Height = this.Height - 80;

        }

        //este método é parte de uma tentativa de fazer o programa em c# executar o programa em python.
        static string CallPython(string inputText)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                FileName = "C:\\Users\\i5\\AppData\\Local\\Programs\\Python\\Python312\\python.exe",
                Arguments = "C:\\Users\\i5\\Documents\\projetosPython\\projeto_grafico_2\\projeto_grafico_2.py --text \"" + inputText + "\\",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }


        private void Form2_Resize(object sender, EventArgs e)
        {

        }

        private void Form2_ResizeEnd(object sender, EventArgs e)
        {

            
        }

        private void Form2_MaximizedBoundsChanged(object sender, EventArgs e)
        {

        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            //se janela foi maximizada ou desmaximizada ( ou o tamanho mudou...) ... ajusta tamanho do grafico.
            this.chart1.Width = this.Width - 50;
            this.chart1.Height = this.Height - 80;
        }
    }
}
