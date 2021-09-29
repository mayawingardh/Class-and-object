using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uppgift : ProcessingLite.GP21
{
    public Player player;
    public Ball myBall;
    public Ball[] balls;
    public int numbersOfBalls = 10;
    bool gameOver;

    public void Start()
    {
        init();
    }

    //Start method. 
    private void init()
    {
        balls = new Ball[numbersOfBalls];

        for (int i = 0; i < numbersOfBalls; i++)
        {
            float x1 = Random.Range(0, Width);
            float y1 = Random.Range(0, Height);
            balls[i] = new Ball(x1, y1);
        }

        player = new Player();
        float x = Width / 2;
        float y = Height / 2;
        myBall = new Ball(x, y);
    }

    void Update()
    {
        //Makes the games start over.
        if (Input.GetMouseButtonDown(0))
        {
            gameOver = false;
            init();    
        }
       
        if (gameOver)
        {
            return;
        }

        player.Circle();
        myBall.Draw();
        myBall.UpdatePos();
        myBall.Bounce();

        //Check for collision
        for (int i = 0; i < numbersOfBalls; i++)
        {
            balls[i].UpdatePos();
            balls[i].Draw();
            balls[i].Bounce();

            bool hit = CircleCollision(
                balls[i].position.x,
                balls[i].position.y,
                balls[i].diameter,
                player.circlePosition.x,
                player.circlePosition.y,
                player.circleSize);

        //If collision
            if (hit)
            {           
                stop();
                break;
            }            
        }
    }
    public bool CircleCollision(float x1, float y1, float size1, float x2, float y2, float size2)
    {
        float maxDistance = size1/2 + size2/2;

        if (Mathf.Abs(x1 - x2) > maxDistance || Mathf.Abs(y1 - y2) > maxDistance)
        {
            return false;
        }

        else if (Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)) > maxDistance)
        {
            return false;
        }

        else
        {
            return true;
        }
    }
    //Method for game over
    public void stop()
    {
        Background(46, 139, 87);
        Stroke(0);
        gameOver = true;
        Text("GAME OVER", Width / 2, Height / 2);      
    }

}
