using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nbmCoursework.Messages;

namespace nbmTesting
{
    [TestClass]
    public class HeaderTests
    {

        [TestMethod]
        public void messageHeader_leftBlank_returnsTrue()
        {
            SMS oSMS = new SMS("S123456789", 'S', "Hello", "07123456789" );
            Assert.AreEqual(true, oSMS.processMessage())

        }
    }
}
