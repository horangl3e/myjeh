using UnityEngine;
using System.Collections;

namespace SpriteSpace
{
    public enum SpriteOrientation
    {
        TopLeft,
        MiddleCenter
    };

    public enum SpriteUV
    {
        Full,
        Tex,
    }

    public class ImageSprite: MonoBehaviour
    {
        public Material spriteMaterial;
        public Vector2  spriteTopLeft;
        public Vector2 spriteSize = Vector2.one;
        public SpriteOrientation spriteOrientation = SpriteOrientation.MiddleCenter;
        public SpriteUV spriteUV = SpriteUV.Full;

        protected Mesh m_mesh;
        protected MeshRenderer m_renderer;
        protected MeshFilter m_meshFilter;

        public void ResetMeshTexture()
        {
            if (null == m_renderer.sharedMaterial || null == m_renderer.sharedMaterial.mainTexture)
                return;

            float texWidth = m_renderer.sharedMaterial.mainTexture.width;
            float texHeight = m_renderer.sharedMaterial.mainTexture.height;

            if( SpriteUV.Full == spriteUV )
            {
                m_mesh.uv = new Vector2[]
                {
                    new Vector2(0.0f, 0.0f),
                    new Vector2(0.0f, 0.0f),
                    new Vector2(1.0f, 0.0f),
                    new Vector2(1.0f, 1.0f)
                };
            }
            else
            {
                m_mesh.uv = new Vector2[]
                {
		            new Vector2( 1f/texWidth * spriteTopLeft.x, 1f-1f/texHeight * (spriteSize.y + spriteSize.y) ),
				    new Vector2( 1f/texWidth * spriteTopLeft.x, 1f-1f/texHeight * spriteSize.y ),
				    new Vector2( 1f/texWidth * (spriteTopLeft.x + spriteSize.x), 1f-1f/texHeight * (spriteSize.y +spriteSize.y) ),
				    new Vector2( 1f/texWidth * (spriteTopLeft.x + spriteSize.x), 1f-1f/texHeight * spriteSize.y ),
                };
            }
        }

        public void CreateInEdit()
        {
            CreateDefault();
            ResetMeshVertices();
            ResetMaterial();
            ResetMeshTexture();
            ResetMeshData();
        }

        void Awake()
        {
            CreateDefault();
            ResetMeshVertices();
            ResetMaterial();
            ResetMeshTexture();
            ResetMeshData();
        }

        void Start()
        {
        }

        void Update()
        {

        }

        private void ResetMeshData()
        {
            m_mesh.Optimize();
            m_mesh.RecalculateNormals();
            m_mesh.RecalculateBounds();
        }


        public void SetSpriteTopLeft(Vector2 _Vec3TopLeft)
        {
            if (spriteTopLeft == _Vec3TopLeft)
                return;

            spriteTopLeft = _Vec3TopLeft;
            ResetMeshTexture();
            ResetMeshData();
        }

        public void SetSpriteSize(Vector2 _vec3Size)
        {
            if (spriteSize == _vec3Size)
                return;

            spriteSize = _vec3Size;

            ResetMeshVertices();
            ResetMeshTexture();
            ResetMeshData();
        }

        public void SetSpriteOrientation(SpriteOrientation _eSpriteOrientation)
        {
            if (spriteOrientation == _eSpriteOrientation)
                return;

            spriteOrientation = _eSpriteOrientation;
            ResetMeshVertices();
            ResetMeshData();
        }

        public void SetSpriteUV(SpriteUV _eSpriteUV)
        {
            if (spriteUV == _eSpriteUV)
                return;

            spriteUV = _eSpriteUV;

            ResetMeshTexture();
            ResetMeshData();
        }

        public virtual void SetSpriteMaterial(Material _material)
        {
            if (spriteMaterial == _material)
                return;

            spriteMaterial = _material;

            ResetMaterial();
            ResetMeshTexture();
            ResetMeshData();
        }

        protected void ResetMaterial()
        {
            if (null == spriteMaterial)
                return;

            m_renderer.sharedMaterial = spriteMaterial;
        }

        private void ResetMeshVertices()
        {
            //이거 왜 640인지 알아 내야 함
            float pixelPerWorldUnit = Camera.mainCamera.orthographicSize * 2f / 640;

            if (SpriteOrientation.MiddleCenter == spriteOrientation)
            {
                m_mesh.vertices = new Vector3[]
			{
				new Vector3( -spriteSize.x, -spriteSize.y ) * pixelPerWorldUnit * 0.5f,
				new Vector3( -spriteSize.x, spriteSize.y ) * pixelPerWorldUnit * 0.5f,
				new Vector3( spriteSize.x, -spriteSize.y ) * pixelPerWorldUnit * 0.5f,
				new Vector3( spriteSize.x, spriteSize.y ) * pixelPerWorldUnit * 0.5f
			};
            }
            else
            {
                m_mesh.vertices = new Vector3[]
			{
				new Vector3( 0, -spriteSize.y ) * pixelPerWorldUnit,
				new Vector3( 0, 0 ) * pixelPerWorldUnit,
				new Vector3( spriteSize.x, -spriteSize.y ) * pixelPerWorldUnit,
				new Vector3( spriteSize.x, 0 ) * pixelPerWorldUnit
			};
            }

            m_mesh.triangles = new int[] { 0, 1, 3, 0, 3, 2 };
        }

        protected void CreateDefault()
        {
            // renderer
            m_renderer = gameObject.GetComponent<MeshRenderer>();
            if (null == m_renderer)
                m_renderer = gameObject.AddComponent<MeshRenderer>();

            m_renderer.castShadows = false;
            m_renderer.receiveShadows = false;

            // mesh filter
            m_meshFilter = gameObject.GetComponent<MeshFilter>();
            if (null == m_meshFilter)
                m_meshFilter = gameObject.AddComponent<MeshFilter>();

            // mesh
            if (null == m_mesh)
            {
                m_mesh = new Mesh();
                m_mesh.name = "SpriteMesh";
                m_meshFilter.sharedMesh = m_mesh;
            }

        } 
    }
}

