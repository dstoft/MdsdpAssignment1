# About
This repository contains code implemented for Assignment 1 in Model-Driven Software Development Project course at SDU, spring 2021. The original mock-up containing the MDSD homework tasks are actually based on a similar system, that I use to track my study activities.
The DSL metamodel is found in the folder called Models, and consists of 3 models. These are almost empty for functionality, and is simply meant to be holders of information. The models are unique based on different criterias.
Builders are found in the Builder folder. These make use of a bunch of interfaces, which inherit common functionality from each other. I have attempted to seperate the building functionality into three different builders, one for each model object. These are all implemented as a Singleton.
DSL, the language code itself is found in "HousePeace.cs" and "MdsdHomework.cs" in the folder "Dsl". With the wrapping DSL "manager" found in the same folder. The DSL "manager" would normally be responsible for keeping whatever information that the "language" would create. However, I separated this responsibility into two repositories. These essentially mimic a database, but simply keeps the current objects stored in a map.
A simple controller is also part of the infrastructure, and makes it possible to communicate and build the two different models.

One cool feature, is that several tasks can be bound to the same label, as long as the identifying name of the label is exactly the same. This is visible in the HousePeace DSL with the Cleaning label, or in MDSD DSL with the "MDSD" label.

# How to use
It is implemented as a simple ASP.NET Core project, and should be run as that.
When started, communication should happen through the controller using POST and GET methods.
A simple POST method to the address: http://localhost:5000/taskmanagement/house or http://localhost:5000/taskmanagement/mdsd will build the two different kinds of DSL models. Feel free to try both, there is no need for a restart, as the data is cleared every time a new DSL is built, making all of the controller actions idempotent.
Then there is four possible GET calls:
- http://localhost:5000/taskmanagement/task will list all of the current tasks.
- http://localhost:5000/taskmanagement/task/{task name} will return a single task, identified by the name of the task (Case sensitive and using white spaces)
- http://localhost:5000/taskmanagement/label will list all of the current labels.
- http://localhost:5000/taskmanagement/label/{label name} will return a single label, identified by the name of the label (Case sensitive and using white spaces).

My recommendation:
I would suggest building either DSL, and then fetch all of the tasks, inspect them. Then fetch a single label ("Cleaning" or "MDSD"), and notice how several tasks can be attached to the same label.


# Architectural notes
There is little to no error handling, so any input that is not expected may crash the program.
I don't really like the extensive use of singletons in the code, however, it was the easiest way to implement this proof of concept. There are a few other aspects, that I would have liked to refactor as well.
There is a lot of dependency injection in this, which I love. However, most of it is provided through the ServiceProvider, which is not normally ideal.
Note, that the JSON serializer only allows the same object to be mapped once. Because there is a "circular dependency" between the models (Task -> Label -> Task) by intention. However, the API calls will only return the model once (Task123 -> Label321 -/> Task123).

# Github link
https://github.com/dstoft/MdsdpAssignment1