using System;
using Common;
using FluentAssertions;
using Xunit;

namespace DataAccessLayer.UT
{
    public class DataAccessLayerTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void DataAccessLayer_Constructor_should_throw_if_targetFile_is_invalid(string targetFile)
        {
            //Act
            Action constructor = () => new DataAccessLayer(SourceType.SQL, targetFile);

            //Assert
            constructor.ShouldThrow<ArgumentException>();
        }


    }
}