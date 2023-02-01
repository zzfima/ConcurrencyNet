namespace WinFormsDeadlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = WaitAsync();
            t.Wait();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var t = WaitAsync();
            await t;
        }

        async Task WaitAsync()
        {
            var ctx1 = SynchronizationContext.Current;
            await Task.Factory.StartNew(async () =>
            {
                var ctx3 = SynchronizationContext.Current;
                await Task.Delay(TimeSpan.FromSeconds(5));
                var ctx4 = SynchronizationContext.Current;
            });
            var ctx2 = SynchronizationContext.Current;
            var b = ctx1 == ctx2;
        }
    }
}