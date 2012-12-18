using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GRSPlayer
{
    public partial class PlayList : Form
    {
        // FunObj object of Function class
        functions FunObj = new functions();

        //member object of GRSForm class
        GRSForm m_objGRSForm;

        public PlayList(GRSForm refObjGRSForm)
        {
            InitializeComponent();
            btn_PlaylistSave.Enabled = false;
            m_objGRSForm = refObjGRSForm;
        }
        
        // invoked when Add button is clicked in PlayList form
        private void btn_PlaylistAdd_Click(object sender, EventArgs e)
        {
            String[] Name;
            Name = FunObj.C_OpenFileDialogBox("Open File", "", "All files(*.*)|*.*", "false", "true", "true");
            if (Name != null)
            {               
                PlayListBox.Items.AddRange(Name);
                PlayListBox.SetSelected(0, true);
                string currMedia =(string) PlayListBox.SelectedItem;               
                //FunObj.play(currMedia);
                m_objGRSForm.play_Local(currMedia);
                m_objGRSForm.Btn_Play.Hide();

            }
            
        }
        // Invoked when Items of Playlist removed
        private void btn_PlaylistRemove_Click(object sender, EventArgs e)
        {
            while (PlayListBox.SelectedItem != null) 
            {
                PlayListBox.Items.Remove(PlayListBox.SelectedItem);
            }
            
        }

        // To save Playlist
        private void btn_PlaylistSave_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            for (int t = 0; t < PlayListBox.Items.Count; t++)
            {
                PlayListBox.SetSelected(t, true);
                list.Add(PlayListBox.SelectedItems[t].ToString());
            }
            // C_WritePlayListFile(NameOfFile,Array)
            // To write playlist file in Binary format
            FunObj.C_WritePlayListFile(PlayListName.Text + ".grs", list);
       }

        private void Enabled_Save(object sender, EventArgs e)
        {
            btn_PlaylistSave.Enabled = true;       
        }
    }
}

