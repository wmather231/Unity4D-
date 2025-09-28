A package created for my dissertation 'The Development of a Unity Package to Calculate, Generate, and Interact with Projections of 4D Objects into a 3D Viewport for Use in Games Development'.

Contains functions to project 4D mappings into 3D using unity engine that appear inside a scene
New / in development interaction Method:

The Object manager class will handle all interactions within the package needed to control the 4D object.

It contains direct function calls to commands which allow you to create, rotate, and translate the 4D object created. This new method will also allow for easier integration with multiple 4D objects (testing for performance yet to be done).

The old method was extremely restricted and required the user to directly open up the packages code to change details, this new method allows user to create their own object manager and assign it details such as the object, viewport and options or depth cueing easier.

Going forward this will be the focus of development to create a more user friendly system.

Old interaction Method:

ObjectGenerator is the script to attach to an empty game object in the scene to generate the object

Go into ObjectGenerator and change the declaration: "object4D = Object4D();" so that 'Object4D' is your desired 4D object.

Recommended input mappings are in the ObjectGenerators Update()

If you would like to put the projection output onto a specific part of the scene you can change the viewport centre to the desired location
If you would like to be able to move the object around a scene use the Translate4D class
If you would like to add your own objects follow the format shown in the Hypercube, Simplex, and Hexadecachron classes ensuring your new object inherits from Object4D.
