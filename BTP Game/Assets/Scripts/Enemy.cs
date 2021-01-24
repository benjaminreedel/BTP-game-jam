using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float enemyHealth;

    [SerializeField]
    private float movementSpeed;


    private int damage;

    private GameObject targetTile;

    private void Awake() {
        EnemyManager.enemies.Add(gameObject);
    }

    private void Start() {
        initializeEnemy();
    }

    private void initializeEnemy() {
        targetTile = MapGenerator.startTile;
    }

    public void takeDamage(float amount) {
        enemyHealth -= amount;
        if (enemyHealth <= 0) {
            die();
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Bullet") {
            takeDamage(5);
        }
    }

    private void die() {
        EnemyManager.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
    }

    private void moveEnemy() {
        transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, movementSpeed * Time.deltaTime);
    }

    private void checkPosition() {

        // check the targetTile exists, and that it is not the endtile
        if (targetTile != null && targetTile != MapGenerator.endTile) {
            float distance = (transform.position - targetTile.transform.position).magnitude;

            if (distance < 0.001f) {
                int currentIndex = MapGenerator.pathTiles.IndexOf(targetTile);

                targetTile = MapGenerator.pathTiles[currentIndex + 1];
            }
        }
    }

    private void Update() {
        checkPosition();
        moveEnemy();
    }

}



