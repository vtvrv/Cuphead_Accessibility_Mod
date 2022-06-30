# Cuphead_Accessibility_Mod

## Installation

Download BepinEx version 5. https://github.com/BepInEx/BepInEx/releases (Tested with 5.4.19) 

Extract contents of BepInEx zip to the Cuphead game folder. 

Run game, then close. 

Place Cuphead_Accessibility.dll into the Cuphead\BepInEx\plugins\ directory. 

Confirmed working with versions of Cuphead.

Steam may cause issues I've only tried the GOG release. 

## Features
- Disable film grain
- Photosensitive accessibility changes (disables hitflash, screen shake, flashing level intro, boss explosion animations, and adjusts scenery)
- Skip launch intro movies
- Disable HUD*
- Level select menu (press Home Key at any time)
- Healthbar

\* By default every feature except "disable HUD" is enabled.

Every feature can be toggled by editing "Cuphead\BepinEx\config\Cuphead_Accessibility.cfg"

The game must be restarted to reflect configuration file changes.

## Known bugs.
- Controller binds disregarded at launch. Temporary fix disable "Launch to Title Screen" in config file.
- "Launch To Tile Screen" not working with Cuphead version 1.0.
- Level select debug menu freezes on version 1.3.2
- "Disable Film Grain" also disables optional color filters and Flower Boss psychedelic effect.
- There is one frame of lightning at the beginning of the Dragon Boss final phase.
