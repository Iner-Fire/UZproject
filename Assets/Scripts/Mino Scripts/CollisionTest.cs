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
    public Vector3 lastDir;
    public Vector3 temp;
    public Vector3 DefinitionRight;
    public Vector3 DefinitionLeft;
    public Vector3 DefinitionUp;
    public Vector3 DefinitionDown;
    public int ChanceForBacktrack = 0; //Im wieksze, tym mniejsze prawdopodobienstwo
    private Stopwatch stopWatch = new Stopwatch();
    public Vector3 targetposition;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        DefinitionRight = new Vector3(1, 0, 0);
        DefinitionLeft = new Vector3(-1, 0, 0);
        DefinitionUp = new Vector3(0, 1, 0);
        DefinitionDown = new Vector3(0, -1, 0);
        int[] flag = new int[4];
        for (int i = 0; i < 4; i++) flag[i] = 0;
        moveDir = ChooseDirection(flag); //Wybierz kierunek ruchu na początku zależnie od punktu w którym się znajduje, musi być w punkcie kolizji
    }
    void Update()
    {
        targetposition = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (targetposition.y > transform.position.y - 0.25 && targetposition.y < transform.position.y + 0.25)
        {

        }
        else if (targetposition.x > transform.position.x - 0.25 && targetposition.x < transform.position.x + 0.25)
        {

        }
        else
        {

        }
        rbody.MovePosition(transform.position + moveDir * moveForce); //Przemieszczenie minotaura co update
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        int[] flag = new int[4];
        for (int i = 0; i < 4; i++) flag[i] = 0;
        if (col.gameObject.name == "Mino_GoRight") // Analiza dozwolonych tras, wpisywanie w tabelke jedynek dla wektorów dozwolonych
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
            yield return new WaitForSeconds(0.05f); //Kolizja ma zachodzić po małym odstępie czasu, by minotaur zdążył dojść do środka zakrętu, by wtedy skręcić
            moveDir = ChooseDirection(flag);
        }
        StartCoroutine(czekaj());

    }
    Vector3 ChooseDirection(int[] flagDir)
    {
        System.Random rand = new System.Random();
        Vector3 temp = new Vector3();
        int count = 0;

        for (int k = 0; k < 4; k++) if (flagDir[k] == 1)
            {
                count++; //Zlicz wszystkie działające trasy
            }
        int roll = rand.Next(0, count * ChanceForBacktrack);
        UnityEngine.Debug.Log(roll);
        if (roll == 0)
        {
            temp = -moveDir;
        }
        else
        {
            if (moveDir.Equals(DefinitionRight)) //Usun mozliwosc powrotu
            {
                flagDir[1] = 0;
            }
            if (moveDir.Equals(DefinitionLeft))
            {
                flagDir[0] = 0;
            }
            if (moveDir.Equals(DefinitionUp))
            {
                flagDir[3] = 0;
            }
            if (moveDir.Equals(DefinitionDown))
            {
                flagDir[2] = 0;
            }
            if (roll > 0 && roll <= ChanceForBacktrack)
            {
                if (flagDir[0] == 1) temp = transform.right;
                else if (flagDir[1] == 1) temp = -transform.right;
                else if (flagDir[2] == 1) temp = transform.up;
                else temp = -transform.up;
            }
            else if (roll > ChanceForBacktrack && roll <= 2 * ChanceForBacktrack)
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
            else if (roll > 2 * ChanceForBacktrack && roll <= 3 * ChanceForBacktrack)
            {
                if (flagDir[0] == 1 && flagDir[1] == 1 && flagDir[2] == 1)
                {
                    temp = transform.up;
                }
                else temp = -transform.up;
            }
            else temp = -transform.up;
        }
        UnityEngine.Debug.Log("Ide w " + temp);
        return temp;
    }
}