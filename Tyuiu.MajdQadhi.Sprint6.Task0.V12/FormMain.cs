using Tyuiu.MajdQadhi.Sprint6.Task0.V12.Lib;

namespace Tyuiu.MajdQadhi.Sprint6.Task0.V12
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            DataService ds = new DataService();
            try
            {
                textBoxResult_RKN.Text = Convert.ToString(ds.Calculate(Convert.ToInt32(textBoxVarX_RKN.Text)));
            }
            catch
            {
                MessageBox.Show("������� �������� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxVarX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != ',') && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("���� 0 �������� ������� ������ ������-24-1 ���� ������ ����������", "�������");
        }
    }
}
