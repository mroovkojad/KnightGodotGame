using Godot;
using System;
using System.Collections.Generic;

// Enum to represent the main scenes of the game, that can be used as main view.
public enum MainScenes
    {
        MainMenu,
        Game,
        Options,
    }
public partial class SceneManager : Node
{

    // Dictionary to store the paths of the main scenes.
    Dictionary<MainScenes, string> ScenePaths = new Dictionary<MainScenes, string> {
    { MainScenes.MainMenu, "res://Scenes/Menu/MainMenu.tscn" },
    { MainScenes.Game, "res://Scenes/Game.tscn" },
    { MainScenes.Options, "res://Scenes/Menu/OptionsMenu.tscn" },
};

    public Node CurrentScene { get; set; }

    public static SceneManager instance;


    public override void _Ready()
    {
        Viewport root = GetTree().Root;
        CurrentScene = root.GetChild(-1);
        instance = this;
    }

    public  void ChangeScene(MainScenes sceneEnum)
    {
        CallDeferred(MethodName.DeferredChangeScene,  Variant.From(sceneEnum));
    }

    public  void DeferredChangeScene(MainScenes sceneEnum)
    {
        // It is now safe to remove the current scene.
        CurrentScene.Free();

        // Get the path to the scene from the dictionary.
        string path = ScenePaths[sceneEnum];

        // Load a new scene.
        var nextScene = GD.Load<PackedScene>(path);

        // Instance the new scene.
        CurrentScene = nextScene.Instantiate();

        // Add it to the active scene, as child of root.
        GetTree().Root.AddChild(CurrentScene);

        // Optionally, to make it compatible with the SceneTree.change_scene_to_file() API.
        GetTree().CurrentScene = CurrentScene;
    }

}