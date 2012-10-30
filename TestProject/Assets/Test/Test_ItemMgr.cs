using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Test_ItemMgr
    {
        private ItemMgr m_ItemMgr = new ItemMgr();
        
        [SetUp]
        public void SetUp()
        {
            Assert.NotNull(m_ItemMgr);
        }
        
        [Test]
        public void Initialize()
        {
           // m_ItemMgr.AddItem();
            //m_ItemMgr.RemoveItem();
        }
    }
}
