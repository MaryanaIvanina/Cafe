# Casual Cafe: Management Simulation

**Casual Cafe** is a 3D tycoon-style simulation game where players manage a coffee shop, cook dishes, serve customers, and expand their business.

The project highlights **data persistence systems**, **ScriptableObject architecture**, and dynamic object management in Unity.

---

## Gameplay Loop
- **Cooking System:** Interactive machines (Espresso Machine, Stove) with timer-based cooking mechanics.
- **Economy:** Earn money by fulfilling customer orders to buy new equipment and furniture.
- **Progression:** Level-up system unlocking new recipes (Latte, Cupcakes) and shop items.
- **Shop & Customization:** Place furniture and equipment dynamically within the 3D space.

---

## Technical Implementation

### Persistence System (`SaveManager.cs`)
The game features a robust **JSON-based Save/Load system** that persists the entire game state:
- **Inventory:** Serializes list of items and their sell prices.
- **Scene State:** Saves position, rotation, and active state of every purchased object (`PurchasedObjectData` class).
- **Economy:** Persists player money, score, and current level.
- **Automatic Saving:** Triggers on application quit or pause.

### Data-Driven Design
- **ScriptableObjects:** Used for `Dish` and `InventoryItemData`. This allows game designers to add new items, change prices, or swap icons without touching the codebase.
- **Scalability:** The shop and recipe systems automatically adapt to new ScriptableObjects added to the database.

### Dynamic Object Management
- **ObjectManager:** Handles the instantiation of new furniture and the "Transform Mode," allowing players to move and place objects in the scene at runtime using raycasting.

---

## Technical Retrospective (Self-Review 2026)
*This project demonstrates my ability to build complete game loops and persistence systems. Looking back, I identify several areas for architectural improvement:*

1.  **Decoupling UI from Logic:**
    * *Current:* UI elements (like `CookingUI`) are tightly coupled with gameplay logic, often checking input states directly.
    * *Future Approach:* Implement a **Model-View-Presenter (MVP)** or **MVVM** pattern. The UI should merely visualize the state, while a separate Presenter handles the business logic, communicating via C# Events or Reactive Properties (UniRx/R3).

2.  **Input Handling:**
    * *Current:* Input checks (raycasts) are scattered across `ObjectManager` and `Cooking` classes.
    * *Future Approach:* Centralize input processing in a dedicated `InputService` and broadcast interaction events to relevant listeners.

3.  **Addressables:**
    * *Current:* Direct references to prefabs in Managers.
    * *Future Approach:* Integrate the **Addressables** system to load heavy assets (furniture models) asynchronously, optimizing memory usage and startup time.

---

## Tech Stack
- **Engine:** Unity 2022.3.37f1
- **Language:** C#
- **Data:** JSON Serialization, ScriptableObjects
- **UI:** Unity UI (Canvas, Layout Groups)

## Installation
1. Clone the repository.
2. Open in Unity Hub.
3. Play from the `MainMenu` scene.- Prepared dishes in the inventory.

The game state is saved in **JSON** at `Application.persistentDataPath/save.json` and automatically restored on game launch.  
You can also call `SaveManager.instance.Save()` manually for instant saving.   

---

## Features
- **Casual style**: simple and accessible gameplay loop.  
- **Inventory with visual slots**: dishes are added as icons, each identified by `sellPrice`.  
- **Shop system**: spending money creates purchasable objects in the scene.  
- **Level progression**: reaching score milestones unlocks new recipes and items.  
- **JSON save system**: the entire game state (scene + inventory) is stored and restored.  

---

## Future Development
- More levels and recipes.  
- Customer system with individual orders.  
- Additional shop items (decor, furniture).  
- Multiple save slots support.  

---
## How to Run
- Download the Cafe.zip file from the Releases section.
- Extract it to a convenient folder.
- Run Cafe.exe.

---

## License
This project was created for educational purposes. Usage and distribution are at the author's discretion.
