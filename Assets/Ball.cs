using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ProcessingLite.GP21
{
   public Vector2 position;
   public Vector2 velocity;
   public float diameter;

    //Ball Constructor, called when we type new Ball(x, y);
    public Ball(float x, float y)
    {
        //Set our position when we create the code.
        position = new Vector2(x, y);

        //Create the velocity vector and give it a random direction.
        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
    }

    //Draw our ball
    public void Draw()
    {
        diameter = 1.2f;
        Fill(255, 255, 205);
        Stroke(255, 255, 205);
        Circle(position.x, position.y, diameter);
    }

    //Update our ball
    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;
    }

    //Make the balls bounce
    public void Bounce()
    {
        if (position.x > Width || position.x < 0)
        {
            velocity.x *= -1;

        }

        if (position.y > Height || position.y < 0)
        {
            velocity.y *= -1;
        }
    }
}
