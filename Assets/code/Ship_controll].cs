using UnityEngine;

public class Ship_controll : MonoBehaviour
{
    private float speed = 0f;
    private Rigidbody rd;


    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }
    private float nextChangeTime = 0f; 
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // “ут т€га коробл€ скорее всего переделаю в одну ось
        {
            if (Time.time >= nextChangeTime)
            {
                speed -= 5.0f;
                nextChangeTime = Time.time + 0.2f;
            }
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Time.time >= nextChangeTime)
            {
                speed += 5.0f;
                nextChangeTime = Time.time + 0.2f;
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            if (speed > 5.0)
            {
                speed -= 5.0f;
                nextChangeTime = Time.time + 0.2f;
            }
            else if(speed < -5.0f)
            {
                speed += 5.0f;
                nextChangeTime = Time.time + 0.2f;
            }
            else
            {
                speed = 0;
            }
        }
    }

    void FixedUpdate()
    {
        float YInput = Input.GetAxis("Horizontal"); // »спользует ось "Horizontal" (клавиши A и D)
        float XInput = Input.GetAxis("Vertical"); // »спользует ось "Vertical" (клавиши W и S)
        float ZInput = Input.GetAxis("QE_new_axes"); // »спользует ось "Horizontal" (клавиши Q и E)
        if (YInput != 0)
        {
            rd.AddRelativeTorque(Vector3.up * YInput, ForceMode.Force); //¬ращение по оси Y
        }
        if (XInput != 0)
        {
            rd.AddRelativeTorque(Vector3.right * XInput, ForceMode.Force); //¬ращение по оси X
        }
        if (ZInput != 0)
        {           
            rd.AddRelativeTorque(Vector3.forward * ZInput, ForceMode.Force); //¬ращение по оси Z
        }
        rd.AddForce(transform.forward * speed); // “€га коробл€ прикладываетс€ к короблю


         /* float Horizontal_Moving = Input.GetAxis("Horizontal");
         float Vertical_Moving = Input.GetAxis("Vertical");

         //короче немного заговнокодил, пока не придумал другого передвижени€. ≈сли кто-то сделает из€щнее будет збс

         if (Input.GetKey(KeyCode.Space))
         {
             move = new Vector3(Horizontal_Moving, speed, Vertical_Moving);
         }

         else if (Input.GetKey(KeyCode.LeftControl))
         {
             move = new Vector3(Horizontal_Moving, -speed, Vertical_Moving);
         }

         else
         {
             move = new Vector3(Horizontal_Moving, 0, Vertical_Moving);
         }

         move = transform.TransformDirection(move) * speed;


         Main_Ship_Controll.Move(move * Time.deltaTime);*/

    }
}
