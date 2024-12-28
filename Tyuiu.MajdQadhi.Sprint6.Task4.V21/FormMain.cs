using Tyuiu.MajdQadhi.Sprint6.Task4.V21.Lib;

namespace Tyuiu.MajdQadhi.Sprint6.Task4.V21
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

                textBoxResult_RKN.Text = "";

                for (int i = 0; i < len; i++)
                {
                    xData[i] = startStep + i;
                    yData[i] = valueArray[i];
                    textBoxResult_RKN.AppendText(valueArray[i] + Environment.NewLine);
                }

                formsPlotChartResult_RKN.Plot.Clear();

                var scatter = formsPlotChartResult_RKN.Plot.Add.Scatter(xData, yData);

                formsPlotChartResult_RKN.Plot.Title("������ �������");
                formsPlotChartResult_RKN.Plot.XLabel("��� X");
                formsPlotChartResult_RKN.Plot.YLabel("��� Y");

                formsPlotChartResult_RKN.Refresh();
            }

            catch
            {
                MessageBox.Show("������� �������� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string path = $@"{Directory.GetCurrentDirectory()}\OutPutFileTask4V21.txt";
                File.WriteAllText(path, textBoxResult_RKN.Text);

                DialogResult dialogResult = MessageBox.Show("����" + path + "�������� �������!\n������� ��� � ��������?", "���������", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    System.Diagnostics.Process txt = new System.Diagnostics.Process();
                    txt.StartInfo.FileName = "notepad.exe";
                    txt.StartInfo.Arguments = path;
                    txt.Start();
                }
            }
            catch
            {
                MessageBox.Show("���� ��� ���������� �����", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("���� 4 �������� ������� ������ ������-24-1 ���� ������ ����������", "�������");
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
