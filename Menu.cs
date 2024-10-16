using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Menu : MonoBehaviour
{
    public GameObject buttonPrefab;
    int buttonCount = 1;
    float offset = 0.3f;
    GameObject parent;
    public Transform mainCanvas;
    GameObject holder;
    public Material shaderMaterial;
    int menuSize = 10;
   
    
    public void setOffset(float o) 
    {
        if (o < 0.3) { o = 0.3f; } 
        if(offset != o)
        {
            offset = o;
            drawRadialMenu();
        }
         
    }
    public float getOffset() { return offset; }

    public int getMenuSize(){ return menuSize; }
    public void setMenuSize(int size) 
    {
        if (size != menuSize)
        {
            menuSize = size;
            drawRadialMenu();
        }
       
         
    }
    

    public float getInnerCircle(){ return shaderMaterial.GetFloat("_innerCircle");}
    public void setInnerCircle(float s) { shaderMaterial.SetFloat("_innerCircle",s); }

    public float getOuterCircle() { return shaderMaterial.GetFloat("_outerCircle"); }
    public void setOuterCircle(float s) { shaderMaterial.SetFloat("_outerCircle",s); }

    public int getButtonCount() { return buttonCount; }
    public void setButtonCount(int bC) 
    {
        
        if (bC > 360) { bC = 360; }
        if(bC < 1) { bC = 1; }
        if (360 % bC == 0)
        {
            if( bC != buttonCount)
            {
                buttonCount = bC;
                drawRadialMenu();
            }
            
            
           
            
        }
        else 
        {
            setButtonCount(bC -1);
        }

            
                
    }



    public float angleToRadian(float angle)
    {
        return Mathf.PI * angle / 180;
    }



    public void drawRadialMenu()
    {
        
        
        DestroyImmediate(parent);
        if(buttonCount == 0) { buttonCount = 1; }
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
