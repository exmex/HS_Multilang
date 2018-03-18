using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class EditorCustomization
{
    public const string VersionFilePath = "Assets\\Versioning\\Version.txt";
    public const string VersionTemplateFilePath = "Assets\\Versioning\\Version.tpl";
    
    [MenuItem("ExMex/Versioning/GenerateVersion")]
    private static void GenerateVersion()
    {
        var versions = File.ReadAllLines(VersionFilePath);

        var template = File.ReadAllText(VersionTemplateFilePath);
        template = template.Replace("$TIMESTAMP$",
            ((int) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString(CultureInfo
                .InvariantCulture));
        template = template.Replace("$MAJOR$", versions[0]);
        template = template.Replace("$MINOR$", versions[1]);
        template = template.Replace("$PATCH$", versions[2]);
        template = template.Replace("$TYPE$", "DEBUG");
        File.WriteAllText("Assets\\Scripts\\Version.cs", template);
    }

    [MenuItem("ExMex/Versioning/Increment Patch")]
    private static void VersionIncrPatch()
    {
        if (!File.Exists(VersionFilePath))
            File.WriteAllText(VersionFilePath, "0\n0\n0");
            
        var versions = File.ReadAllLines(VersionFilePath);
        versions[2] = (int.Parse(versions[2]) + 1).ToString();
        File.WriteAllLines(VersionFilePath, versions);

        GenerateVersion();
    }

    [MenuItem("ExMex/Versioning/Increment Minor")]
    private static void VersionIncrMinor()
    {
        if (!File.Exists(VersionFilePath))
            File.WriteAllText(VersionFilePath, "0\n0\n0");
        
        var versions = File.ReadAllLines(VersionFilePath);
        versions[1] = (int.Parse(versions[1]) + 1).ToString();
        File.WriteAllLines(VersionFilePath, versions);
        
        GenerateVersion();
    }

    [MenuItem("ExMex/Versioning/Increment Major")]
    private static void VersionIncrMajor()
    {
        if (!File.Exists(VersionFilePath))
            File.WriteAllText(VersionFilePath, "0\n0\n0");
        
        var versions = File.ReadAllLines(VersionFilePath);
        versions[0] = (int.Parse(versions[0]) + 1).ToString();
        File.WriteAllLines(VersionFilePath, versions);
        
        GenerateVersion();
    }
}