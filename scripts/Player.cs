using Godot;
using System;

public class Player : Area2D
{
    [Export]
    int Speed = 400;
    [Export]
    Vector2 direction = new Vector2(0,0);
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        
        if (Input.IsActionPressed("move_up"))
        {
            direction.y -= 1;
            GD.Print("moving up");
        }
        if (Input.IsActionPressed("move_down"))
        {
            direction.y += 1;
            GD.Print("moving down");
        }
        if (Input.IsActionPressed("move_left"))
        {
            direction.x -= 1;
            GD.Print("moving left");
        }
        if (Input.IsActionPressed("move_right"))
        {
            direction.x += 1;
            GD.Print("moving right");
        }

        if(direction.Length() > 1)
        {
            direction = direction.Normalized();
        }

        this.Position += direction * Speed * delta;
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
