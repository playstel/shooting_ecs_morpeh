# ECS Morpeh Test

This project briefly shows how the ECS architecture works. 

First-person view, the hero is moving forward, has a movement speed, and can deviate left or right (ProviderTransform) if the player holds the mouse button. 
When you press the SPACE, a shooting event is triggered through Morpeh.Events. 
Shooting is accompanied by VFX, SFX, Animation.

![image](https://github.com/user-attachments/assets/63d54b8c-5e8a-493a-bb89-7f090e303f74)

---

There are a few objects: rifle and bullets.
Each object has Components, Providers, and Systems.
In addition, a bullet has Initializer and EventBulletTrigger (IEventData).

![image](https://github.com/user-attachments/assets/46f2ee7a-8609-4010-861f-63862be41de2)

---

Scene GameObjects are connected to the ECS via providers (ProviderSpeed, ProviderTransform, etc.):

![image](https://github.com/user-attachments/assets/1fb09116-c83a-42ab-ad5c-dee98d692405)

Rifle:
![image](https://github.com/user-attachments/assets/8f701b7c-877f-4958-b223-d25b91c44dc9)

Bullet:
![image](https://github.com/user-attachments/assets/74a97b17-c16c-4224-91df-611ec567a4af)

Input:
![image](https://github.com/user-attachments/assets/4d7565dd-6c48-4abe-a914-0df27e12f7a0)


You can learn more by downloading and running the project in Unity (2023.2.17f1). 

# Other

More projects https://playstel.com/





