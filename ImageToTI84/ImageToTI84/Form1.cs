using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageToTI84
{
    public partial class Form1 : Form
    {
        Bitmap rawImage;

        Bitmap img;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap selectedImage = new Bitmap(openFileDialog1.OpenFile());
                Bitmap finalPreview = null;

                int height = 68;
                int width = (selectedImage.Width * height) / selectedImage.Height;

                richTextBox1.Text += height + " " + width + "\n";

                finalPreview = new Bitmap(width, height);

                using (Graphics g = Graphics.FromImage(finalPreview))
                {
                    g.DrawImage(selectedImage, 0, 0, width, height);
                }

                pictureBox1.Image = finalPreview;

                rawImage = finalPreview;

                button3.Enabled = true;
            }

            openFileDialog1.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region Convert to grayscale
            Bitmap grayscale = null;

            using (Bitmap original = rawImage)
            {
                // Credits to http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale

                int totalIterations = original.Width * original.Height;
                int currentIteration = 0;

                //make an empty bitmap the same size as original
                Bitmap newBitmap = new Bitmap(original.Width, original.Height);

                for (int i = 0; i < original.Width; i++)
                {
                    for (int j = 0; j < original.Height; j++)
                    {
                        //get the pixel from the original image
                        Color originalColor = original.GetPixel(i, j);

                        //create the grayscale version of the pixel
                        int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59)
                            + (originalColor.B * .11));

                        //create the color object
                        Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);

                        //set the new image's pixel to the grayscale version
                        newBitmap.SetPixel(i, j, newColor);

                        currentIteration++;
                        progressBar1.Value = currentIteration / totalIterations * 100;
                    }
                }

                grayscale = newBitmap;
            }

            pictureBox1.Image = grayscale;
            #endregion

            if (trackBar1.Value == 2)
            {
                #region Convert to 2-variant

                Bitmap variant2 = null;

                using (Bitmap original = grayscale)
                {
                    // Credits to http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale

                    int totalIterations = original.Width * original.Height;
                    int currentIteration = 0;

                    //make an empty bitmap the same size as original
                    Bitmap newBitmap = new Bitmap(original.Width, original.Height);

                    for (int i = 0; i < original.Width; i++)
                    {
                        for (int j = 0; j < original.Height; j++)
                        {
                            //get the pixel from the original image
                            Color originalColor = original.GetPixel(i, j);

                            int pixCol;

                            if (originalColor.G < 128)
                            {
                                pixCol = 0;
                            }
                            else
                            {
                                pixCol = 255;
                            }

                            //create the color object
                            Color newColor = Color.FromArgb(pixCol, pixCol, pixCol);

                            //set the new image's pixel to the grayscale version
                            newBitmap.SetPixel(i, j, newColor);

                            currentIteration++;
                            progressBar1.Value = currentIteration / totalIterations * 100;
                        }
                    }

                    variant2 = newBitmap;
                    pictureBox1.Image = variant2;

                    img = variant2;
                }

                #endregion

            }
            else if (trackBar1.Value == 3)
            {
                #region Convert to 3-variant

                Bitmap variant3 = null;

                using (Bitmap original = grayscale)
                {
                    // Credits to http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale

                    int totalIterations = original.Width * original.Height;
                    int currentIteration = 0;

                    //make an empty bitmap the same size as original
                    Bitmap newBitmap = new Bitmap(original.Width, original.Height);

                    for (int i = 0; i < original.Width; i++)
                    {
                        for (int j = 0; j < original.Height; j++)
                        {
                            //get the pixel from the original image
                            Color originalColor = original.GetPixel(i, j);

                            int pixCol;

                            if (originalColor.G < 85)
                            {
                                pixCol = 0;
                            }
                            else if (originalColor.G > 170)
                            {
                                pixCol = 128; // Rounded up, actually 127.5
                            }
                            else
                            {
                                pixCol = 255;
                            }

                            //create the color object
                            Color newColor = Color.FromArgb(pixCol, pixCol, pixCol);

                            //set the new image's pixel to the grayscale version
                            newBitmap.SetPixel(i, j, newColor);

                            currentIteration++;
                            progressBar1.Value = currentIteration / totalIterations * 100;
                        }
                    }

                    variant3 = newBitmap;
                    pictureBox1.Image = variant3;

                    img = variant3;
                }

                #endregion

            }
            else if (trackBar1.Value == 4)
            {
                #region Convert to 2-variant

                Bitmap variant4 = null;

                using (Bitmap original = grayscale)
                {
                    // Credits to http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale

                    int totalIterations = original.Width * original.Height;
                    int currentIteration = 0;

                    //make an empty bitmap the same size as original
                    Bitmap newBitmap = new Bitmap(original.Width, original.Height);

                    for (int i = 0; i < original.Width; i++)
                    {
                        for (int j = 0; j < original.Height; j++)
                        {
                            //get the pixel from the original image
                            Color originalColor = original.GetPixel(i, j);

                            int pixCol;

                            if (originalColor.G < 128)
                            {
                                if (originalColor.G < 64)
                                {
                                    pixCol = 0;
                                }
                                else
                                {
                                    pixCol = 85;
                                }
                            }
                            else
                            {
                                if (originalColor.G < 192)
                                {
                                    pixCol = 170;
                                }
                                else
                                {
                                    pixCol = 255;
                                }
                            }

                            //create the color object
                            Color newColor = Color.FromArgb(pixCol, pixCol, pixCol);

                            //set the new image's pixel to the grayscale version
                            newBitmap.SetPixel(i, j, newColor);

                            currentIteration++;
                            progressBar1.Value = currentIteration / totalIterations * 100;
                        }
                    }

                    variant4 = newBitmap;
                    pictureBox1.Image = variant4;

                    img = variant4;
                }

                #endregion
            }            

            #region Parse into code

            List<Point> startPoint = new List<Point>();
            List<Point> finalPoint = new List<Point>();

            bool currBlack = false;

            //richTextBox1.Text += "Printing 2 dimensional array\n";

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    if (img.GetPixel(x, y).G == 255)
                    {
                        if (currBlack)
                        {
                            // Skip
                            continue;
                        }
                        else
                        {
                            // Start line; swap bool
                            currBlack = true;
                            startPoint.Add(new Point(x, y));
                        }
                    }
                    else
                    {
                        if (currBlack)
                        {
                            // End line; swap bool
                            currBlack = false;
                            finalPoint.Add(new Point(x, y));
                        }
                        else
                        {
                            // Skip
                            continue;
                        }
                    }

                    if (x + 1 == img.Width)
                    {
                        if (currBlack)
                        {
                            finalPoint.Add(new Point(x, y));
                        }
                    }
                }                
            }

            for (int i = 0; i < startPoint.Count; i++)
            {
                richTextBox1.Text += "Line(" + ((Point)startPoint[i]).X + "," + ((Point)startPoint[i]).Y + "," +
                    ((Point)finalPoint[i]).X + "," + ((Point)startPoint[i]).Y + ")\n";
            }

            #endregion

            button3.Enabled = false;
        }
    }
}
