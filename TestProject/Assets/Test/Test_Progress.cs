using UnityEngine;
using System.Collections;
using NUnit.Framework;


namespace Test
{

    [TestFixture]
    public class Test_Progress
    {

        [Test]
        public void Initialize()
        {
            //���� ���̳� 0��  0���� ��ȯ �׿ܿ� ����� 1�� ��ȯ
            float val = Mathf.Clamp01(1000);
            Assert.That(1, Is.EqualTo(val));


        }
    }


}
