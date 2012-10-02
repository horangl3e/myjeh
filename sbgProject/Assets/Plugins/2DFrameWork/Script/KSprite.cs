using UnityEngine;
using System.Collections;

public class KSprite : MonoBehaviour 
{
    private Material _material;    
    private Vector2 _texOffset;

   
	void Awake()
	{
		
	}
   
    void Start()
    {       
        _material = gameObject.renderer.material;   
        _texOffset = _material.GetTextureOffset("_MainTex");
	}

    void Update()
    {
        _texOffset.x += Time.deltaTime;
        _material.SetTextureOffset("_MainTex", _texOffset);
    }
}
