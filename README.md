# ConfederateAI
3D logic-based AI for Unity.
**GameController**
- Tag: "GameController"
- Attach: AIControllerCore.cs

  *Create 2 children objects:*
  1. **FauxTarget**
     - Attach: FauxTarget.cs
     - Set Faction: 0 (Ally), 1 (Enemy)

  2. **AI_Agent**
     - Attach: AICore
     - *Create child object:* AIFollowControl.cs

**Spawner**
- Attach: AISpawner.cs

**Player**
- Tag: "Player"
- Attach: PlayerCore.cs

**FEATURES**
- Unity Navmesh compatible
- No Plug-ins required
- Player and AI detection
- Random waypoints, set waypoints and path system
- Ragdoll + animated deaths
- Melee Combat system
- Companion system
- Spawning system

[ConfederateAI on itch.io](https://cursed-entertainment.itch.io/confederate-ai)
