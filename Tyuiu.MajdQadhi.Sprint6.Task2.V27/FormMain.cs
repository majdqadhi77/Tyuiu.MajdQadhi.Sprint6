using Tyuiu.MajdQadhi.Sprint6.Task2.V27.Lib;

namespace Tyuiu.MajdQadhi.Sprint6.Task2.V27
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();
        private void bettonDone_Click(object sender, EventArgs e)
        {
            try
            {
                int startStep = Convert.ToInt32(textBoxStart_RKN.Text);
                int stopStep = Convert.ToInt32(textBoxStop_RKN.Text);

                int len = ds.GetMassFunction(startStep, stopStep).Length;

                double[] valueArray;
                valueArray = new double[len];

                valueArray = ds.GetMassFunction(startStep, stopStep);

                double[] xData = new double[len];
                double[] yData = new double[len];

                for (int i = 0; i < len; i++)
                {
                    xData[i] = startStep + i;
                    yData[i] = valueArray[i];
                }

                formsPlotChartResult_RKN.Plot.Clear();

                var scatter = formsPlotChartResult_RKN.Plot.Add.Scatter(xData,yData);

                formsPlotChartResult_RKN.Plot.Title("������ �������");
                formsPlotChartResult_RKN.Plot.XLabel("��� X");
                formsPlotChartResult_RKN.Plot.YLabel("��� Y");

                formsPlotChartResult_RKN.Refresh();

                for (int i = 0; i <= len - 1; i++)
                {
                    this.dataGridViewResult_RKN.Rows.Add(Convert.ToString(startStep), Convert.ToString(valueArray[i]));
                    startStep++;
                }
            }

            catch
            {
                MessageBox.Show("������� �������� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("���� 2 �������� ������� ������ ������-24-1 ���� ������ ����������", "�������");
        }
        private void buttonResult_RKN_MouseDown(object sender, MouseEventArgs e)
        {
            buttonResult_RKN.BackColor = Color.Blue;
        }

        private void buttonResult_RKN_MouseEnter(object sender, EventArgs e)
        {
            buttonResult_RKN.BackColor = Color.Red;
        }

        private void buttonResult_RKN_MouseLeave(object sender, EventArgs e)
        {
            buttonResult_RKN.BackColor = Color.Green;
        }
    }
}
