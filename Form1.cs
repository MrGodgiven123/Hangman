namespace Hangman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Image[] ImagesList = {Properties.Resources.Hangman1, Properties.Resources.Hangman2, Properties.Resources.Hangman3, Properties.Resources.Hangman4, Properties.Resources.Hangman5, 
                Properties.Resources.Hangman6, Properties.Resources.Hangman7, Properties.Resources.Hangman8, Properties.Resources.HangmanFail};
            int[] AttemptsList;
            InitializeComponent();
            DifficultyPanel.Location = new Point(290, 155);

            foreach(Control btn in this.Controls)
            {
                if (btn.Tag == "Button")
                {
                    btn.Enabled = false;
                }
            }
            if(EasyButton.Checked)
            {
                AttemptsList = [0, 1, 2, 3, 4, 5, 6, 7, 8];
            }
            else if (MediumButton.Checked)
            {
                AttemptsList = [0, 2, 4, 6, 8];
            }
            else if (HardButton.Checked)
            {
                AttemptsList = [0, 4, 8];
            }
            
            string TrueWord = "Word";
            string Word = "";
            /*
            foreach (char c in TrueWord)
            {
                Word.Append('_');
            }

            WordLabel.Text = Word;
            */

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            foreach (Control btn in this.Controls)
            {
                if (btn.Tag == "Button")
                {
                    btn.Enabled = true;
                }
            }

            DifficultyPanel.Enabled = false;
            DifficultyPanel.Visible = false;
        }

        private void Q_Button_Click(object sender, EventArgs e)
        {
            Q_Button.Enabled = false;
        }
    }
}
