using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{ 	
	//player status
	private bool getHorizontal = false, jumping = false, Ground = true, Falling = false;
	public float speed = 1, jumpPower = 0.1f, FallingSpeed;
	Rigidbody2D rb;
	Animator anim;
	//interactable object status
	private bool checkPressed = false;
	private bool windowInteract = false, doorIsGuest=false, doorIsStorage=false, doorIsToilet=false, doorIsStudy=false, doorIsBathingRoom=false, doorIsLaundryRoom=false, doorIsBackDoor=false, doorIsToLv2=false;
	private bool StudyToCorridor = false, StudyToLivingroom = false, LaundryroomToCorridor = false, GuestToCorridor = false, KitchenToCorridor = false, StorageToCorridor = false;
	//when interactable
	public GameObject magnifier;
    public GameObject button;
    public Sprite Image1, Image2;
    public Sprite dairy_1;

    void Start()
    {
		//Defualt setting
		magnifier.SetActive (false);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //PlayerController
        double move = CrossPlatformInputManager.GetAxis("Horizontal");
        if (move == 0)
        {
            if (anim.GetInteger("State") == -2 || anim.GetInteger("State") == -3 || anim.GetInteger("State") == -4)
            {
                anim.SetInteger("State", -1);
            }
            if (anim.GetInteger("State") == 2 || anim.GetInteger("State") == 3 || anim.GetInteger("State") == 4)
            {
                anim.SetInteger("State", 1);
            }
        }
        if (move > 0 || move < 0)
        {
            getHorizontal = true;
            //right
            if (move > 0 && anim.GetInteger("State") == 0)
            {
                anim.SetInteger("State", 2);
            }
            if (move > 0 && anim.GetInteger("State") == -1)
            {
                anim.SetInteger("State", 3);
            }
            if (move > 0 && anim.GetInteger("State") == -2)
            {
                anim.SetInteger("State", 4);
            }
            if (move > 0 && anim.GetInteger("State") == -4)
            {
                anim.SetInteger("State", 4);
            }
            if (move > 0 && anim.GetInteger("State") == -3)
            {
                anim.SetInteger("State", 4);
            }
            //left
            if (move < 0 && anim.GetInteger("State") == 0)
            {
                anim.SetInteger("State", -2);
            }
            if (move < 0 && anim.GetInteger("State") == 1)
            {
                anim.SetInteger("State", -3);
            }
            if (move < 0 && anim.GetInteger("State") == 2)
            {
                anim.SetInteger("State", -4);
            }
            if (move < 0 && anim.GetInteger("State") == 4)
            {
                anim.SetInteger("State", -4);
            }
            if (move < 0 && anim.GetInteger("State") == 3)
            {
                anim.SetInteger("State", -4);
            }
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(-speed, 0.0f, 0);
            anim.SetInteger("State", -2);

        }
        if (Input.GetKey("d"))
        {
            transform.Translate(speed, 0.0f, 0);
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Ground)
        {
            rb.AddForce(Vector3.up * jumpPower);
            Ground = false;
            jumping = true;
        }
        if (getHorizontal == true && move > 0)
        {
            transform.Translate(speed, 0.0f, 0);
        }
        else if (getHorizontal == true && move < 0)
        {
            transform.Translate(-speed, 0.0f, 0);
        }
        if (CrossPlatformInputManager.GetButton("Jump") && Ground)
        {
            rb.AddForce(Vector3.up * jumpPower);
            Ground = false;
        }
        //When Click Button
        if (Input.GetKey("e") || CrossPlatformInputManager.GetButton("Jump"))
        {
            Door door = new Door();
            Button button = new Button();
            ObjectFollow cameraBorder = new ObjectFollow();
            //Door interact
            if (door.getInteract())
            {
                //if (StudyToLivingroom)transform.position = new Vector3 (3.04f, 22.4f, 0f);
                //if (LaundryroomToCorridor)transform.position = new Vector3 (, 0f);
                //if (GuestToCorridor)transform.position = new Vector3 (, 0f);
                //if (StorageToCorridor)transform.position = new Vector3 (, 0f);
                //if (KitchenToCorridor)transform.position = new Vector3 (, 0f);
                if (StudyToCorridor)
                {
                    cameraBorder.setBorder(-364.22f, -314.35f, -14.1f, -6.86f);
                    transform.position = new Vector3(-42.03f, 21.23f, 0f);
                }
                //if (LaundryroomToCorridor)transform.position = new Vector3 (, 0f);
                //if (doorIsLaundryRoom)transform.position = new Vector3 (, 0f);
                //if (doorIsGuest)transform.position = new Vector3 (, 0f);
                //if (doorIsStorage)transform.position = new Vector3 (, 0f);
                //if (doorIsStudy) transform.position = new Vector3(4.04f, -18.09f, 0f);
                //if (doorIsBathingRoom)transform.position = new Vector3 (f, 0f);
                //if (doorIsToilet)transform.position = new Vector3 (, 0f);
            }
            
            //Button interact
            if (button.getInteract() && checkPressed == false)
            {
                button.ButtonPressed();
                checkPressed = true;
            }
            else if (button.getInteract() && checkPressed)
            {
                button.ButtonUnpress();
                checkPressed = false;
            }

            //windows interact
            //if(windowInteract)ss.switchscene("backDoor");
        }
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
       /* Dairy dairy_1;
        if (dairy_1.getInteract())
        {
            if (CrossPlatformInputManager.GetButton("Jump"))
            {
                dairy_1.dairy.SetActive(true);
            }
        }*/

        //when player enter through some interactable items
        if (other.CompareTag ("Door"))magnifier.SetActive (true);
		if(other.CompareTag("interactable_item"))magnifier.SetActive (true);

		if (other.name.Equals ("Door_Study_Corridor"))StudyToCorridor = true;
		if (other.name.Equals ("Door_Study_Livingroom"))StudyToLivingroom = true;
		if (other.name.Equals ("Door_Laundryroom_Corridor"))LaundryroomToCorridor = true;
		if (other.name.Equals ("Door_Guest_Corridor"))GuestToCorridor = true;
		if (other.name.Equals("windows"))windowInteract = true;
		if (other.name.Equals ("Door_guest"))doorIsGuest = true;
		if (other.name.Equals ("Door_laundryRoom"))doorIsLaundryRoom = true;
		if (other.name.Equals ("Door_storage"))doorIsStorage = true;
		if (other.name.Equals ("Door_bathingRoom"))doorIsBathingRoom = true;
		if (other.name.Equals ("Door_study"))doorIsStudy = true;
		if (other.name.Equals ("Door_backDoor"))doorIsBackDoor = true;
		if (other.name.Equals ("Door_toToilet"))doorIsToilet = true;
		if (other.name.Equals ("Door_toLv2"))doorIsToLv2 = true;
        
        //Button Change Image
        button.GetComponent<Image>().sprite = Image1;

    }

	private void OnTriggerExit2D(Collider2D other)
	{
		//when player exit ssome interactable items
		magnifier.SetActive (false);
		windowInteract = false;
		doorIsGuest = false;
		doorIsLaundryRoom = false;
		doorIsStorage = false;
		doorIsBathingRoom = false;
		doorIsStudy = false;
		doorIsBackDoor = false;
		doorIsToilet = false;
		StudyToCorridor = false;

        //Button Change Image
        button.GetComponent<Image>().sprite = Image2;
    }

	//When Player touching other object
	private void OnCollisionEnter2D(Collision2D Other)
    {
		if(Other.gameObject.tag == "Floor") Ground = true;
		if (Other.gameObject.tag == "blocked_item") Ground = true;
    }

	//check is player on ground ver.2


	//player Attack fuc


	//Check Is player On Ground
    private void CheckFallFunction()
    {
        if(FallingSpeed < 0 && Ground)
        {
            Falling = false;
        }
    }

	//Check Is Player Fall
	private void FallingFunction()
    {
        FallingSpeed = rb.velocity.y;
        //Debug.Log (rigidbody2D.velocity.y);
        if (FallingSpeed <= 1 && Ground == false)
        {
            Falling = true;
            //Debug.Log("jumptofall!!");
            jumping = false;
        }
    }
}