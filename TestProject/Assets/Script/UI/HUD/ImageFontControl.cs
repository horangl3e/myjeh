using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ImageFontControl : MonoBehaviour {

    public GameObject gameObject;
    public ArrayList gameObjectList = new ArrayList();
    private int ScoreValue = 0;
	public  bool Reverse = false;
    public Pivot pivot;
	public int DefaultValue = 0;
	public bool CommaDisable = false;
    public int GameObjectSize = 0;

    private float InitPosX = 0.0f;
    public bool CenterSort = false;

	public enum Pivot
	{
		Left,
		Right,
	}
	
    public int _ScoreValue
    {
        set { ScoreValue = value; }
		get { return ScoreValue; }
    }

    void Awake()
    {
        gameObjectList.Add(gameObject);
        for (int i = 0; i < GameObjectSize; i++)
            gameObjectList.Add(NGUITools.AddChild(gameObject.transform.parent.gameObject, gameObject));


        InitPosX = transform.localPosition.x;
    }

	void Update ()
    {
		string strName;
		if( DefaultValue!= 0 )
			strName = DefaultValue.ToString();
		else
			strName = ScoreValue.ToString();
		
		if( !CommaDisable )
		{
	        if (strName.Length > 9)
	        {
	            for (int j = 0; j < 3; j++)
	                strName = strName.Insert(strName.Length - (3 + (4 * j)), ",");
	        }
	        else if (strName.Length > 6)
	        {
	            for (int j = 0; j < 2; j++)
	                strName = strName.Insert(strName.Length - (3 + (4 * j)), ",");
	        }
	        else if (strName.Length > 3)
	        {
	            for (int j = 0; j < 1; j++)
	                strName = strName.Insert(strName.Length - (3 + (4 * j)), ",");
	        }			
		}
		
        char[] array = strName.ToCharArray();
		
		if(Reverse)
        	Array.Reverse(array);

        if (gameObjectList.Count > 0)
        {
            int gameObjectCount = 0;
            float SpriteObjectListWidth = 0.0f;
            foreach (char strNameObject in array)
            {
                GameObject SpriteObject = (GameObject)gameObjectList[gameObjectCount];
                UISprite uiSprite = SpriteObject.GetComponent<UISprite>();
                if (uiSprite)
                {
                    if (uiSprite.spriteName != strNameObject.ToString())
                    {
                        uiSprite.spriteName = strNameObject.ToString();
                        uiSprite.MakePixelPerfect();

                        Vector3 vec = new Vector3(SpriteObject.transform.localPosition.x, SpriteObject.transform.localPosition.y, SpriteObject.transform.localPosition.z);

                        if (gameObjectCount != 0)
                        {
                            GameObject pregameObject = (GameObject)gameObjectList[gameObjectCount - 1];

                            if (pivot == Pivot.Left)
                                vec.x = pregameObject.transform.localPosition.x + pregameObject.transform.localScale.x;
                            else
                                vec.x = pregameObject.transform.localPosition.x - pregameObject.transform.localScale.x;

                            uiSprite.transform.localPosition = vec;
                        }
                    }
                }
                gameObjectCount++;
                SpriteObjectListWidth += SpriteObject.transform.localScale.x;
            }

            if (CenterSort)
                transform.localPosition = new Vector3(InitPosX - (SpriteObjectListWidth/2), transform.localPosition.y, transform.localPosition.z);

            for (; gameObjectCount < gameObjectList.Count; gameObjectCount++)
            {
                GameObject SpriteObject = (GameObject)gameObjectList[gameObjectCount];
                UISprite uiSprite = SpriteObject.GetComponent<UISprite>();
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
