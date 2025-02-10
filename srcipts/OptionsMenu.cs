using Godot;
using System;

public partial class OptionsMenu : Control
{
	CheckBox musicCheckBox;

	Button exitButton;
	AudioStreamPlayer2D music;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		try
		{
			music = GetNode<AudioStreamPlayer2D>("/root/Music");
			musicCheckBox = (CheckBox) GetNode<CheckBox>("%MusicCheckBox");
			musicCheckBox.Connect("toggled", new Callable(this, nameof(OnMusicCheckBoxToggled)));
			exitButton = GetNode<Button>("%ExitButton");
			exitButton.Connect("pressed", new Callable(this, nameof(OnExitButtonPressed)));
			musicCheckBox.ButtonPressed = music.Playing;
		}
		catch (Exception ex)
		{
			GD.PrintErr("An error occurred: " + ex.Message);
		}
	}

	private void OnMusicCheckBoxToggled(bool toggled_on)
	{
		switch (toggled_on)
		{
			case true:
				music.Play();
				break;
			case false:
				music.Stop();
				break;
		}
	}

	private void OnExitButtonPressed()
	{
		SceneManager.instance.ChangeScene(MainScenes.MainMenu);
	}
}
