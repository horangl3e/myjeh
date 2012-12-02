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
            //음수 값이나 0은  0으로 반환 그외에 양수는 1로 반환
            float val = Mathf.Clamp01(1000);
            Assert.That(1, Is.EqualTo(val));


        }
    }


}
