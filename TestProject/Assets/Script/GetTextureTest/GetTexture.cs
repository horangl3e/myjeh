using UnityEngine;
using System.Collections;

public class GetTexture : MonoBehaviour {
	
	public Color[] color;
	// Use this for initialization
	void Start () {
        GameObject UIAtlasData = (GameObject)Resources.Load("UI/HUD/SpeedGage/SpeedGageMaterial/SpeedGage");

        if (UIAtlasData == null)
            Debug.Log("AtlasData null");

        UIAtlas uiAtlas = UIAtlasData.GetComponent<UIAtlas>();

        if (uiAtlas == null)
            Debug.Log("ui Atlas Null");

        UIAtlas.Sprite sprite = uiAtlas.GetSprite("Fuel_Gauge_00");

        if (sprite == null)
            Debug.Log("ui sprite Null");
		
		

        UIFilledSprite uiFilledSprite = gameObject.GetComponent<UIFilledSprite>();
        if (uiFilledSprite)
        {
            Debug.Log("11111111111111 = " + uiFilledSprite.spriteName);
            Debug.Log("2222222222222" + uiFilledSprite.material.name);

//             Texture spriteNametex = uiFilledSprite.material.GetTexture(uiFilledSprite.spriteName);
//             if (spriteNametex)
//             {
//                 Debug.Log("4444444444444" + spriteNametex.name);
// 
//             }
            Debug.Log("44444444444444444444 " + uiFilledSprite.sprite.name);

            Debug.Log("uiFilledSprite.sprite.inner" + uiFilledSprite.sprite.inner);
            Debug.Log("uiFilledSprite.sprite.outer" + uiFilledSprite.sprite.outer);

            Texture2D texture = (Texture2D)uiFilledSprite.material.mainTexture;
            if (texture)
            {
               color = texture.GetPixels((int)uiFilledSprite.sprite.inner.left, (int)uiFilledSprite.sprite.inner.top, (int)uiFilledSprite.sprite.inner.width, (int)uiFilledSprite.sprite.inner.height);
			   Debug.Log("colors.Length = " + color.Length );
            }
            uiFilledSprite.color = color[100];
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
