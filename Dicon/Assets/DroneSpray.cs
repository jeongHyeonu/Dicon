using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneSpray : MonoBehaviour
{
    LineRenderer lr;
    [SerializeField] GameObject lineStart;
    [SerializeField] GameObject targetObj;
    [SerializeField] ParticleSystem extParticle;
    [SerializeField] GameObject droneFireBtn;
    float cooltime = 7f;

    // Start is called before the first frame update
    void Start()
    {
        lr=GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.positionCount = 2;
        lr.SetPosition(0, lineStart.transform.position);
        lr.SetPosition(1, targetObj.transform.position);
        lr.startWidth = 0.03f;
        lr.endWidth = 0.03f;
    }

    public void OnClickDroneFireBtn()
    {
        droneFireBtn.SetActive(false);
        extParticle.Play();
        Invoke("btnActivate", cooltime);
    }

    private void btnActivate() { droneFireBtn.SetActive(true); }
}
