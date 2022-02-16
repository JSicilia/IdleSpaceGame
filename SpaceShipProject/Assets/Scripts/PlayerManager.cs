using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int materialCount;
    public Text materialsText;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Hit");
        Debug.Log("hit" + collision);
        Destroy(collision.gameObject);
        addMaterial();
    }

    void addMaterial()
    {
        //materialCount++;
        //materialsText.text = "Materials: " + materialCount.ToString();
    }

    public int getMeteoriteCount()
    {
        return materialCount;
    }
    
}
