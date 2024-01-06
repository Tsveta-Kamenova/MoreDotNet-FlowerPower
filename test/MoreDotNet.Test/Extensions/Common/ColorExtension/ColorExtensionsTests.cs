using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreDotNet.Test.Extensions.Common.ColorExtensions
{
    using System.Drawing;
    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class ColorExtensionsTests
    {
        [Fact]
        public void ToHexString_ValidColor_ReturnsCorrectHexString()
        {
            // Arrange
            Color color = Color.FromArgb(255, 30, 144, 255);

            // Act
            string hexString = color.ToHexString();

            // Assert
            Assert.Equal("#1E90FF", hexString);
        }

        [Fact]
        public void ToRgbString_ValidColor_ReturnsCorrectRgbString()
        {
            // Arrange
            Color color = Color.FromArgb(255, 255, 0, 0);

            // Act
            string rgbString = color.ToRgbString();

            // Assert
            Assert.Equal("RGB(255,0,0)", rgbString);
        }

        [Fact]
        public void ToGray_ValidColor_ReturnsCorrectGrayscaleColor()
        {
            // Arrange
            Color color = Color.FromArgb(255, 120, 200, 50);

            // Act
            Color grayscaleColor = color.ToGray();

            // Assert
            int tolerance = 10; // Adjust this tolerance based on your requirements
            Assert.InRange(grayscaleColor.R, 151 - tolerance, 151 + tolerance);
            Assert.InRange(grayscaleColor.G, 151 - tolerance, 151 + tolerance);
            Assert.InRange(grayscaleColor.B, 151 - tolerance, 151 + tolerance);
        }

        [Fact]
        public void ToReadableForegroundColor_LightBackgroundColor_ReturnsBlack()
        {
            // Arrange
            Color lightColor = Color.FromArgb(255, 200, 200, 200);

            // Act
            Color foregroundColor = lightColor.ToReadableForegroundColor();

            // Assert
            Assert.Equal(Color.Black, foregroundColor);
        }

        [Fact]
        public void ToReadableForegroundColor_DarkBackgroundColor_ReturnsWhite()
        {
            // Arrange
            Color darkColor = Color.FromArgb(255, 30, 30, 30);

            // Act
            Color foregroundColor = darkColor.ToReadableForegroundColor();

            // Assert
            Assert.Equal(Color.White, foregroundColor);
        }
    }
}
