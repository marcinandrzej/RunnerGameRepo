using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScript : MonoBehaviour
{
    public GameObject CreatePlayer(Vector3 position, Vector3 scale, int orderInLayer,
        Vector2 colliderSize, float gravityScale, RuntimeAnimatorController animatorController, Transform parent)
    {
        GameObject player = new GameObject("Player");
        player.transform.position = position;
        player.transform.localScale = scale;
        player.AddComponent<SpriteRenderer>();
        player.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
        player.AddComponent<BoxCollider2D>();
        player.GetComponent<BoxCollider2D>().size = colliderSize;
        player.AddComponent<Rigidbody2D>();
        player.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        player.AddComponent<Animator>();
        player.GetComponent<Animator>().runtimeAnimatorController = animatorController;
        player.AddComponent<PlayerScript>();
        player.transform.SetParent(parent);
        return player;
    }

    public void CreateEnemy(LayerMask mask, int enemyType, Color32 color, float speed,
        Vector3 position, Vector2 colliderSize, int sortingOrder, Vector3 scale, RuntimeAnimatorController enemyAnimatorController)
    {
        GameObject enemy = new GameObject("Enemy");
        enemy.transform.position = position;
        enemy.transform.localScale = scale;
        enemy.layer = (int)Mathf.Log(mask.value, 2);
        enemy.AddComponent<SpriteRenderer>();
        enemy.AddComponent<BoxCollider2D>();
        enemy.AddComponent<Rigidbody2D>();
        enemy.GetComponent<SpriteRenderer>().color = color;
        //enemy.GetComponent<SpriteRenderer>().sprite = enemySprite;
        enemy.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
        enemy.GetComponent<BoxCollider2D>().isTrigger = true;
        enemy.GetComponent<BoxCollider2D>().size = colliderSize;
        enemy.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0.0f);
        enemy.AddComponent<Animator>();
        enemy.GetComponent<Animator>().runtimeAnimatorController = enemyAnimatorController;
        enemy.GetComponent<Animator>().SetInteger("AnimIndex", enemyType);
        Destroy(enemy, 5.0f);
    }
}
