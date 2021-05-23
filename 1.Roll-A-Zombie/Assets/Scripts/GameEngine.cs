using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class GameEngine : MonoBehaviour
{

    public GameObject selectedZombie;
    public List<GameObject> zombies;
    public Vector3 selectedSize;
    public Vector3 defaultSize;
    private int selectedZombieposition = 0;
    public Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectZombie(selectedZombie);
        scoreText.text = "Score: " + score;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("left"))
        {
            deSelectZombie(zombies[selectedZombieposition]);
            if (selectedZombieposition == 0)
            {
                SelectZombie(zombies[3]);
                selectedZombieposition = 3;
            }
            else 
            {
                SelectZombie(zombies[(selectedZombieposition - 1)%4]);
                selectedZombieposition = (selectedZombieposition - 1)%4;
            }
            selectedZombie = zombies[selectedZombieposition];

            
        }   
        if(Input.GetKeyDown("right"))
        {
            deSelectZombie(zombies[selectedZombieposition]);
            SelectZombie(zombies[(selectedZombieposition + 1)%4]);
            selectedZombieposition = (selectedZombieposition + 1)%4;
            selectedZombie = zombies[selectedZombieposition];
        } 
        if(Input.GetKeyDown("up"))
        {
            PushUp();
        }
    }


    void SelectZombie(GameObject newZombie) => newZombie.transform.localScale = selectedSize;
    void deSelectZombie(GameObject newZombie) => newZombie.transform.localScale = defaultSize;
    void PushUp()
    {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0,0,2,ForceMode.Impulse);
    }
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }
}
