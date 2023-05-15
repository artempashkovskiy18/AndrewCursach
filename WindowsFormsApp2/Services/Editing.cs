using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp2.Constants;

namespace WindowsFormsApp2.Services
{
    public class Editing
    {
        public Image AddPicture(PictureBox pictureBox)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image image = Bitmap.FromFile(openFile.FileName);
                    pictureBox.Image = image;
                    pictureBox.Invalidate();
                    return image;
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return null;
        }

        public void SavePicture(Bitmap image, int slideNumber, PresentationTypes type)
        {
            string path = GetFullPathToSlideFolder(slideNumber, type);
            if (Directory.Exists(path))
            {
                path += Paths.IMAGE_NAME;
            }
            else
            {
                Directory.CreateDirectory(path);
                path += Paths.IMAGE_NAME;
            }

            image.Save(path, ImageFormat.Jpeg);
        }
        
        public void SaveText(string text, int slideNumber, PresentationTypes type)
        {
            string path = GetFullPathToSlideFolder(slideNumber, type);
            if (Directory.Exists(path))
            {
                path += Paths.TEXT_NAME;
            }
            else
            {
                Directory.CreateDirectory(path);
                path += Paths.TEXT_NAME;
            }
            
            if (!File.Exists(path))
            {
                using (File.Create(path)) {}
            }
            
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(text);
            }
        }

        public Bitmap GetPicture(int slideNumber, PresentationTypes type)
        {
            string path = GetFullPathToSlideFolder(slideNumber, type);
            path += Paths.IMAGE_NAME;
            Bitmap image;
            try
            {
                image = GetBitmapAndCloseFile(path);
            }
            catch (Exception e)
            {
                image = null;
            }

            return image;
        }
        
        public string GetText(int slideNumber, PresentationTypes type)
        {
            string path = GetFullPathToSlideFolder(slideNumber, type);
            path += Paths.TEXT_NAME;
            string result;
            try
            {
                result = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                result = null;
            }

            return result;
        }
        
        public void DeleteSlide(int slideNumber, PresentationTypes type, int slidesAmount)
        {
            string path = GetFullPathToSlideFolder(slideNumber, type);
            
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }

            string newPath;
            if (slideNumber < slidesAmount)
            {
                for (int i = slideNumber + 1; i <= slidesAmount; i++)
                {
                    path = GetFullPathToSlideFolder(i, type);
                    newPath = GetFullPathToSlideFolder(i - 1, type);
                    if (Directory.Exists(path))
                    {
                        Directory.Move(path, newPath);
                    }
                }
            }
        }

        public int GetSlidesAmount(PresentationTypes type)
        {
            string path = "";
            switch (type)
            {
                case PresentationTypes.AUTOCAD:
                    path += Paths.AUTOCAD_PATH;
                    break;
                case PresentationTypes.THREEDS:
                    path += Paths.THREEDS_PATH;
                    break;
                case PresentationTypes.ANIMATE:
                    path += Paths.ANIMATE_PATH;
                    break;
                case PresentationTypes.OKD:
                    path += Paths.OKD_PATH;
                    break;
            }

            return Directory.GetDirectories(path).Length;
        }

        private string GetFullPathToSlideFolder(int slideNumber, PresentationTypes type)
        {
            string path = "";
            switch (type)
            {
                case PresentationTypes.AUTOCAD:
                    path += Paths.AUTOCAD_PATH;
                    break;
                case PresentationTypes.THREEDS:
                    path += Paths.THREEDS_PATH;
                    break;
                case PresentationTypes.ANIMATE:
                    path += Paths.ANIMATE_PATH;
                    break;
                case PresentationTypes.OKD:
                    path += Paths.OKD_PATH;
                    break;
            }

            path += String.Format(Paths.SLIDES_FOLDER, slideNumber);
            return path;
        }

        private Bitmap GetBitmapAndCloseFile(string path)
        {
            Bitmap bitmap;

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                bitmap = new Bitmap(stream);
            }

            return bitmap;
        }
        
        
    }
}