using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    class UISugarLoafManagerSubClass : UISugarLoafManager
    {
        public void Start()
        {
            base.Start();
        }

        public GameObject SugarLoafData
        {
            get { return SugarLoafImage; }
            set { SugarLoafImage = value; }
        }
    }

    [TestFixture]
    public class Test_UISugarLoafManager
    {
        static private GameObject gameObject = new GameObject();

        [SetUp]
        public void SetUp()
        {
            //gameObject.AddComponent<UISugarLoafManagerSubClass>();
            gameObject.AddComponent<UITexture>();
            gameObject.name = "Test_UISugarLoafManager";
        }

        [Test]
        public void Initialize()
        {
            //Prefab Load
            GameObject SugarLoafImageObject = (GameObject)Resources.Load("Prefabs/SugarLoafImage/SugarLoafImage");
            Assert.NotNull(SugarLoafImageObject);

            //Attach
            //NGUITools.AddChild(gameObject, SugarLoafImageObject);

            //Script Component
//             UISugarLoafManagerSubClass uiSugarLoafManager = gameObject.GetComponent<UISugarLoafManagerSubClass>();
//             Assert.NotNull(uiSugarLoafManager);


//             uiSugarLoafManager.SugarLoafData = SugarLoafImageObject;
//             uiSugarLoafManager.Start();


//             UITexture uiTexture = gameObject.GetComponent<UITexture>();
//             Assert.NotNull(uiTexture);
// 
//             UITexture SugarLoafTexture = uiSugarLoafManager.SugarLoafData.GetComponent<UITexture>();
//             Assert.NotNull(SugarLoafTexture);
// 
//             uiTexture.material = SugarLoafTexture.material;
        }
    }

}


