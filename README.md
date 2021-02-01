# Vehicle Performance Monitor System

This project aims to build a solution for a performance monitor application for a group of ground vehicles.

This application aims to store, read and track vehicle data that comes in from the vehicles radars. The three types of data being tracked are; temperature, humidity, and, GPS, each vehicle also has its own ID which is unique to each induvidual vehicle. 

The application should work on a three tiered alert system.

# Red
-If the temperature reads below -60 or above 25 degrees Celcius the system will show a red alert. Warning the user that sustained operation of the vehicle in such conditions could have catastrophic consiquences. 
-If the humidity of the vehicle is less than 20% or greater than 60% then the system also show a red alert. This warns the user of dangerous levels of humidity for the vehicle to be operating in. 

# Amber 
-If the temperature reads between -60 to -15 or between 16 to 25 degress Celcius, or the humidity is between 21% and 30%. The system will show up as an amber alert for the user warning of sub optimal vehicle conditions which should be monitored. 

# Green
-If the temperature is between -15 and 15 degrees celcius, or humidity is between 30% to 40% then the system will show up as a green alert for the user. This tells them that the vehicle is operating in optimal conditions and no course of actions needs to be taken.






