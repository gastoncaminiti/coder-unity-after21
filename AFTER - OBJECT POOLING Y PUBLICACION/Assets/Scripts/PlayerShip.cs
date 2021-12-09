using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    // Start is called before the first frame update
    [SerializeField] private GameObject originTwo;
    [SerializeField] private float rotationSpeed = 10f;

    // POLYMORPHISM
    public override void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //InstantiateMunition(originOne.transform);
            //InstantiateMunition(originTwo.transform);

            GameObject b1 = ObjectPool.instance.GetPooledObject();

            if (b1 != null)
            {
                b1.transform.position = originOne.transform.position;
                b1.transform.rotation = Quaternion.identity;
                b1.SetActive(true);
                b1.GetComponent<Rigidbody>().AddForce(originOne.transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
            }

            GameObject b2 = ObjectPool.instance.GetPooledObject();

            if (b2 != null)
            {
                b2.transform.position = originTwo.transform.position;
                b2.transform.rotation = Quaternion.identity;
                b2.SetActive(true);
                b2.GetComponent<Rigidbody>().AddForce(originTwo.transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
            }
        }
    }

    public override void Move()
    {
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, hAxis * rotationSpeed * Time.deltaTime);
        transform.Translate(speedShip * new Vector3(0, 0, vAxis) * Time.deltaTime);
    }

    public override void DrawRaycast()
    {
        base.DrawRaycast();
        DrawRay(originTwo.transform);
    }
}
