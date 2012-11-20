using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImageFont : MonoBehaviour {

    public Dictionary<string, UIAtlas.Sprite> DictionarySprite;

	// Use this for initialization
	void Start () {
        //0부터 이제 숫자 9까지 스프라이트를 insert 했다.
        UISprite uiSprite = gameObject.GetComponent<UISprite>();
        if (uiSprite)
        {
            UIAtlas uiAtlas = uiSprite.atlas;
            if (uiAtlas)
            {
                List<UIAtlas.Sprite> sprite = uiAtlas.spriteList;
                if (sprite.Count != 0)
                {
                    int i = 0;
                    foreach (UIAtlas.Sprite ObjectSprite in sprite)
                    {
                        DictionarySprite.Add(i.ToString(), ObjectSprite);
                        i++;
                    }
                }
            }

        }

        SetTest();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetTest()
    {
       int i = 9;

       if (DictionarySprite.ContainsKey(i.ToString()))
       {
          UIAtlas.Sprite sprite = DictionarySprite[i.ToString()];
          gameObject.GetComponent<UISprite>().spriteName = sprite.name;
       }



    }
}
