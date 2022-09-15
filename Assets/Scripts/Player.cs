using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   
    public Projectile laserPrefab;
    public float speed = 5.0f;
    private bool _laserActive;

    private void Update(){
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)){
            Shoot();
        }
    }

    private void Shoot(){
        if(!_laserActive){
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        }

    }
    private void LaserDestroyed(){
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Invader")||other.gameObject.layer == LayerMask.NameToLayer("Missile")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
/*
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Projectile laserPrefab;
    public System.Action killed;
    public bool laserActive { get; private set; }

    private void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            position.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            position.x += speed * Time.deltaTime;
        }

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        // Clamp the position of the character so they do not go out of bounds
        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);
        transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
    }

    
    

}*/
