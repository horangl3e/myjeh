using UnityEngine;
using System.Collections;
using NUnit.Framework;
using SpriteSpace;

namespace Test
{
    public class ImageSpriteSubClass : ImageSprite
    {
        public MeshRenderer _meshRenderer
        {
            get { return m_renderer; }
        }

        public MeshFilter _meshFilter
        {
            get { return m_meshFilter; }
        }

        public Mesh _mesh
        {
            get { return m_mesh; }
        }

        public void CreateDefault()
        {
            base.CreateDefault();
        }

        public void ResetMaterial()
        {
            base.ResetMaterial();
        }
    }

    [TestFixture]
    public class Test_Sprite
    {
        private GameObject gameObject;

        [SetUp]
        public void SetUp()
        {
            gameObject = new GameObject();
            gameObject.name = "Test_Sprite";
            Assert.NotNull(gameObject);
        }

        [Test]
        public void CreateDefault()
        {
            ImageSpriteSubClass imageSprite = gameObject.AddComponent<ImageSpriteSubClass>();
            Assert.NotNull(imageSprite);

            imageSprite.CreateDefault();

            Assert.NotNull(imageSprite._meshRenderer);
            Assert.NotNull(imageSprite._meshFilter);
            Assert.NotNull(imageSprite._mesh);

            Assert.That("SpriteMesh", Is.EqualTo(imageSprite._mesh.name));

            ImageSpriteSubClass imageSubclass = gameObject.GetComponent<ImageSpriteSubClass>();
            Assert.NotNull(imageSubclass);
        }

        [Test]
        public void ResetMaterial()
        {
            ImageSpriteSubClass imageSprite = gameObject.AddComponent<ImageSpriteSubClass>();
            Assert.NotNull(imageSprite);

            var shaderText =
            "Shader \"Alpha Additive\" {" +
            "Properties { _Color (\"Main Color\", Color) = (1,155,1,0) }" +
            "SubShader {" +
            "    Tags { \"Queue\" = \"Transparent\" }" +
            "    Pass {" +
            "        Blend One One ZWrite Off ColorMask RGB" +
            "        Material { Diffuse [_Color] Ambient [_Color] }" +
            "        Lighting On" +
            "        SetTexture [_Dummy] { combine primary double, primary }" +
            "    }" +
            "}" +
            "}";

            Assert.Null(imageSprite.spriteMaterial);
            imageSprite.spriteMaterial = new Material(shaderText);

            Assert.NotNull(imageSprite.spriteMaterial);

            var color = new Color(1,155,1,0);
            Assert.That( imageSprite.spriteMaterial.color, Is.EqualTo(color) );
        }
    }

}

