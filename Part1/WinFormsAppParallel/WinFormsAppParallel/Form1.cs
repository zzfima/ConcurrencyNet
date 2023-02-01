using System.Diagnostics;
using System.Windows.Forms.VisualStyles;

namespace WinFormsAppParallel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("******");
            Parallel.For(0, 5, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, Work);
            label1.Text = DateTime.Now.Second.ToString();
        }

        void Work(int i)
        {
            Thread.Sleep(TimeSpan.FromSeconds(i * 2));
            Debug.WriteLine($"{i}, {Thread.CurrentThread.ManagedThreadId}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Parallel.Invoke(
                () => Work(1),
                () => Work(4),
                () => Work(6),
                () => Work(6),
                () => Work(6),
                () => Work(6));
        }
    }
}