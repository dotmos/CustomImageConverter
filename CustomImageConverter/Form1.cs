using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomImageConverter
{
    public partial class Form1 : Form
    {
        static readonly string scriptPath = @".\ConverterScripts\";
        private string fileName; //Current name of the selected image
        ImageConverter imageConverter = new ImageConverter();
        //Needed for dithering checkbox to restore original image
        Bitmap originalImage;
        DitheringHelper ditheringHelper = new DitheringHelper();

        public Form1()
        {
            InitializeComponent();

            CheckFitImage();
            InitializeScriptListBox();

            //saveImageFileDialog.Filter = "Binary(*.bin) | *.bin | All files(*.*) | *.*";
            saveImageFileDialog.Filter = "All files(*.*) | *.*";

            //Load first converter
            //if(scriptListBox.Items.Count > 0) imageConverter.LoadScript(scriptListBox.Items[0] as string);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            mainPictureBox.Image = null;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openImageFileDialog.Multiselect = false;

            //Show dialog for opening an image file
            //If user clicks ok, load image into mainPictureBox
            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                //If this is a "simple" image, open and display it
                if (openImageFileDialog.SafeFileName.Contains(".png")
                    || openImageFileDialog.SafeFileName.Contains(".bmp")
                    || openImageFileDialog.SafeFileName.Contains(".jpg"))
                {
                    SetPicture(openImageFileDialog.FileName);
                }
                else //Try to decode
                {
                    imageConverter.Decode(System.IO.File.ReadAllBytes(openImageFileDialog.FileName));
                    if (imageConverter.Source != null)
                    {
                        mainPictureBox.Image = (Image)imageConverter.Source;
                    }
                }

            }
        }

        private void fitImageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckFitImage();
        }

        void CheckFitImage()
        {
            if (fitImageCheckBox.Checked) {
                mainPictureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                mainPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            } else {
                mainPictureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
                mainPictureBox.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            //Do nothing if no images has been loaded
            if (mainPictureBox.Image == null)
                return;

            //Convert image
            SetSaveDialogFileName(fileName);
            //Open save as dialog
            if (saveImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EncodeAndSave((Bitmap)mainPictureBox.Image, saveImageFileDialog.FileName);
            }
        }

        private void batchConvertButton_Click(object sender, EventArgs e)
        {
            openImageFileDialog.Multiselect = true;
            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openImageFileDialog.FileNames.Length == 0)
                    return;

                string[] fileNames = openImageFileDialog.FileNames;

                progressBar.Maximum = openImageFileDialog.FileNames.Length;

                //Start batch conversion
                for (int i = 0; i < openImageFileDialog.FileNames.Length; ++i )
                {
                    string fileName = fileNames[i];
                
                    //Save
                    SetPicture(fileName);
                    if (mainPictureBox.Image == null)
                        continue;
                    EncodeAndSave((Bitmap)mainPictureBox.Image, fileName);
                    progressBar.Value = i;
                }

                progressBar.Value = 0;
                progressBar.Maximum = 0;
                    
                MessageBox.Show("All Done!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }


        /// <summary>
        /// Set the current picture to use for converting
        /// </summary>
        /// <param name="inFilename"></param>
        void SetPicture(string inFilename)
        {
            fileName = inFilename;
            mainPictureBox.Load(inFilename);

            CheckDithering(true);
        }

        /// <summary>
        /// Sets the filename for the savedialog based on image path
        /// </summary>
        /// <param name="pathToImage"></param>
        void SetSaveDialogFileName(string pathToImage)
        {
            saveImageFileDialog.FileName = pathToImage;

            //Remove folders
            int _cutIndex = saveImageFileDialog.FileName.LastIndexOf('\\');
            if (_cutIndex > 0)
                saveImageFileDialog.FileName = saveImageFileDialog.FileName.Remove(0, _cutIndex + 1);

            //Remove file ending
            _cutIndex = saveImageFileDialog.FileName.LastIndexOf('.');
            if (_cutIndex > 0)
                saveImageFileDialog.FileName = saveImageFileDialog.FileName.Remove(_cutIndex);

            //Set new file ending, based on selected converter
            saveImageFileDialog.FileName = saveImageFileDialog.FileName  + "." + imageConverter.GetFileEnding();
        }
        
        /// <summary>
        /// Initialize the script list box
        /// </summary>
        void InitializeScriptListBox()
        {
            //Load all converter scripts
            string[] _scripts = System.IO.Directory.GetFiles(scriptPath, "*.cs", System.IO.SearchOption.AllDirectories);
            foreach (string s in _scripts)
                scriptListBox.Items.Add(s.Remove(0,scriptPath.Length));

            //Select first script in list
            if(_scripts.Length > 0)
                scriptListBox.SelectedItem = _scripts[0].Remove(0, scriptPath.Length);
        }

        /// <summary>
        /// Encode the bitmap and save it at path. Filenending is auto appended based on selected encoder.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="path"></param>
        void EncodeAndSave(Bitmap b, string path)
        {
            if (scriptListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a converter script.", "Note", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            imageConverter.Source = b;
            byte[] _data = imageConverter.Encode();

            //Remove file ending
            int _cutIndex = path.LastIndexOf('.');
            if(_cutIndex > 0) path = path.Remove(_cutIndex);

            //Save converted image
            System.IO.File.WriteAllBytes(path + "." + imageConverter.GetFileEnding(), _data);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ditheringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckDithering();
        }

        void CheckDithering(bool refetchOriginalImage = false)
        {
            if (mainPictureBox.Image == null)
                return;

            if (ditheringCheckBox.Checked)
            {
                //if (originalImage != null)
                //    originalImage.Dispose();
                originalImage = new Bitmap(mainPictureBox.Image);
                mainPictureBox.Image = (Image)ditheringHelper.ApplyDithering((Bitmap)originalImage);
            }
            else
            {
                //When loading a new image from a file, original image should be refetched
                if (refetchOriginalImage)
                {
                    if (originalImage != null)
                        originalImage.Dispose();
                    originalImage = new Bitmap(mainPictureBox.Image);
                }
                mainPictureBox.Image = (Image)originalImage;
            }
        }

        /// <summary>
        /// Set and load converter script
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scriptListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(scriptListBox.SelectedItem != null) {
                imageConverter.LoadScript(scriptListBox.SelectedItem as string);
            }
        }
    }
}
