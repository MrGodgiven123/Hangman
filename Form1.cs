using System.Diagnostics;

namespace Hangman
{
    public partial class Form1 : Form
    {
        List<int> AttemptsList = [];
        List<Image> Images = [Properties.Resources.Hangman1, Properties.Resources.Hangman2, Properties.Resources.Hangman3, Properties.Resources.Hangman4, Properties.Resources.Hangman5,
                Properties.Resources.Hangman6, Properties.Resources.Hangman7, Properties.Resources.Hangman8, Properties.Resources.HangmanFail];

        static List<string> WordsList = ["apple","river","cloud","stone","light","dream","forest","water","sound","bridge","mountain","ocean","flower","window","street","garden","bottle","shadow","mirror","circle",
            "castle","silver","gold","paper","pencil","school","winter","summer","spring","autumn","friend","family","music","memory","energy","planet","galaxy","rocket","planet","animal","coffee","table","chair",
            "phone","computer","keyboard","mouse","screen","window","door"];
        static Random rnd = new Random();
        static string TrueWord = WordsList[rnd.Next(WordsList.Count)];
        char[] Word = new string('_', TrueWord.Length).ToCharArray();

        public Form1()
        {
            InitializeComponent();
            DifficultyPanel.Location = new Point(290, 155);

            foreach (Control btn in Controls.OfType<Button>())
            {
                btn.Enabled = false;
                btn.Click += Play_Click; 
            }

            SWord();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;


            if (TrueWord.Contains(Convert.ToChar(btn.Tag)))
            {
                for (int i = 0; i < TrueWord.Length; i++)
                {
                    if (TrueWord[i] == Convert.ToChar(btn.Tag)) Word[i] = Convert.ToChar(btn.Tag); 
                }

                SWord();

                if(!Word.Contains('_'))
                {
                    foreach (Control bttn in Controls.OfType<Button>())
                    {
                    bttn.Enabled = false;
                    }

                }
            }
            else
            {
                ImageBox.Image = Images[AttemptsList[0]];
                AttemptsList.RemoveAt(0);

                if (AttemptsList.Count == 0)
                {
                    foreach (Control bttn in Controls.OfType<Button>())
                    {
                        bttn.Enabled = false;
                        WordLabel.Text = string.Join(" ", TrueWord.ToCharArray());
                    }
                }

            }


            btn.Enabled = false;

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

        private void SWord()
        {
            WordLabel.Text = string.Join(" ", Word);
        }
    }
}
