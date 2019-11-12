using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ComputerVision101
{
    public partial class Form1 : Form
    {

        public double ScaleFactor { get; set; }
        public int MinimumNeighbours { get; set; }
        public int MinimumFaceSize { get; set; }
        public int MaximumFaceSize { get; set; }
        public int MinFSDetected { get; set; }
        public int MaxFSDetected { get; set; }

        public readonly List<string> ImageExtensions = new List<string> { ".jpg", ".jpe", "jpeg", ".bmp", ".gif", ".png" }; // Will do for now
        private bool STOP = false;


        private string wd = "";
        private string FrontalFaceAlt2HaarPath = "";
        private string EyeHaarPath = "";
        private string ProfileFaceHaarPath = "";
        private string parojosGPath = "";
        private string parojosPath = "";
        private string ojoIPath = "";
        private string ojoDPath = "";
        private string NarizPath = "";
        private string MouthPath = "";
        private string HSPath = "";
        private string upperbodyPath = "";
        private string lowerbodyPath = "";
        private string fullbodyPath = "";
        private string frontalEyesPath = "";

        public Form1()
        {
            InitializeComponent();
            try
            {
                ScaleFactor = 1.1d; tbAutoscaleFactor.Text = ScaleFactor.ToString();
                MinimumNeighbours = 4; tbMinNeighbours.Text = MinimumNeighbours.ToString();
                MinimumFaceSize = 10; tbMinFaceSize.Text = MinimumFaceSize.ToString();
                MaximumFaceSize = 100; tbMaxFaceSize.Text = MaximumFaceSize.ToString();
                this.Refresh();

                wd = Directory.GetCurrentDirectory();
                FrontalFaceAlt2HaarPath = Path.Combine(wd, "Cascades\\haarcascade_frontalface_alt2.xml"); // Remember when changing the cascade to change the detect cascade below
                EyeHaarPath = Path.Combine(wd, "Cascades\\haarcascade_eye.xml");
                ProfileFaceHaarPath = Path.Combine(wd, "Cascades\\haarcascade_profileface.xml");
                parojosGPath = Path.Combine(wd, "Cascades\\parojosG.xml");
                parojosPath = Path.Combine(wd, "Cascades\\parojos.xml");
                ojoIPath = Path.Combine(wd, "Cascades\\ojoI.xml");
                ojoDPath = Path.Combine(wd, "Cascades\\ojoD.xml");
                NarizPath = Path.Combine(wd, "Cascades\\Nariz.xml");
                MouthPath = Path.Combine(wd, "Cascades\\Mouth.xml");
                HSPath = Path.Combine(wd, "Cascades\\HS.xml");
                upperbodyPath = Path.Combine(wd, "Cascades\\haarcascade_upperbody.xml");
                lowerbodyPath = Path.Combine(wd, "Cascades\\haarcascade_lowerbody.xml");
                fullbodyPath = Path.Combine(wd, "Cascades\\haarcascade_fullbody.xml");
                frontalEyesPath = Path.Combine(wd, "Cascades\\frontalEyes35x16.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {

            if (btnStartStop.Text != "Stop")
            {
                try
                {
                    ScaleFactor = double.Parse(tbAutoscaleFactor.Text);
                    MinimumNeighbours = int.Parse(tbMinNeighbours.Text);
                    MinimumFaceSize = int.Parse(tbMinFaceSize.Text);
                    MaximumFaceSize = int.Parse(tbMaxFaceSize.Text);
                    MinFSDetected = 32500; // Just set it large for now - it will be corrected automatically within the program
                }
                catch (Exception)
                {
                    // Just keep with the defaults for now.
                }


                DialogResult dr = FBD.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    btnStartStop.Text = "Stop";
                    var files = Directory.GetFiles(FBD.SelectedPath, "*.*", System.IO.SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        if (STOP) break; // Exit the loop if the StartStop button is pressed

                        FileInfo finfo = new FileInfo(file);
                        if (ImageExtensions.Contains(finfo.Extension.ToLowerInvariant()) && finfo.Length > 0)
                        {
                            try
                            {
                                // Refactored code

                                // Load Original image
                                Image<Rgb, Byte> Original = new Image<Rgb, byte>(file);                                 // Needs Disposing at End
                                Image<Gray, Byte> Greyscale = Original.Convert<Gray, Byte>();                           // Needs Disposing at End

                                // Setup the processing tasks
                                ParallelOptions po = new ParallelOptions();
                                po.MaxDegreeOfParallelism = Environment.ProcessorCount;

                                Task<Rectangle[]>[] allTasks = new Task<Rectangle[]>[14];



                                Task<Rectangle[]> taskProfileFace = new Task<Rectangle[]>(() => processProfileFace(Greyscale));                       // Detect faces in Greyscale image
                                Task<Rectangle[]> taskEye = new Task<Rectangle[]>(() => processEye(Greyscale));     // Detect Eyes in Greyscale image 
                                Task<Rectangle[]> taskFrontalFaceAlt2 = new Task<Rectangle[]>(() => processFrontalFaceAlt2(Greyscale));               // Detect faces in Greyscale image
                                Task<Rectangle[]> taskParojosG = new Task<Rectangle[]>(() => processParojosG(Greyscale));                       // Detect faces in Greyscale image
                                Task<Rectangle[]> taskParojos = new Task<Rectangle[]>(() => processParojos(Greyscale));     // Detect faces in Greyscale image + Normalised Histogram
                                Task<Rectangle[]> taskOjoI = new Task<Rectangle[]>(() => processOjoI(Greyscale));               // Detect faces in Greyscale image + Normalised Histogram + Gama Correction
                                Task<Rectangle[]> taskOjoD = new Task<Rectangle[]>(() => processOjoD(Greyscale));                       // Detect faces in Greyscale image
                                Task<Rectangle[]> taskNariz = new Task<Rectangle[]>(() => processNariz(Greyscale));     // Detect faces in Greyscale image + Normalised Histogram
                                Task<Rectangle[]> taskMouth = new Task<Rectangle[]>(() => processMouth(Greyscale));               // Detect faces in Greyscale image + Normalised Histogram + Gama Correction
                                Task<Rectangle[]> taskHS = new Task<Rectangle[]>(() => processHS(Greyscale));                       // Detect faces in Greyscale image
                                Task<Rectangle[]> taskUpperBody = new Task<Rectangle[]>(() => processUpperBody(Greyscale));     // Detect faces in Greyscale image + Normalised Histogram
                                Task<Rectangle[]> taskLowerBody = new Task<Rectangle[]>(() => processLowerBody(Greyscale));               // Detect faces in Greyscale image + Normalised Histogram + Gama Correction
                                Task<Rectangle[]> taskFullBody = new Task<Rectangle[]>(() => processFullBody(Greyscale));                       // Detect faces in Greyscale image
                                Task<Rectangle[]> taskFrontalEye = new Task<Rectangle[]>(() => processFrontalEye(Greyscale));     // Detect faces in Greyscale image + Normalised Histogram

                                // Add all the tasks to a task array for use later when waiting all the tasks.
                                // There are better ways of doing all this task work, but none more clear in my opinion.
                                allTasks[0] = taskProfileFace;
                                allTasks[1] = taskEye;
                                allTasks[2] = taskFrontalFaceAlt2;
                                allTasks[3] = taskParojosG;
                                allTasks[4] = taskParojos;
                                allTasks[5] = taskOjoI;
                                allTasks[6] = taskOjoD;
                                allTasks[7] = taskNariz;
                                allTasks[8] = taskMouth;
                                allTasks[9] = taskHS;
                                allTasks[10] = taskUpperBody;
                                allTasks[11] = taskLowerBody;
                                allTasks[12] = taskFullBody;
                                allTasks[13] = taskFrontalEye;

                                // Start the Processing Tasks
                                taskProfileFace.Start();
                                taskEye.Start();
                                taskFrontalFaceAlt2.Start();
                                taskParojosG.Start();
                                taskParojos.Start();
                                taskOjoI.Start();
                                taskOjoD.Start();
                                taskNariz.Start();
                                taskMouth.Start();
                                taskHS.Start();
                                taskUpperBody.Start();
                                taskLowerBody.Start();
                                taskFullBody.Start();
                                taskFrontalEye.Start();

                                Task.WaitAll(allTasks, new CancellationToken(STOP)); // Wait for all the tasks to complete

                                if (STOP)    // If the tasks were cancelled STOP will be true so tidy up and leave
                                {
                                    Original.Dispose();
                                    Greyscale.Dispose();
                                    break;
                                }
                                else        // Get results from the processing Tasks once they have all completed
                                {
                                    Rectangle[] ProfileFaceRectangles = taskProfileFace.Result;
                                    Rectangle[] EyeRectangles = taskEye.Result;
                                    Rectangle[] FrontalFaceAlt2Rectangles = taskFrontalFaceAlt2.Result;
                                    Rectangle[] ParajosGRectangles = taskParojosG.Result;
                                    Rectangle[] ParajosRectangles = taskParojos.Result;
                                    Rectangle[] OjoIRectangles = taskOjoI.Result;
                                    Rectangle[] OjoDRectangles = taskOjoD.Result;
                                    Rectangle[] NarizRectangles = taskNariz.Result;
                                    Rectangle[] MouthRectangles = taskMouth.Result;
                                    Rectangle[] HSRectangles = taskHS.Result;
                                    Rectangle[] UpperBodyRectangles = taskUpperBody.Result;
                                    Rectangle[] LowerBodyRectangles = taskLowerBody.Result;
                                    Rectangle[] FullBodyRectangles = taskFullBody.Result;
                                    Rectangle[] FrontalEyeRectangles = taskFrontalEye.Result;



                                    // We don't need the greyscale image any more so we can dispose of it now
                                    Greyscale.Dispose();

                                    // How many features have been found? Need the max for the progress bar!
                                    int max = ProfileFaceRectangles.Count();
                                    max += EyeRectangles.Count();
                                    max += FrontalFaceAlt2Rectangles.Count();
                                    max += ParajosGRectangles.Count();
                                    max += ParajosRectangles.Count();
                                    max += OjoIRectangles.Count();
                                    max += OjoDRectangles.Count();
                                    max += NarizRectangles.Count();
                                    max += MouthRectangles.Count();
                                    max += HSRectangles.Count();
                                    max += UpperBodyRectangles.Count();
                                    max += LowerBodyRectangles.Count();
                                    max += FullBodyRectangles.Count();
                                    max += FrontalEyeRectangles.Count();
                                    progressThisPicture.Maximum = max;

                                    progressThisPicture.Value = 0;
                                    int iterations = 0;

                                    // Map results on to the Original image
                                    AddRectanglesToOriginalImage(Original, ProfileFaceRectangles, Color.AliceBlue);
                                    AddRectanglesToOriginalImage(Original, EyeRectangles, Color.Azure);
                                    AddRectanglesToOriginalImage(Original, FrontalFaceAlt2Rectangles, Color.Beige);
                                    AddRectanglesToOriginalImage(Original, ParajosGRectangles, Color.Black);
                                    AddRectanglesToOriginalImage(Original, ParajosRectangles, Color.BlueViolet);
                                    AddRectanglesToOriginalImage(Original, OjoIRectangles, Color.CadetBlue);
                                    AddRectanglesToOriginalImage(Original, OjoDRectangles, Color.Coral);
                                    AddRectanglesToOriginalImage(Original, NarizRectangles, Color.DarkCyan);
                                    AddRectanglesToOriginalImage(Original, MouthRectangles, Color.ForestGreen);
                                    AddRectanglesToOriginalImage(Original, UpperBodyRectangles, Color.Fuchsia);
                                    AddRectanglesToOriginalImage(Original, LowerBodyRectangles, Color.Goldenrod);
                                    AddRectanglesToOriginalImage(Original, FullBodyRectangles, Color.Honeydew);
                                    AddRectanglesToOriginalImage(Original, FrontalEyeRectangles, Color.Indigo);


                                    // Show the result
                                    lblMinFaceSize.Text = MinFSDetected.ToString();
                                    lblMaxFaceSize.Text = MaxFSDetected.ToString();
                                    pbResult.Image = Original.ToBitmap();
                                    pbResult.Refresh();
                                    progressThisPicture.Value = 0;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        Application.DoEvents();
                    }
                    btnStartStop.Text = "Start";
                    STOP = false;
                }
            }
            else
            {
                STOP = true;
                btnStartStop.Text = "Start";
            }
        }

        private void AddRectanglesToOriginalImage(Image<Rgb, Byte> Original, Rectangle[] ProfileFaceRectangles, System.Drawing.Color displayColour)
        {
            try
            {
                foreach (var face in ProfileFaceRectangles)
                {
                    if (face.Width < MinFSDetected && face.Width > 0) MinFSDetected = face.Width;
                    if (face.Width > MaxFSDetected) MaxFSDetected = face.Width;
                    Original.Draw(new Rectangle(face.X, face.Y, face.Width, face.Height), new Rgb(displayColour), 1);
                    progressThisPicture.Value = progressThisPicture.Value + 1;
                    progressThisPicture.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Rectangle[] processFrontalEye(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(frontalEyesPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processFullBody(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(fullbodyPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processLowerBody(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(lowerbodyPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processUpperBody(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(upperbodyPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processHS(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(HSPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processMouth(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(MouthPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processNariz(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(NarizPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processOjoD(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(ojoDPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processOjoI(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(ojoIPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processParojos(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(parojosPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processParojosG(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(parojosGPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processFrontalFaceAlt2(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(ProfileFaceHaarPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processEye(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(EyeHaarPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }

        private Rectangle[] processProfileFace(Image<Gray, byte> Greyscale)
        {
            CascadeClassifier h = new CascadeClassifier(FrontalFaceAlt2HaarPath);
            return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, new Size(MinimumFaceSize, MinimumFaceSize), new Size(MaximumFaceSize, MaximumFaceSize));
        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pbResult.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            STOP = true;

        }






    }
}
