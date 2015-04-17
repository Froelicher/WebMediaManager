using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestNotif
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Configuration d'un Notification windows
            popupNotifier1.TitleText = "NOM DU STREAM";
            popupNotifier1.ContentText = "NOM DU JEUX \nNOM DE LA CHAINE \nNB VIEWERS";
            popupNotifier1.ContentPadding = new Padding(1);
            popupNotifier1.TitlePadding = new Padding(1);
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData("http://static-cdn.jtvnw.net/previews-ttv/live_user_ogaminglol-320x180.jpg");
            MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

            //Redimmensionnement pour une image de base de 320x180
            System.Drawing.Size sizeimg = new System.Drawing.Size(150, 82);

            popupNotifier1.Image = img;
            popupNotifier1.ImagePadding = new Padding(5);
            popupNotifier1.ImageSize = sizeimg;

            popupNotifier1.Popup();
            
        }
    }
}
