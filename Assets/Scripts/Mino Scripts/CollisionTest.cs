using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class CollisionTest : MonoBehaviour
{
    public float moveForce = 0f;
    private Rigidbody2D rbody;
    public Vector3 moveDir;
    private Stopwatch stopWatch = new Stopwatch();

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        int[] flag = new int[4];
        for (int i = 0; i < 4; i++) flag[i] = 0;
        moveDir = ChooseDirection(flag);
    }
    void Update()
    {
        rbody.MovePosition(transform.position + moveDir * moveForce);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        int[] flag = new int[4];
        for (int i = 0; i < 4; i++) flag[i] = 0;
        if (col.gameObject.name == "Mino_GoRight")
        {
            flag[0] = 1;
        }
        if (col.gameObject.name == "Mino_GoLeft")
        {
            flag[1] = 1;
        }
        if (col.gameObject.name == "Mino_GoUp")
        {
            flag[2] = 1;
        }
        if (col.gameObject.name == "Mino_GoDown")
        {
            flag[3] = 1;
        }
        if (col.gameObject.name == "Mino_GoRightUp")
        {
            flag[0] = 1;
            flag[2] = 1;
        }
        if (col.gameObject.name == "Mino_GoRightDown")
        {
            flag[0] = 1;
            flag[3] = 1;
        }
        if (col.gameObject.name == "Mino_GoLeftUp")
        {
            flag[1] = 1;
            flag[2] = 1;
        }
        if (col.gameObject.name == "Mino_GoLeftDown")
        {
            flag[1] = 1;
            flag[3] = 1;
        }
        if (col.gameObject.name == "Mino_GoNotRight")
        {
            flag[1] = 1;
            flag[2] = 1;
            flag[3] = 1;
        }
        if (col.gameObject.name == "Mino_GoNotLeft")
        {
            flag[0] = 1;
            flag[3] = 1;
            flag[2] = 1;
        }
        if (col.gameObject.name == "Mino_GoNotUp")
        {
            flag[0] = 1;
            flag[1] = 1;
            flag[3] = 1;
        }
        if (col.gameObject.name == "Mino_GoNotDown")
        {
            flag[0] = 1;
            flag[1] = 1;
            flag[2] = 1;
        }
        if (col.gameObject.name == "Mino_GoYes")
        {
            flag[0] = 1;
            flag[1] = 1;
            flag[2] = 1;
            flag[3] = 1;
        }
        IEnumerator czekaj()
        {
            UnityEngine.Debug.Log("czekam");
            yield return new WaitForSeconds(0.05f);
            moveDir = ChooseDirection(flag);
        }
        /*new Task(() =>
        {
            UnityEngine.Debug.Log("Penis");
            moveDir = ChooseDirection(flag);
        })
            .Start();*/
        /* Dispatcher.Invoke(() =>
         {
             for (var i = 0; i < 5; i++)
             {
                 UnityEngine.Debug.Log($"Penisek #{i}");
                 Thread.Sleep(1000);
             }
         });*/
        StartCoroutine(czekaj());
        
    }
    Vector3 ChooseDirection(int[] flagDir)
    {
        System.Random rand = new System.Random();
        Vector3 temp = new Vector3();
        int count=0;
        for (int k = 0; k < 4; k++) if (flagDir[k] == 1)
            {
                count++;
            }
        for (int k = 0; k < count; k++)
        {
            if (rand.Next(0, count) == 0)
            {
                if (flagDir[0] == 1) temp = transform.right;
                else if (flagDir[1] == 1) temp = -transform.right;
                else if (flagDir[2] == 1) temp = transform.up;
                else temp = -transform.up;
            }
            else if (rand.Next(0, count - 1) == 0)
            {
                if (flagDir[0] == 1)
                {
                    if (flagDir[1] == 1) temp = -transform.right;
                    else if (flagDir[2] == 1) temp = transform.up;
                    else temp = -transform.up;
                }
                else if (flagDir[1] == 1)
                {
                    if (flagDir[2] == 1) temp = transform.up;
                    else temp = -transform.up;
                }
                else temp = -transform.up;
            }
            else if (rand.Next(0, count - 2) == 0)
            {
                if (flagDir[0] == 1 && flagDir[1] == 1 && flagDir[2] == 1)
                {
                    temp = transform.up;
                }
                else temp = -transform.up;
            }
            else temp = -transform.up;
        }
        return temp;
    }
}