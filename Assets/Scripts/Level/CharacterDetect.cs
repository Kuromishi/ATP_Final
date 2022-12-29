using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDetect : MonoBehaviour
{
    public GameObject puzzleDoor;
    public GameObject doorMan;
    public GameObject toFind;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponentInParent<CharacterComponent>()!=null)
        {
            puzzleDoor.SetActive(true);
            doorMan.SetActive(true);
            toFind.SetActive(true);
        }
    }
}
