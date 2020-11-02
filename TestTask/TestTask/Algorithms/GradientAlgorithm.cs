using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TestTask.Algorithms
{
    class GradientAlgorithm : Algorithm
    {
        public double[,] XSobel
        {
            get
            {
                return new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };
            }
        }

        public double[,] YSobel
        {
            get
            {
                return new double[,]
                {
                    {  1,  2,  1 },
                    {  0,  0,  0 },
                    { -1, -2, -1 }
                };
            }
        }

        public bool grayscale = false;

        public override Bitmap MathPart(Bitmap input_picture)
        {
            double[,] xkernel = XSobel;
            double[,] ykernel = YSobel;

            int width = input_picture.Width;
            int height = input_picture.Height;

            BitmapData srcData = input_picture.LockBits(new Rectangle(0, 0, width, height),
                                                        ImageLockMode.ReadOnly, 
                                                        PixelFormat.Format32bppArgb);

            int bytes = srcData.Stride * srcData.Height;

            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];

            IntPtr srcScan0 = srcData.Scan0;

            Marshal.Copy(srcScan0, pixelBuffer, 0, bytes);

            input_picture.UnlockBits(srcData);

            if(grayscale == true)
            {
                float rgb = 0;
                for(int i = 0; i < pixelBuffer.Length; i += 4)
                {
                    rgb = pixelBuffer[i] * .21f;
                    rgb += pixelBuffer[i + 1] * .71f;
                    rgb += pixelBuffer[i + 2] * .071f;
                    pixelBuffer[i] = (byte)rgb;
                    pixelBuffer[i + 1] = pixelBuffer[i];
                    pixelBuffer[i + 2] = pixelBuffer[i];
                    pixelBuffer[i + 3] = 255;
                }
            }

            double xr = 0.0;
            double xg = 0.0;
            double xb = 0.0;
            double yr = 0.0;
            double yg = 0.0;
            double yb = 0.0;
            double rt = 0.0;
            double gt = 0.0;
            double bt = 0.0;

            int filterOffset = 1;
            int calcOffset = 0;
            int byteOffset = 0;

            for(int OffsetY = filterOffset; OffsetY < height - filterOffset; OffsetY++)
            {
                for(int OffsetX = filterOffset; OffsetX < width - filterOffset; OffsetX++)
                {
                    xr = xg = xb = yr = yg = yb = 0;
                    rt = gt = bt = 0.0;

                    byteOffset = OffsetY * srcData.Stride + OffsetX * 4;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + filterX * 4 + filterY * srcData.Stride;
                            xb += (double)(pixelBuffer[calcOffset]) * xkernel[filterY + filterOffset, filterX + filterOffset];
                            xg += (double)(pixelBuffer[calcOffset + 1]) * xkernel[filterY + filterOffset, filterX + filterOffset];
                            xr += (double)(pixelBuffer[calcOffset + 2]) * xkernel[filterY + filterOffset, filterX + filterOffset];
                            yb += (double)(pixelBuffer[calcOffset]) * ykernel[filterY + filterOffset, filterX + filterOffset];
                            yg += (double)(pixelBuffer[calcOffset + 1]) * ykernel[filterY + filterOffset, filterX + filterOffset];
                            yr += (double)(pixelBuffer[calcOffset + 2]) * ykernel[filterY + filterOffset, filterX + filterOffset];
                        }
                    }

                    bt = Math.Sqrt((xb * xb) + (yb * yb));
                    gt = Math.Sqrt((xg * xg) + (yg * yg));
                    rt = Math.Sqrt((xr * xr) + (yr * yr));

                    if (bt > 255) bt = 255;
                    else if (bt < 0) bt = 0;
                    if (gt > 255) gt = 255;
                    else if (gt < 0) gt = 0;
                    if (rt > 255) rt = 255;
                    else if (rt < 0) rt = 0;

                    resultBuffer[byteOffset] = (byte)(bt);
                    resultBuffer[byteOffset + 1] = (byte)(gt);
                    resultBuffer[byteOffset + 2] = (byte)(rt);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultImage = new Bitmap(width, height);

            BitmapData resultData = resultImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);

            resultImage.UnlockBits(resultData);

            return resultImage;
        }
    }
}
