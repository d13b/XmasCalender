using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Windows.Forms.VisualStyles;
using System.Runtime.Remoting.Channels;

namespace Advent_Calender_2023
{
    public partial class AdventForm : Form
    { 
        SoundPlayer jokeMade = new SoundPlayer(@"Sounds\komaeda-laugh.wav");
        SoundPlayer badInput = new SoundPlayer(@"Sounds\Wrong-answer-sound-effect.wav");
        SoundPlayer xmasTime = new SoundPlayer(@"Sounds\Demomanlaugh.wav");

        int AppropriateClick = 0;
        Random random = new Random();

        List<string> Punchline = new List<string>()
        {
            "Lighten Up!", "Orna-mints!", "They use Santa-tizer", "It's Christmas, Eve!",
            "He uses Comet.", "At a snowball!", "Because they were chilling together and having a cool Yule!", 
            "It had too many ornament-al issues and couldn't stop feeling tinsel-tension!", 
            "He wanted to improve his cookie-culation skills!", "Because he had low elf-esteem!", 
            "Frostbite!", "An Investigator!", "She’d been hooked on Christmas trees all her life.", "No-eye deer.", "Because they enjoy wrapping.", "He gives them the sack.",
            "Claustrophobic.", "He was elf-taught.", "Reindeer. They sleigh every time.", "Welfy.",
            "“Because of the rain, dear.”", "I took it back and exchanged it for another one – free of charge.", "Because it had drumsticks.", "Tinsilitis.",
        };
        
        List<string> Joke = new List<string>()
        {
            "What did one Christmas tree say to another?", "What is a Christmas tree's favorite candy?",
            "How do elves clean Santa's sleigh?", "What did Adam say on the day before Christmas?",
            "How does Santa keep his bathroom tiles sparkling?", "Where would you find a snowman dancing?", 
            "What did the snowman call his friend an ice cream?", "Why did the christmas tree go to therapy?",
            "Why did the gingerbread man go to school during the holidays?", "Why did Santa's helper see the doctor?", 
            "What do you get if you cross a snowman and a vampire?", "What do you call an alligator in a vest?", "How did the bauble know that she was addicted to Christmas?", "What do you call a blind reindeer?", "Why are mummies such big fans of Christmas?", "What does Santa do when his elves misbehave?",
            "What do you call people who are afraid of Santa?", "How did the reindeer learn to play piano?", "Who tells the best Christmas jokes?", "What could you call an elf who has just won the lottery?",
            "Why did Mrs. Claus insist Santa take an umbrella?", "The Christmas jumper my kids gave me last year kept picking up static electricity.", "Why did the turkey join the rock band?", "What do you get if you eat Christmas decorations?",
        };

        public AdventForm()
        {
            InitializeComponent();
        }

        private void ChronologicalInputTester(object sender, int randomJoke)
        {
            Label clickedLabel = sender as Label;
            
            if(clickedLabel.TabIndex > AppropriateClick)
            {
                badInput.Play();
                MessageBox.Show("CLICK THEM IN THE APPROPRIATE ORDER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(clickedLabel.ForeColor != Color.Black)
                {
                    jokeMade.Play();
                    MessageBox.Show(Joke[randomJoke]);
                    MessageBox.Show(Punchline[randomJoke]);
                    Punchline.Remove(Punchline[randomJoke]);
                    Joke.Remove(Joke[randomJoke]);
                    clickedLabel.ForeColor = Color.Black;
                    AppropriateClick++;
                }
                else
                {
                    badInput.Play();
                    MessageBox.Show("DO NOT CLICK SAME BOX TWICE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_click(object sender, EventArgs e)
        {
            int randomJoke = random.Next(Punchline.Count);
            ChronologicalInputTester(sender, randomJoke);
        }

        private void lbl25_click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel.TabIndex > AppropriateClick)
            {
                badInput.Play();
                MessageBox.Show("CLICK THEM IN THE APPROPRIATE ORDER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                xmasTime.Play();
                MessageBox.Show("Merry Christmas", "Christmas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        
    }
}
