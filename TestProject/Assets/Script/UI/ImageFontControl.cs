using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ImageFontControl : MonoBehaviour {

    public GameObject[] gameObject;

    private UISprite meterImage;
    private int ScoreValue = 0;
	public  int Interval;

    public int _ScoreValue
    {
        set { ScoreValue = value; }
		get { return ScoreValue; }
    }

	void Update ()
    {
        ScoreValue = 12;
        string strName = ScoreValue.ToString();

       strName =  strName.Insert(1, ",");

//         if (strName.Length > 9)
//         {
//             for (int j = 0; j < 3; j++)
//                 strName = strName.Insert(strName.Length - (3 + (4 * j)), ",");
//         }
//         else if (strName.Length > 6)
//         {
//             for (int j = 0; j < 2; j++)
//                 strName = strName.Insert(strName.Length - (3 + (4 * j)), ",");
//         }
//         else if (strName.Length > 3)
//         {
//             for (int j = 0; j < 1; j++)
//                 strName = strName.Insert(strName.Length - (3 + (4 * j)), ",");
//         }

        char[] array = strName.ToCharArray();
        //Array.Reverse(array);

        if (gameObject.Length != 0)
        {
            int gameObjectCount = 0;
            foreach (char strNameObject in array)
            {
                UISprite uiSprite = gameObject[gameObjectCount].GetComponent<UISprite>();
                if (uiSprite)
                {
                    if (uiSprite.spriteName != strNameObject.ToString())
                    {
                        uiSprite.spriteName = strNameObject.ToString();
                        uiSprite.MakePixelPerfect();              
                        Vector3 vec = new Vector3(gameObject[gameObjectCount].transform.localPosition.x, gameObject[gameObjectCount].transform.localPosition.y, gameObject[gameObjectCount].transform.localPosition.z);
                        if (gameObjectCount != 0)
                        {
                            vec.x = gameObject[gameObjectCount - 1].transform.localPosition.x - gameObject[gameObjectCount - 1].transform.localScale.x;
                           uiSprite.transform.localPosition = vec;
                        }

                    }
                }
                gameObjectCount++;
            }

//             meterImage = gameObject[gameObjectCount].GetComponent<UISprite>();
//             if (meterImage)
//             {
//                 if (meterImage.spriteName.ToString() != "Gold_Num")
//                 {
//                     meterImage.spriteName = "Gold_Num";
//                     meterImage.MakePixelPerfect();
//                 }
//                 gameObjectCount++;
//             }

            for (; gameObjectCount < gameObject.Length; gameObjectCount++)
            {
                UISprite uiSprite = gameObject[gameObjectCount].GetComponent<UISprite>();
                if (uiSprite)
                {
                    if (uiSprite.spriteName != "Score_Alpha")
                    {
                        uiSprite.spriteName = "Score_Alpha";
                        uiSprite.MakePixelPerfect();
                    }
                }
            }
        }
	}
}
