using Godot;
using System;

public partial class MainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	Button startButton;
	Button optionsButton;
	Button exitButton;

	SceneManager sceneManager;


	public override void _Ready()
	{
	    sceneManager = (SceneManager) GetNode<SceneManager>("/root/SceneManager");
		startButton = GetNode<Button>("Start");
		optionsButton = GetNode<Button>("Options");
		exitButton = GetNode<Button>("ExitGame");
		startButton.Connect("pressed", new Callable(this, nameof(OnStartPressed)));
		optionsButton.Connect("pressed", new Callable(this, nameof(OnOptionsPressed)));
		exitButton.Connect("pressed", new Callable(this, nameof(OnExitGamePressed)));

	}
	private void OnStartPressed()
	{
		GD.Print("Start button pressed");
        sceneManager.ChangeScene(MainScenes.Game);
 	   // GetTree().ChangeSceneToFile("res://Scenes/game.tscn");
	}

	private void OnOptionsPressed()
	{
		GD.Print("Test");
	}

	private void OnExitGamePressed()
	{
	    GetTree().Quit();
	}



	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
