using Godot;
using System;

public class Player : Area2D
{
    [Export]
    int Speed = 400;
    [Export]
    Vector2 direction = new Vector2(0,0);
    Vector2 screenSize =  new Vector2(0,0);
    Vector2 clampPos = new Vector2(0,0);

    public AnimatedSprite player;
    public override void _Ready()
    {
        
        screenSize = GetViewportRect().Size;
        GD.Print(screenSize);
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

        if(direction.Length() > 0)
        {
            direction = direction.Normalized();
            player = GetNode<AnimatedSprite>("AnimatedSprite");
            player.Play();
            
        }

        this.Position += direction * Speed * delta;
        GD.Print(Position.x);
        clampPos.x = Mathf.Clamp(Position.x,0,screenSize.x);
        clampPos.y = Mathf.Clamp(Position.y,0,screenSize.y);
        Position = clampPos;
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
