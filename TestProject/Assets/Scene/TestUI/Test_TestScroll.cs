using UnityEngine;
using System.Collections;
using NUnit.Framework;

using UnityEditor;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    public class Test_TestScroll
    {
        GameObject gameObject = new GameObject();

        [SetUp]
        public void SetUp()
        {
            gameObject.name = "Test_TestScroll UIRoot";
            TestScroll testScroll = gameObject.AddComponent<TestScroll>();
            Assert.NotNull(testScroll);
        }

        [Test]
        public void Initialize()
        {
            UIRoot uiRoot = gameObject.AddComponent<UIRoot>();
            Assert.NotNull(uiRoot);

            uiRoot.automatic = true;
            uiRoot.manualHeight = 443;

            GameObject camera = new GameObject();
            camera.name = "Test_TestScroll UICamera";
            camera.transform.parent = gameObject.transform;

            UICamera uiCamera = camera.AddComponent<UICamera>();
            Assert.NotNull(uiCamera);
            Assert.That(true, Is.EqualTo(uiCamera.useMouse));

            GameObject uiAnchorGameObejct = new GameObject();
            uiAnchorGameObejct.name = "AnChorGameObject";
            uiAnchorGameObejct.transform.parent = uiCamera.transform;

            UIAnchor uiAnchor = uiAnchorGameObejct.AddComponent<UIAnchor>();
            Assert.NotNull(uiAnchor);
            Assert.That(true,Is.EqualTo(uiAnchor.halfPixelOffset));

            GameObject uiPanelGameObject = new GameObject();
            uiPanelGameObject.name = "UIPanel";
            uiPanelGameObject.transform.parent = uiAnchor.transform;

            UIPanel uiPanel = uiPanelGameObject.AddComponent<UIPanel>();
            Assert.NotNull(uiPanel);


            GameObject uiLabelgameObject = new GameObject();
            uiLabelgameObject.name = "uiLabelGameObject";

            int depth = NGUITools.CalculateNextDepth(uiLabelgameObject);
            uiLabelgameObject = NGUITools.AddChild(uiLabelgameObject);
            uiLabelgameObject.name = "Button";

            UIAtlas uiAtlas = uiLabelgameObject.AddComponent<UIAtlas>();
            Assert.NotNull(uiAtlas);

            Object textureFile = Resources.Load("/Texture/Effect/Fire_00000", typeof(Texture));
            Assert.NotNull(textureFile);

           // uiAtlas.spriteMaterial;
           // uiAtlas.

            //UISlicedSprite bg = NGUITools.AddWidget<UISlicedSprite>(uiLabelgameObject);
            //bg.name = "Background";
            //bg.depth = depth;
           // bg.atlas = UISettings.atlas;
//             bg.spriteName = "NGUI BUTTON";
//             bg.transform.localScale = new Vector3(150f, 40f, 1f);
//             bg.MakePixelPerfect();
// 
//             if (UISettings.font != null)
//             {
//                 UILabel lbl = NGUITools.AddWidget<UILabel>(uiLabelgameObject);
//                 lbl.font = UISettings.font;
//                 lbl.text = uiLabelgameObject.name;
//                 lbl.MakePixelPerfect();
//             }
// 
//             // Add a collider
//             NGUITools.AddWidgetCollider(uiLabelgameObject);
// 
//             // Add the scripts
//             uiLabelgameObject.AddComponent<UIButton>().tweenTarget = bg.gameObject;
//             uiLabelgameObject.AddComponent<UIButtonScale>();
//             uiLabelgameObject.AddComponent<UIButtonOffset>();
//             uiLabelgameObject.AddComponent<UIButtonSound>();
// 
//             Selection.activeGameObject = uiLabelgameObject;
        }
    }
}

