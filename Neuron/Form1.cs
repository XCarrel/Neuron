using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Neuron
{
    public partial class Form1 : Form
    {
        private const int PICSIZE = 28;
        private const int OUTPUTLAYERSIZE = 10;
        private const double NUDGEWEIGHT = 0.25;

        private double PseudoRandom; // for pseudo-random numbers
        private Random alea = new Random(); // we also need other random numbers
        private byte[] MNISTLearningImages; // Images used to train the network. See http://yann.lecun.com/exdb/mnist/
        private byte[] MNISTLearningLabels;
        private byte[] MNISTTestImages; // Images used to test the network after learning
        private byte[] MNISTTestLabels;
        private int batchnb;
        private int trainingnb;
        int NbBatches;
        int BatchSize;

        public Form1()
        {
            InitializeComponent();
        }

        private double Sigmoid(double v)
        {
            return 1.0 / (1 + Math.Exp(-v));
        }

        // Return  a value that between 0 and 1 that seems random.
        // It actually is not, because the serie is the same for a given seed value
        private double NextPseudoRandom()
        {
            this.PseudoRandom = Math.Pow(100*PseudoRandom, 2);
            this.PseudoRandom -= Math.Truncate(this.PseudoRandom);
            return PseudoRandom;
        }

        private void log(string s)
        {
            txtOutput.Text = (s + Environment.NewLine + txtOutput.Text);
        }

        private Vector<double> GetSampleImage(int samplenb)
        {
            double[] res = new double[PICSIZE * PICSIZE];
            int offset = 16 + samplenb * PICSIZE * PICSIZE;
            for (int i = 0; i < PICSIZE * PICSIZE; i++)
                res[i] = (double)MNISTLearningImages[offset + i];
            return Vector<double>.Build.DenseOfArray(res);
        }

        private byte GetSampleLabel(int samplenb)
        {
            return MNISTLearningLabels[8 + samplenb];
        }

        private Vector<double> GetTestImage(int samplenb)
        {
            double[] res = new double[PICSIZE * PICSIZE];
            int offset = 16 + samplenb * PICSIZE * PICSIZE;
            for (int i = 0; i < PICSIZE * PICSIZE; i++)
                res[i] = (double)MNISTTestImages[offset + i];
            return Vector<double>.Build.DenseOfArray(res);
        }

        private byte GetTestLabel(int samplenb)
        {
            return MNISTTestLabels[8 + samplenb];
        }

        private void UpdateProgressBar()
        {
            prbProgress.Value = (int)((double)(batchnb * BatchSize+trainingnb) / (double)(BatchSize * NbBatches) * 100);
        }

        private List<Glimpse> Analyse (Matrix<double> weights, Vector<double> biases, int samplenumber)
        {
            double TotalCost = 0;
            double Cost;
            int SampleId;
            List<Glimpse> res = new List<Glimpse>();
            for (trainingnb = 0; trainingnb < samplenumber; trainingnb++)
            {
                SampleId = alea.Next(0, MNISTLearningImages.Length / (PICSIZE * PICSIZE)-1);
                Vector<double> Input = GetSampleImage(SampleId);
                int target = GetSampleLabel(SampleId);

                // Do the math
                Vector<double> result = weights.Multiply(Input).Add(biases);
                for (int i = 0; i < result.Count; i++) result[i] = Sigmoid(result[i]);
                Glimpse training = new Glimpse(Input, weights, result, target);
                Cost = training.Cost(); 

                // Show results
                // log(string.Format("Sample {0:D5}, a {1} => cost= {2:F2}",SampleId,target,Cost));
                TotalCost += Cost;

                res.Add(training);
            }
            log(String.Format(">>> Average cost of stochastic step: {0:F2}", TotalCost / samplenumber));
            UpdateProgressBar();
            Application.DoEvents(); // Allow showing results while we keep crunching
            return res;
        }

        /* Object serializing commented out for now: deserialization fails on bad XM format
         
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }


        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }

            return objectOut;
        }

        */
        private void cmdCompute_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            Random alea = new Random();
            int v = alea.Next(0, 6000);
            Vector<double> test = GetSampleImage(v);
            byte targetval = GetSampleLabel(v);
            NbBatches = (int)numNbBatches.Value;
            BatchSize = (int)numBatchSize.Value;

            // Initialize our system.
            // We don't use the standard random function because we don't want real ramdonness...
            // We want something that looks random, but that we can reproduce by computation.
            // The seed value defines a deterministic serie of seemingly random numbers
            PseudoRandom = 1 / (double)numSeed.Value;

            Matrix<double> weights = Matrix<double>.Build.DenseOfArray(new double[OUTPUTLAYERSIZE, PICSIZE * PICSIZE]);
            for (int y = 0; y < weights.RowCount; y++)
                for (int x = 0; x < weights.ColumnCount; x++)
                    weights[y, x] = NextPseudoRandom() - 0.5;

            Vector<double> biases = Vector<double>.Build.DenseOfArray(new double[OUTPUTLAYERSIZE]);
            for (int x = 0; x < biases.Count; x++)
                biases[x] = NextPseudoRandom() - 0.5;

            // Let's start crunching...
            prbProgress.Visible = true;
            lblLearning.Visible = true;
            for (batchnb = 0; batchnb < NbBatches; batchnb++)
            {
                List<Glimpse> Batch = Analyse(weights, biases, BatchSize);

                // Average out all the nudges proposed by the training batch
                Matrix<double> AverageNudge = null;
                foreach (Glimpse t in Batch)
                    if (AverageNudge == null)
                        AverageNudge = t.WeightsNudge(NUDGEWEIGHT);
                    else
                        AverageNudge += t.WeightsNudge(NUDGEWEIGHT);
                AverageNudge.Divide(Batch.Count);

                // Apply nudge
                weights += AverageNudge;
            }
            lblLearning.Visible = false;
            lblTesting.Visible = true;
            log("And now see how smart we got....");
            int NbHits = 0;
            for (int i=0; i<numTestBatchSize.Value; i++)
            {
                int TestId = alea.Next(0, MNISTTestImages.Length / (PICSIZE * PICSIZE) - 1);
                Vector<double> Input = GetTestImage(TestId);
                int target = GetTestLabel(TestId);

                // Do the math
                Vector<double> result = weights.Multiply(Input).Add(biases);
                for (int r = 0; r < result.Count; r++) result[r] = Sigmoid(result[r]);

                int MyGuess = result.MaximumIndex();
                if (MyGuess == target) NbHits++;

                log(string.Format("Test image #{0:D6} is a {1}, I would have guessed a {2} {3}",TestId,target,MyGuess,(MyGuess==target) ? "Yesss!!" : ""));
                prbProgress.Value = (int)((double)i/(double)numTestBatchSize.Value*100);
                Application.DoEvents();
            }
            lblTesting.Visible = false;
            prbProgress.Visible = false;
            log(string.Format("Accuracy: {0:F1}%", (double)NbHits / (double)numTestBatchSize.Value * 100));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MNISTLearningImages = File.ReadAllBytes("train-images.idx3-ubyte");
            MNISTLearningLabels = File.ReadAllBytes("train-labels.idx1-ubyte");
            MNISTTestImages = File.ReadAllBytes("t10k-images.idx3-ubyte");
            MNISTTestLabels = File.ReadAllBytes("t10k-labels.idx1-ubyte");
        }
    }
}
