# Cuphead_Accessibility_Mod

## Installation

Download latest Cuphead_Accessibility.dll https://github.com/vtvrv/Cuphead_Accessibility_Mod/releases

Download BepinEx version 5. https://github.com/BepInEx/BepInEx/releases (Tested with 5.4.19) 

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

## Compiling
Add assembly reference to "Aseembly-CSharp.dll" of Cuphead Legacy Version (The version built on Unity Version 5). 

This maintains compatibility with all versions of Cuphead.
