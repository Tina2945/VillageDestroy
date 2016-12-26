using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    private Animator animatorController;
   
    public Transform rotateYTransform;
    public Transform rotateXTransform;
    public float rotateSpeed;
    public float currentRotateX = 0;
    public float MoveSpeed;
    float currentSpeed = 0;
    public Rigidbody rigidBody;
    // Use this for initialization
    public JumpSenser JumpSenser;
    public float JumpSpeed;
    public GameObject sword;
    public GameObject axe;
    public GameObject bomb;
    public GameObject stick;
    public GameObject littleknife;
    public GameObject super;
   
    public GameObject axeaction;
    public GameObject littleknifeaction;
    public GameObject stickaction;
    public GameObject bombaction;
    public GameObject superaction;
    
    void Start()
    {
        animatorController = this.GetComponent<Animator>();
    }

    // Update is called once per frame
   
    void Update()
    {
       
        if (littleknifeaction.activeSelf)
        {
            axeaction.SetActive(false);
            stickaction.SetActive(false);
            bombaction.SetActive(false);
            super.SetActive(false);
           
            if (Input.GetMouseButtonDown(0))
            {
                animatorController.SetBool("Attack04", true);
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            if (Input.GetMouseButtonUp(0))
            {
                animatorController.SetBool("Attack04", false);
                rigidBody.velocity = this.transform.forward * MoveSpeed;
            }
            if (Input.GetKey(KeyCode.LeftShift)){
                 littleknifeaction.SetActive(false);
            }
        }
        if (axeaction.activeSelf)
        {
           
            stickaction.SetActive(false);
            bombaction.SetActive(false);
            super.SetActive(false);
            littleknifeaction.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                animatorController.SetBool("Attack02", true);
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            if (Input.GetMouseButtonUp(0))
            {
                animatorController.SetBool("Attack02", false);
                rigidBody.velocity = this.transform.forward * MoveSpeed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                axeaction.SetActive(false);
            }
        }
        if (stickaction.activeSelf)
        {
            axeaction.SetActive(false);
            
            bombaction.SetActive(false);
            super.SetActive(false);
            littleknifeaction.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                animatorController.SetBool("Attack01", true);
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            if (Input.GetMouseButtonUp(0))
            {
                animatorController.SetBool("Attack01", false);
                rigidBody.velocity = this.transform.forward * MoveSpeed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                stickaction.SetActive(false);
            }
        }
        if (bombaction.activeSelf)
        {
            axeaction.SetActive(false);
            stickaction.SetActive(false);
            
            super.SetActive(false);
            littleknifeaction.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                animatorController.SetBool("Attack02", true);
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            if (Input.GetMouseButtonUp(0))
            {
                animatorController.SetBool("Attack02", false);
                rigidBody.velocity = this.transform.forward * MoveSpeed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                bombaction.SetActive(false);
            }
        }
        if (superaction.activeSelf)
        {
            axeaction.SetActive(false);
            stickaction.SetActive(false);
            bombaction.SetActive(false);
           
            littleknifeaction.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                animatorController.SetBool("Attack03", true);
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            if (Input.GetMouseButtonUp(0))
            {
                animatorController.SetBool("Attack03", false);
                rigidBody.velocity = this.transform.forward * MoveSpeed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                superaction.SetActive(false);
            }
        }
        //決定鍵盤input的結果
        Vector3 movDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.S)) { movDirection.z += 1; }
        if (Input.GetKey(KeyCode.W)) { movDirection.z -= 1; }
        if (Input.GetKey(KeyCode.A)) { movDirection.x += 1; }
        if (Input.GetKey(KeyCode.D)) { movDirection.x -= 1; }
        movDirection = movDirection.normalized;
        if (movDirection.magnitude == 0 || !JumpSenser.IsCanJump()) { currentSpeed = 0; }
        //決定要給Animator的動畫參數
        if (movDirection.magnitude == 0) { currentSpeed = 0; }
        else
        {
            if (movDirection.z < 0) { currentSpeed = -MoveSpeed; }
            else { currentSpeed = MoveSpeed; }
        }
        animatorController.SetFloat("Speed", currentSpeed);
        //轉換成世界座標的方向
        Vector3 worldSpaceDirection = movDirection.z * rotateYTransform.transform.forward +
                                      movDirection.x * rotateYTransform.transform.right;
        Vector3 velocity = rigidBody.velocity;
        velocity.x = worldSpaceDirection.x * MoveSpeed;
        velocity.z = worldSpaceDirection.z * MoveSpeed;

        if (Input.GetKey(KeyCode.Space) && JumpSenser.IsCanJump())
        {
            velocity.y = JumpSpeed;
        }
        rigidBody.velocity = velocity;
        //計算滑鼠
        rotateYTransform.transform.localEulerAngles += new Vector3(0, Input.GetAxis("Horizontal"), 0) * rotateSpeed;
        currentRotateX += Input.GetAxis("Vertical") * rotateSpeed;
        if (currentRotateX > 90)
        {
            currentRotateX = 90;
        }
        else if (currentRotateX < -90)
        {
            currentRotateX = -90;
        }
        rotateXTransform.transform.localEulerAngles = new Vector3(-currentRotateX, 0, 0);

    }
    public void LittleKnifeAttack()
    {
        littleknifeaction.SetActive(true);

    }
    public void AxeAttack()
    {
        axeaction.SetActive(true);

    }
    public void StickAttack()
    {
        stickaction.SetActive(true);

    }
    public void BombAttack()
    {
        bombaction.SetActive(true);

    }
    public void SuperAttack()
    {
        superaction.SetActive(true);
       
    }
}