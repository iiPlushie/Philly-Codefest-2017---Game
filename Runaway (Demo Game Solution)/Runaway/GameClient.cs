using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Runaway
{
    public partial class GameClient : Form
    {
        private PictureBox HauntedMansion, LabRoom, DialogBox, S7, S7Large,
            PhoneCharger, PhoneChargerLarge, Computer, ComputerLarge, ComputerScreen,
            Android, Lady, Credits;
        private Label Logo, DialogText;
        private Button PlayDemo, DialogButton, LogIn;
        private TextBox PasswordBox;
        private SoundPlayer Player;
        private Thread BackgroundProcess;
        private int Scenario = 0;

        public GameClient()
        {
            InitializeComponent();
            BackgroundProcess = new Thread(PlayMenuTheme);
            BackgroundProcess.Start();
            LoadMenu();
        }

        private void LoadMenu()
        {
            HauntedMansion = new PictureBox();
            HauntedMansion.Width = 800;
            HauntedMansion.Height = 450;
            HauntedMansion.Location = new Point(0, 0);
            HauntedMansion.ImageLocation = @"Images\HauntedMansion.png";
            this.Controls.Add(HauntedMansion);

            Logo = new Label();
            Logo.Width = 360;
            Logo.Height = 115;
            Logo.Location = new Point(220, 100);
            Logo.Image = Image.FromFile(@"Images\Logo.png");
            Logo.Parent = HauntedMansion;
            Logo.BackColor = Color.Transparent;
            this.Controls.Add(Logo);
            this.Controls[1].BringToFront();

            PlayDemo = new Button();
            PlayDemo.Width = 250;
            PlayDemo.Height = 50;
            PlayDemo.Location = new Point(275, 300);
            PlayDemo.BackgroundImage = Image.FromFile(@"Images\PlayDemo.png");
            PlayDemo.FlatStyle = FlatStyle.Flat;
            PlayDemo.BackColor = Color.Transparent;
            PlayDemo.Click += StartGame;
            this.Controls.Add(PlayDemo);
            this.Controls[2].BringToFront();
        }

        private void LoadGameMenu()
        {
            LabRoom = new PictureBox();
            LabRoom.Width = 800;
            LabRoom.Height = 450;
            LabRoom.Location = new Point(0, 0);
            LabRoom.ImageLocation = @"Images\LabRoom.png";
            this.Controls.Add(LabRoom);
            this.Controls[3].BringToFront();

            S7 = new PictureBox();
            S7.Width = 18;
            S7.Height = 30;
            S7.Location = new Point(60, 260);
            S7.ImageLocation = @"Images\S7.png";
            S7.Enabled = false;
            S7.Click += PhoneClick;
            this.Controls.Add(S7);
            this.Controls[4].BringToFront();

            PhoneCharger = new PictureBox();
            PhoneCharger.Width = 26;
            PhoneCharger.Height = 23;
            PhoneCharger.Location = new Point(620, 240);
            PhoneCharger.ImageLocation = @"Images\PhoneCharger.png";
            PhoneCharger.Enabled = false;
            PhoneCharger.Click += ChargerClick;
            this.Controls.Add(PhoneCharger);
            this.Controls[5].BringToFront();

            Computer = new PictureBox();
            Computer.Width = 82;
            Computer.Height = 59;
            Computer.Location = new Point(670, 190);
            Computer.ImageLocation = @"Images\Computer.png";
            Computer.Enabled = false;
            Computer.Click += ComputerClick;
            this.Controls.Add(Computer);
            this.Controls[6].BringToFront();

            DialogBox = new PictureBox();
            DialogBox.Width = 700;
            DialogBox.Height = 100;
            DialogBox.Location = new Point(50, 310);
            DialogBox.ImageLocation = @"Images\DialogBox.png";
            this.Controls.Add(DialogBox);
            this.Controls[7].BringToFront();

            DialogText = new Label();
            DialogText.Width = 694;
            DialogText.Height = 96;
            DialogText.Location = new Point(54, 312);
            DialogText.Text = "I woke up finding myself in this place...";
            DialogText.BackColor = Color.Blue;
            DialogText.Font = new Font(DialogText.Font, FontStyle.Bold);
            DialogText.Font = new Font(DialogText.Font.FontFamily, 20);
            DialogText.ForeColor = Color.White;
            this.Controls.Add(DialogText);
            this.Controls[8].BringToFront();

            DialogButton = new Button();
            DialogButton.Width = 100;
            DialogButton.Height = 25;
            DialogButton.Text = "NEXT";
            DialogButton.BackColor = Color.Blue;
            DialogButton.Font = new Font(DialogButton.Font, FontStyle.Bold);
            DialogButton.ForeColor = Color.White;
            DialogButton.Location = new Point(630, 370);
            DialogButton.FlatStyle = FlatStyle.Flat;
            DialogButton.Click += NextScenario;
            this.Controls.Add(DialogButton);
            this.Controls[9].BringToFront();
        }

        private void StartGame(object sender, EventArgs e)
        {
            BackgroundProcess = new Thread(PlayLabTheme);
            BackgroundProcess.Start();
            HauntedMansion.Visible = false;
            Logo.Visible = false;
            PlayDemo.Visible = false;
            LoadGameMenu();
        }

        private void PhoneClick(object sender, EventArgs e)
        {
            S7Large = new PictureBox();
            S7Large.Width = 108;
            S7Large.Height = 225;
            S7Large.Location = new Point(340, 50);
            S7Large.ImageLocation = @"Images\S7Large.png";
            this.Controls.Add(S7Large);
            this.Controls[10].BringToFront();
            S7.Visible = false;
            S7Large.Visible = true;
            DialogButton.Visible = true;
            ScenarioScript();
        }

        private void ChargerClick(object sender, EventArgs e)
        {
            PhoneChargerLarge = new PictureBox();
            PhoneChargerLarge.Width = 205;
            PhoneChargerLarge.Height = 199;
            PhoneChargerLarge.Location = new Point(300, 50);
            PhoneChargerLarge.ImageLocation = @"Images\PhoneChargerLarge.png";
            this.Controls.Add(PhoneChargerLarge);
            this.Controls[11].BringToFront();
            PhoneCharger.Visible = false;
            PhoneChargerLarge.Visible = true;
            DialogButton.Visible = true;
            ScenarioScript();
        }

        private void ComputerClick(object sender, EventArgs e)
        {
            ComputerLarge = new PictureBox();
            ComputerLarge.Width = 344;
            ComputerLarge.Height = 232;
            ComputerLarge.Location = new Point(220, 50);
            ComputerLarge.ImageLocation = @"Images\ComputerLarge.png";
            this.Controls.Add(ComputerLarge);
            this.Controls[12].BringToFront();
            Computer.Visible = false;
            ComputerLarge.Visible = true;
            DialogButton.Visible = true;
            ScenarioScript();
        }

        private void NextScenario(object sender, EventArgs e)
        {
            ScenarioScript();
        }

        private void ScenarioScript()
        {
            if (Scenario < 1)
            {
                DialogText.Text = "I see only one door, but it seems to be locked.";
            }
            else if (Scenario < 2)
            {
                DialogText.Text = "I need to find a way out.";
            }
            else if (Scenario < 3)
            {
                DialogText.Text = "[RING RING RING] I think i hear a phone ringing...";
            }
            else if (Scenario < 4)
            {
                DialogText.Text = "Let's find the phone.";
            }
            else if (Scenario < 5)
            {
                DialogText.Text = "(You can pick up an object by clicking on it)";
                S7.Enabled = true;
                DialogButton.Visible = false;
            }
            else if (Scenario < 6)
            {
                DialogText.Text = "(You found an android smartphone!)";
                DialogButton.Visible = true;
            }
            else if (Scenario < 7)
            {
                DialogText.Text = "It looks like it just ran out of battery, let's find the charger.";
                S7Large.Visible = false;
                DialogButton.Visible = false;
                PhoneCharger.Enabled = true;
            }
            else if(Scenario < 8)
            {
                DialogText.Text = "(You found the phone charger!)";
                DialogButton.Visible = true;
            }
            else if(Scenario < 9)
            {
                DialogText.Text = "You found an outlet and tried to charge the phone.";
                PhoneChargerLarge.Visible = false;
            }
            else if(Scenario < 10)
            {
                DialogText.Text = "The phone charger seems to be not working.";
            }
            else if(Scenario < 11)
            {
                DialogText.Text = "(You see a note lying next to the outlet)";
            }
            else if(Scenario < 12)
            {
                DialogText.Text = "(You picked it up and it reads.....)";
            }
            else if(Scenario < 13)
            {
                DialogText.Text = "(You can get access to the basement's floor using the computer in the room)";
            }
            else if(Scenario < 14)
            {
                DialogText.Text = "Let's try to look for the computer.";
                Computer.Enabled = true;
                DialogButton.Visible = false;
            }
            else if(Scenario < 15)
            {
                DialogText.Text = "(You located the computer)";
                DialogButton.Visible = true;
            }
            else if(Scenario < 16)
            {
                DialogText.Text = "(You turned on the computer by pressing the power button)";
                ComputerLarge.Visible = false;
            }
            else if(Scenario < 17)
            {
                DialogText.Text = "The computer is asking for a password to log in.";
            }
            else if(Scenario < 18)
            {
                DialogText.Text = "The hint is: What am I";
            }
            else if(Scenario < 19)
            {
                DialogText.Text = "(Please enter your password)";
                DialogButton.Visible = false;

                ComputerScreen = new PictureBox();
                ComputerScreen.Width = 273;
                ComputerScreen.Height = 165;
                ComputerScreen.Location = new Point(250, 70);
                ComputerScreen.ImageLocation = @"Images\ComputerScreen.png";
                this.Controls.Add(ComputerScreen);
                this.Controls[13].BringToFront();

                PasswordBox = new TextBox();
                PasswordBox.Width = 120;
                PasswordBox.Height = 25;
                PasswordBox.Location = new Point(272, 140);
                this.Controls.Add(PasswordBox);
                this.Controls[14].BringToFront();

                LogIn = new Button();
                LogIn.Width = 100;
                LogIn.Height = 25;
                LogIn.Text = "Log In";
                LogIn.BackColor = Color.Blue;
                LogIn.Font = new Font(LogIn.Font, FontStyle.Bold);
                LogIn.ForeColor = Color.White;
                LogIn.Location = new Point(272, 170);
                LogIn.FlatStyle = FlatStyle.Flat;
                LogIn.Click += LogInToComputer;
                this.Controls.Add(LogIn);
                this.Controls[15].BringToFront();
            }
            else if(Scenario < 20)
            {
                if (PasswordValidator(PasswordBox.Text))
                {
                    DialogText.Text = "(The password you entered was correct)";
                }
                else
                {
                    DialogText.Text = "(The password you entered was incorrect)";
                } DialogButton.Visible = true;
            }
            else if(Scenario < 21)
            {
                LabRoom.Visible = false;
                DialogText.Text = "(Suddenly, the room goes pitch black)";
            }
            else if(Scenario < 22)
            {
                if (PasswordValidator(PasswordBox.Text))
                {
                    DialogText.Text = "Unknown: You sure know your stuff.....";
                }
                else
                {
                    DialogText.Text = "Unknown: The correct answer was computer.....";
                }
            }
            else if(Scenario < 23)
            {
                BackgroundProcess = new Thread(PlayAndroidTheme);
                BackgroundProcess.Start();
                Android = new PictureBox();
                Android.Width = 600;
                Android.Height = 328;
                Android.Location = new Point(100, -19);
                Android.ImageLocation = @"Images\Android.png";
                this.Controls.Add(Android);
                this.Controls[16].BringToFront();
                DialogText.Text = "Hey there little buddy!";
            }
            else if(Scenario < 24)
            {
                Android.Visible = false;
                Lady = new PictureBox();
                Lady.Width = 163;
                Lady.Height = 174;
                Lady.Location = new Point(310, 75);
                Lady.ImageLocation = @"Images\Lady.png";
                this.Controls.Add(Lady);
                this.Controls[17].BringToFront();
                DialogText.Text = "AHHHHH! RUNNNNN!";
            }
            else if(Scenario < 25)
            {
                Lady.Visible = false;
                DialogText.Text = "(This is the end of the demo)";
            }
            else if(Scenario < 26)
            {
                DialogText.Text = "(THANK YOU FOR PLAYING!)";
            }
            else
            {
                BackgroundProcess = new Thread(PlayCreditsTheme);
                BackgroundProcess.Start();
                Credits = new PictureBox();
                Credits.Width = 800;
                Credits.Height = 450;
                Credits.Location = new Point(0, 0);
                Credits.ImageLocation = @"Images\Credits.png";
                this.Controls.Add(Credits);
                this.Controls[18].BringToFront();
            }
            Scenario++;
        }

        private void LogInToComputer(object sender, EventArgs e)
        {
            ComputerScreen.Visible = false;
            PasswordBox.Visible = false;
            LogIn.Visible = false;
            ScenarioScript();

        }

        private bool PasswordValidator(String Password)
        {
            if (Password.ToLower() == "computer") return true;
            else return false;
        }

        private void PlayMenuTheme()
        {
            Player = new SoundPlayer(@"Audio\Menu Theme.wav");
            Player.PlayLooping();
        }

        private void PlayLabTheme()
        {
            Player = new SoundPlayer(@"Audio\Lab Theme.wav");
            Player.PlayLooping();
        }

        private void PlayAndroidTheme()
        {
            Player = new SoundPlayer(@"Audio\Android Theme.wav");
            Player.PlayLooping();
        }

        private void PlayCreditsTheme()
        {
            Player = new SoundPlayer(@"Audio\Credits Theme.wav");
            Player.Play();
        }
    }
}
