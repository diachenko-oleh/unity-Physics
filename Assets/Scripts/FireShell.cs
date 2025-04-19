using Unity.Mathematics;
using UnityEngine;

public class FireShell : MonoBehaviour
{
    public GameObject bullet;
    public GameObject turret;
    public GameObject enemy;
    public Transform turretBase;
    float speed = 15;
    float rotSpeed = 2f;
    float moveSpeed = 3f;

    void CreateBullet()
    {
       GameObject shell = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
       shell.GetComponent<Rigidbody>().linearVelocity = speed * turretBase.forward;
    }
    float? RotateTureet()
    {
        float? angle = CalculateAngel(false);
        if (angle != null)
        {
            turretBase.localEulerAngles = new Vector3(360f - (float)angle, 0f, 0f);
        }
        return angle;
    }

    float? CalculateAngel(bool low)
    {
        Vector3 targetDir = enemy.transform.position - transform.position;
        float y = targetDir.y;
        targetDir.y = 0f;
        float x = targetDir.magnitude-1;
        float gravity = 9.8f;
        float sSqr = speed * speed;
        float underSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);
        if (underSqrRoot >= 0f)
        {
            float root = Mathf.Sqrt(underSqrRoot);
            float highAngle = sSqr + root;
            float lowAngle = sSqr - root;

        if (low)
        {
            return Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg;
        }
        else
        {
            return Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg;
        }

        }
        else return null;
    }

        void Update()
        {
            Vector3 direction = (enemy.transform.position - transform.position).normalized;
            Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, Time.deltaTime * rotSpeed);
            float? angle =RotateTureet();

        if (true) 
        {
            if (angle != null)
            {
                if (Input.GetKeyDown(KeyCode.Space)) { CreateBullet(); }
            }
            else
            {
                transform.Translate(0, 0, Time.deltaTime * moveSpeed);
            }
        }
    }
}
