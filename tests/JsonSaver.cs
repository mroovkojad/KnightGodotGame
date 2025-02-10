// using System;
// using System.Collections.Generic;
// using System.Text.Json;
// using System.Reflection;
// using Godot;

// public static class JsonSaverLoader<T>
// {
//     private static readonly HashSet<Type> SupportedTypes = new HashSet<Type>
//     {
//         typeof(int), typeof(float), typeof(string), typeof(bool), typeof(Vector2)
//     };

//     public static bool IsSavable(ISavable obj)
//     {
//         if (obj == null)
//             throw new ArgumentNullException(nameof(obj));

//         var properties = obj.GetSavableProperties();
//         Type objType = obj.GetType();
//         foreach (string property in properties)
//         {
//             PropertyInfo propertyInfo = objType.GetProperty(property);
//             if (!SupportedTypes.Contains(propertyInfo.PropertyType))
//             {
//                 GD.PrintErr($"The property type {propertyInfo.PropertyType} is not supported and cannot be used for saving.");
//                 return false;
//             }
//         }
//         return true;
//     }


//     private static Dictionary<string, float> SerializeVector2(Vector2 vector)
//     {
//         return new Dictionary<string, float> { { "x", vector.X }, { "y", vector.Y } };
//     }

//     public static string ConvertToJson<T>(ISavable<T> obj)
//     {
//         if (!IsSavable(obj))
//             throw new ArgumentException("Object is not savable", nameof(obj));

//         var propertiesToSave = obj.GetSavableProperties();
//         Dictionary<string, object> jsonDict = new Dictionary<string, object>();

//         foreach (string property in propertiesToSave)
//         {
//             PropertyInfo propertyInfo = obj.GetType().GetProperty(property);

//             object value = propertyInfo.GetValue(obj);
//             jsonDict[property] = propertyInfo.PropertyType == typeof(Vector2) ? SerializeVector2((Vector2)value) : value;
//         }

//         return JsonSerializer.Serialize(jsonDict, new JsonSerializerOptions { WriteIndented = true });
//     }


// }