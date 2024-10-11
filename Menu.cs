using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject buttonPrefab;
    public int buttonCount;
    public float offset;
    GameObject parent;
    public Transform mainCanvas;
    GameObject holder;
    public Material shaderMaterial;
    float menuSize = 10;


    public float getMenuSize(){ return menuSize; }
    public void setMenuSize(float size){ menuSize = size; }
    
    public float angleToRadian(float angle)
    {
        return Mathf.PI * angle / 180;
    }



    public void drawRadialMenu()
    {
        
        
        DestroyImmediate(parent);

        shaderMaterial.SetFloat("_degree", (360 / buttonCount));
        
        parent = new GameObject("radialMenu");
        parent.transform.SetParent(mainCanvas,true);

        for (int i = 0; i < buttonCount; i++)
        {
            float angle = (360 / buttonCount) * i;

            holder = Instantiate(buttonPrefab, parent.transform.position, parent.transform.rotation);
            holder.name = "button" + i;
            holder.transform.SetParent(parent.transform, true);


            holder.GetComponent<RectTransform>().localScale = Vector3.one;
            holder.GetComponent<RectTransform>().sizeDelta = new Vector2(menuSize, menuSize);
            //holder.GetComponent<RectTransform>().position = Vector3.zero;
            Vector3 temp = transform.rotation.eulerAngles;
            temp.z = angle;
            holder.transform.rotation = Quaternion.Euler(temp);


            holder.transform.position = new Vector3(Mathf.Cos(angleToRadian(angle + 90)) * offset, Mathf.Sin(angleToRadian(angle + 90)) * offset);

            




        }

    }
}
