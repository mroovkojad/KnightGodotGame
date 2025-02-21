using Godot;
using System;

public partial class Slime : CharacterBody2D
{
    private Texture2D _greenTexture;
    private Texture2D _purpleTexture;
    private AnimatedSprite2D _animatedSprite;
    private SpriteFrames _originalFrames;

    public enum SlimeColor
    {
        Green,
        Purple
    }

    [Export]
    public SlimeColor Color
    {
        get => _color;
        set
        {
            _color = value;
            UpdateSpriteFrames();
        }
    }
    private SlimeColor _color = SlimeColor.Purple;

    public override void _Ready()
    {
        _greenTexture = GD.Load<Texture2D>("res://assets/sprites/slime_green.png");
        _purpleTexture = GD.Load<Texture2D>("res://assets/sprites/slime_purple.png");

        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _originalFrames = _animatedSprite.SpriteFrames;

        UpdateSpriteFrames();
    }

    private void UpdateSpriteFrames()
    {
        if (_originalFrames == null)
            return;

        Texture2D selectedTexture = _color == SlimeColor.Green ? _greenTexture : _purpleTexture;

        // Create a new SpriteFrames instance to clone
        SpriteFrames newFrames = new SpriteFrames();

        foreach (string animationName in _originalFrames.GetAnimationNames())
        {
            newFrames.AddAnimation(animationName);
            newFrames.SetAnimationLoop(animationName, _originalFrames.GetAnimationLoop(animationName));
            newFrames.SetAnimationSpeed(animationName, _originalFrames.GetAnimationSpeed(animationName));

            int frameCount = _originalFrames.GetFrameCount(animationName);
            for (int i = 0; i < frameCount; i++)
            {
                // Copy the region and use the new texture
                Texture2D texture = _originalFrames.GetFrameTexture("default", i);
                newFrames.AddFrame(animationName, texture);
            }
        }

        // Apply the new frames to the AnimatedSprite2D
        _animatedSprite.SpriteFrames = newFrames;
        _animatedSprite.Play();
    }
}
