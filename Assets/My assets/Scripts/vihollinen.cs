using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollinen : MonoBehaviour
{
    public CharacterController controller;

    private int kaannos = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(kaanna_vihollinen());
        kaannos = Random.Range(0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nopeus = new Vector3(0, -1, 1);
        nopeus = transform.rotation * nopeus;
        controller.Move(nopeus * Time.deltaTime);
        
    }

    IEnumerator kaanna_vihollinen(){
        yield return new WaitForSeconds(5);
        kaannos = kaannos + 90;
    transform.localRotation = Quaternion.Euler(0, kaannos, 0);
    StartCoroutine(kaanna_vihollinen());
    }
}
