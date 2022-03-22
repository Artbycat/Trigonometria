using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plswork : MonoBehaviour
{
    [SerializeField] 
    private float radius;
    [SerializeField] 
    private float theta;
    [Header ("Nyoom")]
    [SerializeField]
    private float nyoomAngular = 1f;
    [SerializeField]
    private float nyoomRadial = 1f;

    // Update is called once per frame
    void Update()
    {
        //esto hace que se vea bonito
        theta += nyoomAngular * Time.deltaTime;
        radius += nyoomRadial * Time.deltaTime;
        //esto hace que se mueva
        Vector3 cartesiano = PolarToCartesian(radius, theta);
        transform.localPosition = cartesiano;
        //dibujación
        Debug.DrawLine(Vector3.zero, cartesiano);
        Checklmt();
    }

    Vector3 PolarToCartesian(float r, float theta)
    {
        return new Vector3(r * Mathf.Cos(theta), r * Mathf.Sin(theta));
    }

    public void Checklmt()
    {
        if (radius >= 4.5 || radius <= -4.5)
            nyoomRadial = nyoomRadial * -1;
        if (radius <= 4.5 || radius >= -4.5)
            nyoomRadial = nyoomRadial * 1;
    }
}
