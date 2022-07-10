# Cuphead_Accessibility_Mod  <img src="https://raw.githubusercontent.com/vtvrv/Cuphead_Accessibility_Mod/main/images/example01_360p.jpg">


## Installation

Download latest Cuphead_Accessibility.dll https://github.com/vtvrv/Cuphead_Accessibility_Mod/releases

Determine if your version of Cuphead is x86 or x64 by running the game and opening Task Manager. If process is named "Cuphead.exe (32 bit)" it is x86. If not it is x64.

Download the appropriate x86 or x64 version of BepinEx 5. https://github.com/BepInEx/BepInEx/releases (Tested with 5.4.19) 

Extract contents of BepInEx zip to the Cuphead game folder. 

Run game, then close. 

Place Cuphead_Accessibility.dll into the Cuphead\BepInEx\plugins\ directory. 

Confirmed working with all versions of Cuphead.

## Features
- Disable film grain
- Photosensitive accessibility changes (disables hitflash, screen shake, flashing level intro, boss explosion animations, and adjusts scenery)
- Disable flashing level intro
- Disable HUD*
- Healthbar

\* By default every feature except "disable HUD" is enabled.

Every feature can be toggled by editing "Cuphead\BepinEx\config\Cuphead_Accessibility.cfg"

The game must be restarted to reflect configuration file changes.

## Known bugs.
- "Disable Film Grain" also disables optional color filters and flower bss psychedelic effect.
- With the dragon boss photosensensitivity fix enabled there is still one frame of lightning at the beginning of his final phase.
- Debug Menu freezes on Cuphead version 1.3.2. Can be fixed by opening Unity Explorer plugin while loading debug menu.

## Compiling
To set up the poject I followed this tutorial https://docs.bepinex.dev/master/articles/dev_guide/plugin_tutorial/index.html  
Initializing the plugin project I used these two commands  
- dotnet new bepinex5plugin -n Cuphead_Accessibility -T net35 -U 5.6.2  
- dotnet restore Cuphead_Accessibility

Add an assembly reference to "Assembly-CSharp.dll" of Cuphead Legacy Version (The version built on Unity Version 5). 

This maintains compatibility with all versions of Cuphead.
