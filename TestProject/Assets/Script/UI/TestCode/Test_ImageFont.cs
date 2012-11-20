using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Test_ImageFont
    {
        public GameObject gameObject;

        [Test]
        public void Initialize()
        {
            GameObject objectBtn = GameObject.Find("Sprite (+BTN_00)");
            Assert.NotNull(objectBtn);

            objectBtn.AddComponent<ImageFont>();

            ImageFont imageFont = objectBtn.GetComponent<ImageFont>();

            Assert.NotNull(imageFont);

            UISprite uiSprite = objectBtn.GetComponent<UISprite>();
            Assert.NotNull(uiSprite);

            imageFont.SetTest();

        }

    }
}


