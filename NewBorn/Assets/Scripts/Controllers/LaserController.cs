using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserController : MonoBehaviour
{
    private LineRenderer line;
    [SerializeField] AudioSource baby;
    [SerializeField] AudioSource laugh;
    [SerializeField] GameObject InfoPanel;
    [SerializeField] GameObject Band;
    [SerializeField] GameObject Injure;
    // Start is called before the first frame update
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            Dolaser(transform.position, transform.forward, 10f);
            line.enabled = true; 
           
        }
        else
        {
            line.enabled = false;
        }
        if (OVRInput.Get(OVRInput.Button.Start))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    void Dolaser(Vector3 targetpos, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetpos, direction);
        Vector3 endpos = targetpos + (direction * length);

        if (Physics.Raycast(ray, out RaycastHit rayhit, length))
        {
            endpos = rayhit.point;
            if (rayhit.collider.gameObject.tag == "Baby")
            {
                line.startColor = Color.yellow;
                line.endColor = Color.yellow;
                if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger)){
                    Destroy(rayhit.collider.gameObject);
                    baby.Play();
                }
            }
            if (rayhit.collider.gameObject.tag == "Info")
            {
                line.startColor = Color.yellow;
                line.endColor = Color.yellow;
                if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
                {
                    Destroy(rayhit.collider.gameObject);
                    baby.Play();
                    InfoPanel.SetActive(true);
                    StartCoroutine(CreateInjure());
                }
            }
            else if (rayhit.collider.gameObject.tag == "Injure")
            {
                line.startColor = Color.green;
                line.endColor = Color.green;
                if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
                {
                    Destroy(rayhit.collider.gameObject);
                    laugh.Play();
                    Band.SetActive(true);
                }
            }
        }
        else
        {
            line.startColor = Color.red;
            line.endColor = Color.red;
        }
        
        line.SetPosition(0, targetpos);
        line.SetPosition(1, endpos);
    }
    IEnumerator CreateInjure()
    {
        yield return new WaitForSeconds(1.5f);
        Injure.SetActive(true);
    }
}
