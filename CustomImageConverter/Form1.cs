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
                    imageConverter.converterScriptName = scriptListBox.SelectedItem as string;
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
            if (fitImageCheckBox.Checked)
                mainPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            else
                mainPictureBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            //Do nothing if no images has been loaded
            if (mainPictureBox.Image == null)
                return;

            //Convert image
            SetSaveName(fileName);
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

                SetSaveName(openImageFileDialog.FileNames[0]);

                if (saveImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Create naming sheme for batch conversion saves
                    int _cutIndex = saveImageFileDialog.FileName.LastIndexOf('.');
                    string _saveFileName = saveImageFileDialog.FileName;
                    string _saveFileEnding = saveImageFileDialog.FileName;
                    if (_cutIndex > 0)
                    {
                        _saveFileName = _saveFileName.Remove(_cutIndex);
                        _saveFileEnding = _saveFileEnding.Remove(0, _cutIndex);
                    }
                    else
                    {
                        _saveFileEnding = "";
                    }

                    progressBar.Maximum = openImageFileDialog.FileNames.Length;

                    //Start batch conversion
                    for (int i = 0; i < openImageFileDialog.FileNames.Length; ++i )
                    {
                        SetPicture(openImageFileDialog.FileNames[i]);
                        if (mainPictureBox.Image == null)
                            continue;
                        EncodeAndSave((Bitmap)mainPictureBox.Image, _saveFileName + i.ToString() + _saveFileEnding);
                        progressBar.Value = i;
                    }

                    progressBar.Value = 0;
                    progressBar.Maximum = 0;
                    
                    MessageBox.Show("All Done!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
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

        void SetSaveName(string inFilename)
        {
            //Set export name to import name, but with other ending
            saveImageFileDialog.FileName = inFilename;
            //Remove file ending
            int _cutIndex = saveImageFileDialog.FileName.LastIndexOf('.');
            if (_cutIndex > 0)
                saveImageFileDialog.FileName = saveImageFileDialog.FileName.Remove(_cutIndex);
            //remove folders
            _cutIndex = saveImageFileDialog.FileName.LastIndexOf('\\');
            if (_cutIndex > 0)
                saveImageFileDialog.FileName = saveImageFileDialog.FileName.Remove(0, _cutIndex + 1);
        }

        void InitializeScriptListBox()
        {
            string[] _scripts = System.IO.Directory.GetFiles(scriptPath, "*.cs", System.IO.SearchOption.AllDirectories);
            foreach (string s in _scripts)
                scriptListBox.Items.Add(s.Remove(0,scriptPath.Length));

            if(_scripts.Length > 0)
                scriptListBox.SelectedItem = _scripts[0].Remove(0, scriptPath.Length);
        }

        /// <summary>
        /// Encode the bitmap and save it at path
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
            imageConverter.converterScriptName = scriptListBox.SelectedItem as string;
            byte[] _data = imageConverter.Encode();
            System.IO.File.WriteAllBytes(path, _data);
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

    }
}
