How to make a Level!

1. Make a new Scene

2. Click in the menu bar on Level/Needed

3. Now you can make new waypoints and tower places.


WayPointSystem:
Set up a number of way points you want to have and click CreateWayPoints the script generate the number of way points you chose (start and end include).

ClearAllWayPoints delete all way points.


TowerPlacingSystem:
Tower Place need the TowerPlace prefab(should be selected).

AddTowerPlace adding 1 place per click.

RemoveTowerPlace removes the latest place.

SpawnSystem:
Enemy Spawn needs the scriptical object from type SpawnOptions

Time Between Spawns is the time between the spawn of an enemy(start included)

SpawnOptions:
Enemy List can hold as many different enemies as you wish

Amount of enemies is an animationcurve which can hold the amount of enemies in the graphic. 
It shows the enemies in the list using the time(element 0 in the list is time 0) and how many enemies will be spawned shows the value at that point
!IMPORTANT! Just use in the animationcurve integers and no floats!IMPORTANT!

BuildUI:
Tower List can hold all the towers you wish for that level. The List is holding scriptical object from type TowerInformation.
The Tower Panel needs the prefab TowerPanel(should be selected). This panel can be modified or replaced with another canvas object.
The xOffSet is for the spacing between the panels.