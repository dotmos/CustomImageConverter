using MessagePack.Resolvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimationDataCreator {
    public partial class Form1 : Form {
        ComplexAnimation complexAnimationData;
        int currentFrame = -1;

        public Form1() {
            //Set MessagePack Resolvers
            CompositeResolver.RegisterAndSetAsDefault(
                DynamicObjectResolverAllowPrivate.Instance,
                StandardResolver.Instance
            );

            InitializeComponent();

            complexAnimationData = new ComplexAnimation();
            //labelFrameCount.DataBindings.Add(complexAnimationData.GetFrameCountDataBinding()); //Not working ...
            complexAnimationData.OnFrameCountChanged(ComplexDataFramecountChanged);

            IEnumerable<Animation.AnimationType> animationTypes = Enum.GetValues(typeof(Animation.AnimationType)).Cast<Animation.AnimationType>();
            foreach(Animation.AnimationType aT in animationTypes) {
                comboBoxAnimationType.Items.Add(aT.ToString());
            }
            comboBoxAnimationType.SelectedItem = null;
            comboBoxAnimationType.SelectedIndex = 1;

            UpdateFrameDataOutput(-1);
        }

        /// <summary>
        /// Called when total framecount of complex animation data is changed
        /// </summary>
        /// <param name="frameCount"></param>
        void ComplexDataFramecountChanged(int frameCount) {
            labelFrameCount.Text = frameCount.ToString();
            UpdateFrameListBoxItems(frameCount);
        }

        /// <summary>
        /// Add/Remove items to listBoxFrames based on total framecount
        /// </summary>
        /// <param name="frameCount"></param>
        void UpdateFrameListBoxItems(int frameCount) {
            if(frameCount > listBoxFrames.Items.Count) {
                while(listBoxFrames.Items.Count < frameCount) {
                    listBoxFrames.Items.Add(listBoxFrames.Items.Count);
                }
            }
            else if(frameCount < listBoxFrames.Items.Count) {
                while(listBoxFrames.Items.Count > frameCount) {
                    listBoxFrames.Items.RemoveAt(listBoxFrames.Items.Count - 1);
                }
            }

            //Select valid item in listbox if possible
            if(listBoxFrames.Items.Count > 0) {
                listBoxFrames.SelectedItem = null;
                if (currentFrame >= 0 && currentFrame < listBoxFrames.Items.Count) {
                    //Select item near/equal to current frame
                    listBoxFrames.SelectedIndex = currentFrame;
                } else {
                    //Select last item
                    listBoxFrames.SelectedIndex = listBoxFrames.Items.Count - 1;
                }
                
            }
            //Deselect listbox if there are no more items
            else if(listBoxFrames.Items.Count == 0) {
                listBoxFrames.SelectedItem = null;
            }
        }

        /// <summary>
        /// Add new frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddFrame_Click(object sender, EventArgs e) {
            complexAnimationData.AddFrame();
        }

        /// <summary>
        /// Update frame data output
        /// </summary>
        /// <param name="frame"></param>
        void UpdateFrameDataOutput(int frame) {
            simple_textBoxFrametime.Text = complexAnimationData.GetFrametime().ToString();

            if (frame >= 0) {
                textBoxFrametime.Text = complexAnimationData.GetFrametime(frame).ToString();
                textBoxImageID.Text = complexAnimationData.GetImageID(frame).ToString();
                labelSelectedFrameNumber.Text = frame.ToString();
                string _previewImagePath = complexAnimationData.GetPreviewImagePath(frame);
                if (!string.IsNullOrEmpty(_previewImagePath)) {
                    //Draw preview image
                    pictureBoxFrame.Load(_previewImagePath);
                    //Show preview image filename
                    int _cutIndex = _previewImagePath.LastIndexOf('\\');
                    if (_cutIndex > 0) {
                        labelImageFilename.Text = _previewImagePath.Remove(0, _cutIndex + 1);
                    } else {
                        labelImageFilename.Text = _previewImagePath;
                    }
                } else {
                    labelImageFilename.Text = "";
                    pictureBoxFrame.Image = null;
                }
            } else {
                textBoxFrametime.Text = "n/a";
                textBoxImageID.Text = "n/a";
                labelSelectedFrameNumber.Text = "n/a";
                labelImageFilename.Text = "";
                pictureBoxFrame.Image = null;
            }
            
        }

        /// <summary>
        /// User clicked on a frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxFrames_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBoxFrames.SelectedItem != null) {
                currentFrame = listBoxFrames.SelectedIndex;
                UpdateFrameDataOutput(currentFrame);
            } else {
                currentFrame = -1;
                UpdateFrameDataOutput(currentFrame);
            }
        }

        /// <summary>
        /// Image ID of current frame changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxImageID_TextChanged(object sender, EventArgs e) {
            if(currentFrame >= 0) {
                int _imageID;
                if(int.TryParse(textBoxImageID.Text, out _imageID)) {
                    complexAnimationData.SetImageID(currentFrame, _imageID);
                }
            }
        }

        /// <summary>
        /// Frametime of current frame changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFrametime_TextChanged(object sender, EventArgs e) {
            if (currentFrame >= 0) {
                int _frametime;
                if (int.TryParse(textBoxFrametime.Text, out _frametime)) {
                    complexAnimationData.SetFrametime(currentFrame, _frametime);
                }
            }
        }

        private void buttonLoadImage_Click(object sender, EventArgs e) {
            if(currentFrame >= 0) {
                openImageFileDialog.Multiselect = false;

                //Show dialog for opening an image file
                //If user clicks ok, load image into mainPictureBox
                if (openImageFileDialog.ShowDialog() == DialogResult.OK) {
                    //If this is a "simple" image, open and display it
                    if (openImageFileDialog.SafeFileName.Contains(".png")
                        || openImageFileDialog.SafeFileName.Contains(".bmp")
                        || openImageFileDialog.SafeFileName.Contains(".jpg")) {
                        //pictureBoxFrame.Load(openImageFileDialog.FileName);
                        complexAnimationData.SetPreviewImagePath(currentFrame, openImageFileDialog.FileName);
                        UpdateFrameDataOutput(currentFrame);
                    } else //Try to decode
                      {
                        /*
                        imageConverter.Decode(System.IO.File.ReadAllBytes(openImageFileDialog.FileName));
                        if (imageConverter.Source != null) {
                            mainPictureBox.Image = (Image)imageConverter.Source;
                        }
                        */
                    }

                }
            }
            
        }

        private void buttonDeleteFrame_Click(object sender, EventArgs e) {
            if(currentFrame >= 0) {
                complexAnimationData.RemoveFrame(currentFrame);
            }
        }

        /// <summary>
        /// Create new animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            complexAnimationData.Reset();
            UpdateFrameDataOutput(-1);
        }

        /// <summary>
        /// Save current animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (saveAnimationFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                SaveAnimation(saveAnimationFileDialog.FileName);
            }
        }

        void SaveAnimation(string pathToFile) {            
            //complexAnimationData.SerializeToBytes();

            //Save animation
            //System.IO.File.WriteAllBytes(pathToFile, complexAnimationData.SerializeToBytes());
            System.IO.File.WriteAllText(pathToFile, complexAnimationData.SerializeToJson());
        }

        /// <summary>
        /// Open an animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openAnimationFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string data = System.IO.File.ReadAllText(openAnimationFileDialog.FileName);
                complexAnimationData.DeserializeFromJson(data);
                UpdateFrameDataOutput(complexAnimationData.GetFrameCount()-1);
            }
        }

        /// <summary>
        /// Quit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void comboBoxAnimationType_SelectedIndexChanged(object sender, EventArgs e) {
            complexAnimationData.SetAnimationType((Animation.AnimationType)Enum.Parse(typeof(Animation.AnimationType), (string)comboBoxAnimationType.SelectedItem));
            if(complexAnimationData.GetAnimationType() == Animation.AnimationType.Complex) {
                tableLayoutPanelComplexAnimation.Visible = true;
                tableLayoutPanelSimpleAnimation.Visible = false;
            }
            else if(complexAnimationData.GetAnimationType() == Animation.AnimationType.Simple) {
                tableLayoutPanelComplexAnimation.Visible = false;
                tableLayoutPanelSimpleAnimation.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void simple_textBoxFrametime_TextChanged(object sender, EventArgs e) {
            int _frametime;
            if(int.TryParse(simple_textBoxFrametime.Text, out _frametime)) {
                complexAnimationData.SetFrametime(_frametime);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
            if (saveExportFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                System.IO.File.WriteAllBytes(saveExportFileDialog.FileName, complexAnimationData.ExportToBytes());
            }
        }
    }
}
