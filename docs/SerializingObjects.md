# Object serialization

- Save to JSON
- Use ISavable interface
- Make it necessary to select properties that are needed to be saved
- Verify property types

## Request for AI:

- Implement a custom JSON saver for saving Godot files to JSON.
- The saver should only save ISavable classes.
- Savable classes require a list of properties that need to be saved.
- The saver needs to check the property list:
    - The properties must belong to the class implementing ISavable.
    - The properties must be limited to supported types.
- Vector2 objects are supported and customly handled.
