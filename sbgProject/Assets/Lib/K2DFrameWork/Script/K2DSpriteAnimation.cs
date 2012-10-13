using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class K2DFrame
{
	public string name = "";
	public int startFrame;
	public int endFrame;
	public bool loop = false;
	
	private Rect[] m_uvs;	
	private bool m_isEnd;
	private int m_iIndex = 0;
	private float m_fTime = 0.0f;
	
	public void Play()
	{
		m_iIndex = 0;		
	}
	public bool isEnd
	{
		get
		{			
			return m_isEnd;		
		}
	}
	
	public void Create( Vector2 imgXY )
	{		
		int iUvsMax = endFrame - startFrame;
		if( 0 >= iUvsMax )
			return;
		
		m_uvs = new Rect[ iUvsMax ];
		
		int iIndex = 0;
		for( int i=startFrame; i<endFrame; ++i )
		{
			float scx = 1f / imgXY.x;
        	float scy = 1f / imgXY.y;
			
			float f = (float)i;
			float tY = Mathf.Floor(f / imgXY.x);
            float tX = f - (int)(tY * imgXY.y);
			
			float sx = tX * scx;
            float sy = (imgXY.y - 1 - tY) * scy;
			
			m_uvs[iIndex++] = new Rect( sx, sy, scx, scy );			
		}
	}
	
	public void Remove()	
	{
		m_uvs = null;
	}
	
	public void Update( Material _mat, float _fSpeed )
	{
		//is end
		if( true == isEnd )
			return;
		
		// time
		m_fTime += Time.deltaTime;
		
		if( m_fTime < _fSpeed )
			return;
		
		// material
		if(null==_mat)
			return;			
		
		// indes 
		if( m_uvs.Length <= m_iIndex )
		{
			if( true == loop )
			{
				m_iIndex = 0;
				m_fTime = 0.0f;	
			}
			else
			{
				m_isEnd = true;
				return;
			}
			
		}
		
		_mat.mainTextureOffset = new Vector2( m_uvs[m_iIndex].x, m_uvs[m_iIndex].y );
		_mat.mainTextureScale = new Vector2( m_uvs[m_iIndex].width, m_uvs[m_iIndex].height );
		
		++ m_iIndex;
		m_fTime = 0.0f;	
	}
}

[AddComponentMenu( "2D/K2DSpriteAnimation" )]
public class K2DSpriteAnimation : K2DSprite
{
	public float speed;
	public Vector2 imgXY = Vector2.zero;
	public K2DFrame[] frameList;
	
	private K2DFrame m_CurFrame;
	
	public bool Play( string strName )
	{
		foreach( K2DFrame _frame in frameList )
		{
			if( _frame.name == strName )
			{
				m_CurFrame = _frame;
				m_CurFrame.Play();
				return true;
			}
		}
		
		return false;			
	}
	
	public void Stop()
	{
		m_CurFrame = null;
	}
	
	public bool isPlaying
	{
		get
		{
			return m_CurFrame != null;
		}		
	}
	
	public void SetImgXY( Vector2 _imgxy )
	{
		if( _imgxy == imgXY )
			return;
		imgXY = _imgxy;
		
		if( null != frameList )
		{
			foreach( K2DFrame _frame in frameList )
			{
				_frame.Remove();
			}
		}
		
		InitStart();
		InitSpriteUV();
	}
	
	public void SetFrameListCount( int iCount )
	{
		if( null == frameList )
		{
			if( 0 < iCount )
			{
				frameList = new K2DFrame[iCount];
				for( int i=0; i<frameList.Length; ++i )
				{
					frameList[i] = new K2DFrame();
				}
			}
			return;
		}
		
		if( frameList.Length == iCount )
			return;
		
		K2DFrame[] frameListTemp = new K2DFrame[iCount];
		for( int i=0; i<frameListTemp.Length; ++i )
		{
			frameListTemp[i] = new K2DFrame();
			
			if( frameList.Length <= i )			
				continue;		
			
			frameListTemp[i] = frameList[i];
		}
		
		frameList = frameListTemp;
	}
	
	public override void SetSpriteMaterial( Material _material )
	{
		base.SetSpriteMaterial(_material);
		InitSpriteUV();
	}
	
	public void SetFrameData( int iIndex, K2DFrame _data )
	{
		if( null == _data )
		{
			Debug.LogError("K2DSpriteAnimation::SetData()[ null == _data ] index : " + iIndex );
			return;
		}
		
		if( frameList.Length <= iIndex )
		{
			Debug.LogError("K2DSpriteAnimation::SetData()[ frameList.Length <= iIndex ] index : " + iIndex );
			return;
		}
		
		frameList[iIndex] = _data;
	}
	
	
	public override void InitStart()
	{
		if( imgXY == Vector2.zero )
		{
			Debug.LogError("[ imgXY == Vector2.zero ] value : " + imgXY );
			return;
		}
		
		if( null == frameList )
			return;
		
		foreach( K2DFrame _frame in frameList )
		{
			_frame.Create( imgXY );
		}		
	}
	
	private void InitSpriteUV()
	{
		if( null == spriteMaterial )
			return;
		
		float scx = 1f / imgXY.x;
    	float scy = 1f / imgXY.y;
		
		float f = (float)0;
		float tY = Mathf.Floor(f / imgXY.x);
        float tX = f - (int)(tY * imgXY.y);
		
		float sx = tX * scx;
        float sy = (imgXY.y - 1 - tY) * scy;
		
		spriteMaterial.mainTextureOffset = new Vector2( sx, sy );
		spriteMaterial.mainTextureScale = new Vector2( scx, scy );		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null != m_CurFrame )
		{
			m_CurFrame.Update( spriteMaterial, speed );
			if( true == m_CurFrame.isEnd )
			{
				m_CurFrame = null;
			}
		}
	}
}
