# Hotel Management System

Hotel Management System that allow you for Reading, Creating, Updating and Deleting Reservations in the frontend interface and another interface for roomservices

## Installation

Install my-project with downloading this repository by using git

```bash
  git clone https://github.com/Collines/Hotel-Management-System-ITI-.git DirectoryName
```

or by downloading it as ZIP

Open HotelManagementSystem.sln then Open App.config and change Database connection data with yours, don't create any database, the next command will do all for you! also it's not recommended to change Database names unless you know what you're doing

write this command in Package Console Manager tab

![](https://imgur.com/svSVxUm.png)

and run following command

```
update-database
```

Now all database migration have been installed, import Rooms.sql & Cities.sql into your new generated database (FRONTEND) and insert LoginData.sql into your LOGIN Database, now Build in any of Debug/Release modes here

![Debug/Relese](https://imgur.com/WXuj4P2.png)

after building you'll find your files in

bin\Release\net7.0-windows -- if you're building in Release

bin\Debug\net7.0-windows -- if you're building in debug

open HotelManagementSystem.exe, you're ready to go

Use account: admin - password: admin -- to login frontend window
Use account: kitchen - password: kitchen -- to login roomservices window

-- if you want to create your own account open App.xaml and change ` StartupUri="login.xaml"`
to
` StartupUri="register.xaml"`
and rebuild the software, this will make register window appear first so you can create your own account, then return it back to ` StartupUri="login.xaml"`

## Screenshots

![Login window](https://imgur.com/r5eaoC8.png)

![Frontend window](https://imgur.com/kK09cvt.png)

![Kitchen window](https://imgur.com/uEpFBqv.png)

![Search Frontend window](https://imgur.com/WiSlQmV.png)

![Reservation Data Frontend window](https://imgur.com/fkBXO3W.png)

![Room Availability Frontend window](https://imgur.com/RzhXUeS.png)

## Additional Info

This project is made totally for educational purpose not for production or sale
