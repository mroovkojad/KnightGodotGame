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
        { MainScenes.MainMenu, "res://scenes/menus/mainMenu.tscn" },
        { MainScenes.Game,     "res://scenes/game.tscn" },
        { MainScenes.Options,  "res://scenes/menus/optionsMenu.tscn" },
    };

    public Node CurrentScene { get; set; }
    public static SceneManager instance;

    public override void _Ready()
    {
        Viewport root = GetTree().Root;
        CurrentScene = root.GetChild(root.GetChildCount() - 1);
        instance = this;
    }

    public void ChangeScene(MainScenes sceneEnum)
    {
        CallDeferred(MethodName.DeferredChangeScene,  Variant.From(sceneEnum));
    }

    public void DeferredChangeScene(MainScenes sceneEnum)
    {
        // It is now safe to remove the current scene.
        try
        {
            if (CurrentScene != null)
            {
                CurrentScene.Free();
            }
        }
        catch (Exception ex)
        {
            GD.PrintErr("Error freeing current scene: " + ex.Message);
        }

        // Get the path to the scene from the dictionary.
        string path = ScenePaths[sceneEnum];
        // Load a new scene.
        var nextScene = GD.Load<PackedScene>(path);
        GD.Print("Loaded path: " + path);

        // Check if the scene was loaded successfully
        if (nextScene == null)
        {
            GD.PrintErr("Failed to load scene: " + path);
            return;
        }

        // Instance the new scene.
        CurrentScene = nextScene.Instantiate();
        // Add it to the active scene, as child of root.
        GetTree().Root.AddChild(CurrentScene);
        // Optionally, to make it compatible with the SceneTree.change_scene_to_file() API.
        GetTree().CurrentScene = CurrentScene;
    }
}