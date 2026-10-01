using UnityEngine;
using UnityEngine.PlayerLoop;

public class MovingTIle : MonoBehaviour
{
    [SerializeField] float maxLeftPos;
    [SerializeField] float maxRightPos;

    [SerializeField] bool switchDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > maxLeftPos && switchDirection)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 3);
        }else if (transform.position.x < maxRightPos && !switchDirection)
        {
            transform.Translate(Vector2.right * Time.deltaTime * 3);
        }
        else
        {
            switchDirection = !switchDirection;
        }
    }
}
