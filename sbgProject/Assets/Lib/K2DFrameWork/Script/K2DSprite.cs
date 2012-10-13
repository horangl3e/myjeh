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


[AddComponentMenu( "2D/K2DSprite" )]
public class K2DSprite : MonoBehaviour 
{
	//---------------------------------------------------------------------
	/* variable */
	//---------------------------------------------------------------------
	
	public Material spriteMaterial;
	public Vector2 spriteTopLeft;
	public Vector2 spriteSize = Vector2.one;
	public SpriteOrientation spriteOrientation = SpriteOrientation.MiddleCenter;
	public SpriteUV spriteUV = SpriteUV.Full;
	
	
	protected Mesh m_mesh;
	protected MeshRenderer m_renderer;
	protected MeshFilter m_meshFilter;
	//private float m_defCameraPixels = 640f;
	
	
	//---------------------------------------------------------------------
	/* get function */
	//---------------------------------------------------------------------
		
	/*public float getDefCameraPixels
	{
		get
		{
			return m_defCameraPixels;
		}
	}*/
	
	//---------------------------------------------------------------------
	/* set function */
	//---------------------------------------------------------------------
	
	public void SetSpriteTopLeft( Vector2 _vec3TopLeft )
	{
		if( spriteTopLeft == _vec3TopLeft )
			return;	
		
		spriteTopLeft = _vec3TopLeft;
		
		ResetMeshTexture();
		ResetMeshData();
	}
	
	public void SetSpriteSize( Vector2 _vec3Size )
	{
		if( spriteSize == _vec3Size )
			return;
		
		spriteSize = _vec3Size;
		
		ResetMeshVertices();
		ResetMeshTexture();
		ResetMeshData();
	}
	
	public void SetSpriteOrientation( SpriteOrientation _eSpriteOrientation )
	{
		if( spriteOrientation == _eSpriteOrientation )
			return;
		
		spriteOrientation = _eSpriteOrientation;
		ResetMeshVertices();
		ResetMeshData();
	}
	
	public void SetSpriteUV( SpriteUV _eSpriteUV )
	{
		if( spriteUV == _eSpriteUV )
			return;
		spriteUV = _eSpriteUV;
		
		ResetMeshTexture();
		ResetMeshData();		
	}
	
	public virtual void SetSpriteMaterial( Material _material )
	{
		if( spriteMaterial == _material )
			return;
		
		spriteMaterial = _material;
		
		ResetMaterial();
		ResetMeshTexture();
		ResetMeshData();
	}
	
	/*public void SetDefCameraPixels( float fDefCameraPixels )
	{
		if( K2DView.defCameraPixels == fDefCameraPixels )
			return;
		
		m_defCameraPixels = fDefCameraPixels;
		
		ResetMeshVertices();
		ResetMeshData();
	}*/
	
	//---------------------------------------------------------------------
	/* function */
	//---------------------------------------------------------------------
	
	private void CreateDefault()
	{
		// renderer
		m_renderer = gameObject.GetComponent<MeshRenderer>();
		if( null == m_renderer )
		{
			m_renderer = gameObject.AddComponent<MeshRenderer>();
		}		
		m_renderer.castShadows = false;
		m_renderer.receiveShadows = false;
		  
		// mesh filter
		m_meshFilter = gameObject.GetComponent<MeshFilter>();
		if( null == m_meshFilter )
		{
			m_meshFilter = gameObject.AddComponent<MeshFilter>();
		}		
		
		// mesh
		if( null == m_mesh )
		{
			m_mesh = new Mesh();
			m_mesh.name = "SpriteMesh";		
			m_meshFilter.sharedMesh = m_mesh;	
		}
	} 
	
	
	
	
	private void ResetMeshVertices()
	{				
		float pixelPerWorldUnit = Camera.mainCamera.orthographicSize * 2f / K2DView.defCameraPixels;
		
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
			//Debug.LogError("ResetMeshTexture() [ null == m_renderer.sharedMaterial || null == m_renderer.sharedMaterial.mainTexture ]");
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
				new Vector2( 1f/texWidth * spriteTopLeft.x, 1f-1f/texHeight * (spriteSize.y + spriteSize.y) ),
				new Vector2( 1f/texWidth * spriteTopLeft.x, 1f-1f/texHeight * spriteSize.y ),
				new Vector2( 1f/texWidth * (spriteTopLeft.x + spriteSize.x), 1f-1f/texHeight * (spriteSize.y +spriteSize.y) ),
				new Vector2( 1f/texWidth * (spriteTopLeft.x + spriteSize.x), 1f-1f/texHeight * spriteSize.y ),
			};
		}	
	}
	
	private void ResetMeshData()
	{
		m_mesh.Optimize();
		m_mesh.RecalculateNormals();
		m_mesh.RecalculateBounds();
	}

	
	private void ResetMaterial()
	{
		if( null == spriteMaterial )
		{
			//Debug.LogError("KSimpleSprite::ResetMaterial() [ null == spriteMaterial ]");
			return;
		}		
		
		m_renderer.sharedMaterial = spriteMaterial;			
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
	
	// Use this for initialization
	void Start () 
	{
		InitStart();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	public virtual void InitStart()
	{
		
	}
}
