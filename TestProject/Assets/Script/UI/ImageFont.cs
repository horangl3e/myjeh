using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImageFont : MonoBehaviour {

    public Dictionary<string, UIAtlas.Sprite> DictionarySprite;

	// Use this for initialization
	void Start () {
        //0���� ���� ���� 9���� ��������Ʈ�� insert �ߴ�.
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
