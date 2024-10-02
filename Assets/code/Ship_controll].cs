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
        if (Input.GetKey(KeyCode.LeftShift)) // ��� ���� ������� ������ ����� ��������� � ���� ���
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
        float YInput = Input.GetAxis("Horizontal"); // ���������� ��� "Horizontal" (������� A � D)
        float XInput = Input.GetAxis("Vertical"); // ���������� ��� "Vertical" (������� W � S)
        float ZInput = Input.GetAxis("QE_new_axes"); // ���������� ��� "Horizontal" (������� Q � E)
        if (YInput != 0)
        {
            rd.AddRelativeTorque(Vector3.up * YInput, ForceMode.Force); //�������� �� ��� Y
        }
        if (XInput != 0)
        {
            rd.AddRelativeTorque(Vector3.right * XInput, ForceMode.Force); //�������� �� ��� X
        }
        if (ZInput != 0)
        {           
            rd.AddRelativeTorque(Vector3.forward * ZInput, ForceMode.Force); //�������� �� ��� Z
        }
        rd.AddForce(transform.forward * speed); // ���� ������� �������������� � �������


         /* float Horizontal_Moving = Input.GetAxis("Horizontal");
         float Vertical_Moving = Input.GetAxis("Vertical");

         //������ ������� ������������, ���� �� �������� ������� ������������. ���� ���-�� ������� ������� ����� ���

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
