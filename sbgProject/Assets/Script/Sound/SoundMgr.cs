using UnityEngine;
using System.Collections;

public class SoundMgr : MonoBehaviour 
{	GameObject m_kSoundObject;	


	private static SoundMgr m_kInstance = null;
	public static SoundMgr Instance
	{
		get	
		{ 
			return m_kInstance; 
		}
	}

	void Awake()
	{
		m_kInstance = this;		
		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{		
		m_kSoundObject = Resources.Load( "Sound/SoundObject" ) as GameObject;
	}


	public AudioSource PlaySound( string _filename, Vector3 _pos, bool loop )
	{
		if( _pos == Vector3.zero )
		{
			//AsUserEntity userEntity = AsUserInfo.Instance.GetCurrentUserEntity();
			//if( null == userEntity)
				_pos = Camera.main.transform.position;
			//else
			//	_pos = userEntity.gameObject.transform.position;
		}

		GameObject go = GameObject.Instantiate( m_kSoundObject, _pos, Quaternion.identity ) as GameObject;
		go.name = "SND_" + _filename;
		AudioClip clip = Resources.Load( "Sound/" + _filename ) as AudioClip;
		go.audio.clip = clip;
		go.audio.loop = loop;
		go.audio.Play();
		//go.transform.parent = soundRoot.transform;
		
		return go.audio;
	}
	
	public void  StopSound( AudioSource source)
	{
		if( null == source)
			return;
		
		source.Stop();
		source = null;
	}
	
	public void UpdatePosition( AudioSource source, Vector3 pos)
	{
		if( null == source)
			return;
		
		source.transform.position = pos;
	}
}
