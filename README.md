# Vehicle Performance Monitor System

This project aims to build a solution for a performance monitor application for a group of ground vehicles.

This application aims to store, read and track vehicle data that comes in from the vehicles radars. The three types of data being tracked are; temperature, humidity, and, GPS, each vehicle also has its own ID which is unique to each induvidual vehicle. 

# Alert System Tiers
# Red
-If the temperature reads below -60 or above 25 degrees Celcius the system will show a red alert. Warning the user that sustained operation of the vehicle in such conditions could have catastrophic consiquences. 
-If the humidity of the vehicle is less than 20% or greater than 60% then the system also show a red alert. This warns the user of dangerous levels of humidity for the vehicle to be operating in. 

# Amber 
-If the temperature reads between -60 to -15 or between 16 to 25 degress Celcius, or the humidity is between 40% and 60%. The system will show up as an amber alert for the user warning of sub optimal vehicle conditions which should be monitored. 

# Green
-If the temperature is between -15 and 15 degrees celcius, or humidity is between 30% to 40% then the system will show up as a green alert for the user. This tells them that the vehicle is operating in optimal conditions and no course of actions needs to be taken.

The current application is comprised of three parts, an API, an SQL Database, and a WPF App. A real time update system was to be implemented with SignalR but this was not managed within the given timeframe.

# API (James)
The API works as a bridge between the WPF application and the SQL database and the CRUD commands associated with it. The API involves 2 controllers, One controlling the CRUD (Create, Read, Update, Delete) of the vehicles and another for CRUD control of the GPS data associated with such vehicles.

# EntityFramework SQL Database Connection (Will)
The data the application stores and uses are stored in an SQL database. To access the database, EntityFramework is used. The data is accessed by the rest of the system through CRUD methods in services classes.


# WPF APP (Adam)
The purpose of the WPF app was to create a desktop UI for the client to work from for the vehicle monitoring system. This was implemented so that the user UI could be more accessable for a wider user base as it allows for easy use as the application  has larger button with labels and colour co-ordination for the alert levels seen above. 

From the WPF you can currently add, remove and update both a vehicles temperature and humidity values. You can also see a current list of all vehicles on the left hand side all designated with their Ids. CLicking on one of these Ids will allow the user to see the current vaalues for both temperature and humidity.

Currently the WPF app connects to the API and Database as they both get updated when a new value is placed into either of the other elements of the system. The plan was to add a liveupdate element called SignalR so that changes on one element could be seen on all parts of the system in real time.

# How to run the system in its current state

1. Download the code above into visual studio or any other C# IDE and run the sln file to open up the code fully.

2. Right click on the Hackathon project name on the right hand side in the file explorer and click select startup projects. 

3. Select both the API and the DesktopApp. Then click apply and ok.

4. Click the start button at the top of the screen with the green start arrow next to it.

5. Both the API and Desktop App should be up on your screen no, you can now follow the onscreen UI to click on vehicles and update or delete them.  






