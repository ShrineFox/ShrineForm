# ShrineForm
A WinForms setup for creating project management tools.
![](https://i.imgur.com/K8kFa9C.png)
# What is ShrineForm?
I created ShrineForm as a base for my various work-in-progress (WIP) Project Management applications.  
These apps, such as P-Studio and ACNHLab, are meant to simplify modding videogames by acting as a file manager and tool launcher.
# How It Works
- You can create a new project or load one from a ``.yml`` file.  
- Project settings can be easily configured by editing the ``Controls.yml`` associated with your form.  
  For example, SettingsForm would be based on ``SettingsFormControls.yml``.  
- Each setting can have various attributes, such as read-only, alphanumeric-only, required, default value etc.  
- The settings will only be saved if they are valid, checked against these attributes when you click the Save button.  
- Then, the program can use settings loaded from the ``.yml`` file for various operations in the program.  
## Dependencies
- [MetroSet-UI](https://github.com/N-a-r-w-i-n/MetroSet-UI)
- [ShrineFox.IO](https://github.com/ShrineFox/ShrineFox.IO)  
# Why Make a Dynamic WinForms Project?
I'm used to manually creating these forms all the time, and it gets repetitive.  
Now I have a reusable, highly configurable solution that I can implement in seconds.  
# What Can It Do Right Now?
Not much. You can save/load projects, and alternate between treeview that represents your filesystem.  
You can toggle the sidebar and output log.  
# What's Planned?
In the future, dynamically assigned icons and right click context menu options/actions are planned,  
so you can associate different files and extensions with different tools.  
I'm also planning to be able to mount/dock applications launched from this program within the "workspace" panel.  
You can see a proof of concept of that in my [P-Studio repo](https://github.com/ShrineFox/P-Studio).  
  
![](https://i.imgur.com/lHR0ViP.gif)  
  
You can track further progress by [viewing my Trello tasklist](https://bit.ly/shrinefox).
