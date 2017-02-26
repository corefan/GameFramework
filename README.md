## HOMEPAGE

- **English** - Coming soon.
- **简体中文** - [http://gameframework.cn/](http://gameframework.cn/)
  - **QQ 讨论群** 216332935

---

## INTRODUCTION

Game Framework is literally a game framework, based on Unity 5.3+ game engine. It encapsulates commonly used game modules during development, and, to a large degree, standardises the process, enhances the development speed and ensures the product quality.

Game Framework provides the following 17 builtin modules, and more will be developed later for game developers to use.

1. **Data Node** - DataNode saves arbitrary types of data within tree structures in order to manage various data during game runtime.

2. **Data Table** - is intended to invoke game data in the form of pre-configured tables (such as Microsoft Excel sheets). The format of the tables can be customised.

3. **Debugger** - displays a debugger window when the game runs in the Unity Editor or in a development build, to facilitate the viewing of runtime logs and debug messages. The user can register their own features to the debugger windows and use them conveniently.

4. **Download** - provides the ability to download files. The user is free to set how many downloaders could be used simultaneously.

5. **Entity** - provides the ability to manage entities and groups of entities, where an entity is defined as any dynamically created objects in the game scene. It shows or hides entities, attach one entity to another (such as weapons, horses or snatching up another entity). Entities could avoid being destroyed instantly after use, and hence be recycled for reuse.

6. **Event** - gives the mechanism for the game logic to fire or observe events. Many modules in the Game Framework fires events after operations, and observing these events will largely decouple game logic modules. The user can define his own game logic events, too.

7. **FSM** - provides the ability to create, use and destroy finite state machines. It’d be a good choice to use this module for some state-machine-like game logic.

8. **Localization** - provides the ability to localise the game. Game Framework not only supports the localisation of texts, but also assets of all kinds. For example, a firework effect in the game can be localised as various versions, so that the player will see a "新年好" - like effect in the Chinese version, while "Happy New Year" - like in the English version.

9. **Network** - provides socket connections where TCP is currently supported and both IPv4 and IPv6 are valid. The user can establish several connections to different servers at the same time. For example, the user can connect to a normal game server, and another server for voice chat. The 'Packet' class is ready for inheritance and implemented if the user wants to take use of protocol libraries such as ProtoBuf.

10. **Object Pool** - provides the ability to cache objects in pools. It avoids frequent creation and destruction operations of game objects, and hence improves the game performance. Game Framework itself uses object pools, and the user could conveniently create and manage his own pools.

11. **Procedure** - is in fact an FSM of the whole lifecycle of the game. It’d be a very good habit to decouple different game states via procedures. For a network game, you probably need procedures of checking resources, updating resources, checking the server list, selecting a server, logging in a server and creating avatars. For a standalone game, you perhaps need to switch between procedures of the menu and the real gameplay. The user could add procedures by simply subclassing and implementing the 'ProcedureBase' class.

12. **Resource** - provides only asynchronous interfaces to load resources. We don’t recommend synchronous approaches for better play experience, and Game Framework itself uses a complete system of asynchronous resource loading. We load everything asynchronously, including simple things like data tables and localisation texts, and complex things like entities, scenes and UIs. Meanwhile, Game Framework provides default strategies of memory management (and of course, you could define your own strategies). In most cases, you don't even need to call 'Instantiate' or 'Destroy' when using 'GameObject' instances.

13. **Scene** - provides features to manage scenes. It supports simultaneous loading of multiple scenes, and the user is allowed to unload a scene at any time. Therefore partial loading/unloading of scenes could be easily implemented.

14. **Setting** - stores and loads player data in the form of key-value pairs. It simply encapsulates the 'UnityEngine.PlayerPrefs' class.

15. **Sound** - provides features to manage sounds and groups of sounds. The user could set the properties of an audio clip, such as the volume, whether the clip is 2D or 3D, and could even bind the clip to some entity to follow its position.

16. **UI** - provides features to manage user interfaces and groups of UIs, such as showing or hiding, activating or deactivating, and depth changing. No matter the user uses the builtin uGUI in Unity or other UI plugins (NGUI, for example), he only needs to subclass 'UIFormLogic' and implement his own UI logic. The UIs could avoid being destroyed instantly after use, and hence be recycled for reuse.

17. **Web Request** - provides features of short connections, supports GET and POST methods to send requests to the server and acquire the response data, and allows the user to send simultaneous requests to different servers.

---

## ABOUT ASSEMBLIES

Game Framework includes 3 assemblies:

- **GameFramework.dll** - encapsulates fundamental game logic like data management, resource management, object pools, FSMs, localisation, events, entities, network, user interfaces and sounds. This assembly doesn’t depend on the Unity engine (and therefore it’s fairly possible to make some UnrealGameFramework based on this assembly).

- **UnityGameFramework.Runtime.dll** - implements GameFramework.dll depending on UnityEngine.dll. This part is open-source on GitHub conforming to the MIT license.

- **UnityGameFramework.Editor.dll** - implements tools and inspectors based on UnityEditor.dll.

![Game Framework](http://gameframework.cn/wp-content/uploads/2016/04/Game-Framework.png)

We'll refer to Game Framework as GF and Unity Game Framework as UGF for short in technical articles related to this Game Framework.

---

## AUTHORS

- **JIANG Yin (Ellan)**
  - ellan@gameframework.cn
  - [https://github.com/ellanjiang/](https://github.com/ellanjiang/)
