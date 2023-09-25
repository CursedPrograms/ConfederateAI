# ConfederateAI

*3D Logic-Based AI for Unity*

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
- Ensure that you have a blood pool and blood spatter particle system.
- Create all the required UI elements in world space and assign them as children to their respective AI (the Player can be the Camera).
- Make sure to check all fields that require a GameObject.
- [Prerequisite: Unity Starter Assets (Third Person Character Controller URP)](https://assetstore.unity.com/packages/essentials/starter-assets-third-person-character-controller-urp-196526)

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

### 3. Player - Character Controller
   - **Tag:** "Player"
   - **Attach:** PlayerCore.cs

### 4. Spawner
   - **Attach:** AISpawner.cs

[ConfederateAI on itch.io](https://cursed-entertainment.itch.io/confederate-ai)
