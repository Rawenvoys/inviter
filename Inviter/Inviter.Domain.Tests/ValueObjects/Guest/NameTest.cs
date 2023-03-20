using Inviter.Domain.Exceptions;
using Inviter.Domain.ValueObjects.Guest;

namespace Inviter.Domain.Tests.ValueObjects.Guest
{
    [TestFixture]
    public class NameTest
    {
        [TestCase("", "Name is empty")]
        [TestCase(" ", "Name is empty")]
        [TestCase(null, "Name is empty")]
        public void Name_IsEmpty_ThrowEmptyNameException(string value, string expected)
        {
            TestDelegate code = (() => { Name name = value; });
            var exception = Assert.Throws<EmptyNameException>(code);

            Assert.That(exception.Message, Is.EqualTo(expected));
        }
    }
}
