using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Image.Classes;
using Image;
using System.Drawing.Imaging;

namespace TestImage
{
    /// <summary>
    /// Unit tests for the ImageFilters class and FilterMatrix class.
    /// </summary>
    [TestClass]
    public class ImageTest
    {
        /// <summary>
        /// Test the RainbowFilter method.
        /// </summary>
        [TestMethod]
        public void TestRainbowFilter()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the RainbowFilter
            Bitmap outputBitmap = ImageFilters.RainbowFilter(inputBitmap);

            // Assert: Check that the output is not null
            Assert.IsNotNull(outputBitmap);
        }

        /// <summary>
        /// Test the ApplyFilter method.
        /// </summary>
        [TestMethod]
        public void TestApplyFilter()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the filter with some values
            Bitmap outputBitmap = ImageFilters.ApplyFilter(inputBitmap, 2, 3, 4, 5);

            // Assert: Check that the output is not null
            Assert.IsNotNull(outputBitmap);
        }

        /// <summary>
        /// Test the BlackWhite method.
        /// </summary>
        [TestMethod]
        public void TestBlackWhite()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Convert the image to black and white
            Bitmap outputBitmap = ImageFilters.BlackWhite(inputBitmap);

            // Assert: Check that the output is not null
            Assert.IsNotNull(outputBitmap);
        }

        /// <summary>
        /// Test the ApplyFilterSwap method.
        /// </summary>
        [TestMethod]
        public void TestApplyFilterSwap()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the Swap filter
            Bitmap outputBitmap = ImageFilters.ApplyFilterSwap(inputBitmap);

            // Assert: Check that the output is not null
            Assert.IsNotNull(outputBitmap);
        }

        /// <summary>
        /// Test the ApplyFilterSwapDivide method.
        /// </summary>
        [TestMethod]
        public void TestApplyFilterSwapDivide()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the Swap and Divide filter with some values
            Bitmap outputBitmap = ImageFilters.ApplyFilterSwapDivide(inputBitmap, 2, 3, 4, 5);

            // Assert: Check that the output is not null
            Assert.IsNotNull(outputBitmap);
        }

        /// <summary>
        /// Test the ApplyFilterMega method.
        /// </summary>
        [TestMethod]
        public void TestApplyFilterMega()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the Mega filter with some values
            Bitmap outputBitmap = ImageFilters.ApplyFilterMega(inputBitmap, 50, 10, Color.Red);

            // Assert: Check that the output is not null
            Assert.IsNotNull(outputBitmap);
        }

        /// <summary>
        /// Test the DivideCrop method.
        /// </summary>
        [TestMethod]
        public void TestDivideCrop()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the DivideCrop method
            Bitmap outputBitmap = ImageFilters.DivideCrop(inputBitmap);

            // Assert: Check that the output is not null
            Assert.IsNotNull(outputBitmap);
        }

        /// <summary>
        /// Test the Laplacian3x3 matrix.
        /// </summary>
        [TestMethod]
        public void TestLaplacian3x3Matrix()
        {
            // Arrange: Get the Laplacian3x3 matrix
            double[,] laplacianMatrix = FilterMatrix.Laplacian3x3;

            // Act: Add your assertions here to check the values in the matrix
            Assert.AreEqual(-1, laplacianMatrix[0, 0]);
            Assert.AreEqual(8, laplacianMatrix[1, 1]);
            Assert.AreEqual(-1, laplacianMatrix[2, 2]);
        }

        /// <summary>
        /// Test Gaussian3x3 matrix.
        /// </summary>
        [TestMethod]
        public void TestGaussian3x3Matrix()
        {
            // Arrange: Get the Gaussian3x3 matrix
            double[,] gaussianMatrix = FilterMatrix.Gaussian3x3;

            // Act: Add your assertions here to check the values in the matrix
            Assert.AreEqual(1, gaussianMatrix[0, 0]);
            Assert.AreEqual(4, gaussianMatrix[1, 1]);
            Assert.AreEqual(1, gaussianMatrix[2, 2]);
        }

        /// <summary>
        /// Test the ApplyFilter method with different parameters.
        /// </summary>
        [TestMethod]
        public void TestApplyFilterWithDifferentParameters()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the filter with different parameters
            Bitmap outputBitmap1 = ImageFilters.ApplyFilter(inputBitmap, 2, 3, 4, 5);
            Bitmap outputBitmap2 = ImageFilters.ApplyFilter(inputBitmap, 1, 1, 1, 1); // Minimum parameters
            Bitmap outputBitmap3 = ImageFilters.ApplyFilter(inputBitmap, 10, 10, 10, 10); // Maximum parameters

            // Assert: Check that the outputs are not null
            Assert.IsNotNull(outputBitmap1);
            Assert.IsNotNull(outputBitmap2);
            Assert.IsNotNull(outputBitmap3);
        }

        /// <summary>
        /// Test the ApplyFilterSwapDivide method with different parameters.
        /// </summary>
        [TestMethod]
        public void TestApplyFilterSwapDivideWithDifferentParameters()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the Swap and Divide filter with different parameters
            Bitmap outputBitmap1 = ImageFilters.ApplyFilterSwapDivide(inputBitmap, 2, 3, 4, 5);
            Bitmap outputBitmap2 = ImageFilters.ApplyFilterSwapDivide(inputBitmap, 1, 1, 1, 1); // Minimum parameters
            Bitmap outputBitmap3 = ImageFilters.ApplyFilterSwapDivide(inputBitmap, 10, 10, 10, 10); // Maximum parameters

            // Assert: Check that the outputs are not null
            Assert.IsNotNull(outputBitmap1);
            Assert.IsNotNull(outputBitmap2);
            Assert.IsNotNull(outputBitmap3);
        }

        /// <summary>
        /// Test the RainbowFilter method with complex scenarios.
        /// </summary>
        [TestMethod]
        public void TestRainbowFilterComplex()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the RainbowFilter
            Bitmap outputBitmap = ImageFilters.RainbowFilter(inputBitmap);

            // Assert: Check that the output is not null
            Assert.IsNotNull(outputBitmap);

            // Test the expected results by comparing pixel values
            for (int i = 0; i < outputBitmap.Width; i++)
            {
                for (int x = 0; x < outputBitmap.Height; x++)
                {
                    Color expectedColor;

                    if (i < (outputBitmap.Width / 4))
                    {
                        expectedColor = Color.FromArgb(inputBitmap.GetPixel(i, x).R / 5, inputBitmap.GetPixel(i, x).G, inputBitmap.GetPixel(i, x).B);
                    }
                    else if (i < (outputBitmap.Width / 2))
                    {
                        expectedColor = Color.FromArgb(inputBitmap.GetPixel(i, x).R, inputBitmap.GetPixel(i, x).G / 5, inputBitmap.GetPixel(i, x).B);
                    }
                    else if (i < (outputBitmap.Width * 3 / 4))
                    {
                        expectedColor = Color.FromArgb(inputBitmap.GetPixel(i, x).R, inputBitmap.GetPixel(i, x).G, inputBitmap.GetPixel(i, x).B / 5);
                    }
                    else if (i < outputBitmap.Width)
                    {
                        expectedColor = Color.FromArgb(inputBitmap.GetPixel(i, x).R / 5, inputBitmap.GetPixel(i, x).G, inputBitmap.GetPixel(i, x).B / 5);
                    }
                    else
                    {
                        expectedColor = Color.FromArgb(inputBitmap.GetPixel(i, x).R / 5, inputBitmap.GetPixel(i, x).G / 5, inputBitmap.GetPixel(i, x).B / 5);
                    }

                    // Compare the actual pixel color with the expected color
                   Assert.AreEqual(expectedColor, outputBitmap.GetPixel(i, x));
                }
            }
        }

        /// <summary>
        /// Test the RainbowFilter method with RGB color space.
        /// </summary>
        [TestMethod]
        public void TestRainbowFilterRGB()
        {
            // Arrange: Create a test input bitmap in RGB color space
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the RainbowFilter
            Bitmap outputBitmap = ImageFilters.RainbowFilter(inputBitmap);

            // Assert: Check that the output is not null
            Assert.IsNotNull(outputBitmap);

            // Check that the output bitmap is still in the RGB color space
            Assert.AreEqual(PixelFormat.Format32bppArgb, outputBitmap.PixelFormat);
        }

        /// <summary>
        /// Test the ApplyFilter method with very small divisor values.
        /// </summary>
        [TestMethod]
        public void TestApplyFilterWithSmallDivisors()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the filter with very small divisor values
            Bitmap outputBitmap = ImageFilters.ApplyFilter(inputBitmap, 1, 1, 1, 1);

            // Assert: Check that the output is not null
            Assert.IsNotNull(outputBitmap);
        }

        /// <summary>
        /// Test the ApplyFilter method with very large divisor values.
        /// </summary>
        [TestMethod]
        public void TestApplyFilterWithLargeDivisors()
        {
            // Arrange: Create a test input bitmap
            Bitmap inputBitmap = new Bitmap(100, 100);

            // Act: Apply the filter with very large divisor values
            Bitmap outputBitmap = ImageFilters.ApplyFilter(inputBitmap, 1000, 1000, 1000, 1000);

            // Assert: Check that the output is not null
            Assert.IsNotNull(outputBitmap);
        }

        /// <summary>
        /// Test the Laplacian5x5 matrix.
        /// </summary>
        [TestMethod]
        public void TestLaplacian5x5Matrix()
        {
            // Arrange: Get the Laplacian5x5 matrix
            double[,] laplacianMatrix = FilterMatrix.Laplacian5x5;

            // Act: Add your assertions here to check the values in the matrix
            Assert.AreEqual(-1, laplacianMatrix[0, 0]);
            Assert.AreEqual(24, laplacianMatrix[2, 2]);
            Assert.AreEqual(-1, laplacianMatrix[4, 4]);
        }

        /// <summary>
        /// Test the Gaussian5x5Type2 matrix.
        /// </summary>
        [TestMethod]
        public void TestGaussian5x5Type2Matrix()
        {
            // Arrange: Get the Gaussian5x5Type2 matrix
            double[,] gaussianMatrix = FilterMatrix.Gaussian5x5Type2;

            // Act: Add your assertions here to check the values in the matrix
            Assert.AreEqual(1, gaussianMatrix[0, 0]);
            Assert.AreEqual(36, gaussianMatrix[2, 2]);
            Assert.AreEqual(1, gaussianMatrix[4, 4]);
        }

        /// <summary>
        /// Test the Sobel3x3Horizontal matrix.
        /// </summary>
        [TestMethod]
        public void TestSobel3x3HorizontalMatrix()
        {
            // Arrange: Get the Sobel3x3Horizontal matrix
            double[,] sobelMatrix = FilterMatrix.Sobel3x3Horizontal;

            // Act: Add your assertions here to check the values in the matrix
            Assert.AreEqual(-1, sobelMatrix[0, 0]);
            Assert.AreEqual(2, sobelMatrix[1, 2]);
            Assert.AreEqual(-1, sobelMatrix[2, 0]);
        }

        /// <summary>
        /// Test the Sobel3x3Vertical matrix.
        /// </summary>
        [TestMethod]
        public void TestSobel3x3VerticalMatrix()
        {
            // Arrange: Get the Sobel3x3Vertical matrix
            double[,] sobelMatrix = FilterMatrix.Sobel3x3Vertical;

            // Act: Add your assertions here to check the values in the matrix
            Assert.AreEqual(1, sobelMatrix[0, 2]);
            Assert.AreEqual(0, sobelMatrix[1, 1]);
            Assert.AreEqual(-1, sobelMatrix[2, 0]);
        }

        /// <summary>
        /// Test the Kirsch3x3Horizontal matrix.
        /// </summary>
        [TestMethod]
        public void TestKirsch3x3HorizontalMatrix()
        {
            // Arrange: Get the Kirsch3x3Horizontal matrix
            double[,] kirschMatrix = FilterMatrix.Kirsch3x3Horizontal;

            // Act: Add your assertions here to check the values in the matrix
            Assert.AreEqual(5, kirschMatrix[0, 0]);
            Assert.AreEqual(-3, kirschMatrix[1, 0]);
            Assert.AreEqual(-3, kirschMatrix[2, 2]);
        }

        /// <summary>
        /// Test the LaplacianOfGaussian matrix.
        /// </summary>
        [TestMethod]
        public void TestLaplacianOfGaussianMatrix()
        {
            // Arrange: Get the LaplacianOfGaussian matrix
            double[,] laplacianOfGaussianMatrix = FilterMatrix.LaplacianOfGaussian;

            // Act: Add your assertions here to check the values in the matrix
            Assert.AreEqual(0, laplacianOfGaussianMatrix[0, 0]);
            Assert.AreEqual(-1, laplacianOfGaussianMatrix[1, 1]);
            Assert.AreEqual(16, laplacianOfGaussianMatrix[2, 2]);
            Assert.AreEqual(-1, laplacianOfGaussianMatrix[3, 3]);
            Assert.AreEqual(0, laplacianOfGaussianMatrix[4, 4]);
        }
    }
}