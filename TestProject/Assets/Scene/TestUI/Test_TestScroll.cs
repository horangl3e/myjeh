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

            GameObject UIAtlasData = (GameObject)Resources.Load("Atllases/ScFi/SciFi Atlas");
            Assert.NotNull(UIAtlasData);

            int depth = NGUITools.CalculateNextDepth(uiPanelGameObject);

            GameObject uiLabelgameObject = new GameObject();
            uiLabelgameObject = NGUITools.AddChild(uiPanelGameObject);
            uiLabelgameObject.name = "Button";

            UIAtlas uiAtlas = UIAtlasData.GetComponent<UIAtlas>();
            Assert.NotNull(uiAtlas);

            UISlicedSprite bg = NGUITools.AddWidget<UISlicedSprite>(uiLabelgameObject);
            bg.name = "Background";
            bg.depth = depth;
            bg.atlas = uiAtlas;
            bg.spriteName = "NGUI BUTTON";
            bg.transform.localScale = new Vector3(150.0f, 40.0f, 1f);
            bg.MakePixelPerfect();

            GameObject uiFontObject = (GameObject)Resources.Load("Font/GodicBold25");
            //Assert.NotNull(uiFontObject);


            UIFont uiFont = UIAtlasData.GetComponent<UIFont>();
            //Assert.NotNull(uiFont);

            UILabel lbl = NGUITools.AddWidget<UILabel>(uiLabelgameObject);
            lbl.font = uiFont;
            lbl.text = uiLabelgameObject.name;
            lbl.MakePixelPerfect();

            NGUITools.AddWidgetCollider(uiLabelgameObject);

            // Add the scripts
            uiLabelgameObject.AddComponent<UIButton>().tweenTarget = bg.gameObject;
            uiLabelgameObject.AddComponent<UIButtonScale>();
            uiLabelgameObject.AddComponent<UIButtonOffset>();
            uiLabelgameObject.AddComponent<UIButtonSound>();

            Selection.activeGameObject = uiLabelgameObject;
        }
    }
}

