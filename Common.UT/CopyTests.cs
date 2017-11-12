using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Common.UT
{
    public class CopyTests
    {
        [Theory]
        [MemberData(nameof(InvalidConstructorArguments))]
        public void Copy_Constructor_should_throw_if_argument_is_invalid(
            string id,
            string itemId,
            bool isBorrowed)
        {
            //Act
            Action constructor = () => new Copy(id, itemId, isBorrowed);

            //Assert
            constructor.ShouldThrow<ArgumentException>();
        }

        [Theory]
        [MemberData(nameof(ValidConstructorArguments))]
        public void Copy_Constructor_should_not_throw_if_arguments_are_valid(
            string id,
            string itemId,
            bool isBorrowed)
        {
            //Act
            Action constructor = () => new Copy(id, itemId, isBorrowed);

            //Assert
            constructor.ShouldNotThrow();
        }

        [Theory]
        [MemberData(nameof(ValidConstructorArguments))]
        public void Copy_Constructor_should_set_fields(
            string id,
            string itemId,
            bool isBorrowed)
        {
            //Act
            var copy = new Copy(id, itemId, isBorrowed);

            //Assert
            copy.Id.ShouldBeEquivalentTo(id);
            copy.ItemId.ShouldBeEquivalentTo(itemId);
            copy.IsBorrowed.ShouldBeEquivalentTo(isBorrowed);
        }

        public static IEnumerable<object[]> InvalidConstructorArguments => new[]
        {
            new object[] {string.Empty, "itemId", true},
            new object[] {"  ", "itemId", true},
            new object[] {null, "itemId", true},
            new object[] {"id", string.Empty, true},
            new object[] {string.Empty, "   ", true},
            new object[] {string.Empty, null, true}
        };

        public static IEnumerable<object[]> ValidConstructorArguments => new[]
        {
            new object[] {"1", "1", true}
        };
    }
}