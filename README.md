# Tiled2UnityAutoImport
---
## For use with [Tiled2Unity](http://www.seanba.com/tiled3unity)

A simple bit of Editor script to allow .tmx Tiled Map files to be automatically
processed by Tiled2Unity.

### Usage:
1. Add the *Editor/* directory somewhere in your Unity project
2. The next time a .tmx file is added to/modified in your project a preferences
window will open
3. Adjust your settings and click OK
4. That's it!

To change your settings in the future clicked the Tiles2Unity menu ->
Set Tiled2Unity Import Prefs

### Settings
* **Path**: The path to Tiled2Unity.exe
* **Vertex scale**: See [this article](http://www.seanba.com/revisit-tiled2unity-scale.html)
* **Exit on complete**: Have Tiled2Unity auto-close on complete
* **Hide Tiled2Unity Window**: Hide the Tiled2Unity window as it exports
* **Export timeout**: The length of time to wait for Tiled2Unity to export
in milliseconds
