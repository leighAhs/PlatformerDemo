using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField] Vector2 brushPosition;
    [SerializeField] GameObject[] brushPoint;

    [SerializeField] bool[] switchBrush;

    //[SerializeField] GameObject[] brushPointParents;

    [SerializeField] GameObject[] parents;

    [SerializeField] int brushPointNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        brushPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = brushPosition;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            brushPointNumber++;
            if (brushPointNumber == 4)
            {
                brushPointNumber = 1;
            }
        }

        if(brushPointNumber == 1)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                GameObject obj = Instantiate(brushPoint[0], transform.position, transform.rotation);
                obj.transform.parent = parents[0].transform;
            }
        } else if (brushPointNumber == 2)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject obj = Instantiate(brushPoint[1], transform.position, transform.rotation);
                obj.transform.parent = parents[1].transform;
            } else if (Input.GetMouseButtonUp(0))
            {
                Rigidbody2D parentRb2d = parents[1].AddComponent<Rigidbody2D>();
            }
        } else if(brushPointNumber == 3)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                GameObject obj = Instantiate(brushPoint[2], transform.position, transform.rotation);
                obj.transform.parent = parents[2].transform;
            }
        }
    }


}
