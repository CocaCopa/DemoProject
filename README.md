# Demo Project

------------
Introduction
------------

This project is created for anyone that may want to take an early dive on how small __Unity__ games are usually structured.
The project is constructed to have as much balance as possible between following best practices and keeping the code simple.

While some familiarity with the engine should make navigation through the project easier, don't hesitate to take a curious peek, even without prior experience!  

Since this project is meant for begginers in Unity, I documented only the PlayerController class among all the classes, ensuring that those familiar with coding can follow along and gain a brief understanding of how Unity's API functions.
However, even those with no coding experience are also encouraged to explore the code and gain exposure to its concepts.

-----------
Familiarity is Key
-----------

Don't worry if you're unsure about how the code functions. The aim of exploring the code is to become familiar with the tools you'll use in the future.
Focus on understanding the logic behind how things work. Coding is about problem-solving skills, creatively tackling any issues that come your way. It's not about memorizing every command game engines offer.

---------------
Project Classes
---------------

Let's briefly explore each class within the project. This will help you understand the code structure in case you decide to investigate the project further!

1. __PlayerController__  
It handles our player-character's logic and listens to input provided by the player handling our character's movement.

2. __CharacterAnimator__  
The CharacterAnimator class reads the public properties  of our PlayerController class and manages all character animations by interacting with Unity's animation system, Mecanim. This interaction between CharacterAnimator and Mecanim is facilitated through the Animator component.

3. __CoinCounter__  
CoinCounter tracks the number of coins collected by the player. It provides a public function for other scripts to call, that increments the coin counter upon collection.

4. __Coin__  
The Coin script, attached to each coin in the scene, handles collision detection with the player. Upon collision, it destroys the coin and notifies CoinCounter to increment the coin counter using its public function mentioned above.

---------
Have Fun!
---------

Have fun exploring the project and always remember that game development should be an enjoyable journey.  

Encountering the unknown is just part of the fun! Fortunately, there's a vast community eager to assist us in learning. Within the Unity community, various resources are waiting to be discovered – all it takes is the determination to seek them out.  

Feel free to dive into the project, exploring both code snippets and editor functionalities that pique your interest. Utilize the vast resources available on the internet to decipher unfamiliar code and uncover intriguing features within the editor. Embrace the learning process, as each new understanding and discovery enriches your journey in game development!
