using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    public void DestroyParent()
    {
        Destroy(parent);
        
    }
}
