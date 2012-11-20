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

       int j = 9;
       //이제 각 스프라이트 마다 숫자를 전달 해줘야 한다..
       //11123412 이라면 맨 끝에 부터 토근 별로 얻어 온다음에 
       Debug.Log(" DictionarySprite.Count = " + DictionarySprite.Count);
       if (DictionarySprite.ContainsKey(j.ToString()))
       {
           UIAtlas.Sprite sprite = DictionarySprite[j.ToString()];
          gameObject.GetComponent<UISprite>().spriteName = sprite.name;
       }

    }
}
