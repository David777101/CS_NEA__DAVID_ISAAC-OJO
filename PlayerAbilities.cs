using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Transform Ball; // reference to the ball game object
    public Transform Arms; // reference to the arms game object
    public Transform OverHeadPos; // reference to the overhead position game object
    public Transform DribblePos; // reference to the dribble game object
    public Transform Target; // reference to the target / hoop game object



    //variables
    public float Walkspeed = 10; // determines how fast the player moves
    public float jumpSpeed = 10f; // determines how high the player jumps
    public float gravityScale = 5f; // determines the strength of gravity on the player

    private bool BallInHand = true; // true when the player has the ball
    private bool BallFlying = false; // true when the ball has been thrown and is flying towards the rim
    private float T = 0; // time of ball's flight in the air is 0 by default
    private Rigidbody rb; // this is a reference to the player's physical body

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // gets the rigidbody component
        
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f); // checks if the player is grounded
    }

    void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass); // applies extra gravitational force
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // checks if left shift key is held
        {
            Walkspeed = 25; //increase walkspeed while left shift is held
        }

        else
        {
            Walkspeed = 10;
        }
        
        //walking
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); // receives the player's input
        transform.position += direction * Walkspeed * Time.deltaTime; // updates the player's position based on input
        transform.LookAt(transform.position + direction); //player rotates to face the direction they're moving in

        //jumping
        if (Input.GetKeyUp(KeyCode.Space) && IsGrounded()) // checks if space bar has been pressed and released and player is grounded
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode.Impulse); // Player jumps upwards as high as the jumpSpeed
        }

        // ball in hands
        if (BallInHand) // checks if ball is in player's hand
        {

            //hold over head
            if (Input.GetKeyUp(KeyCode.Space)) // checks if the space bar has been pressed and released
            {
                Ball.position = OverHeadPos.position; // player holds the ball up
                Arms.localEulerAngles = Vector3.right * 180; // Player's hand is raised upwards

                // look towards the target
                transform.LookAt(Target.parent.position); // player looks at the hoop
            }

            //dribbling
            else
            {
                Ball.position = DribblePos.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5)); // ball bounces up and down
                Arms.localEulerAngles = Vector3.right * 0; // arms are placed down to dribble
            }

            // throw ball
            if (Input.GetKeyUp(KeyCode.Space)) // checks if the space bar has been pressed down and released
            {
                BallInHand = false; // the ball is no longer in the player's hand
                BallFlying = true; //the ball is flying through the air
                T = 0; // flight timer is 0
            }
        }

       
        

        // ball in the air
        if (BallFlying)
        {
            T += Time.deltaTime;
            float duration = 0.5f; // ball's flight duration is 0.5 seconds
            float t01 = T / duration;

            //move to target
            Vector3 A = OverHeadPos.position; // the ball's overhead position - where the player has the ball before it is thrown
            Vector3 B = Target.position; // the hoop's position
            Vector3 pos = Vector3.Lerp(A, B, t01); // calculates where the ball should be between the player's hands and the hoop during the flight duration

            // move in arc
            Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f); // generates an arc 

            Ball.position = pos + arc; // adds arc to the ball's flight motion

            // moment when ball arrives at the target
            if (t01 >= 1) // checks that flight duration is over
            {
                BallFlying = false; // ball is no longer flying through the air
                Ball.GetComponent<Rigidbody>().isKinematic = false; // ball is subject to gravity again and falls thorugh the hoop
                Scoremanager.instance.Addpoint(); // score increments by 1

            }
        }
            
    }

    private void OnTriggerEnter(Collider other) // when the player touches the ball
    {
        if (!BallInHand && !BallFlying) // checks if ball isn't in the player's hand and if the ball isn't in the air
        {
            BallInHand = true; // the ball is now in the player's hand
            Ball.GetComponent<Rigidbody>().isKinematic = true; // ball follows the player's hand
        }
    }
}
