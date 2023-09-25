# ConfederateAI
3D logic-based AI for Unity.

1. **GameController**
   - *Tag:* "GameController"
   - *Attach:* AIControllerCore.cs
   - *Create 2 children objects (1 for each faction):*
     - *Attach:* FauxTarget.cs
     - *Set Faction:* 0 (Ally), 1 (Enemy)

2. **AI_Agent**
   - *Attach:* AICore
   - *Create child object:* AIFollowControl.cs

3. **Player - Character Controller**
   - *Tag:* "Player"
   - *Attach:* PlayerCore.cs

4. **Spawner**
   - *Attach:* AISpawner.cs

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
