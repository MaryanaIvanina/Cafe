# 🍰 Casual Cafe

**Casual Cafe** is a casual-style Unity game where you manage your own café: cook dishes, serve customers, buy equipment, and unlock new recipes as you progress.  

---

## Gameplay
- Start with a small amount of money and some basic equipment.  
- Interact with kitchen machines to prepare different dishes.  
- Earn money from sales and use it to buy new items in the **Shop**: coffee machines, cupboards, stove, and more.  
- Each new level unlocks additional recipes (latte, cupcakes, etc.) and new interior objects.  
- Inventory is limited: you need to deliver dishes to customers in time.  

---

## Save System
The game includes **automatic saving**:
- Money.
- Score and leve.
- Purchased objects (with their position and active state).
- Prepared dishes in the inventory.

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
