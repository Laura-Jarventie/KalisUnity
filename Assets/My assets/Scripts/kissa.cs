using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kissa : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    private float verticalSpeed = 0f;
	private float horizontalSpeed = 0f;
    private float mouseMovement = 0f;
    public int speed = 3;
    public int mouseSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //eteen ja sivulle liikkuminen
		verticalSpeed = Input.GetAxis("Vertical");
		horizontalSpeed = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalSpeed, -1, verticalSpeed);

        //hiirellä kääntyminen
		mouseMovement += Input.GetAxis("Mouse X") * mouseSpeed;
		transform.localRotation = Quaternion.Euler(0, mouseMovement, 0);
		direction = transform.rotation * direction;

        //tämä lopulta liikuttaa
		controller.Move(direction * Time.deltaTime * speed);

        //animaatiot
		if(verticalSpeed != 0){
			animator.SetBool("Walk", true);
		}
		else{
			animator.SetBool("Walk", false);
		}
    }

    //Kissan törmäys tyhjään maaliin
	void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Maali")
        {
            Debug.Log("Kissa maalissa");
		}
	}
}
