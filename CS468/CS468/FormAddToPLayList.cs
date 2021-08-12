using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CS468
{
    public partial class FormAddToPLayList : Form
    {
        public FormAddToPLayList()
        {
            InitializeComponent();
            loadDataForComboBox();
        }

        public FormAddToPLayList(string song)
        {
            InitializeComponent();
            loadDataForComboBox();
            this.song = song;
        }

        string song = null;
        public void loadDataForComboBox()
        {
            SqlConnection connection = null;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
            string query = "select playlistName from Playlists";

            try
            {
                DataSet data = Database.ExecuteQuery(connection, query, connectionString, CommandType.Text);
                comboBox1.DataSource = data.Tables[0];
                comboBox1.DisplayMember = "playlistName";
                comboBox1.ValueMember = "playlistName";
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            string playlistName = comboBox1.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
           
            SqlParameter playlistid = new SqlParameter("@playlistid", SqlDbType.Int);
            playlistid.Value = 1;
            SqlParameter songid = new SqlParameter("@songid", SqlDbType.Int);
            songid.Value = 3;
            SqlParameter favorites = new SqlParameter("@favorites", SqlDbType.Int);
            favorites.Value = 1;
            string query = "sp_updatePlaylist";

            try
            {
                int rowAffected = Database.ExecuteNonQuery(connectionString, query, CommandType.StoredProcedure, playlistid, songid, favorites);
                if (rowAffected > 0)
                {
                    MessageBox.Show("Successfully add to playlist");
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
