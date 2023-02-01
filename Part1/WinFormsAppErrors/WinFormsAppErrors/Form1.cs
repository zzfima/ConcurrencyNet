namespace WinFormsAppErrors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var i = await Task1();
            label1.Text = i.ToString();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var t1 = Task1();
            var i = await t1;
            label1.Text = i.ToString();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var t1 = Task2();
            try
            {
                Task.Delay(1000);
                await Task.Delay(1000);
                var i = await t1;
                label1.Text = i.ToString();
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }

        }

        async Task<int> Task1()
        {
            await Task.Delay(1000);
            return 11;
        }

        async Task<int> Task2()
        {
            var t = Task.Factory.StartNew(() =>
            {
                int i = 0;
                int j = 16;

                j /= i;

                i++;
                return j;
            });
            var k = await t;
            return k;
        }
    }
}