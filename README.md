<br>
<div align="center">
  <a href="https://ko-fi.com/cursedentertainment">
    <img src="https://ko-fi.com/img/githubbutton_sm.svg" alt="ko-fi" style="width: 20%;"/>
  </a>
</div>
<br>


<div align="center"> 
  <img alt="Unity" src="https://img.shields.io/badge/unity%20-%23323330.svg?&style=for-the-badge&logo=unity&logoColor=white"/>  
</div>

<div align="center">
  <img alt="C#" src="https://img.shields.io/badge/C%23-%23323330.svg?&style=for-the-badge&logo=csharp&logoColor=white"/> 
  <img alt="JSON" src="https://img.shields.io/badge/JSON-%23323330.svg?&style=for-the-badge&logo=json&logoColor=white"/>
   <img alt="HLSL" src="https://img.shields.io/badge/HLSL-%23323330.svg?&style=for-the-badge&logo=microsoft&logoColor=white"/>
  <img alt="ShaderLab" src="https://img.shields.io/badge/ShaderLab-%23323330.svg?&style=for-the-badge&logo=unity&logoColor=white"/>
</div>

<div align="center">
  <img alt="PowerShell" src="https://img.shields.io/badge/PowerShell-%23323330.svg?&style=for-the-badge&logo=powershell&logoColor=white"/>
  <img alt="Shell" src="https://img.shields.io/badge/Shell-%23323330.svg?&style=for-the-badge&logo=gnu-bash&logoColor=white"/>
  <img alt="Batch" src="https://img.shields.io/badge/Batch-%23323330.svg?&style=for-the-badge&logo=windows&logoColor=white"/>
  </div>
<br>

# ConfederateAI

*3D Logic-Based AI for Unity*
<div align="center">
<a target="_blank">
    <img src="https://github.com/CursedPrograms/ConfederateAI/blob/main/Assets/Sprites/Confederate%20AI%20Logo.png"
        alt="CursedGPT" style="width:50%;">
</a></div>

<br>
  
## Features
- Unity Navmesh compatible
- No Plug-ins required
- Player and AI detection
- Random waypoints, set waypoints, and path system
- Ragdoll + animated deaths
- Melee Combat system
- Companion system
- Spawning system

## Instructions

- Make sure you have a blood pool and blood spatter particle system.
- Create all the required UI elements in world space and assign them as children to their respective AI (the Player can be the Camera).
- Double-check all fields that require a GameObject.
- Ensure that you are using the new Unity Input System.
- Make sure to set it to URP (Universal Render Pipeline).

## Setup

### 1. GameController
   - **Tag:** "GameController"
   - **Attach:** AIControllerCore.cs
   - Create 2 children objects (1 for each faction):
     - **Attach:** FauxTarget.cs
     - **Set Faction:** 0 (Ally), 1 (Enemy)

### 2. AI_Agent
   - **Attach:** AICore.cs
   - Create child object:
     - **Attach:** AIFollowControl.cs
   - Create Ragdoll

### 3. Player - Character Controller
   - **Tag:** "Player"
   - **Attach:** PlayerCore.cs

### 4. Spawner
   - **Attach:** AISpawner.cs

[ConfederateAI on itch.io](https://cursed-entertainment.itch.io/confederate-ai)

### Example Games:
- [Araknia](https://cursed-entertainment.itch.io/araknia)
- [Nystylla: Girls of Maluxzka](https://cursed-entertainment.itch.io/nystylla)

<br>
<div align="center">
© Cursed Entertainment 2024
</div>
<br>
<div align="center">
<a href="https://cursed-entertainment.itch.io/" target="_blank">
    <img src="https://github.com/CursedPrograms/cursedentertainment/raw/main/images/logos/logo-wide-grey.png"
        alt="CursedEntertainment Logo" style="width:250px;">
</a>
</div>
