using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImageFont : MonoBehaviour {

    public Dictionary<string, UIAtlas.Sprite> DictionarySprite = new Dictionary<string, UIAtlas.Sprite>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetTest()
    {
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

       int j = 9;
       //���� �� ��������Ʈ ���� ���ڸ� ���� ����� �Ѵ�..
       //11123412 �̶�� �� ���� ���� ��� ���� ��� �´����� 
       Debug.Log(" DictionarySprite.Count = " + DictionarySprite.Count);
       if (DictionarySprite.ContainsKey(j.ToString()))
       {
           UIAtlas.Sprite sprite = DictionarySprite[j.ToString()];
          gameObject.GetComponent<UISprite>().spriteName = sprite.name;
       }

    }
}
