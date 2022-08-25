# vr_project - Alicja Kiluk
The goal of this project was to analyze the impact of various virtual environments on the performance of users and their ability to focus. A VR application was developed allowing participants to play a game simulating skills similar to those used during programming tasks in different digital scenes. Users could work ina classroom full of students, an empty, dark room with no stimuli or a relaxing beach resort. The data about their performance and focus is collected.

# List of required hardware and software
- Unity 2021.3.3f1 or higher
- Oculus Windows Software
- Oculus Quest VR headset with controllers
- Oculus Link Cable
- Bluestacks 5 Android emulator with "Lightbot" installed on it 

# Application launch instructions
1. Plug the Oculus Quest to a PC using the Oculus Link cable
2. Activate the Oculus App on your machine and ensure that the HMD is connected successfully 
3. Put on the Oculus Quest, navigate to settings and activate Oculus Link. This step should result in the user being moved to the Oculus Link environment
4. Take off the HMD and activate the project in Unity (Warning: if the project in Unity is activated before Oculus Quest is successfully conntected, the HMD will not be detected)

# Application usage instructions
1. Select and open the scene you wish to launch in the Unity Editor
2. Ensure that Oculus Link is running properly and the user is in the Oculus Link environment
3. Press "play" in the Unity Editor
4. In order to activate the task completion timer, press the trigger button on the right Oculus Quest controller. A pink circle should appear in the upper right corner of the screen in VR
5. To deactivate the timer, press the trigger again

# Additional information
- In order to play "Lightbot" in VR, open it in Bluestacks 5 and ensure it is currently the top-most tab. The application can stream the PC display into VR, allowing users to play the game using a computer mouse attached to the machine
- To switch the scene, stop the play in Unity Editor and switch to a different scene. Next, press "play" again
- Files containing completion and focus times in different environments can be found in Assets -> StreamingAssets -> ExperimentLogs
