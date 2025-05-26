A package created for my dissertation 'The Development of a Unity Package to Calculate, Generate, and Interact with Projections of 4D Objects into a 3D Viewport for Use in Games Development'.
Contains functions to project 4D mappings into 3D using unity engine that appear inside a scene
ObjectGenerator is the script to attach to an empty game object in the scene to generate the object
Go into ObjectGenerator and change the declaration: "object4D = Object4D();" so that 'Object4D' is your desired 4D object.
Recommended input mappings are in the ObjectGenerators Update()
If you would like to put the projection output onto a specific part of the scene you can change the viewport centre to the desired location
If you would like to be able to move the object around a scene use the Translate4D class
If you would like to add your own objects follow the format shown in the Hypercube, Simplex, and Hexadecachron classes ensuring your new object inherits from Object4D.
