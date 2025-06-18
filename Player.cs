using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		// Add the gravity.
		//if (!IsOnFloor())
		//{
		//velocity += GetGravity() * (float)delta;
		//}

		// Handle Jump.
		//if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		//{
		//velocity.Y = JumpVelocity;
		//animatedSprite2D.Animation = "stand-front";
		//}

		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;

			if (direction.X > 0)
			{
				animatedSprite2D.Animation = "stand-right";
			}
			else if (direction.X < 0)
			{
				animatedSprite2D.Animation = "stand-left";
			}
			else if (direction.Y > 0)
			{
				animatedSprite2D.Animation = "stand-front";
			}
			else
			{
				animatedSprite2D.Animation = "stand-back";
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var collision = GetSlideCollision(i);
			GD.Print("I collided with ", ((Node)collision.GetCollider()).Name);
		}
	}
}
