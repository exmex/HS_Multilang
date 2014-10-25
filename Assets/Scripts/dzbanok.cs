using UnityEngine;
using System.Collections;

public class dzbanok : MonoBehaviour {

	void OnMouseUpAsButton()
    {
        Camera.main.SendMessage("replace");
        transform.parent.gameObject.SetActive(false);
    }
}
