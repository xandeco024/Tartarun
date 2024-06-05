namespace Tartarun2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {

        }

        private void clock_Tick(object sender, EventArgs e)
        {

        }

        private void creditsBtn_Click(Object sender, EventArgs e)
        {
            creditsPanel.Focus();
            creditsPanel.BringToFront();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void creditsBackBtn_Click(object sender, EventArgs e)
        {
            mainMenuPanel.Focus();
            mainMenuPanel.BringToFront();
        }
    }
}