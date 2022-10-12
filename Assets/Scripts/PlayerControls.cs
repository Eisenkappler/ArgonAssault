using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 25f;

    [SerializeField] float xRange = 5f;

    [SerializeField] float yMin = -3f;
    [SerializeField] float yMax = 12f;

    [SerializeField] float positionPitchFaktor = -2f;
    [SerializeField] float controllPitchFaktor = -15f;

    [SerializeField] float positionYawFaktor = 1.5f;
    [SerializeField] float controllRollFaktor = -20f;

    [SerializeField] GameObject[] lasers;


    float horizontalThrow;
    float verticalThrow;

    void Start()
    {
        
    }

    private void OnEnable() {
        movement.Enable();
    }

    private void OnDisable() {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        

        float pitchDueToPosition = transform.localPosition.y * positionPitchFaktor;
        float pitchDueToControlThrow = verticalThrow * controllPitchFaktor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFaktor;

        float roll = horizontalThrow * controllRollFaktor;


        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }


    private void ProcessTranslation()
    {
        //horizontalThrow = movement.ReadValue<Vector2>().x;

        //verticalThrow = movement.ReadValue<Vector2>().y;

        horizontalThrow = Input.GetAxis("Horizontal");

        verticalThrow = Input.GetAxis("Vertical");


        float xOffset = horizontalThrow * Time.deltaTime * controlSpeed;
        float yOffset = verticalThrow * Time.deltaTime * controlSpeed;



        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, yMin, yMax);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }



    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            Activatelasers(true);
        }else
        {
            Activatelasers(false);
        }
    }

    void Activatelasers(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionHanlder = laser.GetComponent<ParticleSystem>().emission;
            emissionHanlder.enabled = isActive;
        }
    }


}
