using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PACMAN : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;

    public Rigidbody rb;
    public Collision col;
    public Animator manimator;
      

    public KeyCode Haut;
    public KeyCode Bas;
    public KeyCode Droite;
    public KeyCode Gauche;
    public Vector3 direction;

    public float distance = 2f;

    public LayerMask Wall;

    public bool canMove;


    
    void Update()
    {
        Raycast2000();
        Move(direction);
        if (Input.GetKeyDown(Haut))
        {
            direction = Vector3.forward;
            canMove = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(Bas))
        {
            direction = Vector3.back;
            canMove = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKeyDown(Droite))
        {
            direction = Vector3.right;
            canMove = true;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Input.GetKeyDown(Gauche))
        {
            direction = Vector3.left;
            canMove = true;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
    public void Move(Vector3 direction)
    {
        if (!canMove)
            return; 

        transform.position += direction * Time.deltaTime * speed;

    }

    public void Raycast2000()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, distance, Wall))
        {
            canMove = false;
            Debug.Log("SEXO2");
        }
        
    }

     void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Pac_gomme")
        {
            Destroy(col.gameObject);  
            manimator.SetTrigger("Infirmus");
            canMove = false;
            
        }
    }
   




}
