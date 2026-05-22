using System.Diagnostics;

namespace Hangman
{
    public partial class Form1 : Form
    {
        List<int?> AttemptsList = [];
        Image[] Images = {Properties.Resources.Hangman1, Properties.Resources.Hangman2, Properties.Resources.Hangman3, Properties.Resources.Hangman4, Properties.Resources.Hangman5,
                Properties.Resources.Hangman6, Properties.Resources.Hangman7, Properties.Resources.Hangman8, Properties.Resources.HangmanFail};
        string[] WordsList = { "a", "aa" };
        public Form1()
        {

            InitializeComponent();
            DifficultyPanel.Location = new Point(290, 155);
            
            foreach (Control btn in this.Controls.OfType<Button>())
            {
                btn.Click += Play_Click; 
            }

            foreach (Control btn in this.Controls.OfType<Button>())
            {
                btn.Enabled = false;
            }

            Random rnd = new Random();
            string TrueWord = WordsList[rnd.Next(WordsList.Length)];
            string Word = new string('_', TrueWord.Length);

            WordLabel.Text = string.Join(" ", Word.ToCharArray());
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            WordLabel.Text = btn.Tag.ToString();

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            foreach (Control btn in this.Controls.OfType<Button>())
            {
                btn.Enabled = true;
            }

            if (EasyButton.Checked)
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

            DifficultyPanel.Enabled = false;
            DifficultyPanel.Visible = false;

        }
    }
}
