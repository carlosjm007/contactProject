# Contact project

This code is a RESTful API, which allows you to manage contacts info; it was built with:
* .Net core 3.1
* MongoDB

##  Getting started
Make sure you have installed Docker and Visual Studio (2017 or 2019) and git.

### How run run this project
First, we are going to clone this project as follows:
```
$ git clone https://github.com/carlosjm007/contactProject.git
$ cd contactProject
```
Then, let's install mongodb into a docker container:
```
$ docker-compose up --build
```
Finally, open the next solution with Visual Studio and run it with IIS Express:
```
contactProject/ContactProject.sln
```
