using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{
    
    public Vector2 circlePosition;

    public float circleSize = 1.3f;
    public float speed = 5;

     Vector2 velocity;
     Vector2 acceleration;

        //draw the player. C
        public void Circle()
        {
           Background(219, 112, 147);
          
            float x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            float y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

            Fill(46, 139, 87);
            Stroke(46, 139, 87);

            circlePosition += new Vector2(x, y);

            Circle(circlePosition.x, circlePosition.y, circleSize);

            StayInside();
        }

        // makes the playar and the balls stay inside the screen.
        public void StayInside()
        { 
            circlePosition.x = (circlePosition.x + Width) % Width;
            circlePosition.y = (circlePosition.y + Height) % Height;
        }



    
}
