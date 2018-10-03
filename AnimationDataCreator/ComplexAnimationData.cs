using MessagePack;
using MessagePack.Resolvers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimationDataCreator {

    [MessagePackObject]
    public class Animation {
        public enum AnimationType : int {
            Simple = 0,
            Complex = 1
        }
        /// <summary>
        /// Animation type
        /// </summary>
        [Key(0)]
        protected AnimationType animationType = AnimationType.Simple;

        /// <summary>
        /// Frametime between frames for simple animation.
        /// </summary>
        [Key(1)]
        protected int frametime;

        public void SetAnimationType(AnimationType animationType) {
            this.animationType = animationType;
        }

        public AnimationType GetAnimationType() {
            return this.animationType;
        }

        public void SetFrametime(int frametime) {
            this.frametime = frametime;
        }

        public int GetFrametime() {
            return this.frametime;
        }
    }

    [MessagePackObject]
    public class ComplexAnimation : Animation {

        [MessagePackObject]
        public class FrameData {
            /// <summary>
            /// ID of the image to draw
            /// </summary>
            [Key(0)]
            public int imageID;

            /// <summary>
            /// Time in milliseconds to show the image before drawing the next image
            /// </summary>
            [Key(1)]
            public int frameTime = 128;

            /// <summary>
            /// Preview image for the frame. Optional.
            /// </summary>
            //public Image previewImage;


            /// <summary>
            /// Path to preview image. Optional.
            /// </summary>
            [Key(2)]
            public string previewImagePath;
        }

        [Key(2)]
        ObservableCollection<FrameData> data;

        public ComplexAnimation() {
            SetAnimationType(AnimationType.Complex);
            data = new ObservableCollection<FrameData>();
        }

        public void OnFrameCountChanged(Action<int> onFrameCountChanged) {
            data.CollectionChanged += (sender, args) => {
                onFrameCountChanged(data.Count);
            };
        }

        /*
        //Commented out, as this is not working.
        Binding listCountDataBinding = null;
        Binding ListCountDataBinding {
            get {
                if (listCountDataBinding == null) {
                    listCountDataBinding = new Binding("Text", data, "Count", true);
                    listCountDataBinding.Format += (sender, e) => {
                        e.Value = string.Format("{0} items", e.Value);
                    };
                }
                return listCountDataBinding;
            }
        }

        /// <summary>
        /// Returns a binding for the total framecount
        /// </summary>
        /// <returns></returns>
        public Binding GetFrameCountDataBinding() {
            return ListCountDataBinding;
        }
        */

            
        
        bool HasFrameData(int frame) {
            if(frame < data.Count) {
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// Add a new frame
        /// </summary>
        public int AddFrame() {
            data.Add(new FrameData());
            return data.Count - 1;
        }

        /// <summary>
        /// Remove the frame
        /// </summary>
        /// <param name="frame"></param>
        public void RemoveFrame(int frame) {
            if(HasFrameData(frame)) {
                data.RemoveAt(frame);
            }
        }

        /// <summary>
        /// Get total frame count
        /// </summary>
        /// <returns></returns>
        public int GetFrameCount() {
            return data.Count;
        }

        /// <summary>
        /// Set the image to be used for the frame
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="imageID"></param>
        public void SetImageID(int frame, int imageID) {
            if(HasFrameData(frame)) {
                data[frame].imageID = imageID;
            }
        }

        /*
        public void SetPreviewImage(int frame, Image image) {
            if (HasFrameData(frame)) {
                data[frame].previewImage = image;
            }
        }

        public Image GetPreviewImage(int frame) {
            if (HasFrameData(frame)) {
                return data[frame].previewImage;
            } else return null;
        }
        */

        public void SetPreviewImagePath(int frame, string path) {
            if (HasFrameData(frame)) {
                data[frame].previewImagePath = path;
            }
        }

        public string GetPreviewImagePath(int frame) {
            if (HasFrameData(frame)) {
                return data[frame].previewImagePath;
            } else return null;
        }

        /// <summary>
        /// Set the frametime in milliseconds for the frame
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="frameTime"></param>
        public void SetFrametime(int frame, int frameTime) {
            if(HasFrameData(frame)) {
                data[frame].frameTime = frameTime;
            }
        }

        public int GetFrametime(int frame) {
            if (HasFrameData(frame)) {
                return data[frame].frameTime;
            } else return -1;
        }

        public int GetImageID(int frame) {
            if (HasFrameData(frame)) {
                return data[frame].imageID;
            } else return -1;
        }

        public void Reset() {
            SetAnimationType(AnimationType.Simple);
            data.Clear();
        }

        /// <summary>
        /// Serialize the current data
        /// </summary>
        /// <returns></returns>
        public byte[] SerializeToBytes() {
            return MessagePackSerializer.Serialize(this);
        }

        public string SerializeToJson() {
            return MessagePackSerializer.ToJson(this);
        }

        /// <summary>
        /// Deserialize data
        /// </summary>
        /// <param name="data"></param>
        public void DeserializeFromBytes(byte[] data) {
            ComplexAnimation _newData = MessagePackSerializer.Deserialize<ComplexAnimation>(data);
            this.CopyFromInstance(_newData);
        }

        public void DeserializeFromJson(string json) {
            DeserializeFromBytes(MessagePackSerializer.FromJson(json));
        }

        void CopyFromInstance(ComplexAnimation animationInstance) {
            Reset();
            SetAnimationType(animationInstance.GetAnimationType());
            SetFrametime(animationInstance.GetFrametime());
            foreach (FrameData d in animationInstance.data) {
                this.data.Add(d);
            }
            animationInstance.data.Clear();
        }
    }
}