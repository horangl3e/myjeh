using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class K2DFrame
{
	public string name;
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
	
	public void Create(K2DFrameImg _img)
	{
		if( null == _img )
			return;
		
		m_uvs = new Rect[ endFrame - startFrame ];
		
		int iIndex = 0;
		for( int i=startFrame; i<endFrame; ++i )
		{
			float scx = 1f / _img.framesXY.x;
        	float scy = 1f / _img.framesXY.y;
			
			float f = (float)i;
			float tY = Mathf.Floor(f / _img.framesXY.x);
            float tX = f - (int)(tY * _img.framesXY.y);
			
			float sx = tX * scx;
            float sy = (_img.framesXY.y - 1 - tY) * scy;
			
			m_uvs[iIndex++] = new Rect( sx, sy, scx, scy );			
		}
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

[System.Serializable]
public class K2DFrameImg
{
	public Vector2 framesXY = Vector2.zero;	
}

public class K2DSpriteAnimation : K2DSprite
{
	public float speed;
	public K2DFrameImg frameImg;
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
	
	public bool isPlay
	{
		get
		{
			return m_CurFrame != null;
		}		
	}
	
	
	public override void InitStart()
	{
		if( frameImg.framesXY == Vector2.zero )
		{
			Debug.LogError("[ frameImg.framesXY == Vector2.zero ] value : " + frameImg.framesXY );
			return;
		}
		
		foreach( K2DFrame _frame in frameList )
		{
			_frame.Create( frameImg );
		}
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
