using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ImageFontControl : MonoBehaviour {

    public  GameObject ImageObject;
    public  ArrayList gameObjectList = new ArrayList();
	public  bool Reverse = false;
    public  Pivot pivot;
	public  int DefaultValue = 0;
	public  bool CommaDisable = false;
    public  int GameObjectSize = 0;

    private float InitPosX = 0.0f;
    private int ScoreValue = 0;

    public  bool CenterSort = false;
	public  int Interval = 0;
    public  int FixingVisibleSize = 0;
    public  int CommaPreInterval = 0;
    public  int CommaNextInterval = 0;

    private string stringValue;

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
        gameObjectList.Add(ImageObject);

        for (int i = 0; i < GameObjectSize; i++)
            gameObjectList.Add(NGUITools.AddChild(ImageObject.transform.parent.gameObject, ImageObject));

        InitPosX = transform.localPosition.x;
    }

    bool IsCommaDisable()
    {
        return CommaDisable;
    }

    void InsertComma()
    {
        if (this.stringValue.Length > 9)
        {
            for (int j = 0; j < 3; j++)
                this.stringValue = this.stringValue.Insert(this.stringValue.Length - (3 + (4 * j)), ",");
        }
        else if (this.stringValue.Length > 6)
        {
            for (int j = 0; j < 2; j++)
                this.stringValue = this.stringValue.Insert(this.stringValue.Length - (3 + (4 * j)), ",");
        }
        else if (this.stringValue.Length > 3)
        {
            for (int j = 0; j < 1; j++)
                this.stringValue = this.stringValue.Insert(this.stringValue.Length - (3 + (4 * j)), ",");
        }	
    }

    void SetInvisible(int GameObjectCount)
    {
        for (; GameObjectCount < gameObjectList.Count; GameObjectCount++)
        {
            GameObject SpriteObject = (GameObject)gameObjectList[GameObjectCount];
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

	void Update ()
    {
		if( DefaultValue!= 0 )
            this.stringValue = DefaultValue.ToString();
		else
            this.stringValue = ScoreValue.ToString();

        if (!IsCommaDisable())
            InsertComma();

        InsertZeroString();

        char[] array = this.stringValue.ToCharArray();
		
		if(Reverse)
        	Array.Reverse(array);

        if (gameObjectList.Count > 0)
        {
            int   gameObjectCount = 0;
            float SpriteObjectListWidth = 0.0f;
            float PreSpriteObjectListWidth = 0.0f;
            char  PreString = '&';

            foreach (char strNameObject in array)
            {
                GameObject SpriteObject = (GameObject)gameObjectList[gameObjectCount];
				if( SpriteObject )
				{
	                UISprite uiSprite = SpriteObject.GetComponent<UISprite>();
	
	                if (uiSprite)
	                {
	                    if ((uiSprite.spriteName != strNameObject.ToString()) )
	                       SetPosition(ref uiSprite, strNameObject, SpriteObject, gameObjectCount, PreString);
	                }					
				}
                gameObjectCount++;
                SpriteObjectListWidth += SpriteObject.transform.localScale.x;
                PreString = strNameObject;
            }

            if (PreSpriteObjectListWidth != SpriteObjectListWidth)
                SpriteObjectListWidth = Resize(array);

            PreSpriteObjectListWidth = SpriteObjectListWidth;

            SetTopDepth(array);

            if (CenterSort)
                transform.localPosition = new Vector3(InitPosX - (SpriteObjectListWidth/2), transform.localPosition.y, transform.localPosition.z);
            
            if (FixingVisibleSize > 0)
                gameObjectCount = FixingVisibleSize;

            SetInvisible(gameObjectCount);
        }
	}

    private float Resize(char[] array)
    {
        char  PreString             = '&';
        int   gameObjectCount       = 0;
        float SpriteObjectListWidth = 0.0f;

        foreach (char strNameObject in array)
        {
            GameObject SpriteObject = (GameObject)gameObjectList[gameObjectCount];
            UISprite uiSprite = SpriteObject.GetComponent<UISprite>();

            if (uiSprite)
                SetPosition(ref uiSprite, strNameObject, SpriteObject, gameObjectCount, PreString);

            gameObjectCount++;
            SpriteObjectListWidth += SpriteObject.transform.localScale.x;
            PreString = strNameObject;
        }

        return SpriteObjectListWidth;
    }

    private void InsertZeroString()
    {
        if (this.stringValue.Length < FixingVisibleSize)
        {
            int temp = FixingVisibleSize - this.stringValue.Length;
            for (int i = 0; i < temp; i++)
                this.stringValue = this.stringValue.Insert(0, "0");
        }
    }

    private void SetPosition(ref UISprite uiSprite, char strNameObject, GameObject SpriteObject, int gameObjectCount, char PreString)
    {
        uiSprite.spriteName = strNameObject.ToString();
        Vector3 vec = new Vector3(SpriteObject.transform.localPosition.x, SpriteObject.transform.localPosition.y, SpriteObject.transform.localPosition.z);
        if (gameObjectCount != 0)
        {
            GameObject pregameObject = (GameObject)gameObjectList[gameObjectCount - 1];

            if (pivot == Pivot.Left)
            {
                if (strNameObject == ',')
                    vec.x = GetPos(pregameObject) + CommaPreInterval;
                else if (PreString == ',')
                    vec.x = GetPos(pregameObject) + CommaPreInterval + CommaNextInterval;
                else
                    vec.x = GetPos(pregameObject);
            }
            else
                vec.x = pregameObject.transform.localPosition.x - pregameObject.transform.localScale.x - Interval;

            uiSprite.transform.localPosition = vec;
        }
        uiSprite.MakePixelPerfect();
    }

    private int GetPos(GameObject pregameObject)
    {
        return (int)pregameObject.transform.localPosition.x + (int)pregameObject.transform.localScale.x + this.Interval;
    }

    private void SetTopDepth(char[] array)
    {
        int gameObjectCount = 0;
        foreach (char strNameObject in array)
        {
            if (strNameObject == ',')
            {
                GameObject SpriteObject = (GameObject)gameObjectList[gameObjectCount];
                if (SpriteObject)
                {
                    UISprite uiSprite = SpriteObject.GetComponent<UISprite>();
                    if (uiSprite)
                        uiSprite.depth = 9999;
                }
            }
            gameObjectCount++;
        }
    }
}