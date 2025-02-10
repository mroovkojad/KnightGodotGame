using Godot;
using System;

public partial class OptionsMenu : Control, ISavable
{
	CheckBox musicCheckBox;

	private Button exitButton;
	private ConfigFile optionsFile = new ConfigFile();
	[Export]
	private string optionsFileName;

	private string optionsFilePath;
	[Export]
	private AudioStreamPlayer2D music;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		optionsFileName = "options.cfg";
		optionsFilePath = "user://" + optionsFileName;
		Load();
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

	public void Save()
	{
		optionsFile.SetValue("music", "enabled", music.Playing);
		optionsFile.Save(optionsFilePath);
		GD.Print("Options Saved:");
		GD.Print("Music enabled: " + music.Playing);
	}
	public void Load()
	{
		if (optionsFile.Load(optionsFilePath) == Error.Ok)
		{
			musicCheckBox.ButtonPressed = (bool) optionsFile.GetValue("music", "enabled", music.Playing);
			GD.Print("Options Loaded:");
			GD.Print("Music enabled: " + music.Playing);
		}
		else
		{
			Save();
		}
	}

	private void OnExitButtonPressed()
	{
		SceneManager.instance.ChangeScene(MainScenes.MainMenu);
	}

}
