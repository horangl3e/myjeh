using UnityEngine;
using System.Collections;
using NUnit.Framework;

using UnityEditor;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    public class Test_RuntimeUIWidget
    {
        GameObject Root;
        static GameObject PanelGameObject = new GameObject();

        [Test]
        public void CreateButtonRunTime()
        {
            Root = new GameObject();
            Root.name = "Test_RunTime_UIRoot(ListView)";

            UIRoot uiRoot = Root.AddComponent<UIRoot>();
            Assert.NotNull(uiRoot);

            uiRoot.automatic = true;
            uiRoot.manualHeight = 443;

            GameObject camera = new GameObject();
            camera.name = "Test_TestScroll UICamera";
            camera.transform.parent = Root.transform;
            camera.transform.Translate(0.0f, 0.0f, -500.0f);

            UICamera uiCamera = camera.AddComponent<UICamera>();
            Assert.NotNull(uiCamera);
            Assert.That(true, Is.EqualTo(uiCamera.useMouse));

            GameObject uiAnchorGameObejct = new GameObject();
            uiAnchorGameObejct.name = "AnChorGameObject";
            uiAnchorGameObejct.transform.parent = uiCamera.transform;

            UIAnchor uiAnchor = uiAnchorGameObejct.AddComponent<UIAnchor>();
            Assert.NotNull(uiAnchor);
            Assert.That(true,Is.EqualTo(uiAnchor.halfPixelOffset));

            PanelGameObject.name = "UIPanel";
            PanelGameObject.transform.parent = uiAnchor.transform;

            UIPanel uiPanel = PanelGameObject.AddComponent<UIPanel>();
            Assert.NotNull(uiPanel);

             GameObject UIAtlasData = (GameObject)Resources.Load("Atlases/ScFi/ScFiAtlasPrefab/SciFi Atlas");
             Assert.NotNull(UIAtlasData);

            int depth = NGUITools.CalculateNextDepth(PanelGameObject);

            GameObject uiLabelgameObject;
            uiLabelgameObject = NGUITools.AddChild(PanelGameObject);
            uiLabelgameObject.name = "RunTimeButton";
            uiLabelgameObject.transform.Translate(0.0f,100.0f,500.0f);

            UIAtlas uiAtlas = UIAtlasData.GetComponent<UIAtlas>();
            Assert.NotNull(uiAtlas);

            UISlicedSprite bg = NGUITools.AddWidget<UISlicedSprite>(uiLabelgameObject);
            bg.name = "Background";
            bg.depth = depth;
            bg.atlas = uiAtlas;
            bg.spriteName = "NGUI BUTTON";
            bg.transform.localScale = new Vector3(150.0f, 40.0f, 1f);
            bg.MakePixelPerfect();

            GameObject uiFontObject = (GameObject)Resources.Load("Font/GodicBold25Prefab/GodicBold25");
            Assert.NotNull(uiFontObject);

            UIFont uiFont = uiFontObject.GetComponent<UIFont>();
            Assert.NotNull(uiFont);

            UILabel lbl = NGUITools.AddWidget<UILabel>(uiLabelgameObject);
            lbl.font = uiFont;
            lbl.text = uiLabelgameObject.name;
            lbl.transform.Translate(new Vector3(0.0f, 0.0f, -5.0f));
            lbl.MakePixelPerfect();

            NGUITools.AddWidgetCollider(uiLabelgameObject);

            // Add the scripts
            uiLabelgameObject.AddComponent<UIButton>().tweenTarget = bg.gameObject;
            uiLabelgameObject.AddComponent<UIButtonScale>();
            uiLabelgameObject.AddComponent<UIButtonOffset>();
            uiLabelgameObject.AddComponent<UIButtonSound>();

            Selection.activeGameObject = uiLabelgameObject;
        }

        [Test]
        public void RuntimeCreateScroll()
        {
            Assert.NotNull(PanelGameObject);
            GameObject ScrollPanal;

            ScrollPanal = NGUITools.AddChild(PanelGameObject);
            ScrollPanal.name = "UIPanal(2D UI)";
            ScrollPanal.layer = 3;

            Assert.NotNull(ScrollPanal);
            PanelGameObject.AddComponent<UIPanel>();

            GameObject WindowRoot;
            WindowRoot = NGUITools.AddChild(ScrollPanal);
            WindowRoot.name = "Window Root";


            TweenRotation tweenRotation = WindowRoot.AddComponent<TweenRotation>();
            Assert.NotNull(tweenRotation);

            tweenRotation.method = UITweener.Method.EaseInOut;

            GameObject UIPanelClippedView;
            UIPanelClippedView = NGUITools.AddChild(WindowRoot);
            Assert.NotNull(UIPanelClippedView);

            UIPanelClippedView.name = "UIPanel(Clipped View)";
            UIPanel UIPanelClippedViewUIPanel = UIPanelClippedView.AddComponent<UIPanel>();
            Assert.NotNull(UIPanelClippedViewUIPanel);

            //리스트 뷰 보이는 영역 설정
            UIPanelClippedViewUIPanel.widgetsAreStatic = true;
            UIPanelClippedViewUIPanel.clipping = UIDrawCall.Clipping.SoftClip;
            UIPanelClippedViewUIPanel.clipRange = new Vector4(41f,-1f,700f,240f);
            UIPanelClippedViewUIPanel.clipSoftness = new Vector2(10,10);


            UIDraggablePanel UIPanelClippedViewDraggablePanel = UIPanelClippedView.AddComponent<UIDraggablePanel>();
            Assert.NotNull(UIPanelClippedViewDraggablePanel);

            UIPanelClippedViewDraggablePanel.scale = new Vector3(1.0f,0.0f,0.0f);

            GameObject uiGridObject;
            uiGridObject = NGUITools.AddChild(UIPanelClippedView);

            Assert.NotNull(uiGridObject);
            uiGridObject.name = "UIGrid";
            UIGrid uiGrid = uiGridObject.AddComponent<UIGrid>();
            Assert.NotNull(uiGrid);

            uiGrid.cellWidth = 150.0f;
            uiGrid.cellHeight = 200.0f;

            
            GameObject Item0;
            Item0 = NGUITools.AddChild(uiGridObject);

            Assert.NotNull(Item0);
            Item0.name = "Item";
            Item0.transform.Translate(0.0f, 0.0f, 500.0f);

            BoxCollider boxCollider = NGUITools.AddWidgetCollider(Item0);
            Assert.NotNull(boxCollider);

            //컬리젼 영역을 잡아 줘야 마우스와 충돌이 발생하겠지.
            boxCollider.center = new Vector3(-0.8f, 9.7f, 0.0f);
            boxCollider.size = new Vector3(400f, 197f, 0.0f);
            Assert.That(9.7f, Is.EqualTo(boxCollider.center.y));

            UIDragPanelContents uiDragPanelContents = Item0.AddComponent<UIDragPanelContents>();
            Assert.NotNull(uiDragPanelContents);

            uiDragPanelContents.draggablePanel = UIPanelClippedView.GetComponent<UIDraggablePanel>();

            GameObject uiLabel;
            uiLabel = NGUITools.AddChild(Item0);
            uiLabel.name = "UILabel";
            Assert.NotNull(uiLabel);

            UILabel uiItemLabel = NGUITools.AddWidget<UILabel>(uiLabel);
            Assert.NotNull(uiItemLabel);

            GameObject Item0font = (GameObject)Resources.Load("Font/GodicBold25Prefab/GodicBold25");
            Assert.NotNull(Item0font);

            UIFont uiFont = Item0font.GetComponent<UIFont>();
            Assert.NotNull(uiFont);
            uiItemLabel.font = uiFont;
            uiItemLabel.text = "Some Item";            
        }
    }
}

