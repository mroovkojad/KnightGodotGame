using Godot;
using System;
using System.Text.Json;
using System.Collections.Generic;

public interface ISavable<T>
{
    List<string> GetSavableProperties();
    public void Save(T obj);
    public void Save(T obj, string path);
    public T Load();
    public T Load(string path);
    public void Delete();
    public void Delete(string path);
}
