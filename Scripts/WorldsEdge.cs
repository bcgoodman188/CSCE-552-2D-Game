using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldsEdge : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Rock") {
            Destroy(other.gameObject);
        }
    }
}
