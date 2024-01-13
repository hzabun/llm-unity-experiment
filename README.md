# LLM-Unity-experiment
 
## Project description
Testing the ability of LLMs to create custom-tailored games via the Unity game engine without writing any code myself.

Tried in a previous project this experiment purely with PyGame. My hypothesis was that as PyGame is purely text-based, LLMs should be able to create some neat game code for it. Turns out telling an LLM to make different game modules (main controller, level generation, game loop etc.) work together is a nightmare. This is due to current LLMs having quite limited context window sizes and creates tons of overhead for me when giving prompts. That beats the point of this whole experiment to create game without having too think much about the code.

Now experimenting with the Unity game engine to see how much it's UI can help have LLMs write all the code without having too think too much about how modules communicate with each other.
