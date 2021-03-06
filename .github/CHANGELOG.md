# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/), and this project *somewhat* adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.6.0] - 2020-07-10
### Added
 - Added the following class and method :
   - Class : **ScriptingTools.Math**
     - `RoundToStep(float, float)`
     - `RoundToStepInt(float, int)`

## [0.5.0] - 2020-06-09
### Added
 - Added the following class and method :
   - Class : **ScriptingToolsEditor.CustomEditor**
     - `EnumField<T>(string, T, params GUILayoutOption[])`

## [0.4.0] - 2020-06-09
### Added
 - Added the following classes and methods :
   - Class : **ScriptingTools.Strings**
     - `IsAnyNullOrEmpty(List<string>)`
     - `IsAnyNullOrEmpty(string[])`

## [0.3.0] - 2020-06-09
### Added
 - Added the following classes and methods :
   - Class : **ScriptingTools.Lists**
     - `AddUnique<T>(List<T>, T, Predicate<T>)`
     - `AddUniqueRange<T>(List<T>, List<T>, Predicate<T>)`
   - Class : **ScriptingTools.Strings**
     - `SubstringByIndexes(string, int, int)`

### Bug fix
 - Class : **ScriptingToolsEditor.Lists**
   - Fixed some incorrect summaries 

## [0.2.1] - 2020-05-31
### Bug fix
 - Class : **ScriptingToolsEditor.Handles**
   - Fixed a small math error for `DrawWireCone` 

## [0.2.0] - 2020-05-31
### Added
 - Added the following classes and methods :
   - Class : **ScriptingTools.Color**
     - `ColorAndAlpha(Color, float)`
     - `ColorToHex(Color)`
     - `HexToColor(string)`
     - `RichTextColor(string, string)`
     - `RichTextColor(string, Color)`
     - `RichTextColor(char, string)`
     - `RichTextColor(char, Color)`
     - 23 shortcuts for Colors based on rich text markup ([see here](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html#supported-colors))
   - Class : **ScriptingTools.File**
     - `QuickScreenshot(string, string)`
     - `QuickScreenshot(string)`
     - `QuickScreenshot()`
     - `TryLoadFile<T>(string, out T)`
     - `WriteFile<T>(string, T, bool)`
     - `WriteFile<T>(string, T)`
   - Class : **ScriptingTools.Lists**
     - `PickRandomAndShuffle<T>(T[])`
     - `WeightedRandom<T>(T[], int[])`
     - `WeightedRandom<T>(List<T>, List<int>)`
     - `WeightedRandom<T>(Dictionary<T, int>)`
   - Class : **ScriptingTools.Math**
     - `Remap(float, float, float, float, float)`
     - `Average(float[])`
     - `Average(List<float>)`
     - `Average(Vector3[])`
     - `InRange(float, float, float)`
     - `InRange(int, int, int)`
     - `AngleIsBetween(float, float, float)`
     - `DirectionToAngle(Vector2)`
     - `DirectionToAngle(float, float)`
     - `AngleToDirection(float)`
   - Class : **ScriptingTools.Physics**
     - `OverlapCone(Vector3, Vector3, float, float, int, QueryTriggerInteraction)`
     - `OverlapCone(Vector3, Vector3, float, float, int)`
     - `OverlapCone(Vector3, Vector3, float, float)`
     - `OverlapCone<T>(Vector3, Vector3, float, float, int, QueryTriggerInteraction)`
     - `OverlapCone<T>(Vector3, Vector3, float, float, int)`
     - `OverlapCone<T>(Vector3, Vector3, float, float)`

 - Added the following Editor classes and methods :
   - Class : **ScriptingToolsEditor.AssetDatabase**
     - `FindAssetsByType<T>()`
     - `FocusAsset(Object)`
   - Class : **ScriptingToolsEditor.CustomEditor**
     - `LayerMaskField(string, LayerMask, params GUILayoutOption[])`
     - `LayerMaskField(LayerMask, params GUILayoutOption[])`
     - `RecordedField<T>(Object, ref T, Func<T>, string)`
     - `RecordedField<T>(Object, ref T, Func<T>)`
   - Class : **ScriptingToolsEditor.Debug**
     - `LogColored(string, Color, Object)`
     - `LogColored(string, Color)`
     - `LogFormatColored(Object, Color, string, params object[])`
     - `LogFormatColored(Color, string, params object[])`
     - `LogWarningColored(string, Color, Object)`
     - `LogWarningColored(string, Color)`
     - `LogWarningFormatColored(Object, Color, string, params object[])`
     - `LogWarningFormatColored(Color, string, params object[])`
     - `LogErrorColored(string, Color, Object)`
     - `LogErrorColored(string, Color)`
     - `LogErrorFormatColored(Object, Color, string, params object[])`
     - `LogErrorFormatColored(Color, string, params object[])`
   - Class : **ScriptingToolsEditor.Handles**
     - `DrawWireCone(Vector3, Quaternion, float, float)`
     - `DrawWireCube(Vector3, Quaternion, Vector3)`
     - `DrawWireSphere(Vector3, Quaternion, float)`

## [0.1.0] - 2020-05-31
### Initial setup
 - Added the base Github stuff