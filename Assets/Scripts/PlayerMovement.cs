using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;

    public float forwardForce = 1000f;
    public float sidewaysForce = 500f;
    public float upwardsForce = 2000f;
    public float rotationSpeed = 50f;

    public float maximumHeight = 50f;
    public float maximumForwardForce = 1200f;
    public float minimumForwardForce = 500f;

    private bool onGround;

    private ParticleMovement particleMovement;
    private bool inBetween;

    public Text speedText;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, forwardForce * Time.deltaTime, 0);
        onGround = false;
        inBetween = false;
        particleMovement = GameObject.Find("BirdSystem").GetComponent<ParticleMovement>();
        setSpeedText();
    }

    void FixedUpdate() {

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        inBetween = particleMovement.getFunction();
        if (inBetween == true)
        {
            forwardForce = 1000f;
        }

        if (onGround == false)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        } else
        {
            rb.AddForce(0, 0, forwardForce * 3 * Time.deltaTime);
            onGround = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, upwardsForce * Time.deltaTime, 0);
            rb.useGravity = false;
            rb.drag = 1.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.useGravity = true;
            rb.drag = 3;
        }

         if (Input.GetKey(KeyCode.RightArrow))
         {
             rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.Force);
         }

         if (Input.GetKey(KeyCode.LeftArrow))
         {
             rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.Force);
         }

        if (rb.position.y < -10f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (rb.position.y > maximumHeight)
        {
            float positionX = rb.position.x;
            float positionZ = rb.position.z;
            rb.transform.position = new Vector3(positionX, maximumHeight, positionZ);
        }

        setSpeedText();
    }

    private void setSpeedText()
    {
        speedText.text = "Speed: " + (forwardForce/10).ToString("0");
    }

    public float getForwardForce()
    {
        return forwardForce;
    }

    public void setForwardForce(float increment, bool increase)
    {
        if (increase == true)
        {
            forwardForce += increment;
            if (forwardForce > maximumForwardForce)
            {
                forwardForce = maximumForwardForce;
            }
        } else
        {
            forwardForce -= increment;
            if (forwardForce < minimumForwardForce)
            {
                forwardForce = minimumForwardForce;
            }
        }
    }

    public bool getOnGround()
    {
        return onGround;
    }

    public void setOnGround(bool variable)
    {
        onGround = variable;
    }
}
