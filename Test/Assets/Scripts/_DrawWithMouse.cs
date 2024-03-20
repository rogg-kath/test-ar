using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 previsousPosition;

    [SerializeField]
    private float minDistance = 0.1f;

    // Start is called before the first frame update
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        previsousPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            // pos of mouse in world coordinates
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //if drawing in 2D -> set z to 0
            // currentPosition.z = 0f;

            if (Vector3.Distance(currentPosition, previsousPosition) > minDistance) {
                line.positionCount++;
                line.SetPosition(line.positionCount -1, currentPosition);
                previsousPosition = currentPosition;
            }
        }
    }
}
