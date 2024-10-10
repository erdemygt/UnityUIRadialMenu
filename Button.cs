using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : Image
{
    float innerCircle;           //_InnerCircle
    float outerCircle;           //_OuterCircle
    float degree;
    float tanDegree;
    float innerMin;
    float outerMax;
    public override bool Raycast(Vector2 sp, Camera eventCamera)
    {
        // Get the local point from the screen point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, sp, eventCamera, out Vector2 localPoint);


        


        // Normalize the local point
        Vector2 normalizedPoint = new Vector2(
            (localPoint.x - rectTransform.rect.x) / rectTransform.rect.width,
            (localPoint.y - rectTransform.rect.y) / rectTransform.rect.height
        );

        innerCircle = material.GetFloat("_innerCircle");           //_InnerCircle
        outerCircle = material.GetFloat("_outerCircle");           //_OuterCircle
        degree = material.GetFloat("_degree") ;


        // Here you check against your shader's shape
        // For example, using a circular shape
        if (IsPointWithinCustomShape(normalizedPoint))
        {
            //Debug.Log("inside");
            return true;  // The click is within the shape
        }

        return false;  // Otherwise, ignore the click
    }

    // Implement the shape checking logic (for example, a circular shape)
    private bool IsPointWithinCustomShape(Vector2 normalizedPoint)
    {
        
        //innerCircle = material.GetFloat("_innerCircle");
        //outerCircle = material.GetFloat("_outerCircle");
        // Example: Circular hit detection
        innerMin = Mathf.Min(innerCircle, outerCircle);
        outerMax = Mathf.Max(outerCircle, innerCircle);
        //Debug.Log("inner:" + innerMin + " outer:" + outerMax);
        //degree =  (degree * (MathF.PI)) / 180;
        tanDegree = 90 - degree / 2;
        tanDegree = tanDegree * Mathf.PI / 180;
        float distance = Vector2.Distance(normalizedPoint, new Vector2(0.5f, 0.5f));
        
        bool check = (distance >= (innerMin / 2)) && (distance <= (outerMax / 2)) 
            && (normalizedPoint.y > 0.5f)
            && ((normalizedPoint.y - 0.5) >= Mathf.Tan(tanDegree) * (normalizedPoint.x - 0.5) ) 
            && ((normalizedPoint.y - 0.5) >= -Mathf.Tan(tanDegree) * (normalizedPoint.x - 0.5)  );
        return check ;  // Within the radius of the circle
    }


    public void setOffset(float o)
    {
        
        transform.localPosition = new Vector3(0, o, 0);
    }
    
    

    

    public void printName()
    {
        Debug.Log(gameObject.name);
    }
   
}
