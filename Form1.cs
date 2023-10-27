using System;
using System.Windows.Forms;
using PBL_WindowsForms.Objetos;
using System.Windows.Forms.DataVisualization.Charting;
//https://macoratti.net/12/11/c_chart1.htm ensinando como criar gráficos apartir de uma databse com chart

namespace PBL_WindowsForms

{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            chart.Parent = this;
            //chart.Location = new System.Drawing.Point(10, 150); // Ajuste a localização conforme necessário
            //chart.Size = new System.Drawing.Size(400, 300); // Ajuste o tamanho conforme necessário

            // Adicione séries para o projétil e o meteoro
            Series seriesProjetil = new Series("Projétil");
            Series seriesMeteoro = new Series("Meteoro");
            seriesProjetil.ChartType = SeriesChartType.Line;
            seriesMeteoro.ChartType = SeriesChartType.Line;
            chart.Series.Add(seriesProjetil);
            chart.Series.Add(seriesMeteoro);

        }

        private void buttonCalcular_Click_1(object sender, EventArgs e)
        {
            double velocidadeInicial;
            double anguloDaTrajetoria;

            if (!double.TryParse(textBoxAngulo.Text, out anguloDaTrajetoria) || !double.TryParse(textBoxVelocidade.Text, out velocidadeInicial))
            {
                MessageBox.Show("Valores inválidos. Certifique-se de inserir números válidos.");
                return;
            }

            Projetil projetil = new Projetil(velocidadeInicial, anguloDaTrajetoria);
            Meteoro meteoro = new Meteoro();
            double tempo = meteoro.DistanciaDoCanhao / projetil.Vox;
            meteoro.SetAltura(tempo);
            projetil.SetAltura(tempo);

            if (projetil.Altura < 0)
            {
                labelResultado.Text = "Infelizmente o projétil não foi capaz de atingir o alvo";
            }
            else if (projetil.Altura == meteoro.Altura)
            {
                labelResultado.Text = $"O projétil atingiu o alvo no ponto x:{meteoro.DistanciaDoCanhao} y:{meteoro.Altura}.\n" +
                    $"O alvo foi acertado no instante {tempo}";
                if (projetil.AlturaMaximaProjetil > projetil.Altura)
                {
                    labelResultado.Text += "\nO alvo foi acertado na trajetória descendente";
                }
                else
                {
                    labelResultado.Text += "\nO alvo foi acertado na trajetória ascendente";
                }
            }
            else
            {
                labelResultado.Text = "Infelizmente o projétil não foi capaz de atingir o alvo";
            }

            /*for (double tempoInicial = 0; tempoInicial <= tempo; tempoInicial += 1)
            {
                meteoro.SetAltura(tempo);
                projetil.SetAltura(tempo);

                chart.Series["Projétil"].Points.AddXY(tempo, projetil.Altura);
                chart.Series["Meteoro"].Points.AddXY(tempo, meteoro.Altura);
            }*/

            chart.Series["Projétil"].Points.AddXY(2, 3);
            chart.Series["Projétil"].Points.AddXY(4, 5);
            chart.Series["Projétil"].Points.AddXY(6, 9);

            chart.Series["Meteoro"].Points.AddXY(10, 12);
            chart.Series["Meteoro"].Points.AddXY(11, 13);



        }
    }
}
