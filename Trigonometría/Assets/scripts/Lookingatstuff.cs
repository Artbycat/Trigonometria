using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookingatstuff : MonoBehaviour
{
    [SerializeField]
    private float fiaun;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = GetWorldMousePosition();
        Vector3 thisPos = transform.position;
        Vector3 dir = (mousePos - thisPos).normalized;
        var nyoom = dir * fiaun;
        Target(thisPos + nyoom);    
        Vector3 endPos = new Vector3(nyoom.x, nyoom.y, 0);
        transform.position += endPos * Time.deltaTime;
    }
    private Vector4 GetWorldMousePosition()
    {
        Camera cam = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        return worldPos;
    }
    private void RotZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
    private void Target(Vector3 targPos)
    {
        Vector3 mousePos = GetWorldMousePosition();
        Vector3 dif = mousePos - transform.position;
        float radians = Mathf.Atan2(dif.y, dif.x);
        RotZ(radians - Mathf.PI / 2);
    }
}
