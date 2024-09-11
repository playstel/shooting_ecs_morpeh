# ECS Morpeh Test

This project briefly shows how the ECS architecture works. 

---

what's happening on the scene? 

First-person view, the hero is moving forward, has a movement speed, and can deviate left or right (ProviderTransform) if the player holds the mouse button. 
When you press the SPACE, a shooting event is triggered through Morpeh.Events. 
Shooting is accompanied by VFX, SFX, Animation.

![alt text](image-3.png)

---

There are few objects: rifle and bullets.
Each object has Components, Providers, and Systems.
In addition, bullet has Initializer and EventBulletTrigger (IEventData).

![alt text](image-4.png)

---

Scene GameObjects are connected to the ECS via providers (ProviderSpeed, ProviderTransform, etc.):

![alt text](image-2.png)

You can learn more by downloading and running the project in Unity (2023.2.17f1). 

# Other

More projects https://playstel.com/





