# HexUN
Centralized patterns and reusable elements that uses Unity UI.

### Installation
To add this to your project make sure the following is in your package.json

```json
{
    "dependencies" : 
    {
        "com.hex.hexcs" : "https://github.com/hexthedev/HexCS.git",
        "com.hex.hexcs.data" : "https://github.com/hexthedev/HexCS-Data.git",
        "com.hex.hexun" : "https://github.com/hexthedev/HexUN.git",
        "com.hex.hexun.input" : "https://github.com/hexthedev/HexUN-Input.git",
        "com.unity.inputsystem": "1.0.1",
        "com.hex.hexun.uxui" : "https://github.com/hexthedev/HexUN-UXUI.git",
    }
}
```

# Overview
Ok, so I made this to hlep medecouple some of the input vs. ux stuff in my Unity projects but I stepped away from it for a while. Time to clean and figure out what I did that's actually useful.

Below, systems defined by their own folders in each parent (`Scripts`, `Prefabs`) etc.


## Defaults
This exists simply to provide defaults to stuff, so that things arn't null and breaking ever. 

## ProtoUI
This is a set of premade Ui elements that should make prototyping uis quick cause everything premade and acts as examples for better Uis. 

Basically, all Ui elements are VisualFacades that hide the inner members of the element. All Ui element of a certain type have an abstract class the defines behavious, and a concrete implementation of how that behaviour is rendered. 

## `APuiControl : AVisualFacade`
Abstract class for all PuiControls. Gives a plae to provide functionality to everything.
* Get `RectTransform` with easy property. 

## `APuiInteractable : APuiControl`
Abstract class for all PuiControls that can toggle some kind of interactability. 
* Provides a editor toggle for interactability
* Interactiability is managed by providing references to the input component providing the interactability