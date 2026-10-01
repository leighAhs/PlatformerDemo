using System.Collections;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;

    [SerializeField] GameObject Key;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(focusOnkey());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void resetCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
    }

    IEnumerator focusOnkey()
    {
        yield return new WaitForSeconds(1f);
        resetCamera();
        cameras[1].SetActive(true);
        yield return new WaitForSeconds(2f);
        cameras[1].SetActive(false );
        cameras[0].SetActive(true); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
           
            Destroy(GameObject.Find("key"));
            if(GameObject.Find("Key") == null)
            {
                StartCoroutine(backToPlayerCamera());

            }
        }
    }

    IEnumerator backToPlayerCamera()
    {
        resetCamera();
        cameras[2].SetActive(true);
        yield return new WaitForSeconds(3f);
        cameras[2].SetActive(false);
        cameras[0].SetActive(true);
    }
}
