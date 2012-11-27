using UnityEngine;
using System.Collections;

public class ShopReceiveDescriptionMessage : MonoBehaviour {

    public void ReceiveMessage(string strMessage)
    {
        UILabel uiLabel = gameObject.GetComponent<UILabel>();
        if (uiLabel)
            uiLabel.text = strMessage;
    }

}
