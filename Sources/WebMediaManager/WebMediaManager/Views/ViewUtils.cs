using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebMediaManager.Models;

namespace WebMediaManager.Views
{
    static class ViewUtils
    {
        public static Panel CreatePreview(StreamingSite.SVideo video)
        {
            Panel gPanel = new Panel();

            //Create the picture box
            PictureBox imgPreview = new PictureBox();
            gPanel.Size = new Size(460, 145);
            imgPreview.Size = new Size(150, 82);
            imgPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            imgPreview.Load(video.preview);

            return gPanel;
        }
    }
}
