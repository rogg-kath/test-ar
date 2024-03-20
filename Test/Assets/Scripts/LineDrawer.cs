using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    List<Vector3> linePoints;
    float timer;
    public float timerDelay;

    GameObject newLine;
    LineRenderer drawLine;
    public float lineWidth;
    

    // Start is called before the first frame update
    void Start()
    {
        linePoints = new List<Vector3>();
        timer = timerDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            SetupLineRenderer();
        }

        if (Input.GetMouseButton(0)) {
            DrawContinous();
        }

        if (Input.GetMouseButtonUp(0)) {
            // Debug.Log(linePoints.Count);
            linePoints.Clear();
        }
    }

    Vector3 GetMousePosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ray.origin + ray.direction * 10;
    }

    Color randomColor() {
        return Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    void SetupLineRenderer() {
        newLine = new GameObject();
        drawLine = newLine.AddComponent<LineRenderer>();
        drawLine.material = new Material(Shader.Find("Sprites/Default"));
        drawLine.startColor = randomColor();
        drawLine.endColor = drawLine.startColor;
        drawLine.startWidth = lineWidth;
        drawLine.endWidth = lineWidth;
    }

    void DrawContinous() {
        Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), GetMousePosition(), Color.red);
        timer -= Time.deltaTime;
        if (timer <= 0) {
            linePoints.Add(GetMousePosition());
            drawLine.positionCount = linePoints.Count;
            drawLine.SetPositions(linePoints.ToArray());
            timer = timerDelay;
        }
    }
}
