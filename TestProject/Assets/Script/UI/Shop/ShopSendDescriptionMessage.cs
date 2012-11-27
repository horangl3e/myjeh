using UnityEngine;
using System.Collections;

public class ShopSendDescriptionMessage : MonoBehaviour {

    public GameObject[] ReceiveObject;
	public string	    strSendMessage;
	
	void OnClick()
    {
		for (int i = 0; i < ReceiveObject.Length; i++ )
        {
            ShopReceiveDescriptionMessage shopDes = ReceiveObject[i].GetComponent<ShopReceiveDescriptionMessage>();
            if (shopDes)
                shopDes.ReceiveMessage(strSendMessage);
        }
	}
}
