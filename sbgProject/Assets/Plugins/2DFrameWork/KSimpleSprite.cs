using UnityEngine;
using System.Collections;

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


[ExecuteInEditMode]
public class KSimpleSprite : MonoBehaviour 
{
	public Material spriteMaterial;
	public Vector2 spriteTopLeft;
	public Vector2 spriteSize = Vector2.one;
	public SpriteOrientation spriteOrientation = SpriteOrientation.MiddleCenter;
	public SpriteUV spriteUV = SpriteUV.Full;
	
	protected Mesh m_mesh;
	protected MeshRenderer m_renderer;
	protected MeshFilter m_meshFilter; 
	
#if UNITY_EDITOR
	private Vector2 preSpriteTopLeft;
	private Vector2 preSpriteSize;
	private float preDefCameraPixels = 640f;//(1024*768)
	private Material preSpriteMaterial;
	private SpriteOrientation preSpriteOrientation = SpriteOrientation.MiddleCenter;
	private SpriteUV preSpriteUV = SpriteUV.Full;	
#endif
	
	private void CreateMesh()
	{
		if( null != m_mesh )
		{
			Debug.LogError("KSimpleSprite::CreateMesh() [ null != m_mesh");
			return;
		}
		  
		// mesh
		m_mesh = new Mesh();
		m_mesh.name = "SpriteMesh";		
		m_meshFilter.sharedMesh = m_mesh;
	} 
	
	private void ResetMeshVertices()
	{
		float pixelPerWorldUnit = Camera.mainCamera.orthographicSize * 2f / K2DView.Instance.defCameraPixels;
		
		if( SpriteOrientation.MiddleCenter == spriteOrientation )	
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
		
		m_mesh.triangles = new int[]{ 0, 1, 3, 0, 3, 2 };	
	}
	
	private void ResetMeshTexture()
	{
		if( null == m_renderer.sharedMaterial || null == m_renderer.sharedMaterial.mainTexture )
		{
			Debug.LogError("null == m_renderer.sharedMaterial || null == m_renderer.sharedMaterial.mainTexture");
			return;
		}
		
		
		float texWidth = m_renderer.sharedMaterial.mainTexture.width;
		float texHeight = m_renderer.sharedMaterial.mainTexture.height;
		
		if( SpriteUV.Full == spriteUV )
		{
			m_mesh.uv = new Vector2[]
			{
				new Vector2( 0.0f, 0f),
				new Vector2( 0f, 1f ),
				new Vector2( 1f, 0f ),
				new Vector2( 1f, 1f)
			};
		}
		else
		{
			m_mesh.uv = new Vector2[]
			{
				new Vector2( 1f/texWidth * spriteTopLeft.x, 1f-1f/texHeight * (spriteTopLeft.y + spriteSize.y) ),
				new Vector2( 1f/texWidth * spriteTopLeft.x, 1f-1f/texHeight * spriteTopLeft.y ),
				new Vector2( 1f/texWidth * (spriteTopLeft.x + spriteSize.x), 1f-1f/texHeight * (spriteTopLeft.y +spriteSize.y) ),
				new Vector2( 1f/texWidth * (spriteTopLeft.x + spriteSize.x), 1f-1f/texHeight * spriteTopLeft.y ),
			};
		}	
	}
	
	private void RestMeshData()
	{
		m_mesh.Optimize();
		m_mesh.RecalculateNormals();
		m_mesh.RecalculateBounds();
	}
	
	private void CreateRenderer()
	{
		if( null != m_mesh )
		{
			Debug.LogError("KSimpleSprite::CreateRenderer() [ null != m_renderer");
			return;
		}
		
		m_renderer = gameObject.GetComponent<MeshRenderer>();
		if( null == m_renderer )
		{
			m_renderer = gameObject.AddComponent<MeshRenderer>();
		}
		
		m_renderer.castShadows = false;
		m_renderer.receiveShadows = false;
	}
	
	
	
	private void SetMaterial()
	{
		if( null == spriteMaterial  || null == spriteMaterial.mainTexture )
		{
			Debug.LogError("KSimpleSprite::SetMaterial() [ null == spriteMaterial  || null == spriteMaterial.mainTexture ]");
			return;
		}		
		
		m_renderer.sharedMaterial = spriteMaterial;			
	}
	
	
	void Awake()
	{	
		m_meshFilter = gameObject.GetComponent<MeshFilter>();
		if( null == m_meshFilter )
		{
			m_meshFilter = gameObject.AddComponent<MeshFilter>();
		}
		
		CreateRenderer();
		CreateMesh();	
		ResetMeshVertices();

		if( null == spriteMaterial  || null == spriteMaterial.mainTexture )
			return;
		
		SetMaterial();
		ResetMeshTexture();
		RestMeshData();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
#if UNITY_EDITOR
		if( true == Application.isPlaying )
			return;
		
		if( spriteSize != preSpriteSize)
		{
			ResetMeshVertices();
			ResetMeshTexture();
			RestMeshData();
			
			preSpriteSize = spriteSize;
		}
		
		if( spriteTopLeft != preSpriteTopLeft)
		{
			ResetMeshTexture();
			RestMeshData();
			
			preSpriteTopLeft = spriteTopLeft; 
		}		
		
		if( K2DView.Instance.defCameraPixels != preDefCameraPixels)
		{
			ResetMeshVertices();
			RestMeshData();
			preDefCameraPixels = K2DView.Instance.defCameraPixels;
		}		
		
		if( spriteMaterial != preSpriteMaterial)
		{
			SetMaterial();
			ResetMeshTexture();
			RestMeshData();
			preSpriteMaterial = spriteMaterial;
		}
		
		if( spriteOrientation != preSpriteOrientation )
		{
			ResetMeshVertices();
			RestMeshData();
			preSpriteOrientation = spriteOrientation;
		}
		
		if( spriteUV != preSpriteUV )
		{
			ResetMeshTexture();
			RestMeshData();
			preSpriteUV = spriteUV;
		}
#endif
	}
}
