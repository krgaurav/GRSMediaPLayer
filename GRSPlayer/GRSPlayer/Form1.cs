using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using QuartzTypeLib; /* For media palyer functions */


namespace GRSPlayer
{
    public partial class GRSForm : Form
    {
        private const int WS_CHILD = 0x40000000;
        private const int WS_CLIPCHILDREN = 0x2000000;
        public Boolean check = true;
        // FunObj object of function class
        functions FunObj = new functions();
        
        //playlist object declaration
        PlayList ShowPlayList;
        public string playsong;

        
        public GRSForm()
        {
            InitializeComponent();            
            Thread th = new Thread(new ThreadStart(DoSplash));
            th.Start();
            Thread.Sleep(3000);
            th.Abort();
            Thread.Sleep(1000);
           
        }
       
        /*
         * *******************
         * For Splash Screen *           
         * *******************
         * 
         **/
        private void DoSplash() 
        {
            SplashScreen ShowSplash = new SplashScreen();
            ShowSplash.ShowDialog();
            ShowSplash.Dispose();
        }
        /*
         * *******************
         * Form Methods      *           
         * *******************
         * GRSForm_Load = On the loading of Main form.. GRS form
         * sizeChanged = Size of Form is changed by enduser
         **/
        private void GRSForm_Load(object sender, EventArgs e)
        {
            // ShowPlayList object of PlayList Form
            ShowPlayList = new PlayList(this);
        }        
        private void sizeChanged(object sender, EventArgs e)
        {
            if (FunObj.m_objVideoWindow != null)
            {
                FunObj.m_objVideoWindow.SetWindowPosition(video.ClientRectangle.Left,
                    video.ClientRectangle.Top,
                    video.ClientRectangle.Width,
                    video.ClientRectangle.Height);
            }
        }




        /*
         * *******************
         * Other Methods      *           
         * *******************
         * play_Local = To plat current media
         * timer1_Tick = To change the scrol value as per CurrentPosition of Media
         * UpdateStatusBarTime = To update the status bar
         **/
        public void play_Local(String filename)
        {        
            FunObj.CleanUp();           

            FunObj.m_objFilterGraph = new FilgraphManager();

            if (filename != null)
            {
                FunObj.m_objFilterGraph.RenderFile(filename);               
            }
            FunObj.m_objBasicAudio = FunObj.m_objFilterGraph as IBasicAudio;
            try
            {
                /**
                 * For Video files
                 * */
                FunObj.m_objVideoWindow = FunObj.m_objFilterGraph as IVideoWindow;
                FunObj.m_objVideoWindow.Owner = (int)video.Handle;
                FunObj.m_objVideoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;

            }
            catch (Exception)
            {
                FunObj.m_objVideoWindow = null;
            }

            FunObj.m_objMediaEvent = FunObj.m_objFilterGraph as IMediaEvent;
            FunObj.m_objMediaEventEx = FunObj.m_objFilterGraph as IMediaEventEx;
            FunObj.m_objMediaPosition = FunObj.m_objFilterGraph as IMediaPosition;
            FunObj.m_objMediaControl = FunObj.m_objFilterGraph as IMediaControl;
            FunObj.m_objMediaTypeInfo = FunObj.m_objFilterGraph as IMediaTypeInfo;
            FunObj.m_objMediaControl.Run();
            c_mediaScroll.Maximum = (int)FunObj.m_objMediaPosition.Duration;
            c_mediaScroll.Minimum = 0;
            c_mediaScroll.TickFrequency = 1;
            c_mediaScroll.LargeChange = 3;  //on clicking left side of scroll
            c_mediaScroll.SmallChange = 2; // scrolling through Keyboard
            volume.Maximum = 0;
            volume.Minimum = -10000;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (FunObj.m_objVideoWindow != null)
            {
                c_mediaScroll.Value = (int)FunObj.m_objMediaPosition.CurrentPosition;
            }
            UpdateStatusBarTime();
        }
        public void UpdateStatusBarTime()
        {
            if (FunObj.m_objMediaPosition != null)
            {
                int s = (int)FunObj.m_objMediaPosition.Duration;
                int h = s / 3600;
                int m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);

                string duration = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
                
                s = (int)FunObj.m_objMediaPosition.CurrentPosition;
                h = s / 3600;
                m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);

                string curr = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
                statusBarPanel2.Text = curr;
                statusBarPanel3.Text = duration;

            }
        }

        

        
        

        
        /*****************************
         * Media Menu -->Items    *
         * ***************************
         * MediaItemOpen_Click =  Open Media ... Directly play state
         * MediaItemRecentMedia_Click = Open Recently palyed media
         * MediaItemSaveToPlaylist_Click = Save current Media to current playlist
         * MediaItemQuit_Click =  Quit Media
         * 
         * */
        private void MediaItemOpen_Click(object sender, EventArgs e)
        {
            String[] Name;
            Name = FunObj.C_OpenFileDialogBox("Open File", "", "All files(*.*)|*.*", "false", "true", "true");
            if (Name != null)
            {
                play_Local(Convert.ToString(Name[0]));
                foreach (string MediaName in Name)
                {
                    ShowPlayList.PlayListBox.Items.Add(MediaName);
                }
                ShowPlayList.PlayListBox.SetSelected(0, true);
                //change play to pause button
                Btn_Pause.Visible = true; Btn_Play.Visible = false;
                //update status bar panel
                statusBarPanel1.Text = "Playing";
                UpdateStatusBarTime();
            }
        }
        private void MediaItemRecentMedia_Click(object sender, EventArgs e)
        {

        }
        private void MediaItemSaveToPlaylist_Click(object sender, EventArgs e)
        {

        }
        private void MediaItemQuit_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Do you really want to quit ?", "Quit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                Close();
            }
        }
        /*****************************
         * Playback Menu -->Items    *
         * ***************************
         * PlaybackItemPlay_Click =  Play Media
         * PlaybackItemStop_Click =  Stop Media
         * PlaybackItemPause_Click = Pause Media
         * PlaybackItemNext_Click = Play Next media
         * PlaybackItemPrevious_Click = Play Previous Media
         * PlaybackItemFastForward_Click = Fast Forward
         * PlaybackItemFastBackward_Click = Fast Backward
         * */
        private void PlaybackItemPlay_Click(object sender, EventArgs e)
        {
            playsong = (String)ShowPlayList.PlayListBox.SelectedItem;
            Btn_Pause.Visible = true; Btn_Play.Visible = false;
            play_Local(playsong);
            FunObj.m_objMediaPosition.CurrentPosition = c_mediaScroll.Value;
            c_mediaScroll.Maximum = (int)FunObj.m_objMediaPosition.Duration;
            c_mediaScroll.TickFrequency = 1;
            c_mediaScroll.LargeChange = 3;
            c_mediaScroll.SmallChange = 2;
            statusBarPanel1.Text = "Playing";

        }
        private void PlaybackItemStop_Click(object sender, EventArgs e)
        {
            FunObj.stop();
            //change pause to play button
            Btn_Pause.Visible = false; Btn_Play.Visible = true;
            statusBarPanel1.Text = "Stopped";
        }
        private void PlaybackItemPause_Click(object sender, EventArgs e)
        {
            Btn_Pause.Visible = false; Btn_Play.Visible = true;
            FunObj.pause();
            statusBarPanel1.Text = "Paused";
        }
        private void PlaybackItemNext_Click(object sender, EventArgs e)
        {
            FunObj.m_objFilterGraph = null;
            int TotalLength = ShowPlayList.PlayListBox.Items.Count;
            string currMedia = (string)ShowPlayList.PlayListBox.SelectedItem;
            int IndexOfCurrMedia = ShowPlayList.PlayListBox.SelectedIndex;

            if (IndexOfCurrMedia == TotalLength - 1)
            {
                ShowPlayList.PlayListBox.ClearSelected();
                ShowPlayList.PlayListBox.SetSelected(0, true);
                String NewMedia = (String)ShowPlayList.PlayListBox.SelectedItem;
                play_Local(NewMedia);
                FunObj.m_objMediaPosition.CurrentPosition = c_mediaScroll.Value;
                c_mediaScroll.Maximum = (int)FunObj.m_objMediaPosition.Duration;
                c_mediaScroll.TickFrequency = 10;
                c_mediaScroll.LargeChange = 3;
                c_mediaScroll.SmallChange = 2;
                statusBarPanel1.Text = "Playing";

            }
            else
            {
                ShowPlayList.PlayListBox.ClearSelected();
                IndexOfCurrMedia = IndexOfCurrMedia + 1;
                ShowPlayList.PlayListBox.SetSelected(IndexOfCurrMedia, true);
                String NewMedia = (String)ShowPlayList.PlayListBox.SelectedItem;
                play_Local(NewMedia);
                FunObj.m_objMediaPosition.CurrentPosition = c_mediaScroll.Value;
                c_mediaScroll.Maximum = (int)FunObj.m_objMediaPosition.Duration;
                c_mediaScroll.TickFrequency = 10;
                c_mediaScroll.LargeChange = 3;
                c_mediaScroll.SmallChange = 2;
                statusBarPanel1.Text = "Playing";

            }
        }
        private void PlaybackItemPrevious_Click(object sender, EventArgs e)
        {
            FunObj.m_objFilterGraph = null;
            int TotalLength = ShowPlayList.PlayListBox.Items.Count;
            int IndexOfCurrMedia = ShowPlayList.PlayListBox.SelectedIndex;
            if (IndexOfCurrMedia != 0)
            {
                ShowPlayList.PlayListBox.ClearSelected();
                IndexOfCurrMedia = IndexOfCurrMedia - 1;
                ShowPlayList.PlayListBox.SetSelected(IndexOfCurrMedia, true);
                String NewMedia = (String)ShowPlayList.PlayListBox.SelectedItem;
                play_Local(NewMedia);
                FunObj.m_objMediaPosition.CurrentPosition = c_mediaScroll.Value;
                c_mediaScroll.Maximum = (int)FunObj.m_objMediaPosition.Duration;
                c_mediaScroll.TickFrequency = 10;
                c_mediaScroll.LargeChange = 3;
                c_mediaScroll.SmallChange = 2;
                statusBarPanel1.Text = "Playing";
            }
            else
            {
                ShowPlayList.PlayListBox.ClearSelected();
                ShowPlayList.PlayListBox.SetSelected(0, true);
                String NewMedia = (String)ShowPlayList.PlayListBox.SelectedItem;
                play_Local(NewMedia);
                FunObj.m_objMediaPosition.CurrentPosition = c_mediaScroll.Value;
                c_mediaScroll.Maximum = (int)FunObj.m_objMediaPosition.Duration;
                c_mediaScroll.TickFrequency = 10;
                c_mediaScroll.LargeChange = 3;
                c_mediaScroll.SmallChange = 2;
                statusBarPanel1.Text = "Playing";
            }

        }
        private void PlaybackItemFastForward_Click(object sender, EventArgs e)
        {
            int iNewPosition = (int)FunObj.m_objMediaPosition.CurrentPosition + 10;
            if (iNewPosition < (int)FunObj.m_objMediaPosition.Duration)
            {
                c_mediaScroll.Value = (int)FunObj.m_objMediaPosition.CurrentPosition + 10;
                FunObj.m_objMediaPosition.CurrentPosition = FunObj.m_objMediaPosition.CurrentPosition + 10;

            }
            else
            {
                c_mediaScroll.Value = (int)FunObj.m_objMediaPosition.Duration;
            }
            UpdateStatusBarTime();
        }
        private void PlaybackItemFastBackward_Click(object sender, EventArgs e)
        {
            int iNewPosition = (int)FunObj.m_objMediaPosition.CurrentPosition - 10;
            if (iNewPosition > 0)
            {
                c_mediaScroll.Value = (int)FunObj.m_objMediaPosition.CurrentPosition - 10;
                FunObj.m_objMediaPosition.CurrentPosition = FunObj.m_objMediaPosition.CurrentPosition - 10;

            }
            else
            {
                c_mediaScroll.Value = 0;
            }
            UpdateStatusBarTime();
        }
        /*****************************
         * View Menu -->Items    *
         * ***************************
         * ViewItemNormal_Click =  Window state Normal
         * ViewItemMinimal_Click = Window stae Minimal
         * ViewItemFullscreen_Click = Window state Fullscreen
         * playlistToolStripMenuItem_Click =  Show playlist
         * mediaInfoToolStripMenuItem_Click = Infromation about current media
         * ViewItemOptions_Click = GRS Media Player Option window
         * */
        private void ViewItemNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        private void ViewItemMinimal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void ViewItemFullscreen_Click(object sender, EventArgs e)
        {
            this.
            FunObj.m_objVideoWindow.FullScreenMode = 0;
            //this.WindowState = FormWindowState.Maximized;           
            FunObj.m_objVideoWindow.SetWindowPosition(0,
               0,
               640,
               480);
        }
        private void playlistToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void mediaInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void ViewItemOptions_Click(object sender, EventArgs e)
        {

        }


        /*****************************
         * Help Menu -->Items    *
         * ***************************
         * HelpItemHelp_Click =  GRS Player Help .. Load Help file here
         * HelpItemAbout_Click = About us Window
         * ViewItemDeveloper_Click = Developer Window
         * 
         * */

        private void HelpItemHelp_Click(object sender, EventArgs e)
        {

        }
        private void HelpItemAbout_Click(object sender, EventArgs e)
        {
            AboutUs ShowAbout = new AboutUs();
            ShowAbout.Show();
        }
        private void ViewItemDeveloper_Click(object sender, EventArgs e)
        {
            Developers ShowDevelopers = new Developers();
            ShowDevelopers.ShowDialog();


        }
        /*****************************
         * Control Panel -->Items    *
         * ***************************
         * c_mediaScroll_Scroll =  Ticker to change the Current Position of Media
         * Btn_Previous_Click = To play Previous Mediads
         * Btn_Play_Click = To paly current media
         * Btn_Pause_Click =  To pause current media
         * Btn_Next_Click = To play Next media
         * Btn_FastBackward_Click = For FastBackward current position of Media by 10
         * Btn_Stop_Click = To Stop current media
         * button5_Click =For FastForward current position of Media by 10
         * Btn_PlayList_Click = To show Playlist Window
         * Btn_FullVol_Click = For Volume On
         * btn_Mute_Click = For Mute 
         * volume_Scroll = To change Volume on Scroll of this controll
         * */
        private void c_mediaScroll_Scroll(object sender, EventArgs e)
        {
            FunObj.m_objMediaPosition.CurrentPosition = c_mediaScroll.Value;
            UpdateStatusBarTime();
        }
        private void Btn_Previous_Click(object sender, EventArgs e)
        {
            FunObj.m_objFilterGraph = null;
            int TotalLength = ShowPlayList.PlayListBox.Items.Count;            
            int IndexOfCurrMedia = ShowPlayList.PlayListBox.SelectedIndex;            
            if (IndexOfCurrMedia != 0)
            {                
                ShowPlayList.PlayListBox.ClearSelected();
                IndexOfCurrMedia = IndexOfCurrMedia - 1;
                ShowPlayList.PlayListBox.SetSelected(IndexOfCurrMedia, true);
                String NewMedia = (String)ShowPlayList.PlayListBox.SelectedItem;
                play_Local(NewMedia);
                FunObj.m_objMediaPosition.CurrentPosition = c_mediaScroll.Value;
                c_mediaScroll.Maximum = (int)FunObj.m_objMediaPosition.Duration;
                c_mediaScroll.TickFrequency = 10;
                c_mediaScroll.LargeChange = 3;
                c_mediaScroll.SmallChange = 2;
                statusBarPanel1.Text = "Playing";
            }
            else {
                ShowPlayList.PlayListBox.ClearSelected();
                ShowPlayList.PlayListBox.SetSelected(0, true);
                String NewMedia = (String)ShowPlayList.PlayListBox.SelectedItem;
                play_Local(NewMedia);
                FunObj.m_objMediaPosition.CurrentPosition = c_mediaScroll.Value;
                c_mediaScroll.Maximum = (int)FunObj.m_objMediaPosition.Duration;
                c_mediaScroll.TickFrequency = 10;
                c_mediaScroll.LargeChange = 3;
                c_mediaScroll.SmallChange = 2;
                statusBarPanel1.Text = "Playing";
            }

        }
        private void Btn_Play_Click(object sender, EventArgs e)
        {
            playsong = (String)ShowPlayList.PlayListBox.SelectedItem;
            Btn_Pause.Visible = true; Btn_Play.Visible = false;
            play_Local(playsong);
            FunObj.m_objMediaPosition.CurrentPosition = c_mediaScroll.Value;
            c_mediaScroll.Maximum = (int)FunObj.m_objMediaPosition.Duration;
            c_mediaScroll.TickFrequency = 1;
            c_mediaScroll.LargeChange = 3;
            c_mediaScroll.SmallChange = 2;
            statusBarPanel1.Text = "Playing";
        }
        private void Btn_Pause_Click(object sender, EventArgs e)
        {
            Btn_Pause.Visible = false; Btn_Play.Visible = true;
            FunObj.pause();
            statusBarPanel1.Text = "Paused";
        }
        private void Btn_Next_Click(object sender, EventArgs e)
        {
            FunObj.m_objFilterGraph = null; 
            int TotalLength = ShowPlayList.PlayListBox.Items.Count;
            string currMedia = (string)ShowPlayList.PlayListBox.SelectedItem;            
            int IndexOfCurrMedia = ShowPlayList.PlayListBox.SelectedIndex;

            if (IndexOfCurrMedia == TotalLength-1)
            {
                ShowPlayList.PlayListBox.ClearSelected();
                ShowPlayList.PlayListBox.SetSelected(0, true);
                String NewMedia = (String)ShowPlayList.PlayListBox.SelectedItem;
                play_Local(NewMedia);
                FunObj.m_objMediaPosition.CurrentPosition = c_mediaScroll.Value;
                c_mediaScroll.Maximum = (int)FunObj.m_objMediaPosition.Duration;
                c_mediaScroll.TickFrequency = 10;
                c_mediaScroll.LargeChange = 3;
                c_mediaScroll.SmallChange = 2;
                statusBarPanel1.Text = "Playing";

            }
            else
            {
                ShowPlayList.PlayListBox.ClearSelected();
                IndexOfCurrMedia = IndexOfCurrMedia + 1;
                ShowPlayList.PlayListBox.SetSelected(IndexOfCurrMedia, true);
                String NewMedia = (String)ShowPlayList.PlayListBox.SelectedItem;                
                play_Local(NewMedia);
                FunObj.m_objMediaPosition.CurrentPosition = c_mediaScroll.Value;
                c_mediaScroll.Maximum = (int)FunObj.m_objMediaPosition.Duration;
                c_mediaScroll.TickFrequency = 10;
                c_mediaScroll.LargeChange = 3;
                c_mediaScroll.SmallChange = 2;
                statusBarPanel1.Text = "Playing";

            }

        }
        private void Btn_FastBackward_Click(object sender, EventArgs e)
        {
            int iNewPosition = (int)FunObj.m_objMediaPosition.CurrentPosition - 10;
            if (iNewPosition > 0)
            {
                c_mediaScroll.Value = (int)FunObj.m_objMediaPosition.CurrentPosition - 10;
                FunObj.m_objMediaPosition.CurrentPosition = FunObj.m_objMediaPosition.CurrentPosition - 10;

            }
            else
            {
                c_mediaScroll.Value = 0;
            }
            UpdateStatusBarTime();
        }
        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            FunObj.stop();
            //change pause to play button
            Btn_Pause.Visible = false; Btn_Play.Visible = true;
            statusBarPanel1.Text = "Stopped";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int iNewPosition = (int)FunObj.m_objMediaPosition.CurrentPosition + 10;
            if (iNewPosition < (int)FunObj.m_objMediaPosition.Duration)
            {
                c_mediaScroll.Value = (int)FunObj.m_objMediaPosition.CurrentPosition + 10;
                FunObj.m_objMediaPosition.CurrentPosition = FunObj.m_objMediaPosition.CurrentPosition + 10;

            }
            else
            {
                c_mediaScroll.Value = (int)FunObj.m_objMediaPosition.Duration;
            }
            UpdateStatusBarTime();
        }
        private void Btn_PlayList_Click(object sender, EventArgs e)
        {
            
            if (check)
            {
                ShowPlayList.Show();
                check = false;
            }
            else {
                check = true;
                ShowPlayList.Hide();
            }
            ShowPlayList.StartPosition = FormStartPosition.Manual;
            ShowPlayList.Location = new Point(885, 127);
            

        }
        private void Btn_FullVol_Click(object sender, EventArgs e)
        {
            Btn_FullVol.Visible = false; btn_Mute.Visible = true;
            FunObj.m_objBasicAudio.Volume = -10000;
        }        
        private void btn_Mute_Click(object sender, EventArgs e)
        {
            btn_Mute.Visible = false; Btn_FullVol.Visible = true;
            FunObj.m_objBasicAudio.Volume = 0;
        }
        private void volume_Scroll(object sender, EventArgs e)
        {
            FunObj.m_objBasicAudio.Volume = volume.Value;
        }

       

               
    }
}