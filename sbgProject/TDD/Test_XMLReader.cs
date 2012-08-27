using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using System.Xml;

namespace TDD
{
    
    
    /// <summary>
    ///This is a test class for TestXMLReaderTest_XMLReader and is intended
    ///to contain all TestXMLReaderTest_XMLReader Unit Tests
    ///</summary>
    [TestClass()]
    public class Test_XMLReader
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for TestXMLReader Constructor
        ///</summary>
        [TestMethod()]
        public void ConstructorTest_XMLReader()
        {
            TestXMLReader target = new TestXMLReader();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Start
        ///</summary>
        [TestMethod()]
        public void StartTest_XMLReader()
        {
            TestXMLReader target = new TestXMLReader(); // TODO: Initialize to an appropriate value
            target.Start();
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest_XMLReader()
        {
            TestXMLReader target = new TestXMLReader(); // TODO: Initialize to an appropriate value
            target.Update();
        }

        [TestMethod()]
        public void Test_GetXmlRootElement()
        {
            //시발 Unity함수라 안됨
            //XmlElement xmlElement = TestXMLReader.GetXmlRootElement("Root/Table");
        }
    }
}
